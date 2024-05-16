using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace SecurityEnchancements
{
    public class SecurityEnchancements
    {
        public static string GenerateHash(string input)
        {
            using (SHA512 sha512 = SHA512.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                byte[] outputBytes = sha256.ComputeHash(inputBytes);
                return Convert.ToBase64String(outputBytes);
            }
        }
        
        public static bool VerifyDigitalSignature(string publicKey, string data, string signature)
        {
            // Implement digital signature verification logic using public key cryptography
            // For demonstration purposes, assume signature is valid if it matches the hash of the data
            string hashedData = GenerateHash(data);
            return signature == hashedData;
        }

        public static bool VerifyMerkleTree(List<string> hashes, string rootHash)
        {
            // Implement Merkle tree verification logic
            // For demonstration purposes, assume the root hash is valid if it matches the calculated Merkle root
            string calculatedRootHash = CalculateMerkleRoot(hashes);
            return rootHash == calculatedRootHash;
        }

        private static string CalculateMerkleRoot(List<string> hashes)
        {
            // Implement Merkle tree calculation logic
            // For demonstration purposes, concatenate all hashes and hash them iteratively to get the root hash
            StringBuilder concatenatedHashes = new StringBuilder();
            foreach (var hash in hashes)
            {
                concatenatedHashes.Append(hash);
            }
            return GenerateHash(concatenatedHashes.ToString());
        }
    }
}