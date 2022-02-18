
//https://www.c-sharpcorner.com/article/building-a-blockchain-in-net-core-proof-of-work/

using BlockchainApp.Entities;

DateTime startTime = DateTime.Now;

BlockChain blockchain = new BlockChain(3);

User userA = new User { Name = "Rodrigo" };
User userB = new User { Name = "Bill Gates" };

Block blockA = new Block { From = userA, To = userB, Message = "10BTC" };
Block blockB = new Block { From = userB, To = userA, Message = "1BTC" };
Block blockC = new Block { From = userA, To = userB, Message = "1BTC" };

blockchain.AddBlock(blockA);
blockchain.AddBlock(blockB);
blockchain.AddBlock(blockC);

blockchain.Show();

DateTime endTime = DateTime.Now;

Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("Tempo para construção da rede: " + (endTime - startTime).TotalSeconds + "s");

Console.ReadKey();