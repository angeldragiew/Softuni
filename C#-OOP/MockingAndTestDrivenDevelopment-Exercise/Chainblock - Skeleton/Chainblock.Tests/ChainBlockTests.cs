using Chainblock.Contracts;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chainblock.Tests
{
    [TestFixture]
    public class ChainBlockTests
    {
        private IChainblock chainblock
            ;
        private ITransaction simpleTransaction;

        [SetUp]
        public void SetUp()
        {
            chainblock = new Chainblock.ChainBlock();
            simpleTransaction = new Transaction(1, "Angel", "Pesho", 200);
            simpleTransaction.Status = TransactionStatus.Failed;
        }

        [Test]
        public void AddThrows_When_ThereIsAlreadyATransactionWithThatId()
        {
            int id = 1;
            ITransaction firstTransaction = new Transaction(id, "Angel", "Pesho", 200);
            ITransaction secondTransaction = new Transaction(id, "Ivan", "Dragan", 300);

            chainblock.Add(firstTransaction);
            Assert.Throws<InvalidOperationException>(() => chainblock.Add(secondTransaction));
        }

        [Test]
        public void Add_Should_AddTransaction()
        {
            int initialCount = chainblock.Count;

            chainblock.Add(simpleTransaction);
            int expectedCount = initialCount + 1;

            Assert.AreEqual(expectedCount, chainblock.Count);
            Assert.That(chainblock.Contains(simpleTransaction.Id), Is.True);
        }

        [Test]
        public void ContainsId_ReturnsTrue_WhenTransactionWithThatIdExists()
        {
            chainblock.Add(simpleTransaction);

            Assert.That(chainblock.Contains(simpleTransaction.Id), Is.True);
        }

        [Test]
        public void ContainsId_ReturnsFalse_WhenTransactionWithThatIdDoesntExist()
        {
            Assert.That(chainblock.Contains(simpleTransaction.Id), Is.False);
        }

        [Test]
        public void ContainsTransaction_ReturnsFalse_WhenTransactionWithThatIdExists_ButOtherPropsDontMatch()
        {
            chainblock.Add(simpleTransaction);

            ITransaction searchedTransaction = new Transaction(simpleTransaction.Id,
                simpleTransaction.From + "Fake",
                simpleTransaction.To + "Fake",
                simpleTransaction.Amount + 50);
            searchedTransaction.Status = TransactionStatus.Aborted;

            Assert.That(chainblock.Contains(searchedTransaction), Is.False);
        }

        [Test]
        public void ContainsTransaction_ReturnsTrue_WhenAllThePropertiesMatch()
        {
            chainblock.Add(simpleTransaction);

            ITransaction searchedTransaction = new Transaction(simpleTransaction.Id,
                simpleTransaction.From,
                simpleTransaction.To,
                simpleTransaction.Amount);
            searchedTransaction.Status = simpleTransaction.Status;

            Assert.That(chainblock.Contains(searchedTransaction), Is.True);
        }

        [Test]
        public void Count_ShouldBeZero_WhenChainblockIsEmpty()
        {
            Assert.AreEqual(0, chainblock.Count);
        }


        [Test]
        public void ChangeTransactionStatusThrows_When_TransactionWithThatIdDoesntExist()
        {
            Assert.Throws<ArgumentException>(() => chainblock.ChangeTransactionStatus(1, TransactionStatus.Successfull));
        }

        [Test]
        public void ChangeTransactionStatus_ChangeStatus_When_IdExists()
        {
            TransactionStatus newStatus = TransactionStatus.Successfull;
            chainblock.Add(simpleTransaction);

            chainblock.ChangeTransactionStatus(simpleTransaction.Id, newStatus);

            Assert.AreEqual(newStatus, simpleTransaction.Status);
        }

        [Test]
        public void RemoveTransactionByIdThrows_When_IdDoesntExist()
        {
            chainblock.Add(simpleTransaction);
            Assert.Throws<InvalidOperationException>(() => chainblock.RemoveTransactionById(127));
        }

        [Test]
        public void RemoveTransactionById_Removes_When_IdExists()
        {
            chainblock.Add(simpleTransaction);

            chainblock.RemoveTransactionById(simpleTransaction.Id);

            Assert.AreEqual(0, chainblock.Count);
            Assert.That(chainblock.Contains(simpleTransaction.Id), Is.False);
        }

        [Test]
        public void GetByIdThrows_When_IdDoesNotExist()
        {
            chainblock.Add(simpleTransaction);
            Assert.Throws<InvalidOperationException>(() => chainblock.GetById(simpleTransaction.Id + 1));
        }

        [Test]
        public void GetById_ReturnsTransaction_WhenIdExists()
        {
            chainblock.Add(simpleTransaction);

            ITransaction transaction = chainblock.GetById(simpleTransaction.Id);

            Assert.That(transaction, Is.EqualTo(simpleTransaction));
        }

        [Test]
        public void GetByTransactionStatusThrows_When_ThereAreNotTransactionsWithThatStatus()
        {
            ITransaction successfullTransaction = new Transaction(1, "A", "B", 200);
            successfullTransaction.Status = TransactionStatus.Successfull;
            ITransaction failedTransaction = new Transaction(2, "C", "D", 100);
            failedTransaction.Status = TransactionStatus.Failed;
            ITransaction unauthorizedTransaction = new Transaction(3, "E", "F", 300);
            unauthorizedTransaction.Status = TransactionStatus.Unauthorized;

            chainblock.Add(successfullTransaction);
            chainblock.Add(failedTransaction);
            chainblock.Add(unauthorizedTransaction);

            Assert.Throws<InvalidOperationException>(()=>chainblock.GetByTransactionStatus(TransactionStatus.Aborted));
        }

        [Test]
        public void GetByTransactionStatus_ReturnsTransactionsWithThatStatus_OrderedDescendingByAmount()
        {
            List<ITransaction> expected = new List<ITransaction>();

            for (int i = 1; i < 100; i++)
            {
                TransactionStatus status = TransactionStatus.Aborted;
                if (i % 2 == 0)
                {
                    status = TransactionStatus.Successfull;
                }
                if (i % 3 == 0)
                {
                    status = TransactionStatus.Failed;
                }
                if (i % 5 == 0)
                {
                    status = TransactionStatus.Unauthorized;
                }

                ITransaction currTransaction = new Transaction(i, $"Sender{i}", "Receiver", 100 + i);
                currTransaction.Status = status;

                chainblock.Add(currTransaction);
                expected.Add(currTransaction);
            }

            TransactionStatus searchedStatus = TransactionStatus.Successfull;
            expected = expected.Where(t => t.Status == searchedStatus).OrderByDescending(t => t.Amount).ToList();
            List<ITransaction> actual = chainblock.GetByTransactionStatus(searchedStatus).ToList();
            Assert.That(expected, Is.EquivalentTo(actual));
        }
    }
}
