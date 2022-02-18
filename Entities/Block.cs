
using System.Security.Cryptography;
using System.Text;

namespace BlockchainApp.Entities
{
    public class Block
    {
        public User From { get; set; }
        public User To { get; set; }
        public string Message { get; set; }
        public string Hash { get; private set; }
        public long TimeStamp { get; set; } = DateTime.UtcNow.ToFileTime();
        public int Nonce { get; set; }
        public string PreviousHash { get; set; }

        public string CalculateHash()
        {
            SHA256 sha = SHA256.Create();
            byte[] inputBytes = Encoding.ASCII.GetBytes($"{TimeStamp}-{PreviousHash ?? ""}-{Nonce}-{Message}");
            byte[] outputBytes = sha.ComputeHash(inputBytes);
            return Convert.ToBase64String(outputBytes);
        }

        public void Mine(int difficulty = 4)
        {
            string leadingZeros = new string('0', difficulty);
            while(Hash == null || Hash.Substring(0, difficulty) != leadingZeros)
            {
                ++Nonce;
                Hash = CalculateHash();
            }
        }

    }
}
