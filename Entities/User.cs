namespace BlockchainApp.Entities
{
    public class User
    {
        public Guid ID { get; private set; }
        public string Name { get; set; }

        public User()
        {
            ID = Guid.NewGuid();
        }
    }
}
