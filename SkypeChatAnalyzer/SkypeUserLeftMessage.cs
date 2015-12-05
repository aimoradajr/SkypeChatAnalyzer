namespace SkypeChatAnalyzer
{
    public class SkypeUserLeftMessage : SkypeMessage
    {
        public string Username { get; set; }
        public SkypeUserLeftMessage()
        {
        }

        public SkypeUserLeftMessage(string username)
        {
            Username = username;
        }
    }
}