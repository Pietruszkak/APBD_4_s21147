namespace LegacyApp
{
    public class Client
    {
        public string name { get; internal set; }
        public int clientId { get; internal set; }
        public string email { get; internal set; }
        public string address { get; internal set; }
        public string type { get; set; }
    }
}