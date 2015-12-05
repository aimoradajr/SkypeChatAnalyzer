namespace SkypeChatAnalyzer
{
    public class SkypeUserJoinedMessage : SkypeMessage
    {
        public string Username { get; set; }
        public SkypeUserJoinedMessage()
        {
        }

        public SkypeUserJoinedMessage(string username)
        {
            Username = username;
        }
    }
}