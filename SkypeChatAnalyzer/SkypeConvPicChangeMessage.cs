namespace SkypeChatAnalyzer
{
    public class SkypeConvPicChangeMessage : SkypeMessage
    {
        public string Username { get; set; }
        public SkypeConvPicChangeMessage()
        {
        }

        public SkypeConvPicChangeMessage(string username)
        {
            Username = username;
        }
    }
}