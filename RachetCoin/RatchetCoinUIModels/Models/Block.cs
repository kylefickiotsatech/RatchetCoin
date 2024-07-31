using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace RatchetCoinUIModels.Models
{
    public class Block
    {
        public int Index { get; set; }
        public DateTime Timestamp { get; set; }
        public IList<Transaction> Transactions { get; set; }
        public string PreviousHash { get; set; }
        public string Hash { get; set; }
        public int Nonce { get; set; }
        public Block(DateTime timestamp, IList<Transaction> transactions, string previousHash = "")
        {
            Index = 0;
            Timestamp = timestamp;
            Transactions = transactions;
            PreviousHash = previousHash;
            Hash = CalculateHash();
            Nonce = 0;
        }

        public string CalculateHash()
        {
            SHA256 sha256 = SHA256.Create();
            byte[] inputBytes = Encoding.ASCII.GetBytes($"{Timestamp}-{PreviousHash ?? string.Empty}-{Nonce}-{Transactions}");
            byte[] outputBytes = sha256.ComputeHash( inputBytes );
            return Convert.ToBase64String( outputBytes );
        }

        public void MineBlock(int difficulty)
        {
            string hashValidationTemplate = new string('0', difficulty);
            while (Hash.Substring(0, difficulty ) != hashValidationTemplate)
            {
                Nonce++;
                Hash = CalculateHash();
            }
        }
    }
}
