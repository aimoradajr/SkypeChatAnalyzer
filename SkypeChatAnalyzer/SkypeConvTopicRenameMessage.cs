namespace SkypeChatAnalyzer
{
    public class SkypeConvTopicRenameMessage : SkypeMessage
    {
        public string Username { get; set; }
        public string Topic { get; set; }
        public SkypeConvTopicRenameMessage()
        {
        }

        public SkypeConvTopicRenameMessage(string username, string topic)
        {
            Username = username;
            Topic = Topic;
        }
    }
}