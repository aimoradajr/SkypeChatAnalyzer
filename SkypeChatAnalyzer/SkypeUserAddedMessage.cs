using System.Collections.Generic;

namespace SkypeChatAnalyzer
{
    public class SkypeUserAddedMessage : SkypeMessage
    {
        public string Username { get; set; }
        public List<string> AddedUsers { get; set; }
        public SkypeUserAddedMessage()
        {
        }

        public SkypeUserAddedMessage(string username, List<string> addedUsers)
        {
            Username = username;
            AddedUsers = addedUsers;
        }

        public void insertAddedUser(string user)
        {
            AddedUsers.Add(user);
        }
    }
}