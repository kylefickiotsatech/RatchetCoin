using MasterCodeBC;
using Mining;

namespace Ratchet_Coin;

class Program
{
    static void Main(string[] args)
    {
        // Initialize Blockchain 
        Blockchain blockchain = new Blockchain();

        // Initialize Miner
        Miner miner = new Miner(4); // Set mining difficulty Level

        // Intialize decentralization
        Decentralization decentralization = new Decentralization();
        // Add nodes to the network
        Blockchain node1 = new Blockchain();
        Blockchain node2 = new Blockchain();
        decentralization.AddNode(node1);
        decentralization.AddNode(node2);

        // Initialize smart contract
        SmartContract smartContract = new SmartContract();

        // Intialize tokenization
        Tokenization tokenization = new Tokenization();

        // Intialize integration
        Intergration intergration = new Intergration();

        // Main menu Loop
        while (true)
        {
            Console.WriteLine("=== Ratchet Coin ===");
            Console.WriteLine("1. View Blockchain");
            Console.WriteLine("2. Mine Block");
            Console.WriteLine("3. Transer Tokens");
            Console.WriteLine("4. Deploy Smart Contract");
            Console.WriteLine("5. Interact With Smart Contract");
            Console.WriteLine("6. Exit");
            Console.Write("Enter your Choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    ViewBlockchain(blockchain);
                    break;
                case "2":
                    MineBlock(blockchain, miner);
                    break;
                case "3":
                    TransferTokens(tokenization);
                    break;
                case "4":
                    DeploySmartContract(smartContract);
                    break;
                case "5":
                    InteractWithSmartContract(smartContract);
                    break;
                case "6":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    static void ViewBlockchain(Blockchain blockchain)
    {
        
    }
}
