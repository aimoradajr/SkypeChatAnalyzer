using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace SkypeChatAnalyzer
{
    public class SkypeUserMessage : SkypeMessage
    {   
        public SkypeUserMessage()
        {
            RawMessage = "";

            RawDateTime = "";
            RawTime = "";
            RawDate = "";

            isEdited = false;
            isRemoved = false;

            Type = MessageType.USER_MESSAGE;

            MessageOwner = "";
            MessageContent = "";

            isValid = true;
        }

        private bool parseConversationPictureChangeEvent(ref string message)
        {
            Regex rgx = new Regex(@"\*\*\*([\w.] *) has changed the conversation picture\. \*\*\*$");

            Match match = rgx.Match(message);
            if (match.Success)
            {
                MessageOwner = match.Groups[1].Value;
                Type = MessageType.CONV_PIC_CHANGE;
            }
            else
                return false;

            message = message.Substring(MessageContent.Length);
            MessageContent = MessageContent.Trim();

            return true;
        }

        public void setTimeModified(string rawtimemodified)
        {
            RawTimeModified = rawtimemodified;
        }
    }
    
    
}

