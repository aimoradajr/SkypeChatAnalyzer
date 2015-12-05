using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SkypeChatAnalyzer
{
    public partial class UserMessagesViewForm : Form
    {
        public UserMessagesViewForm(string username, List<SkypeUserMessage> list)
        {
            InitializeComponent();

            populateTable(list);
            setRangeDateTime(list);
            setUserName(username);
            setMessageCount(list.Count);
        }

        private void setMessageCount(int count)
        {
            label_messageCount.Text = count + " messages";
        }

        private void setUserName(string username)
        {
            label_username.Text = username;
        }

        private void populateTable(List<SkypeUserMessage> list)
        {
            foreach (SkypeUserMessage message in list)
                dataGridView_messages.Rows.Add(message.RawDateTime, message.MessageContent);
        }

        private void setRangeDateTime(List<SkypeUserMessage> list)
        {
            string range = "";

            range += list[0].RawDateTime;
            range += " - ";
            range += list[list.Count-1].RawDateTime;

            rangeDateTimeLabel.Text = range;
        }
    }
}
