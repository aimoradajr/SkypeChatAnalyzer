namespace SkypeChatAnalyzer
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel_console = new System.Windows.Forms.Panel();
            this.console = new System.Windows.Forms.RichTextBox();
            this.tab_main = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dataGridView_usernames = new System.Windows.Forms.DataGridView();
            this.button2 = new System.Windows.Forms.Button();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.input_text = new System.Windows.Forms.TextBox();
            this.clearButton = new System.Windows.Forms.Button();
            this.analyze_button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.label_inputsourcefile = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.panel_main = new System.Windows.Forms.Panel();
            this.column_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_messages_count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_messages_frequency_chart = new System.Windows.Forms.DataGridViewButtonColumn();
            this.column_messages = new System.Windows.Forms.DataGridViewButtonColumn();
            this.column_word_frequency = new System.Windows.Forms.DataGridViewButtonColumn();
            this.column_emoticon_frequency = new System.Windows.Forms.DataGridViewButtonColumn();
            this.column_link_count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_links = new System.Windows.Forms.DataGridViewButtonColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.button_analyze_from_file = new System.Windows.Forms.Button();
            this.panel_console.SuspendLayout();
            this.tab_main.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_usernames)).BeginInit();
            this.tabPage1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.panel_main.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_console
            // 
            this.panel_console.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel_console.Controls.Add(this.console);
            this.panel_console.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_console.Location = new System.Drawing.Point(0, 336);
            this.panel_console.Name = "panel_console";
            this.panel_console.Size = new System.Drawing.Size(478, 99);
            this.panel_console.TabIndex = 7;
            // 
            // console
            // 
            this.console.Dock = System.Windows.Forms.DockStyle.Fill;
            this.console.Location = new System.Drawing.Point(0, 0);
            this.console.Name = "console";
            this.console.ReadOnly = true;
            this.console.Size = new System.Drawing.Size(478, 99);
            this.console.TabIndex = 3;
            this.console.Text = "";
            // 
            // tab_main
            // 
            this.tab_main.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tab_main.Controls.Add(this.tabPage1);
            this.tab_main.Controls.Add(this.tabPage2);
            this.tab_main.ItemSize = new System.Drawing.Size(60, 18);
            this.tab_main.Location = new System.Drawing.Point(0, 0);
            this.tab_main.Margin = new System.Windows.Forms.Padding(0);
            this.tab_main.Name = "tab_main";
            this.tab_main.SelectedIndex = 0;
            this.tab_main.Size = new System.Drawing.Size(478, 333);
            this.tab_main.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tab_main.TabIndex = 5;
            this.tab_main.SelectedIndexChanged += new System.EventHandler(this.tab_main_SelectedIndexChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.button2);
            this.tabPage2.Controls.Add(this.dataGridView_usernames);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(470, 307);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Report";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dataGridView_usernames
            // 
            this.dataGridView_usernames.AllowUserToAddRows = false;
            this.dataGridView_usernames.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView_usernames.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView_usernames.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridView_usernames.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridView_usernames.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_usernames.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.column_name,
            this.column_messages_count,
            this.column_messages_frequency_chart,
            this.column_messages,
            this.column_word_frequency,
            this.column_emoticon_frequency,
            this.column_link_count,
            this.column_links});
            this.dataGridView_usernames.Location = new System.Drawing.Point(6, 6);
            this.dataGridView_usernames.Name = "dataGridView_usernames";
            this.dataGridView_usernames.Size = new System.Drawing.Size(458, 253);
            this.dataGridView_usernames.TabIndex = 3;
            this.dataGridView_usernames.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_usernames_CellContentClick);
            this.dataGridView_usernames.SortCompare += new System.Windows.Forms.DataGridViewSortCompareEventHandler(this.dataGridView_usernames_SortCompare);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button2.Location = new System.Drawing.Point(3, 277);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(103, 27);
            this.button2.TabIndex = 11;
            this.button2.Text = "frequency graph";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tabControl1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(470, 307);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Input";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.ItemSize = new System.Drawing.Size(50, 18);
            this.tabControl1.Location = new System.Drawing.Point(3, 3);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(0);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tabControl1.RightToLeftLayout = true;
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(464, 301);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label1);
            this.tabPage3.Controls.Add(this.analyze_button);
            this.tabPage3.Controls.Add(this.clearButton);
            this.tabPage3.Controls.Add(this.input_text);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tabPage3.Size = new System.Drawing.Size(456, 275);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "Text";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // input_text
            // 
            this.input_text.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.input_text.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.input_text.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.input_text.ForeColor = System.Drawing.SystemColors.GrayText;
            this.input_text.Location = new System.Drawing.Point(6, 28);
            this.input_text.Multiline = true;
            this.input_text.Name = "input_text";
            this.input_text.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.input_text.Size = new System.Drawing.Size(444, 212);
            this.input_text.TabIndex = 0;
            this.input_text.Text = resources.GetString("input_text.Text");
            // 
            // clearButton
            // 
            this.clearButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.clearButton.Location = new System.Drawing.Point(294, 246);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(75, 23);
            this.clearButton.TabIndex = 4;
            this.clearButton.Text = "clear";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // analyze_button
            // 
            this.analyze_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.analyze_button.Location = new System.Drawing.Point(375, 246);
            this.analyze_button.Name = "analyze_button";
            this.analyze_button.Size = new System.Drawing.Size(75, 23);
            this.analyze_button.TabIndex = 1;
            this.analyze_button.Text = "analyze";
            this.analyze_button.UseVisualStyleBackColor = true;
            this.analyze_button.Click += new System.EventHandler(this.analyze_button_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(6, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(197, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Copy messages from Skype. Paste here.";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.button_analyze_from_file);
            this.tabPage4.Controls.Add(this.label2);
            this.tabPage4.Controls.Add(this.button1);
            this.tabPage4.Controls.Add(this.label_inputsourcefile);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tabPage4.Size = new System.Drawing.Size(456, 275);
            this.tabPage4.TabIndex = 1;
            this.tabPage4.Text = "File";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // label_inputsourcefile
            // 
            this.label_inputsourcefile.AutoSize = true;
            this.label_inputsourcefile.Location = new System.Drawing.Point(6, 86);
            this.label_inputsourcefile.Name = "label_inputsourcefile";
            this.label_inputsourcefile.Size = new System.Drawing.Size(127, 13);
            this.label_inputsourcefile.TabIndex = 8;
            this.label_inputsourcefile.Text = "C:\\sample\\path\\to\\file.txt";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(9, 36);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(111, 47);
            this.button1.TabIndex = 7;
            this.button1.Text = "browse";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel_main
            // 
            this.panel_main.AutoSize = true;
            this.panel_main.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel_main.Controls.Add(this.panel_console);
            this.panel_main.Controls.Add(this.tab_main);
            this.panel_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_main.Location = new System.Drawing.Point(0, 0);
            this.panel_main.Name = "panel_main";
            this.panel_main.Size = new System.Drawing.Size(478, 435);
            this.panel_main.TabIndex = 10;
            // 
            // column_name
            // 
            this.column_name.HeaderText = "Name";
            this.column_name.Name = "column_name";
            this.column_name.ReadOnly = true;
            this.column_name.Width = 60;
            // 
            // column_messages_count
            // 
            dataGridViewCellStyle5.Format = "N2";
            dataGridViewCellStyle5.NullValue = null;
            this.column_messages_count.DefaultCellStyle = dataGridViewCellStyle5;
            this.column_messages_count.HeaderText = "Messages count";
            this.column_messages_count.Name = "column_messages_count";
            this.column_messages_count.ReadOnly = true;
            this.column_messages_count.Width = 101;
            // 
            // column_messages_frequency_chart
            // 
            this.column_messages_frequency_chart.HeaderText = "Messages chart";
            this.column_messages_frequency_chart.Name = "column_messages_frequency_chart";
            this.column_messages_frequency_chart.Text = "show";
            this.column_messages_frequency_chart.UseColumnTextForButtonValue = true;
            this.column_messages_frequency_chart.Width = 79;
            // 
            // column_messages
            // 
            this.column_messages.HeaderText = "Messages";
            this.column_messages.Name = "column_messages";
            this.column_messages.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.column_messages.Text = "messages";
            this.column_messages.UseColumnTextForButtonValue = true;
            this.column_messages.Width = 61;
            // 
            // column_word_frequency
            // 
            this.column_word_frequency.HeaderText = "Word frequency";
            this.column_word_frequency.Name = "column_word_frequency";
            this.column_word_frequency.Text = "word frequency";
            this.column_word_frequency.UseColumnTextForButtonValue = true;
            this.column_word_frequency.Width = 80;
            // 
            // column_emoticon_frequency
            // 
            this.column_emoticon_frequency.HeaderText = "Emoticon";
            this.column_emoticon_frequency.Name = "column_emoticon_frequency";
            this.column_emoticon_frequency.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.column_emoticon_frequency.Text = "(emoticon)";
            this.column_emoticon_frequency.UseColumnTextForButtonValue = true;
            this.column_emoticon_frequency.Width = 57;
            // 
            // column_link_count
            // 
            this.column_link_count.HeaderText = "Links count";
            this.column_link_count.Name = "column_link_count";
            this.column_link_count.ReadOnly = true;
            this.column_link_count.Width = 80;
            // 
            // column_links
            // 
            this.column_links.HeaderText = "Links";
            this.column_links.Name = "column_links";
            this.column_links.Text = "links";
            this.column_links.UseColumnTextForButtonValue = true;
            this.column_links.Width = 38;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(316, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Copy messages from Skype. Paste in a text file. Save. Open here.";
            // 
            // button_analyze_from_file
            // 
            this.button_analyze_from_file.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_analyze_from_file.Location = new System.Drawing.Point(339, 244);
            this.button_analyze_from_file.Name = "button_analyze_from_file";
            this.button_analyze_from_file.Size = new System.Drawing.Size(111, 25);
            this.button_analyze_from_file.TabIndex = 10;
            this.button_analyze_from_file.Text = "analyze";
            this.button_analyze_from_file.UseVisualStyleBackColor = true;
            this.button_analyze_from_file.Click += new System.EventHandler(this.button_analyze_from_file_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(478, 435);
            this.Controls.Add(this.panel_main);
            this.MinimumSize = new System.Drawing.Size(494, 474);
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel_console.ResumeLayout(false);
            this.tab_main.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_usernames)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.panel_main.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel_console;
        private System.Windows.Forms.RichTextBox console;
        private System.Windows.Forms.TabControl tab_main;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label_inputsourcefile;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button analyze_button;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.TextBox input_text;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView dataGridView_usernames;
        private System.Windows.Forms.Panel panel_main;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_messages_count;
        private System.Windows.Forms.DataGridViewButtonColumn column_messages_frequency_chart;
        private System.Windows.Forms.DataGridViewButtonColumn column_messages;
        private System.Windows.Forms.DataGridViewButtonColumn column_word_frequency;
        private System.Windows.Forms.DataGridViewButtonColumn column_emoticon_frequency;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_link_count;
        private System.Windows.Forms.DataGridViewButtonColumn column_links;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_analyze_from_file;
    }
}

