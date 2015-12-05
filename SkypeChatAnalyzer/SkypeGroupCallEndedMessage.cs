namespace SkypeChatAnalyzer
{
    public class SkypeGroupCallEndedMessage : SkypeMessage
    {
        public string Duration { get; set; }                // Convert to DateTime?
        public SkypeGroupCallEndedMessage()
        {
        }
    }
}