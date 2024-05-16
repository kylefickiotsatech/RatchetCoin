using System;
using System.Collections.Generic;
namespace Tokenization 
{
    public class Tokenization
    {
        private Dictionary<string, decimal> _balances;

        public Tokenization()
        {
            _balances = new Dictionary<string,decimal>();
        }

        public void Initialize(Dictionary<string, decimal> initialBalances)
        {
            _balances = initialBalances;
        }

        public void Transfer(string sender, string recipient, decimal amount)
        {
            if(!_balances.ContainsKey(sender) || !_balances.ContainsKey(recipient))
            {
                throw new InvalidOperationException("Sender or recipient not found.");
            }

            if(_balances[sender] < amount)
            {
                throw new InvalidOperationException("Insufficient Balance. ");
            }

            _balances[sender] -= amount;
            _balances[recipient] += amount;
        }

        public decimal GetBalance(string address)
        {
            if(!_balances.ContainsKey(address))
            {
                throw new InvalidOperationException("Address not Found.");
            }
            return _balances[address];
        }
    }
}