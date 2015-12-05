using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace SkypeChatAnalyzer
{
    public class ChatAnalyzer
    {
        string InputText;
        List<SkypeMessage> allMessages;     // I will use this to generate reports such as 'which users you reply to the most'
        public Dictionary<string, List<SkypeUserMessage>> userToMessages;
        List<SkypeMessage> skypeEventMessages;
        List<string> invalidMessages;
        
        public string InputFile { get; private set; }

        public ChatAnalyzer()
        {
            InputFile = "";
            InputText = "";
            allMessages = new List<SkypeMessage>();
            invalidMessages = new List<string>();
            userToMessages = new Dictionary<string, List<SkypeUserMessage>>();
            skypeEventMessages = new List<SkypeMessage>();
        }

        public void setInputText(string input)
        {
            InputText = input;
        }

        public void setInputFile(string inputFile)
        {
            InputFile = inputFile;
        }

        public void analyzeChatString()
        {
            if (InputText.Length < 1)
                return;

            parseMessagesFromString(InputText);
        }

        private void parseMessagesFromFile(string inputFile)
        {
            StreamReader reader = new StreamReader(inputFile);

            string line="";
            string messagetemp = "";
            while((line = reader.ReadLine()) != null)
            {
                // Detect new message
                if (line.StartsWith("["))           // NOTEE: better detection.
                {
                    // Save completed message first
                    if (messagetemp != "")
                    {
                        addMessageToDictionary(messagetemp);
                    }

                    // Save the new line
                    messagetemp = line;
                }
                else
                {
                    messagetemp += line;
                }
            }
            
            // Save last completed message
            if (messagetemp != "")
            {
                addMessageToDictionary(messagetemp);
            }
        }

        public void analyzeChatFile()
        {
            if (InputFile.Length < 1)
                return;

            parseMessagesFromFile(InputFile);
        }

        private void parseMessagesFromString(string inputstring)
        {
            string[] lines = inputstring.Split('\n');
            parseMessages(lines);
        }


        private void parseMessages(string[] lines)
        {
            string messagetemp = "";
            foreach (string line in lines)
            {
                // Detect new message
                if (line.StartsWith("["))           // NOTEE: better detection.
                {
                    // Save completed message first
                    if (messagetemp != "")
                    {
                        addMessageToDictionary(messagetemp);
                    }

                    // Save the new line
                    messagetemp = line;
                }
                else
                {
                    messagetemp += line;
                }
            }
            // Save last completed message
            if (messagetemp != "")
            {
                addMessageToDictionary(messagetemp);
            }
        }

        private void addMessageToDictionary(string message)
        {

            // USER_MESSAGE
            if (parseUserMessage(message)) { }

            // CONV_TOPIC_RENAME
            else if (parseConvTopicRename(message)) { }

            // CONV_PIC_CHANGE
            else if (parseConvPicChange(message)) { }

            // USER_ADDED
            else if (parseUserAdded(message)) { }

            // GROUP_CALL
            else if (parseGroupCall(message)) { }

            // GROUP_CALL_NO_ANSWER
            else if (parseGroupCallNoAnswer(message)) { }

            // GROUP_CALL_MISSED            
            else if (parseGroupCallMissed(message)) { }

            // GROUP_CALL_ENDED
            else if (parseGroupCallEnded(message)) { }

            // USER_LEFT
            else if (parseUserLeft(message)) { }

            // USER_JOINED
            else if (parseUserJoined(message)) { }

            else
            {
                invalidMessages.Add(message);
            }

        }

        private bool parseUserJoined(string message)
        {
            string raw_datetime = "", raw_date = "", raw_time = "", raw_time_modif = "";
            bool is_edited = false, is_removed = false;
            string message_owner = "Skype";
            string message_content = "";
            string name = "";
            SkypeUserJoinedMessage cmessage = new SkypeUserJoinedMessage();

            if (!parseTime(ref message, ref raw_datetime, ref raw_date, ref raw_time, ref is_edited, ref is_removed, ref raw_time_modif))
                return false;
            if (!parseUserJoinedContent(ref message, ref message_content, ref name))
                return false;

            cmessage.RawDateTime = raw_datetime;
            cmessage.RawDate = raw_date;
            cmessage.RawTime = raw_time;
            cmessage.setDateTimeCreated(raw_date, raw_time);
            cmessage.isEdited = is_edited;
            cmessage.isRemoved = is_removed;
            cmessage.RawTimeModified = raw_time_modif;
            cmessage.MessageContent = message_content;
            cmessage.MessageOwner = message_owner;
            cmessage.Username = name;
            cmessage.Type = MessageType.USER_JOINED;

            skypeEventMessages.Add(cmessage);
            allMessages.Add(cmessage);

            return true;
        }

        private bool parseUserJoinedContent(ref string message, ref string message_content, ref string name)
        {
            message = message.Trim();
            Regex rgx = new Regex(@"\*\*\* ([\w .]*) has joined\. \*\*\*$");

            Match match = rgx.Match(message);
            if (match.Success)
            {
                message_content = match.Groups[0].Value;
                name = match.Groups[1].Value.Trim();
            }
            else
            {
                return false;
            }

            message = message.Substring(message_content.Length);

            return true;
        }

        private bool parseUserLeft(string message)
        {
            string raw_datetime = "", raw_date = "", raw_time = "", raw_time_modif = "";
            bool is_edited = false, is_removed = false;
            string message_owner = "Skype";
            string message_content = "";
            string name = "";
            SkypeUserLeftMessage cmessage = new SkypeUserLeftMessage();

            if (!parseTime(ref message, ref raw_datetime, ref raw_date, ref raw_time, ref is_edited, ref is_removed, ref raw_time_modif))
                return false;
            if (!parseUserLeftContent(ref message, ref message_content, ref name))
                return false;

            cmessage.RawDateTime = raw_datetime;
            cmessage.RawDate = raw_date;
            cmessage.RawTime = raw_time;
            cmessage.setDateTimeCreated(raw_date, raw_time);
            cmessage.isEdited = is_edited;
            cmessage.isRemoved = is_removed;
            cmessage.RawTimeModified = raw_time_modif;
            cmessage.MessageContent = message_content;
            cmessage.MessageOwner = message_owner;
            cmessage.Username = name;
            cmessage.Type = MessageType.USER_LEFT;

            skypeEventMessages.Add(cmessage);
            allMessages.Add(cmessage);

            return true;
        }

        private bool parseUserLeftContent(ref string message, ref string message_content, ref string name)
        {
            message = message.Trim();
            Regex rgx = new Regex(@"\*\*\* ([\w .]*) has left\. \*\*\*$");

            Match match = rgx.Match(message);
            if (match.Success)
            {
                message_content = match.Groups[0].Value;
                name = match.Groups[1].Value.Trim();
            }
            else
            {
                return false;
            }

            message = message.Substring(message_content.Length);

            return true;
        }

        private bool parseGroupCallMissed(string message)
        {
            string raw_datetime = "", raw_date = "", raw_time = "", raw_time_modif = "";
            bool is_edited = false, is_removed = false;
            string message_owner = "Skype";
            string message_content = "";

            SkypeGroupCallMissedMessage gmessage = new SkypeGroupCallMissedMessage();

            if (!parseTime(ref message, ref raw_datetime, ref raw_date, ref raw_time, ref is_edited, ref is_removed, ref raw_time_modif))
                return false;
            if (!parseGroupCallMissedContent(ref message, ref message_content))
                return false;

            gmessage.RawDateTime = raw_datetime;
            gmessage.RawDate = raw_date;
            gmessage.RawTime = raw_time;
            gmessage.setDateTimeCreated(raw_date, raw_time);
            gmessage.isEdited = is_edited;
            gmessage.isRemoved = is_removed;
            gmessage.RawTimeModified = raw_time_modif;
            gmessage.MessageContent = message_content;
            gmessage.MessageOwner = message_owner;
            gmessage.Type = MessageType.GROUP_CALL_MISSED;

            skypeEventMessages.Add(gmessage);
            allMessages.Add(gmessage);

            return true;
        }

        private bool parseGroupCallMissedContent(ref string message, ref string message_content)
        {
            message = message.Trim();
            Regex rgx = new Regex(@"\*\*\* Missed group call\. \*\*\*$");

            Match match = rgx.Match(message);
            if (match.Success)
            {
                message_content = match.Groups[0].Value;
            }
            else
            {
                return false;
            }

            message = message.Substring(message_content.Length);

            return true;
        }

        private bool parseGroupCallNoAnswer(string message)
        {
            string raw_datetime = "", raw_date = "", raw_time = "", raw_time_modif = "";
            bool is_edited = false, is_removed = false;
            string message_owner = "Skype";
            string message_content = "";

            SkypeGroupCallNoAnswerMessage gmessage = new SkypeGroupCallNoAnswerMessage();

            if (!parseTime(ref message, ref raw_datetime, ref raw_date, ref raw_time, ref is_edited, ref is_removed, ref raw_time_modif))
                return false;
            if (!parseGroupCallNoAnswerContent(ref message, ref message_content))
                return false;

            gmessage.RawDateTime = raw_datetime;
            gmessage.RawDate = raw_date;
            gmessage.RawTime = raw_time;
            gmessage.setDateTimeCreated(raw_date, raw_time);
            gmessage.isEdited = is_edited;
            gmessage.isRemoved = is_removed;
            gmessage.RawTimeModified = raw_time_modif;
            gmessage.MessageContent = message_content;
            gmessage.MessageOwner = message_owner;
            gmessage.Type = MessageType.GROUP_CALL_NO_ANSWER;

            skypeEventMessages.Add(gmessage);
            allMessages.Add(gmessage);

            return true;
        }

        private bool parseGroupCallNoAnswerContent(ref string message, ref string message_content)
        {
            message = message.Trim();
            Regex rgx = new Regex(@"\*\*\* Group call\, no answer\. \*\*\*$");

            Match match = rgx.Match(message);
            if (match.Success)
            {
                message_content = match.Groups[0].Value;
            }
            else
            {
                return false;
            }

            message = message.Substring(message_content.Length);

            return true;
        }

        private bool parseGroupCall(string message)
        {
            string raw_datetime = "", raw_date = "", raw_time = "", raw_time_modif = "";
            bool is_edited = false, is_removed = false;
            string message_owner = "Skype";
            string message_content = "";

            SkypeGroupCallMessage smessage = new SkypeGroupCallMessage();

            if (!parseTime(ref message, ref raw_datetime, ref raw_date, ref raw_time, ref is_edited, ref is_removed, ref raw_time_modif))
                return false;
            if (!parseGroupCallContent(ref message, ref message_content))
                return false;

            smessage.RawDateTime = raw_datetime;
            smessage.RawDate = raw_date;
            smessage.RawTime = raw_time;
            smessage.setDateTimeCreated(raw_date, raw_time);
            smessage.isEdited = is_edited;
            smessage.isRemoved = is_removed;
            smessage.RawTimeModified = raw_time_modif;
            smessage.MessageContent = message_content;
            smessage.MessageOwner = message_owner;
            smessage.Type = MessageType.GROUP_CALL;
            
            skypeEventMessages.Add(smessage);
            allMessages.Add(smessage);

            return true;
        }

        private bool parseGroupCallContent(ref string message, ref string message_content)
        {
            message = message.Trim();
            Regex rgx = new Regex(@"\*\*\* Group call \*\*\*$");
            
            Match match = rgx.Match(message);
            if (match.Success)
            {
                message_content = match.Groups[0].Value;
            }
            else
            {
                return false;
            }

            message = message.Substring(message_content.Length);

            return true;
        }

        private bool parseGroupCallEnded(string message)
        {
            string raw_datetime = "", raw_date = "", raw_time = "", raw_time_modif = "";
            bool is_edited = false, is_removed = false;
            string message_owner = "Skype";
            string message_content = "";
            string duration = "";

            SkypeGroupCallEndedMessage gmessage = new SkypeGroupCallEndedMessage();

            if (!parseTime(ref message, ref raw_datetime, ref raw_date, ref raw_time, ref is_edited, ref is_removed, ref raw_time_modif))
                return false;
            if (!parseGroupCallEndedContent(ref message, ref message_content, ref duration))
                return false;

            gmessage.RawDateTime = raw_datetime;
            gmessage.RawDate = raw_date;
            gmessage.RawTime = raw_time;
            gmessage.setDateTimeCreated(raw_date, raw_time);
            gmessage.isEdited = is_edited;
            gmessage.isRemoved = is_removed;
            gmessage.RawTimeModified = raw_time_modif;
            gmessage.MessageContent = message_content;
            gmessage.MessageOwner = message_owner;
            gmessage.Type = MessageType.GROUP_CALL_ENDED;
            gmessage.Duration = duration;

            skypeEventMessages.Add(gmessage);
            allMessages.Add(gmessage);

            return true;
        }

        private bool parseGroupCallEndedContent(ref string message, ref string message_content, ref string duration)
        {
            message = message.Trim();
            Regex rgx = new Regex(@"\*\*\* Call ended\, duration (\d+:\d+)* \*\*\*$");

            Match match = rgx.Match(message);
            if (match.Success)
            {
                message_content = match.Groups[0].Value;
                duration = match.Groups[1].Value;
            }
            else
            {
                return false;
            }

            message = message.Substring(message_content.Length);

            return true;
        }

        private bool parseUserAdded(string message)
        {
            string raw_datetime = "", raw_date = "", raw_time = "", raw_time_modif = "";
            bool is_edited = false, is_removed = false;
            string message_owner = "Skype";
            string message_content = "";
            string name = "";
            List<string> addedUsers = new List<string>();

            SkypeUserAddedMessage smessage = new SkypeUserAddedMessage();

            if (!parseTime(ref message, ref raw_datetime, ref raw_date, ref raw_time, ref is_edited, ref is_removed, ref raw_time_modif))
                return false;
            if (!parseUserAddedContent(ref message, ref message_content, ref name, ref addedUsers))
                return false;

            smessage.RawDateTime = raw_datetime;
            smessage.RawDate = raw_date;
            smessage.RawTime = raw_time;
            smessage.setDateTimeCreated(raw_date, raw_time);
            smessage.isEdited = is_edited;
            smessage.isRemoved = is_removed;
            smessage.RawTimeModified = raw_time_modif;
            smessage.MessageContent = message_content;
            smessage.MessageOwner = message_owner;
            smessage.Type = MessageType.USER_ADDED;

            smessage.Username = name;
            smessage.AddedUsers = addedUsers;

            skypeEventMessages.Add(smessage);
            allMessages.Add(smessage);

            return true;
        }

        private bool parseUserAddedContent(ref string message, ref string message_content, ref string name, ref List<string> addedUsers)
        {
            message = message.Trim();
            Regex rgx = new Regex(@"\*\*\* ([\w| ]*) added ([\w .,]*) \*\*\*$");

            string[] addedPeople;

            Match match = rgx.Match(message);
            if (match.Success)
            {
                message_content = match.Groups[0].Value;
                name = match.Groups[1].Value.Trim();
                addedPeople = match.Groups[2].Value.Trim().Split(',') ;

                foreach(string asd in addedPeople)
                    addedUsers.Add(asd);
            }
            else
            {
                return false;
            }

            message = message.Substring(message_content.Length);

            return true;
        }

        private bool parseConvPicChange(string message)
        {
            string raw_datetime = "", raw_date = "", raw_time = "", raw_time_modif = "";
            bool is_edited = false, is_removed = false;
            string message_owner = "Skype";
            string message_content = "";
            string name = "";
            SkypeConvPicChangeMessage cmessage = new SkypeConvPicChangeMessage();

            if (!parseTime(ref message, ref raw_datetime, ref raw_date, ref raw_time, ref is_edited, ref is_removed, ref raw_time_modif))
                return false;
            if (!parseConvPicChangeContent(ref message, ref message_content, ref name))
                return false;

            cmessage.RawDateTime = raw_datetime;
            cmessage.RawDate = raw_date;
            cmessage.RawTime = raw_time;
            cmessage.setDateTimeCreated(raw_date, raw_time);
            cmessage.isEdited = is_edited;
            cmessage.isRemoved = is_removed;
            cmessage.RawTimeModified = raw_time_modif;
            cmessage.MessageContent = message_content;
            cmessage.MessageOwner = message_owner;
            cmessage.Username = name;
            cmessage.Type = MessageType.CONV_PIC_CHANGE;

            skypeEventMessages.Add(cmessage);
            allMessages.Add(cmessage);

            return true;
        }

        private bool parseConvPicChangeContent(ref string message, ref string message_content, ref string name)
        {
            message = message.Replace("\"", "quotess");
            message = message.Trim();
            Regex rgx = new Regex(@"\*\*\* ([\w .]*) has changed the conversation picture\. \*\*\*$");

            Match match = rgx.Match(message);
            if (match.Success)
            {
                message_content = match.Groups[0].Value;
                name = match.Groups[1].Value.Trim();
            }
            else
            {
                return false;
            }

            message = message.Substring(message_content.Length);

            return true;
        }

        private bool parseConvTopicRename(string message)
        {
            string raw_datetime = "", raw_date = "", raw_time = "", raw_time_modif = "";
            bool is_edited = false, is_removed = false;
            string message_owner = "Skype";
            string message_content = "";
            string user = "";
            string topic = "";
            SkypeConvTopicRenameMessage cmessage = new SkypeConvTopicRenameMessage();

            if (!parseTime(ref message, ref raw_datetime, ref raw_date, ref raw_time, ref is_edited, ref is_removed, ref raw_time_modif))
                return false;
            if (!parseConvTopicRenameContent(ref message, ref message_content, ref user, ref topic))
                return false;

            cmessage.RawDateTime = raw_datetime;
            cmessage.RawDate = raw_date;
            cmessage.RawTime = raw_time;
            cmessage.setDateTimeCreated(raw_date, raw_time);
            cmessage.isEdited = is_edited;
            cmessage.isRemoved = is_removed;
            cmessage.RawTimeModified = raw_time_modif;
            cmessage.MessageContent = message_content;
            cmessage.MessageOwner = message_owner;
            cmessage.Username = user;
            cmessage.Topic = topic;
            cmessage.Type = MessageType.CONV_TOPIC_RENAME;

            skypeEventMessages.Add(cmessage);
            allMessages.Add(cmessage);

            return true;
        }

        private bool parseConvTopicRenameContent(ref string message, ref string message_content, ref string user, ref string topic)
        {
            message = message.Replace("\"", "quotess");
            message = message.Trim();
            Regex rgx = new Regex(@"^\*\*\* ([\w .]*) has renamed this conversation to quotess(.*)quotess \*\*\*$");

            Match match = rgx.Match(message);
            if (match.Success)
            {
                message_content = match.Groups[0].Value;
                user = match.Groups[1].Value.Trim();
                topic = match.Groups[2].Value.Trim();
            }
            else
            {
                return false;
            }

            message = message.Substring(message_content.Length);

            return true;
        }

        private bool parseUserMessage(string message)
        {
            string raw_datetime = "", raw_date = "", raw_time = "", raw_time_modif = "";
            bool is_edited = false, is_removed = false;
            string message_owner = "";
            string message_content = "";
            SkypeUserMessage umessage = new SkypeUserMessage();

            if (!parseTime(ref message, ref raw_datetime, ref raw_date, ref raw_time, ref is_edited, ref is_removed, ref raw_time_modif ))
                return false;
            if (!parseName(ref message, ref message_owner))
                return false;
            if (!parseChat(ref message, ref message_content))
                return false;

            // set Attributes
            umessage.RawDateTime = raw_datetime;
            umessage.RawDate = raw_date;
            umessage.RawTime = raw_time;
            umessage.setDateTimeCreated(raw_date, raw_time);
            umessage.RawTimeModified = raw_time_modif;
            umessage.isEdited = is_edited;
            umessage.isRemoved = is_removed;
            umessage.MessageOwner = message_owner;
            umessage.MessageContent = message_content;
            umessage.isValid = true;
            umessage.Type = MessageType.USER_MESSAGE;
            
            if (!userToMessages.ContainsKey(umessage.MessageOwner))
                userToMessages.Add(umessage.MessageOwner, new List<SkypeUserMessage>());

            userToMessages[umessage.MessageOwner].Add(umessage);
            allMessages.Add(umessage);

            return true;
        }

        private bool parseTime(ref string message, ref string rawDateTime, ref string rawDate, ref string rawTime, ref bool isEdited, ref bool isRemoved, ref string rawTimeModified)
        {
            isEdited = false;
            isRemoved = false;

            Regex rgx = new Regex(@"^\[(\d+\/\d+\/\d+ )*(\d+:\d+:\d+ [A/P]M)( \| (\w+) (\d+:\d+:\d+ [A/P]M))*\]");

            Match match = rgx.Match(message);
            if (match.Success)
            {
                rawDateTime = match.Groups[0].Value;
                rawDate = match.Groups[1].Value.Trim();
                rawTime = match.Groups[2].Value.Trim();
                string modif = match.Groups[4].Value.Trim();
                switch (modif)
                {
                    case "Edited":
                        isEdited = true;
                        break;
                    case "Removed":
                        isRemoved = true;
                        break;
                    default:
                        break;
                }
                rawTimeModified = match.Groups[5].Value.Trim();
            }
            else
            {
                return false;
            }
            
            message = message.Substring(rawDateTime.Length);

            return true;
        }

        private bool parseName(ref string message, ref string messageOwner)
        {
            Regex rgx = new Regex(@"(^\s\w[^:]+):");

            Match match = rgx.Match(message);
            if (match.Success)
            {
                if (match.Groups[0].Value[match.Groups[0].Value.Length - 1] != ':')
                    return false;
                messageOwner = match.Groups[1].Value.Trim();
            }
            else
            {
                return false;
            }

            message = message.Substring(match.Groups[0].Value.Length);

            return true;
        }

        private bool parseChat(ref string message, ref string message_content)
        {
            // Normal chat
            Regex rgx = new Regex(@"(.*)");

            Match match = rgx.Match(message);
            if (match.Success)
            {
                message_content = match.Groups[1].Value;
            }
            else
            {
                return false;
            }

            message = message.Substring(message_content.Length);
            message_content = message_content.Trim();

            return true;
        }

        public List<SkypeMessage> getAllMessages()
        {
            return allMessages;
        }

        public List<SkypeMessage> getAllSkypeEventMessages()
        {
            return skypeEventMessages;
        }

        public List<string> getInvalidMessages()
        {
            return invalidMessages;
        }

        public List<SkypeUserMessage> getMessagesFrom(string name)
        {
            if (userToMessages.ContainsKey(name))
                return userToMessages[name];
            return new List<SkypeUserMessage>();
        }

        public HashSet<string> getSkypeNames()
        {
            HashSet<string> tempn = new HashSet<string>();
            foreach (string name in userToMessages.Keys)
            {
                tempn.Add(name);
            }
            return tempn;
        }
    }
}
