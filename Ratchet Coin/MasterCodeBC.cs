using System;

namespace MasterCodeBC
{
    public class Block
    {
        public int Index { get; set;}
        public DateTime Timestamp {get; set;}
        public string Data {get; set;}
        public string PreviousHash {get; set;}
        public string Hash {get; set;} 

        public Block(DateTime timestamp, string data, string previousHash = "" )
        {
            Index = 0;
            Timestamp = timestamp;
            Data = data;
            PreviousHash = previousHash;
            Hash = CalculateHash();
        }

        public string CalculateHash()
        {
            using(SHA512 sha512 = SHA512.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes($"{Index}-{Timestamp}-{Data}-{PreviousHash}");
                byte[] outputBytes = sha512.ComputeHash(inputBytes);
                return Convert.ToBase64String(outputBytes);
            }
        }
    }

    public class Blockchain
    {
        public List<Block> Chain { get; set; }

        public Blockchain()
        {
            Chain = new List<Block>();
            AddGenesisBlock();
        } 

        public void AddGenesisBlock()
        {
            Chain.Add(new Block(DateTime.Now, "Genesis Block"));
        }

        public Block GetLatestBlock()
        {
            return Chain[Chain.Count - 1];
        }

        public void AddBlock(Block newBlock)
        {
            newBlock.Index = Chain.Count;
            newBlock.PreviousHash = GetLatestBlock().Hash;
            newBlock.Hash = newBlock.CalculateHash();
            Chain.Add(newBlock);
        }

        public bool IsChainValid()
        {
            for (int i = 1; i < Chain.Count; i++)
            {
                Block currentBlock = Chain[i];
                Block previousBlock = Chain[i - 1];

                if(currentBlock.Hash != currentBlock.CalculateHash())
                {
                    return false;
                }
            }
            return true;
        }
    }

    class Program 
    {
        static void Main(string[] args)
        {
            Blockchain blockchain= new Blockchain();
            blockchain.AddBlock(new Block(DateTime.Now,"Transaction 1"));
            blockchain.AddBlock(new Block(DateTime.Now, "Transaction 2"));

            Console.WriteLine("Blockchain validity:" + blockchain.IsChainValid());

            Console.WriteLine("\nTampering with the blockchain...");
            blockchain.Chain[1].Data = "Tampered Data";

            Console.WriteLine("Blockchain validity after tampering:" + blockchain.IsChainValid());
            Console.ReadLine();
        }
    }
}