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
            List<ITransaction> result = transactionsById
                .Values
                .OrderByDescending(t => t.Amount)
                .ThenBy(t => t.Id)
                .ToList();
            return result;
        }

        public IEnumerable<string> GetAllReceiversWithTransactionStatus(TransactionStatus status)
        {
            List<string> result = transactionsById
                .Values
                .Where(t => t.Status == status)
                .OrderBy(t => t.Amount)
                .Select(t => t.To)
                .ToList();
            if (result.Count == 0)
            {
                throw new InvalidOperationException($"There are not receivers with transaction status {status}");
            }
            return result;
        }

        public IEnumerable<string> GetAllSendersWithTransactionStatus(TransactionStatus status)
        {
            List<string> result = transactionsById.
                Values.
                Where(t => t.Status == status)
                .OrderBy(t => t.Amount)
                .Select(t => t.From)
                .ToList();
            if (result.Count == 0)
            {
                throw new InvalidOperationException($"There are not senders with transaction status {status}");
            }
            return result;
        }

        public ITransaction GetById(int id)
        {
            if (transactionsById.ContainsKey(id) == false)
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
            List<ITransaction> result = transactionsById
                .Values
                .Where(t => t.To == receiver)
                .OrderByDescending(t => t.Amount)
                .ThenBy(t => t.Id)
                .ToList();

            if (result.Count == 0)
            {
                throw new InvalidOperationException($"There are not transactions with receiver name: {receiver}");
            }

            return result;
        }

        public IEnumerable<ITransaction> GetBySenderAndMinimumAmountDescending(string sender, double amount)
        {
            List<ITransaction> result = transactionsById
                .Values
                .Where(t => t.From == sender && t.Amount > amount)
                .OrderByDescending(t => t.Amount)
                .ToList();

            if (result.Count == 0)
            {
                throw new InvalidOperationException();
            }

            return result;
        }

        public IEnumerable<ITransaction> GetBySenderOrderedByAmountDescending(string sender)
        {
            List<ITransaction> result = transactionsById
                .Values
                .Where(t => t.From == sender)
                .OrderByDescending(t => t.Amount)
                .ToList();

            if (result.Count == 0)
            {
                throw new InvalidOperationException($"There are not transactions with sender name: {sender}");
            }
            return result;
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
            return transactionsById
                .Values
                .Where(t => t.Status == status && t.Amount <= amount)
                .OrderByDescending(t => t.Amount);
        }


        public void RemoveTransactionById(int id)
        {
            if (transactionsById.ContainsKey(id) == false)
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
