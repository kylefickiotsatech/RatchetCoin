using System;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;
using Future;

namespace Mining
{
    public class Miner
    {
        private readonly int_difficulty;
        
        public Miner(int_difficulty)
        {
            _difficulty = difficulty;
        }

        public Block Mine(Block block)
        {
            Stopwatch stopwatch= new Stopwatch();
            stopwatch.Start();

            while (true)
            {
                string hash = CalculateHash(block);
                if (isHashValid(hash))
                {
                    stopwatch.Stop();
                    Console.WriteLine($"Block mined successfully in {stopwatch.ElapsedMilliseconds} milliseconds");
                    block.Hash = hash;
                    return block;
                }
                block.Nonce++;
            }
        }

        private string CalculateHash(Block block)
        {
            using (SHA512 sha512 = SHA512.Create())
            {
            byte[] inputBytes = Encoding.UTF8.GetBytes($"{block.Index}-{block.Timestamp}-{block.Data}-{block.PreviousHash}-{block.Nonce}")
            byte[] outputBytes = sha512.ComputeHash(inputBytes);
            return Convert.ToBase64String(outputBytes);
            }
        }

        private bool IsHashValid(string hash)
        {
            for (int i = 0; i < _difficulty; i++)
            {
                if (hash[i] != '0')
                {
                    return false;
                }
            }
            return true;
        }
    }
}