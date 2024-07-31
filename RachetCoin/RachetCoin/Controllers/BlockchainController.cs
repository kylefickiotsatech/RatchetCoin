using System;
using Microsoft.AspNetCore.Mvc;
using RachetCoinUIModels.Models;
using System.Collections.Generic;

namespace RachetCoin.Controllers
{
    public class BlockchainController : Controller
    { 
        private static Blockchain blockchain = new Blockchain();
        public IActionResult Index()
        {
            return View(_blockchain);
        }

        public IActionResult Mine()
        {
            var lastBlock = _blockchain.GetLastBlock();
            var transactions = new List<Transaction>
            {
                new Transaction("network", "miner-address", 1)
            };
            var newBlock = new Block(DateTime.Now, transactions, lastBlock.Hash);
            _blockchain.AddBlock(newBlock);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult AddTransaction(string fromAddress, string toAddress, decimal amount)
        {
            var transaction = new Transaction(fromAddress, toAddress, amount);
            var transactions = new List<Transaction> { transaction };
            var lastBlock = _blockchain.GetLatestBlock();
            var newBlock = new Block(DateTime.Now, transactions, lastBlock.Hash);
            _blockchain.AddBlock(newBlock);
            return RedirectToAction("Index");
        }
    }
}

