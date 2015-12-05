using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkypeChatAnalyzer
{
    public class SkypeMessage
    {
        public string RawMessage { get; set; }
        public string RawDateTime { get; set; }
        public string RawDate { get; set; }
        public string RawTime { get; set; }
        public DateTime DateTimeWritten;

        // Modified
        public bool isEdited { get; set; }
        public bool isRemoved { get; set; }
        public string RawTimeModified { get; set; }

        public MessageType Type = MessageType.UNKNOWN;

        public string MessageOwner { get; set; }
        public string MessageContent { get; set; }

        public bool isValid { get; set; }


        public void setDateTimeCreated(string date, string time)
        {
            DateTime dt = Convert.ToDateTime(date + " " + time);
            DateTimeWritten = dt;
        }
    }

    public enum MessageType
    {
        UNKNOWN,
        USER_MESSAGE,
        CONV_TOPIC_RENAME,
        CONV_PIC_CHANGE,
        USER_ADDED,
        GROUP_CALL,                     // Not sure if combine group call events. .hmmm.
        GROUP_CALL_NO_ANSWER,
        GROUP_CALL_MISSED,
        GROUP_CALL_ENDED,
        USER_LEFT,
        USER_JOINED
    }
}
