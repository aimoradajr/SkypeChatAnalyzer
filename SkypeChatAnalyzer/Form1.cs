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
    public partial class Form1 : Form
    {
        string InputText;
        string InputFile;
        ChatAnalyzer Analyzer;
        ReportGenerator ReporterRobot;

        public Form1()
        {
            InitializeComponent();

            InputText = "";
            InputFile = "";
            Analyzer = new ChatAnalyzer();
            ReporterRobot = new ReportGenerator();
        }

        private void analyze_button_Click(object sender, EventArgs e)
        {
            console.Clear();

            // Get input text
            InputText = input_text.Text;
            
            if( InputText == "" )
            {
                printOutput("No input found");
                return;
            }

            // Analyze
            Analyzer = new ChatAnalyzer();
            Analyzer.setInputText(InputText);
            Analyzer.analyzeChatString();
            
            // Print Reports
            printOutput(getHashSettoString("Skype Names", Analyzer.getSkypeNames(), true));
            printOutput(getMessageListStringtoString("Invalid messages", Analyzer.getInvalidMessages(), true));
            printOutput(getMessageListtoString("All messages", Analyzer.getAllMessages(), true));
            printOutput(getMessageListtoString("All skype events", Analyzer.getAllSkypeEventMessages(), true));

            goToReportTab();
        }
        
        private string getMessageListStringtoString(string title, List<string> list, bool showItemNumbers = false)
        {
            string tempm = "";
            tempm += title + ":\n";

            if (list == null)
            {
                tempm += "null list.\n";
                return tempm;
            }

            tempm += list.Count + " items found\n";

            for (int i = 0; i < list.Count; i++)
            {
                string temps = list[i];
                if (showItemNumbers)
                    tempm += (i + 1) + "\t" + temps + "\n";
                else
                    tempm += "\t" + temps + "\n";
            }

            return tempm;
        }

        private string getMessageListRawtoString(string title, List<SkypeMessage> list, bool showItemNumbers = false)
        {
            string tempm = "";
            tempm += title + ":\n";

            if (list == null)
            {
                tempm += "null list.\n";
                return tempm;
            }

            tempm += list.Count + " items found\n";

            for (int i = 0; i < list.Count; i++)
            {
                string temps = list[i].RawMessage;
                if (showItemNumbers)
                    tempm += (i + 1) + "\t" + temps + "\n";
                else
                    tempm += "\t" + temps + "\n";
            }

            return tempm;
        }

        private string getMessageListtoString(string title, List<SkypeMessage> list, bool showItemNumbers=false)
        {
            string tempm = "";
            tempm += title + ":\n";

            if (list == null)
            {
                tempm += "null list.\n";
                return tempm;
            }

            tempm += list.Count + " items found\n";

            for (int i = 0; i < list.Count; i++)
            {
                string temps = list[i].RawDateTime + " ::: " + list[i].MessageOwner + " ::: " + list[i].MessageContent;
                if (showItemNumbers)
                    tempm += (i + 1) + "\t" + temps + "\n";
                else
                    tempm += "\t" + temps + "\n";
            }

            return tempm;
        }

        private string getHashSettoString(string title, HashSet<string> list, Boolean showItemNumbers=false)
        {
            string tempm = "";
            tempm += title + ":\n";

            if (list == null)
            {
                tempm += "null list\n"; 
                return tempm;
            }

            tempm += list.Count + " items found\n";

            for (int i = 0; i < list.Count; i++)
            {
                if(showItemNumbers)
                    tempm += (i +1) + "\t" + list.ElementAt(i) + "\n";
                else
                    tempm += "\t" + list.ElementAt(i) + "\n";
            }
            return tempm;
        }

        private void printOutput(string text)
        {
            console.Text += text + "\n";
        }

        private string generateReport()
        {
            string report;

            report = "temp report.";

            return report;
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            input_text.Clear();
        }

        private void loadStatisticsToListView(HashSet<string> hashSet)
        {
            dataGridView_usernames.Rows.Clear();
            foreach (string name in hashSet)
            {
                int index = 0;
                string[] subitems = new string[9];
                subitems[index++] = name;
                subitems[index++] = ReporterRobot.generateMessageCountReport(Analyzer.getMessagesFrom(name)).ToString();
                subitems[index++] = "this is messages";
                subitems[index++] = "this is messages chart";
                subitems[index++] = "this is word frequency";
                subitems[index++] = "this is emoticon frequency";
                subitems[index++] = ReporterRobot.generateLinkCountReport(Analyzer.getMessagesFrom(name)).ToString();
                subitems[index++] = "links";
                
                dataGridView_usernames.Rows.Add(subitems[0], subitems[1], subitems[2], subitems[3], subitems[4], subitems[5], subitems[6]);
            }
        }

        private void dataGridView_usernames_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex < 0 | e.RowIndex < 0)
                return;
            
            string columnname = dataGridView_usernames.Columns[e.ColumnIndex].Name;


            int SkypeUsernameColumnIndex = dataGridView_usernames.Columns["column_name"].Index;

            DataGridViewCell name_cell = dataGridView_usernames.Rows[e.RowIndex].Cells[SkypeUsernameColumnIndex];
            if (name_cell == null || name_cell.Value == null ||name_cell.Value.ToString() == "")
                return;

            string name = name_cell.Value.ToString();

            List<SkypeUserMessage> userMessages = Analyzer.getMessagesFrom(name);

            switch (columnname)
            {
                case "column_messages":
                    //MessageBox.Show(getMessageListtoString("All messages from: " + name, userMessages,true), name + " messages");
                    showUserMessagesReport(name, userMessages);
                    break;
                case "column_messages_frequency_chart":
                    showUserMessagesFrequencyChartReport(name);
                    break;
                case "column_word_frequency":
                    MessageBox.Show(ReporterRobot.generateWordFrequencyReportTopNToString(userMessages,30),"Top 30 most used words");
                    break;
                case "column_emoticon_frequency":
                    MessageBox.Show(ReporterRobot.generateEmoticonFrequencyReportTopNToString(userMessages, 30), "Top 30 most used emoticons");
                    break;
                case "column_links":        // CHeck this code if ok.
                    MessageBox.Show(ReporterRobot.generateLinksReportToString(userMessages, 30), name + " links");
                    break;
                default:
                    //MessageBox.Show("Oops. This button's action is undefined. Sry.");
                    break;
            }
            
            
        }

        private void showUserMessagesFrequencyChartReport(string name)
        {
            UserMessageFrequencyView ct = new UserMessageFrequencyView(Analyzer.userToMessages, name);
            ct.Show();
        }

        private void showUserMessagesReport(string name, List<SkypeUserMessage> userMessages)
        {
            UserMessagesViewForm report = new UserMessagesViewForm(name,userMessages);
            report.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.CheckFileExists = true;
            ofd.Filter = "Text files (*.txt)|*.txt";
            ofd.Multiselect = false;
            DialogResult result = ofd.ShowDialog(this);
            
            setInputSourceFile(ofd.FileName);
        }

        private void setInputSourceFile(string v)
        {
            InputFile = v;
            label_inputsourcefile.Text = InputFile;

            analyzeFromFile();
        }

        private void analyzeFromFile()
        {
            console.Clear();

            if (InputFile.Length < 1)
            {
                printOutput("No input file found");
                return;
            }

            // Analyze
            Analyzer = new ChatAnalyzer();
            Analyzer.setInputFile(InputFile);
            Analyzer.analyzeChatFile();


            // Print Reports
            printOutput(getHashSettoString("Skype Names", Analyzer.getSkypeNames(), true));
            printOutput(getMessageListStringtoString("Invalid messages", Analyzer.getInvalidMessages(), true));
            //printOutput(getMessageListtoString("All messages", Analyzer.getAllMessages(), true));
            printOutput(getMessageListtoString("All skype events", Analyzer.getAllSkypeEventMessages(), true));

            goToReportTab();
        }

        private void goToReportTab()
        {
            tab_main.SelectedIndex = 1;
        }

        private void dataGridView_usernames_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {
            if(e.Column.Name == "column_messages_count" || e.Column.Name == "column_link_count")
            {
                if (double.Parse(e.CellValue1.ToString()) > double.Parse(e.CellValue2.ToString()))
                {
                    e.SortResult = 1;
                }
                else if (double.Parse(e.CellValue1.ToString()) < double.Parse(e.CellValue2.ToString()))
                {
                    e.SortResult = -1;
                }
                else
                    e.SortResult = 0;

                e.Handled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UserMessageFrequencyView ct = new UserMessageFrequencyView(Analyzer.userToMessages, "all_users_123d123d123s1wr4ftet4t");
            ct.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
        }

        private void button_analyze_from_file_Click(object sender, EventArgs e)
        {
            analyzeFromFile();
        }

        private void tab_main_SelectedIndexChanged(object sender, EventArgs e)
        {
            if( tab_main.SelectedIndex == 1 )       // Report tab
            loadStatisticsToListView(Analyzer.getSkypeNames());
        }
    }
}
