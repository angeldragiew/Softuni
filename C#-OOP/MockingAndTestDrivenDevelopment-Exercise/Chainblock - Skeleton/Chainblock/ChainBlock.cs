using Chainblock.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chainblock
{
    public class ChainBlock : IChainblock
    {
        private Dictionary<int, ITransaction> transactionsById;

        public ChainBlock()
        {
            transactionsById = new Dictionary<int, ITransaction>();
        }

        public int Count => transactionsById.Count;

        public void Add(ITransaction tx)
        {
            if (transactionsById.ContainsKey(tx.Id))
            {
                throw new InvalidOperationException($"Transaction with id {tx.Id} already exists");
            }
            transactionsById.Add(tx.Id, tx);
        }

        public void ChangeTransactionStatus(int id, TransactionStatus newStatus)
        {
            if (transactionsById.ContainsKey(id) == false)
            {
                throw new ArgumentException($"Transaction with id {id} does not exist");
            }

            transactionsById[id].Status = newStatus;
        }

        public bool Contains(ITransaction tx)
        {
            if (transactionsById.ContainsKey(tx.Id) == false)
            {
                return false;
            }

            ITransaction existingTransaction = transactionsById[tx.Id];

            bool DoesTransactionExists = existingTransaction.From == tx.From &&
                existingTransaction.To == tx.To &&
                existingTransaction.Amount == tx.Amount &&
                existingTransaction.Status == tx.Status;

            return DoesTransactionExists;
        }

        public bool Contains(int id)
        {
            return this.transactionsById.ContainsKey(id);
        }

        public IEnumerable<ITransaction> GetAllInAmountRange(double lo, double hi)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ITransaction> GetAllOrderedByAmountDescendingThenById()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<string> GetAllReceiversWithTransactionStatus(TransactionStatus status)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<string> GetAllSendersWithTransactionStatus(TransactionStatus status)
        {
            throw new NotImplementedException();
        }

        public ITransaction GetById(int id)
        {
            if(transactionsById.ContainsKey(id) == false)
            {
                throw new InvalidOperationException($"Transaction with id {id} does not exist");
            }
            return transactionsById[id];
        }

        public IEnumerable<ITransaction> GetByReceiverAndAmountRange(string receiver, double lo, double hi)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ITransaction> GetByReceiverOrderedByAmountThenById(string receiver)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ITransaction> GetBySenderAndMinimumAmountDescending(string sender, double amount)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ITransaction> GetBySenderOrderedByAmountDescending(string sender)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ITransaction> GetByTransactionStatus(TransactionStatus status)
        {
            List<ITransaction> transactionsToReturn = transactionsById.Values.Where(t => t.Status == status).OrderByDescending(t => t.Amount).ToList();
            if (transactionsToReturn.Count == 0)
            {
                throw new InvalidOperationException($"There are not transactions with {status} status");
            }
            return transactionsToReturn;
        }

        public IEnumerable<ITransaction> GetByTransactionStatusAndMaximumAmount(TransactionStatus status, double amount)
        {
            throw new NotImplementedException();
        }


        public void RemoveTransactionById(int id)
        {
            if(transactionsById.ContainsKey(id) == false)
            {
                throw new InvalidOperationException($"Transaction with id {id} does not exist");
            }
            transactionsById.Remove(id);
        }
        public IEnumerator<ITransaction> GetEnumerator()
        {
            foreach (var item in transactionsById)
            {
                yield return item.Value;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
