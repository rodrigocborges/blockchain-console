using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BlockchainApp.Entities
{
    public class BlockChain
    {
        public int Difficulty { get; private set; } = 4;
        public List<Block> Blocks { get; private set; } = new List<Block>();

        public BlockChain(int difficulty)
        {
            Difficulty = difficulty;
        }

        public string GenerateHash(Block block)
        {
            string data = JsonSerializer.Serialize(block);
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(data));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        public void AddBlock(Block newBlock)
        {
            Block? lastBlock = Blocks.LastOrDefault();
            newBlock.PreviousHash = lastBlock?.Hash;
            newBlock.Mine(Difficulty);
            Blocks.Add(newBlock);
        }

        public void Show()
        {
            foreach (Block block in Blocks)
            {
                Console.WriteLine("-------------------------------------");
                Console.WriteLine("Hash: " + block.Hash);
                Console.WriteLine("Previous Hash: " + block.PreviousHash);
                Console.WriteLine("Timestamp: " + block.TimeStamp);
                Console.WriteLine("Nonce: " + block.Nonce);
                Console.WriteLine(string.Format("[{0} -> {1}]: {2}", block.From.Name, block.To.Name, block.Message));
                Console.WriteLine("-------------------------------------");
            }
        }
    }
}
