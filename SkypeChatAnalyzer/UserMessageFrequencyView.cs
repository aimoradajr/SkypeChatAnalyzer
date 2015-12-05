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
    public partial class UserMessageFrequencyView : Form
    {
        Dictionary<string, List<SkypeUserMessage>> UserToMessages = new Dictionary<string, List<SkypeUserMessage>>();
        string SelectedUser="";
        int SelectedYear=0;
        int SelectedMonth=0;
        int SelectedDay=0;

        List<Color> colors = new List<Color>();

        //public UserMessageFrequencyView()
        //{
        //    InitializeComponent();
        //}

        public UserMessageFrequencyView(Dictionary<string, List<SkypeUserMessage>> user_to_messages, string user = "")
        {
            InitializeComponent();

            if(user_to_messages != null)
                UserToMessages = user_to_messages;

            SelectedUser = user;
            
            setChartOptions();
        }

        private void setChartOptions()
        {
            // Users
            comboBox_users.Items.Add("All Users");
            foreach (string name in UserToMessages.Keys)
                comboBox_users.Items.Add(name);

            if( SelectedUser == "all_users_123d123d123s1wr4ftet4t" )
                comboBox_users.SelectedIndex = 0;  // All users
            else
                comboBox_users.SelectedIndex = comboBox_users.Items.IndexOf(SelectedUser);

            // Year
            comboBox_years.Items.Add("");
            for (int i = 2010; i <= DateTime.Today.Year; i++)
                comboBox_years.Items.Add(i);

            comboBox_years.SelectedIndex = comboBox_years.Items.IndexOf(DateTime.Now.Year);

            // Month
            comboBox_month.Items.Add("");
            comboBox_month.Items.Add("January");
            comboBox_month.Items.Add("February");
            comboBox_month.Items.Add("March");
            comboBox_month.Items.Add("April");
            comboBox_month.Items.Add("May");
            comboBox_month.Items.Add("June");
            comboBox_month.Items.Add("July");
            comboBox_month.Items.Add("August");
            comboBox_month.Items.Add("September");
            comboBox_month.Items.Add("October");
            comboBox_month.Items.Add("November");
            comboBox_month.Items.Add("December");
            
        }

        private void drawChartMonth(string user, int year)
        {
            int MaxX = 12;  //months
            int MaxY = 50;
            int YInterval = 1;

            // Clear whole chart
            mychart.Legends.Clear();
            mychart.Series.Clear();
            mychart.ChartAreas.Clear();

            // User
            List<SkypeUserMessage> userMessages;


            Random rand = new Random();
            int usernum = 0;
            foreach (string tempuser in UserToMessages.Keys)
            {

                // If this only for one user
                if (user != "All Users" && user != "")
                    if (tempuser != user)
                        continue;

                // Get messages
                userMessages = new List<SkypeUserMessage>();
                if (UserToMessages.ContainsKey(tempuser))
                    userMessages = UserToMessages[tempuser];
                else
                {
                    // warning
                }

                // Color
                Color userColor = Color.FromArgb(rand.Next(255), rand.Next(255), rand.Next(255));

                // New Function Series
                string userfunc = "MyFuncUser" + tempuser;
                mychart.Series.Add(userfunc);
                mychart.Series[userfunc].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                //mychart.Series[userfunc].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
                mychart.Series[userfunc].Color = userColor;
                mychart.Series[userfunc].BorderWidth = 2;
                mychart.Series[userfunc].LegendText = tempuser;
                
                int maxcount = 0;
                int mess_index = 0;

                Dictionary<int, int> monthToCount = new Dictionary<int, int>();

                // Init month counts
                for (int i = 1; i <= 12; i++)
                    monthToCount.Add(i, 0);


                // Tally
                while (mess_index < userMessages.Count)
                {
                    if (userMessages[mess_index].DateTimeWritten.Year == year)
                    {
                        int month = userMessages[mess_index].DateTimeWritten.Month;
                        if (!monthToCount.ContainsKey(month))
                            monthToCount.Add(month, 0);

                        monthToCount[month]++;
                    }
                    mess_index++;
                }

                // Add points
                foreach(int monthkey in monthToCount.Keys)
                {
                    if (monthToCount[monthkey] > maxcount)
                        maxcount = monthToCount[monthkey];
                    mychart.Series[userfunc].Points.AddXY(monthkey, monthToCount[monthkey]);
                }

                // Set MaxY
                if (maxcount > MaxY)
                    MaxY = maxcount;

                // Set Y interval
                if (MaxY < 10)
                    YInterval = 1;
                else if (MaxY < 100)
                    YInterval = 10;
                else if (MaxY < 500)
                    YInterval = 20;
                else if (MaxY < 1000)
                    YInterval = 100;
                else if (MaxY < 5000)
                    YInterval = 200;
                else if (MaxY < 10000)
                    YInterval = 1000;
                else
                    YInterval = 10000;


                // Create a new legend MyLegend
                mychart.Legends.Add(userfunc);
                mychart.Legends[userfunc].BorderColor = userColor;
            }
            
            // Graph
            //mychart.Size = new Size(100, 300);

            // Add a chartarea called "area", add axes to it and color the area black
            mychart.ChartAreas.Add("draw");
            mychart.ChartAreas["draw"].Position.Auto = true;
            //mychart.ChartAreas["draw"].Position.X = 50;
            //mychart.ChartAreas["draw"].Position.Y = 0;
            mychart.ChartAreas["draw"].Position.Height = 100;
            mychart.ChartAreas["draw"].Position.Width = 80;

            mychart.ChartAreas["draw"].AxisX.Minimum = 0;
            mychart.ChartAreas["draw"].AxisX.Maximum = MaxX;
            mychart.ChartAreas["draw"].AxisX.Interval = 1;
            mychart.ChartAreas["draw"].AxisX.MajorGrid.LineColor = Color.LightGray;
            mychart.ChartAreas["draw"].AxisX.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            

            mychart.ChartAreas["draw"].AxisY.Minimum = 0;
            mychart.ChartAreas["draw"].AxisY.Maximum = MaxY;
            mychart.ChartAreas["draw"].AxisY.Interval = YInterval;
            mychart.ChartAreas["draw"].AxisY.MajorGrid.LineColor = Color.LightGray;
            mychart.ChartAreas["draw"].AxisY.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            mychart.ChartAreas["draw"].AlignmentStyle = System.Windows.Forms.DataVisualization.Charting.AreaAlignmentStyles.All;

            mychart.ChartAreas["draw"].BackColor = Color.Black;

            usernum++;
        }

        private void button_generateChart_Click(object sender, EventArgs e)
        {
            // Year resolution report
            //drawChartYear(SelectedUser);          TODOO

            // Month resolution report
            if (SelectedYear > 0 && SelectedMonth < 1)
                drawChartMonth(SelectedUser, SelectedYear);

            // Day resolution report
            //drawChartDay(SelectedUser, SelectedYear, SelectedMonth);

            // Hour resolution report
            //drawChartDay(SelectedUser, SelectedYear, SelectedMonth, SelectedDay)
        }

        private void comboBox_month_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedMonth = comboBox_month.SelectedIndex;
            if (SelectedMonth > 0)
            {
                comboBox_day.Enabled = true;
                comboBox_day.Items.Clear();
                for (int i = 1; i <= DateTime.DaysInMonth(SelectedYear, SelectedMonth); i++)
                    comboBox_day.Items.Add(i);
            }
            else
            {
                comboBox_day.Enabled = false;
                comboBox_day.SelectedIndex = -1;
                SelectedDay = 0;
            }
        }

        private void comboBox_years_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((sender as ComboBox).Items[(sender as ComboBox).SelectedIndex].ToString() == "")
                SelectedYear = 0;
            else
                SelectedYear = int.Parse((sender as ComboBox).Items[(sender as ComboBox).SelectedIndex].ToString());

            if ((sender as ComboBox).SelectedIndex >= 0)
                comboBox_month.Enabled = true;
            else
            {
                comboBox_month.Enabled = false;
                SelectedMonth = 0;
            }
        }

        private void comboBox_users_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((sender as ComboBox).SelectedIndex >= 0)
            {
                SelectedUser = (sender as ComboBox).Items[(sender as ComboBox).SelectedIndex].ToString();
            }
            else
            {
                SelectedUser = "";
            }
        }

        private void comboBox_day_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((sender as ComboBox).SelectedIndex >= 0)
            {
                SelectedDay = (sender as ComboBox).SelectedIndex+1;
            }
            else
            {
                SelectedUser = "";
            }
        }

        private void UserMessageFrequencyView_Load(object sender, EventArgs e)
        {
            // Generate
            button_generateChart.PerformClick();
        }
    }

}
