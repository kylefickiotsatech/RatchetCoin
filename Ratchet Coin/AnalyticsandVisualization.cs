using System;
using System.Collections.Generic;
using System.Linq;
using Future;

namespace AnalyticsandVisualization
{
    public class AnalyticsandVisualization
    {
        public static void AnalyzeBlockchain(Blockchain blockchain)
        {
            Console.WriteLine("Blockchain Analysis:");
            Console.WriteLine($"Total Number Of Blocks:{blockchain.Chain.Count}");
            decimal totalTransactions = blockchain.Chain.Sum(block => block.Transactions.Count);
            Console.WriteLine($"Total Number of Transactions: {totalTransactions}");

            List<Transaction> allTransactions = blockchain.Chain.SelectMany(block => block.Transactions).ToList();
            Dictionary<string, decimal> senderBalances = CalculateBalances(allTransactions);
            Console.WriteLine("Sender Balances:");
            foreach (var sender in senderBalances)
            {
                Console.WriteLine($"Address: {sender.Key}, Blanace: {sender.Value}");
            }
        }
        
        private static Dictionary<string, decimal> CalculateBalances(List<Transaction> transactions)
        {
            Dictionary<string, decimal> balances = new Dictionary<string, decimal>();

            foreach (var transaction in transactions)
            {
                if (!balances.ContainsKey(transaction.Sender))
                {
                    balances[transaction.Sender] = 0;
                }
                if(!balances.ContainsKey(transaction.Recipient))
                {
                    balances[transaction] = 0;
                }

                balances[transaction.Sender] -= transaction.Amount;
                balances[transaction.Recipient] += transaction.Amount;
            }
            return balances;
        }
    }
}