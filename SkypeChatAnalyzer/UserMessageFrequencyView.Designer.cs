namespace SkypeChatAnalyzer
{
    partial class UserMessageFrequencyView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mychart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.button_generateChart = new System.Windows.Forms.Button();
            this.comboBox_users = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox_years = new System.Windows.Forms.ComboBox();
            this.comboBox_month = new System.Windows.Forms.ComboBox();
            this.comboBox_day = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.mychart)).BeginInit();
            this.SuspendLayout();
            // 
            // mychart
            // 
            this.mychart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mychart.Location = new System.Drawing.Point(130, -1);
            this.mychart.Name = "mychart";
            this.mychart.Size = new System.Drawing.Size(683, 424);
            this.mychart.TabIndex = 0;
            // 
            // button_generateChart
            // 
            this.button_generateChart.Location = new System.Drawing.Point(3, 225);
            this.button_generateChart.Name = "button_generateChart";
            this.button_generateChart.Size = new System.Drawing.Size(121, 39);
            this.button_generateChart.TabIndex = 1;
            this.button_generateChart.Text = "generate";
            this.button_generateChart.UseVisualStyleBackColor = true;
            this.button_generateChart.Click += new System.EventHandler(this.button_generateChart_Click);
            // 
            // comboBox_users
            // 
            this.comboBox_users.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.comboBox_users.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox_users.FormattingEnabled = true;
            this.comboBox_users.Location = new System.Drawing.Point(3, 25);
            this.comboBox_users.Name = "comboBox_users";
            this.comboBox_users.Size = new System.Drawing.Size(121, 21);
            this.comboBox_users.TabIndex = 2;
            this.comboBox_users.SelectedIndexChanged += new System.EventHandler(this.comboBox_users_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "User";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Year";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Month";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 182);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Day";
            // 
            // comboBox_years
            // 
            this.comboBox_years.FormattingEnabled = true;
            this.comboBox_years.Location = new System.Drawing.Point(3, 77);
            this.comboBox_years.Name = "comboBox_years";
            this.comboBox_years.Size = new System.Drawing.Size(121, 21);
            this.comboBox_years.TabIndex = 7;
            this.comboBox_years.SelectedIndexChanged += new System.EventHandler(this.comboBox_years_SelectedIndexChanged);
            // 
            // comboBox_month
            // 
            this.comboBox_month.Enabled = false;
            this.comboBox_month.FormattingEnabled = true;
            this.comboBox_month.Location = new System.Drawing.Point(3, 137);
            this.comboBox_month.Name = "comboBox_month";
            this.comboBox_month.Size = new System.Drawing.Size(121, 21);
            this.comboBox_month.TabIndex = 8;
            this.comboBox_month.SelectedIndexChanged += new System.EventHandler(this.comboBox_month_SelectedIndexChanged);
            // 
            // comboBox_day
            // 
            this.comboBox_day.Enabled = false;
            this.comboBox_day.FormattingEnabled = true;
            this.comboBox_day.Location = new System.Drawing.Point(3, 198);
            this.comboBox_day.Name = "comboBox_day";
            this.comboBox_day.Size = new System.Drawing.Size(121, 21);
            this.comboBox_day.TabIndex = 9;
            this.comboBox_day.SelectedIndexChanged += new System.EventHandler(this.comboBox_day_SelectedIndexChanged);
            // 
            // UserMessageFrequencyView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(813, 422);
            this.Controls.Add(this.comboBox_day);
            this.Controls.Add(this.comboBox_month);
            this.Controls.Add(this.comboBox_years);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox_users);
            this.Controls.Add(this.button_generateChart);
            this.Controls.Add(this.mychart);
            this.Name = "UserMessageFrequencyView";
            this.Text = "UserMessageFrequencyView";
            this.Load += new System.EventHandler(this.UserMessageFrequencyView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mychart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart mychart;
        private System.Windows.Forms.Button button_generateChart;
        private System.Windows.Forms.ComboBox comboBox_users;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox_years;
        private System.Windows.Forms.ComboBox comboBox_month;
        private System.Windows.Forms.ComboBox comboBox_day;
    }
}