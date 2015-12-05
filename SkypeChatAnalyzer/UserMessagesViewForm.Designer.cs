namespace SkypeChatAnalyzer
{
    partial class UserMessagesViewForm
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
            this.dataGridView_messages = new System.Windows.Forms.DataGridView();
            this.column_datetime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_message = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rangeDateTimeLabel = new System.Windows.Forms.Label();
            this.label_username = new System.Windows.Forms.Label();
            this.label_messageCount = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_messages)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_messages
            // 
            this.dataGridView_messages.AllowUserToAddRows = false;
            this.dataGridView_messages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView_messages.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView_messages.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridView_messages.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_messages.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.column_datetime,
            this.column_message});
            this.dataGridView_messages.GridColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridView_messages.Location = new System.Drawing.Point(5, 66);
            this.dataGridView_messages.Margin = new System.Windows.Forms.Padding(10);
            this.dataGridView_messages.Name = "dataGridView_messages";
            this.dataGridView_messages.Size = new System.Drawing.Size(609, 362);
            this.dataGridView_messages.TabIndex = 0;
            // 
            // column_datetime
            // 
            this.column_datetime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.column_datetime.HeaderText = "DateTime";
            this.column_datetime.Name = "column_datetime";
            this.column_datetime.ReadOnly = true;
            this.column_datetime.Width = 78;
            // 
            // column_message
            // 
            this.column_message.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.column_message.HeaderText = "Message";
            this.column_message.Name = "column_message";
            this.column_message.ReadOnly = true;
            this.column_message.Width = 75;
            // 
            // rangeDateTimeLabel
            // 
            this.rangeDateTimeLabel.AutoSize = true;
            this.rangeDateTimeLabel.Location = new System.Drawing.Point(5, 35);
            this.rangeDateTimeLabel.Name = "rangeDateTimeLabel";
            this.rangeDateTimeLabel.Size = new System.Drawing.Size(260, 13);
            this.rangeDateTimeLabel.TabIndex = 4;
            this.rangeDateTimeLabel.Text = "12/30/2015 12:00:60 PM - 12/30/2015 12:00:60 PM\r\n";
            // 
            // label_username
            // 
            this.label_username.AutoSize = true;
            this.label_username.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_username.Location = new System.Drawing.Point(4, 7);
            this.label_username.Name = "label_username";
            this.label_username.Size = new System.Drawing.Size(118, 20);
            this.label_username.TabIndex = 5;
            this.label_username.Text = "Juan Dela Cruz";
            // 
            // label_messageCount
            // 
            this.label_messageCount.AutoSize = true;
            this.label_messageCount.Location = new System.Drawing.Point(5, 50);
            this.label_messageCount.Name = "label_messageCount";
            this.label_messageCount.Size = new System.Drawing.Size(69, 13);
            this.label_messageCount.TabIndex = 6;
            this.label_messageCount.Text = "22 messages";
            // 
            // UserMessagesViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(619, 439);
            this.Controls.Add(this.label_messageCount);
            this.Controls.Add(this.label_username);
            this.Controls.Add(this.rangeDateTimeLabel);
            this.Controls.Add(this.dataGridView_messages);
            this.Name = "UserMessagesViewForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "Skype User Messages";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_messages)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_messages;
        private System.Windows.Forms.Label rangeDateTimeLabel;
        private System.Windows.Forms.Label label_username;
        private System.Windows.Forms.Label label_messageCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_datetime;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_message;
    }
}