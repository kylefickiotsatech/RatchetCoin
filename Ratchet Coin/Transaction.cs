using System;

namespace Transaction
{
    public class Transaction 
    {
        public string Sender {get;}
        public string Recipient{get;}
        public decimal Amount {get;}
        public DateTime Timestamp {get;}

        public Transaction(string sender, string recipient, decimal amount)
        {
            Sender = sender;
            Recipient = recipient;
            Amount = amount;
            Timestamp = DateTime.Now;
        }
        
        public override string ToString()
        {
            return $"{Timestamp}: {Sender} sent {Amount} to {Recipient}";
        }
    }
}