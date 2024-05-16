using System;
using System.Collections.Generic;
using Future;

namespace Decentralization
{
    public class Decentralization
    {
        private List<Blockchain> _nodes;

        public Decentralization(Blockchain blockchain)
        {
            _nodes.Add(blockchain);
        }

        public void BroadcastTransaction (Transaction transaction)
        {
            foreach (var node in _nodes) 
            {
                node.AddTransaction(transaction);
            }
        }

        public void Consensus()
        {
            foreach (var node in _nodes)
            {
                foreach(var otherNode in _nodes)
                {
                    if(node != otherNode)
                    {
                        if (otherNode.Chain.Count > node.Chain.Count)
                        {
                            if (IsValidChain(otherNode.Chain))
                            {
                                node.Chain = otherNode.Chain;
                            }
                        }
                    }
                }
            }
        }
        private bool IsValidChain(List<Block> chain)
        {
            for (int i  = 1; i < chain.Count; i++)
            {
                Block currentBlock = chain[i];
                Block previousBlock = chain[i - 1];

                if(currentBlock.Hash != currentBlock.CalculateHash())
                {
                    return false;
                }

                if(currentBlock.PreviousHash != previousBlock.Hash)
                {
                    return false;
                }
            }
            return true;
        }
    }
}