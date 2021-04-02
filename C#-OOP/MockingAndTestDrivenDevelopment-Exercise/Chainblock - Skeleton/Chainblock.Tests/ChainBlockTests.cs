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

            Assert.Throws<InvalidOperationException>(() => chainblock.GetByTransactionStatus(TransactionStatus.Aborted));
        }

        [Test]
        public void GetByTransactionStatus_ReturnsTransactionsWithThatStatus_OrderedDescendingByAmount()
        {
            CreateHundredTransactions();

            TransactionStatus searchedStatus = TransactionStatus.Successfull;
            List<ITransaction> expected = chainblock.Where(t => t.Status == searchedStatus).OrderByDescending(t => t.Amount).ToList();
            List<ITransaction> actual = chainblock.GetByTransactionStatus(searchedStatus).ToList();
            Assert.That(expected, Is.EquivalentTo(actual));
        }

        [Test]
        public void GetAllSendersWithTransactionStatusThrows_When_ThereAreNotSendersWithThatStatus()
        {
            ITransaction firstTransaction = new Transaction(1, "Angel", "Receiver1", 5);
            firstTransaction.Status = TransactionStatus.Successfull;
            ITransaction secondTransaction = new Transaction(2, "Ivan", "Receiver2", 6);
            secondTransaction.Status = TransactionStatus.Failed;

            Assert.Throws<InvalidOperationException>(() => chainblock.GetAllSendersWithTransactionStatus(TransactionStatus.Aborted));
        }

        [Test]
        public void GetAllSendersWithTransactionStatus_ReturnsAllSendersSortedByAmount_WhenThereAreSendersWithThatStatus()
        {
            CreateHundredTransactions();

            TransactionStatus searchedStatus = TransactionStatus.Successfull;
            List<string> expectedSenderNames = chainblock
                .Where(t => t.Status == searchedStatus)
                .OrderBy(t => t.Amount)
                .Select(t => t.From)
                .ToList();

            List<string> actualSenderNames = chainblock.GetAllSendersWithTransactionStatus(searchedStatus).ToList();

            Assert.That(expectedSenderNames, Is.EquivalentTo(actualSenderNames));
        }

        [Test]
        public void GetAllReceiversWithTransactionStatusThrows_When_ThereAreNotReceiversWithThatStatus()
        {
            ITransaction firstTransaction = new Transaction(1, "Angel", "Receiver1", 5);
            firstTransaction.Status = TransactionStatus.Successfull;
            ITransaction secondTransaction = new Transaction(2, "Ivan", "Receiver2", 6);
            secondTransaction.Status = TransactionStatus.Failed;

            Assert.Throws<InvalidOperationException>(() => chainblock.GetAllReceiversWithTransactionStatus(TransactionStatus.Aborted));
        }


        [Test]
        public void GetAllReceiversWithTransactionStatus_ReturnsAllReceiversSortedByAmount_WhenThereAreReceiversWithThatStatus()
        {
            CreateHundredTransactions();

            TransactionStatus searchedStatus = TransactionStatus.Successfull;
            List<string> expectedReceiversNames = chainblock
                .Where(t => t.Status == searchedStatus)
                .OrderBy(t => t.Amount)
                .Select(t => t.To)
                .ToList();

            List<string> actualReceiversNames = chainblock.GetAllReceiversWithTransactionStatus(searchedStatus).ToList();

            Assert.That(expectedReceiversNames, Is.EquivalentTo(actualReceiversNames));
        }

        [Test]
        public void GetAllOrderedByAmountDescendingThenById_ReturnsAllTranstactionsOrdered()
        {
            CreateHundredTransactions();

            List<ITransaction> expected = chainblock
                .OrderByDescending(t => t.Amount)
                .ThenBy(t => t.Id)
                .ToList();

            List<ITransaction> actual = chainblock.GetAllOrderedByAmountDescendingThenById().ToList();

            Assert.That(actual, Is.EquivalentTo(expected));
        }

        [Test]
        public void GetBySenderOrderedByAmountDescendingThrows_When_SenderDoesntExists()
        {
            CreateHundredTransactions();
            Assert.Throws<InvalidOperationException>(() => chainblock.GetBySenderOrderedByAmountDescending("NonExistentSender"));
        }

        [Test]
        public void GetBySenderOrderedByAmountDescending_ReturnsTransactionsFilteredAndOrdered_When_SenderExists()
        {
            CreateHundredTransactions();

            string sender = chainblock.FirstOrDefault().From;
            List<ITransaction> expected = chainblock
                .Where(t => t.From == sender)
                .OrderByDescending(t => t.Amount)
                .ToList();

            List<ITransaction> actual = chainblock.GetBySenderOrderedByAmountDescending(sender).ToList();

            Assert.That(actual, Is.EquivalentTo(expected));

        }

        [Test]
        public void GetByReceiverOrderedByAmountThenByIdThrows_When_ReceiverDoesntExists()
        {
            CreateHundredTransactions();
            Assert.Throws<InvalidOperationException>(() => chainblock.GetByReceiverOrderedByAmountThenById("NonExistentReceiver"));
        }

        [Test]
        public void GetByReceiverOrderedByAmountThenById_ReturnsTransactionsFilteredAndOrdered_When_ReceiverExists()
        {
            CreateHundredTransactions();

            string receiver = chainblock.FirstOrDefault().To;
            List<ITransaction> expected = chainblock
                .Where(t => t.To == receiver)
                .OrderByDescending(t => t.Amount)
                .ThenBy(t=>t.Id)
                .ToList();

            List<ITransaction> actual = chainblock.GetByReceiverOrderedByAmountThenById(receiver).ToList();

            Assert.That(actual, Is.EquivalentTo(expected));

        }

        [Test]
        public void GetByTransactionStatusAndMaximumAmount_ReturnsEmptyCollection_WhenConditionsAreNotMet()
        {
            ITransaction firstTransaction = new Transaction(1, "a", "b", 110);
            firstTransaction.Status = TransactionStatus.Aborted;
            ITransaction secondTransaction = new Transaction(2, "a", "b", 140);
            secondTransaction.Status = TransactionStatus.Failed;
            ITransaction thridTransaction = new Transaction(3, "a", "b", 140);
            thridTransaction.Status = TransactionStatus.Unauthorized;


            List<ITransaction> actual = chainblock.GetByTransactionStatusAndMaximumAmount(TransactionStatus.Failed, 120).ToList();

            Assert.That(actual, Is.EquivalentTo(new List<ITransaction>()));
        }

        [Test]
        public void GetByTransactionStatusAndMaximumAmount_ReturnsFilteredCollectionOfTransactions_WhenConditionsAreMet()
        {
            CreateHundredTransactions();

            TransactionStatus status = TransactionStatus.Failed;
            double amount = 120;
            List<ITransaction> expected = chainblock
                .Where(t => t.Status == status && t.Amount <= amount)
                .OrderByDescending(t => t.Amount)
                .ToList();

            List<ITransaction> actual = chainblock.GetByTransactionStatusAndMaximumAmount(status, amount).ToList();

            Assert.That(expected, Is.EquivalentTo(actual));
        }

        [Test]
        public void GetBySenderAndMinimumAmountDescendingThrows_When_ThereAreNotTransactionsThatMeetCondition()
        {
            ITransaction firstTransaction = new Transaction(1, "Ivan", "b", 100);
            firstTransaction.Status = TransactionStatus.Aborted;
            ITransaction secondTransaction = new Transaction(2, "Petko", "b", 120);
            secondTransaction.Status = TransactionStatus.Failed;
            ITransaction thridTransaction = new Transaction(3, "Petar", "b", 100);
            thridTransaction.Status = TransactionStatus.Unauthorized;

            double minAmount = 110;
            string sender = "Angel";

            Assert.Throws<InvalidOperationException>(()=>chainblock.GetBySenderAndMinimumAmountDescending(sender, minAmount));
        }

        [Test]
        public void GetBySenderAndMinimumAmountDescending()
        {
            CreateHundredTransactions();

            string sender = "Ivan";
            double minAmount = 110;

            List<ITransaction> expected = chainblock
                .Where(t => t.From == sender && t.Amount > minAmount)
                .OrderByDescending(t=>t.Amount)
                .ToList();

            List<ITransaction> actual = chainblock.GetBySenderAndMinimumAmountDescending(sender, minAmount).ToList();

            Assert.That(expected, Is.EquivalentTo(actual));
        }


        private void CreateHundredTransactions()
        {
            int n = 100;
            for (int i = 1; i < n; i++)
            {
                TransactionStatus status = TransactionStatus.Aborted;
                string from = "Ivan";
                string to = "Galq";
                if (i % 2 == 0)
                {
                    status = TransactionStatus.Successfull;
                    from = "Petar";
                    to = "Qna";
                }
                if (i % 3 == 0)
                {
                    status = TransactionStatus.Failed;
                    from = "Angel";
                    to = "Petq";
                }
                if (i % 5 == 0)
                {
                    from = "Stefan";
                    to = "Jana";
                    status = TransactionStatus.Unauthorized;
                }

                double amount = i % 2 == 0 ? 100 : 100 + i;

                ITransaction currTransaction = new Transaction(n - i, from, to, amount);
                currTransaction.Status = status;

                chainblock.Add(currTransaction);
            }
        }
    }
}
