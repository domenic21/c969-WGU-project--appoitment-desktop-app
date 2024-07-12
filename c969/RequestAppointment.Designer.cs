namespace c969
{
    partial class RequestAppointment
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
            this.customerLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labeluser = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.localTimelbl = new System.Windows.Forms.Label();
            this.descriptionText = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.addApptBtn = new System.Windows.Forms.Button();
            this.titletextBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tittleLabel = new System.Windows.Forms.Label();
            this.Timelabel = new System.Windows.Forms.TextBox();
            this.timeMinusBtn = new System.Windows.Forms.Button();
            this.timeAddBtn = new System.Windows.Forms.Button();
            this.mainMenubtn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // customerLabel
            // 
            this.customerLabel.AutoSize = true;
            this.customerLabel.Location = new System.Drawing.Point(130, 67);
            this.customerLabel.Name = "customerLabel";
            this.customerLabel.Size = new System.Drawing.Size(92, 25);
            this.customerLabel.TabIndex = 28;
            this.customerLabel.Text = "customer";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 25);
            this.label1.TabIndex = 27;
            this.label1.Text = "Hello User:";
            // 
            // labeluser
            // 
            this.labeluser.AutoSize = true;
            this.labeluser.Location = new System.Drawing.Point(126, 28);
            this.labeluser.Name = "labeluser";
            this.labeluser.Size = new System.Drawing.Size(27, 25);
            this.labeluser.TabIndex = 26;
            this.labeluser.Text = "id";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.monthCalendar1);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.localTimelbl);
            this.groupBox1.Controls.Add(this.descriptionText);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.addApptBtn);
            this.groupBox1.Controls.Add(this.titletextBox);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.tittleLabel);
            this.groupBox1.Controls.Add(this.Timelabel);
            this.groupBox1.Controls.Add(this.timeMinusBtn);
            this.groupBox1.Controls.Add(this.timeAddBtn);
            this.groupBox1.Location = new System.Drawing.Point(17, 108);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(1005, 656);
            this.groupBox1.TabIndex = 29;
            this.groupBox1.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(-643, 324);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(569, 100);
            this.label8.TabIndex = 28;
            this.label8.Text = "Want to request and specific time and date? \r\nPlease click on the button,\r\n then " +
    "pick a date from the calendar a follow to complete the form, \r\nthen proceed to c" +
    "lick on \" create appointment\".\r\n";
            // 
            // localTimelbl
            // 
            this.localTimelbl.AutoSize = true;
            this.localTimelbl.Font = new System.Drawing.Font("Bahnschrift Condensed", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.localTimelbl.ForeColor = System.Drawing.Color.Black;
            this.localTimelbl.Location = new System.Drawing.Point(283, 438);
            this.localTimelbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.localTimelbl.Name = "localTimelbl";
            this.localTimelbl.Size = new System.Drawing.Size(136, 29);
            this.localTimelbl.TabIndex = 37;
            this.localTimelbl.Text = "Your local time:";
            // 
            // descriptionText
            // 
            this.descriptionText.Location = new System.Drawing.Point(8, 151);
            this.descriptionText.Margin = new System.Windows.Forms.Padding(4);
            this.descriptionText.Name = "descriptionText";
            this.descriptionText.Size = new System.Drawing.Size(472, 142);
            this.descriptionText.TabIndex = 21;
            this.descriptionText.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(15, 117);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(158, 30);
            this.label2.TabIndex = 20;
            this.label2.Text = "Description";
            // 
            // addApptBtn
            // 
            this.addApptBtn.BackColor = System.Drawing.SystemColors.Info;
            this.addApptBtn.Location = new System.Drawing.Point(143, 600);
            this.addApptBtn.Margin = new System.Windows.Forms.Padding(4);
            this.addApptBtn.Name = "addApptBtn";
            this.addApptBtn.Size = new System.Drawing.Size(217, 46);
            this.addApptBtn.TabIndex = 18;
            this.addApptBtn.TabStop = false;
            this.addApptBtn.Text = "Create Appoitment";
            this.addApptBtn.UseVisualStyleBackColor = false;
            this.addApptBtn.Click += new System.EventHandler(this.addApptBtn_Click);
            // 
            // titletextBox
            // 
            this.titletextBox.Location = new System.Drawing.Point(154, 50);
            this.titletextBox.Margin = new System.Windows.Forms.Padding(4);
            this.titletextBox.Name = "titletextBox";
            this.titletextBox.Size = new System.Drawing.Size(309, 29);
            this.titletextBox.TabIndex = 10;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Bahnschrift Condensed", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.IndianRed;
            this.label9.Location = new System.Drawing.Point(7, 386);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(206, 29);
            this.label9.TabIndex = 36;
            this.label9.Text = "Appointment in EST TIME";
            // 
            // tittleLabel
            // 
            this.tittleLabel.AutoSize = true;
            this.tittleLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tittleLabel.Location = new System.Drawing.Point(15, 51);
            this.tittleLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.tittleLabel.Name = "tittleLabel";
            this.tittleLabel.Size = new System.Drawing.Size(76, 30);
            this.tittleLabel.TabIndex = 4;
            this.tittleLabel.Text = "Tittle";
            // 
            // Timelabel
            // 
            this.Timelabel.Location = new System.Drawing.Point(8, 433);
            this.Timelabel.Margin = new System.Windows.Forms.Padding(4);
            this.Timelabel.Name = "Timelabel";
            this.Timelabel.Size = new System.Drawing.Size(115, 29);
            this.Timelabel.TabIndex = 35;
            // 
            // timeMinusBtn
            // 
            this.timeMinusBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeMinusBtn.Location = new System.Drawing.Point(213, 433);
            this.timeMinusBtn.Margin = new System.Windows.Forms.Padding(4);
            this.timeMinusBtn.Name = "timeMinusBtn";
            this.timeMinusBtn.Size = new System.Drawing.Size(62, 34);
            this.timeMinusBtn.TabIndex = 33;
            this.timeMinusBtn.Text = "-";
            this.timeMinusBtn.UseVisualStyleBackColor = true;
            this.timeMinusBtn.Click += new System.EventHandler(this.timeMinusBtn_Click);
            // 
            // timeAddBtn
            // 
            this.timeAddBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeAddBtn.Location = new System.Drawing.Point(143, 433);
            this.timeAddBtn.Margin = new System.Windows.Forms.Padding(4);
            this.timeAddBtn.Name = "timeAddBtn";
            this.timeAddBtn.Size = new System.Drawing.Size(62, 34);
            this.timeAddBtn.TabIndex = 34;
            this.timeAddBtn.Text = "+";
            this.timeAddBtn.UseVisualStyleBackColor = true;
            this.timeAddBtn.Click += new System.EventHandler(this.timeAddBtn_Click);
            // 
            // mainMenubtn
            // 
            this.mainMenubtn.Location = new System.Drawing.Point(913, 835);
            this.mainMenubtn.Name = "mainMenubtn";
            this.mainMenubtn.Size = new System.Drawing.Size(146, 48);
            this.mainMenubtn.TabIndex = 30;
            this.mainMenubtn.Text = "Cancel";
            this.mainMenubtn.UseVisualStyleBackColor = true;
            this.mainMenubtn.Click += new System.EventHandler(this.mainMenubtn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 25);
            this.label4.TabIndex = 31;
            this.label4.Text = "CustomerId:";
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(602, 116);
            this.monthCalendar1.Margin = new System.Windows.Forms.Padding(12, 14, 12, 14);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 32;
            // 
            // RequesrAppointment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1071, 895);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.mainMenubtn);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.customerLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labeluser);
            this.Name = "RequesrAppointment";
            this.Text = "RequesrAppointment";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label customerLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labeluser;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label localTimelbl;
        private System.Windows.Forms.RichTextBox descriptionText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button addApptBtn;
        private System.Windows.Forms.TextBox titletextBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label tittleLabel;
        private System.Windows.Forms.TextBox Timelabel;
        private System.Windows.Forms.Button timeMinusBtn;
        private System.Windows.Forms.Button timeAddBtn;
        private System.Windows.Forms.Button mainMenubtn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
    }
}