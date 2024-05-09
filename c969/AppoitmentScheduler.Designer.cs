namespace c969
{
    partial class AppoitmentScheduler
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
            this.weekCheckBox = new System.Windows.Forms.CheckBox();
            this.Month = new System.Windows.Forms.CheckBox();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.exitBtn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.timetextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.datetextbox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.apptOrderLabel = new System.Windows.Forms.TextBox();
            this.descriptionText = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.addApptBtn = new System.Windows.Forms.Button();
            this.titletextBox = new System.Windows.Forms.TextBox();
            this.tittleLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.localTimelabel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.estTimelabel = new System.Windows.Forms.Label();
            this.textBoxcount = new System.Windows.Forms.TextBox();
            this.comboBoxappt = new System.Windows.Forms.ComboBox();
            this.logout = new System.Windows.Forms.Button();
            this.labelappt = new System.Windows.Forms.Label();
            this.labeluser = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.mainMenubtn = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // weekCheckBox
            // 
            this.weekCheckBox.AutoSize = true;
            this.weekCheckBox.Location = new System.Drawing.Point(126, 136);
            this.weekCheckBox.Margin = new System.Windows.Forms.Padding(4);
            this.weekCheckBox.Name = "weekCheckBox";
            this.weekCheckBox.Size = new System.Drawing.Size(90, 29);
            this.weekCheckBox.TabIndex = 1;
            this.weekCheckBox.Text = "Week";
            this.weekCheckBox.UseVisualStyleBackColor = true;
            this.weekCheckBox.CheckedChanged += new System.EventHandler(this.weekCheckBox_CheckedChanged);
            // 
            // Month
            // 
            this.Month.AutoSize = true;
            this.Month.Location = new System.Drawing.Point(25, 136);
            this.Month.Margin = new System.Windows.Forms.Padding(4);
            this.Month.Name = "Month";
            this.Month.Size = new System.Drawing.Size(93, 29);
            this.Month.TabIndex = 2;
            this.Month.Text = "Month";
            this.Month.UseVisualStyleBackColor = true;
            this.Month.CheckedChanged += new System.EventHandler(this.Month_CheckedChanged);
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(25, 176);
            this.monthCalendar1.Margin = new System.Windows.Forms.Padding(12, 14, 12, 14);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 3;
            this.monthCalendar1.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateChanged);
            // 
            // exitBtn
            // 
            this.exitBtn.Location = new System.Drawing.Point(1376, 1);
            this.exitBtn.Margin = new System.Windows.Forms.Padding(4);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(103, 48);
            this.exitBtn.TabIndex = 7;
            this.exitBtn.Text = "Exit";
            this.exitBtn.UseVisualStyleBackColor = true;
            this.exitBtn.Click += new System.EventHandler(this.exitBtn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.timetextBox);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.datetextbox);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.apptOrderLabel);
            this.groupBox1.Controls.Add(this.descriptionText);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.addApptBtn);
            this.groupBox1.Controls.Add(this.titletextBox);
            this.groupBox1.Controls.Add(this.tittleLabel);
            this.groupBox1.Location = new System.Drawing.Point(949, 69);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(520, 551);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            // 
            // timetextBox
            // 
            this.timetextBox.Location = new System.Drawing.Point(362, 318);
            this.timetextBox.Margin = new System.Windows.Forms.Padding(4);
            this.timetextBox.Name = "timetextBox";
            this.timetextBox.Size = new System.Drawing.Size(137, 29);
            this.timetextBox.TabIndex = 27;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.142858F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(241, 322);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(116, 23);
            this.label7.TabIndex = 26;
            this.label7.Text = "Local Time";
            // 
            // datetextbox
            // 
            this.datetextbox.Location = new System.Drawing.Point(80, 320);
            this.datetextbox.Margin = new System.Windows.Forms.Padding(4);
            this.datetextbox.Name = "datetextbox";
            this.datetextbox.Size = new System.Drawing.Size(153, 29);
            this.datetextbox.TabIndex = 25;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.142858F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(16, 324);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 23);
            this.label5.TabIndex = 24;
            this.label5.Text = "Date";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Bahnschrift Condensed", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(159, 373);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(167, 23);
            this.label3.TabIndex = 23;
            this.label3.Text = "Appoitment confirmation";
            // 
            // apptOrderLabel
            // 
            this.apptOrderLabel.Location = new System.Drawing.Point(348, 369);
            this.apptOrderLabel.Margin = new System.Windows.Forms.Padding(4);
            this.apptOrderLabel.Name = "apptOrderLabel";
            this.apptOrderLabel.Size = new System.Drawing.Size(115, 29);
            this.apptOrderLabel.TabIndex = 22;
            // 
            // descriptionText
            // 
            this.descriptionText.Location = new System.Drawing.Point(12, 153);
            this.descriptionText.Margin = new System.Windows.Forms.Padding(4);
            this.descriptionText.Name = "descriptionText";
            this.descriptionText.Size = new System.Drawing.Size(472, 142);
            this.descriptionText.TabIndex = 21;
            this.descriptionText.Text = "What is this appoitment for?";
            this.descriptionText.TextChanged += new System.EventHandler(this.descriptionText_TextChanged);
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
            this.addApptBtn.Location = new System.Drawing.Point(140, 428);
            this.addApptBtn.Margin = new System.Windows.Forms.Padding(4);
            this.addApptBtn.Name = "addApptBtn";
            this.addApptBtn.Size = new System.Drawing.Size(217, 47);
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
            this.titletextBox.Text = "What type of appoitment?";
            this.titletextBox.TextChanged += new System.EventHandler(this.titletextBox_TextChanged);
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
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(521, 58);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(206, 25);
            this.label4.TabIndex = 13;
            this.label4.Text = "Available Appoitments";
            // 
            // localTimelabel
            // 
            this.localTimelabel.AutoSize = true;
            this.localTimelabel.Location = new System.Drawing.Point(21, 519);
            this.localTimelabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.localTimelabel.Name = "localTimelabel";
            this.localTimelabel.Size = new System.Drawing.Size(0, 25);
            this.localTimelabel.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.IndianRed;
            this.label6.Location = new System.Drawing.Point(16, 638);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(556, 25);
            this.label6.TabIndex = 16;
            this.label6.Text = " Business hours of 9:00 a.m. to 5:00 p.m., Monday–Friday, EST";
            // 
            // estTimelabel
            // 
            this.estTimelabel.AutoSize = true;
            this.estTimelabel.Location = new System.Drawing.Point(21, 586);
            this.estTimelabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.estTimelabel.Name = "estTimelabel";
            this.estTimelabel.Size = new System.Drawing.Size(0, 25);
            this.estTimelabel.TabIndex = 17;
            // 
            // textBoxcount
            // 
            this.textBoxcount.Location = new System.Drawing.Point(512, 86);
            this.textBoxcount.Name = "textBoxcount";
            this.textBoxcount.Size = new System.Drawing.Size(429, 29);
            this.textBoxcount.TabIndex = 18;
            // 
            // comboBoxappt
            // 
            this.comboBoxappt.FormattingEnabled = true;
            this.comboBoxappt.Location = new System.Drawing.Point(512, 201);
            this.comboBoxappt.Name = "comboBoxappt";
            this.comboBoxappt.Size = new System.Drawing.Size(415, 32);
            this.comboBoxappt.TabIndex = 19;
            this.comboBoxappt.SelectedIndexChanged += new System.EventHandler(this.comboBoxappt_SelectedIndexChanged);
            // 
            // logout
            // 
            this.logout.Location = new System.Drawing.Point(1300, 626);
            this.logout.Margin = new System.Windows.Forms.Padding(4);
            this.logout.Name = "logout";
            this.logout.Size = new System.Drawing.Size(103, 48);
            this.logout.TabIndex = 20;
            this.logout.Text = "Log Out";
            this.logout.UseVisualStyleBackColor = true;
            this.logout.Click += new System.EventHandler(this.logout_Click);
            // 
            // labelappt
            // 
            this.labelappt.AutoSize = true;
            this.labelappt.Location = new System.Drawing.Point(512, 157);
            this.labelappt.Name = "labelappt";
            this.labelappt.Size = new System.Drawing.Size(0, 25);
            this.labelappt.TabIndex = 21;
            // 
            // labeluser
            // 
            this.labeluser.AutoSize = true;
            this.labeluser.Location = new System.Drawing.Point(169, 13);
            this.labeluser.Name = "labeluser";
            this.labeluser.Size = new System.Drawing.Size(27, 25);
            this.labeluser.TabIndex = 22;
            this.labeluser.Text = "id";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 25);
            this.label1.TabIndex = 23;
            this.label1.Text = "Hello User:";
            // 
            // mainMenubtn
            // 
            this.mainMenubtn.Location = new System.Drawing.Point(1147, 626);
            this.mainMenubtn.Name = "mainMenubtn";
            this.mainMenubtn.Size = new System.Drawing.Size(146, 48);
            this.mainMenubtn.TabIndex = 24;
            this.mainMenubtn.Text = "Main Page";
            this.mainMenubtn.UseVisualStyleBackColor = true;
            this.mainMenubtn.Click += new System.EventHandler(this.mainMenubtn_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(121, 13);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(27, 25);
            this.label8.TabIndex = 25;
            this.label8.Text = "id";
            // 
            // AppoitmentScheduler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1492, 675);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.mainMenubtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labeluser);
            this.Controls.Add(this.labelappt);
            this.Controls.Add(this.logout);
            this.Controls.Add(this.comboBoxappt);
            this.Controls.Add(this.textBoxcount);
            this.Controls.Add(this.estTimelabel);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.localTimelabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.exitBtn);
            this.Controls.Add(this.monthCalendar1);
            this.Controls.Add(this.Month);
            this.Controls.Add(this.weekCheckBox);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "AppoitmentScheduler";
            this.Text = "AppoitmentScheduler";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckBox weekCheckBox;
        private System.Windows.Forms.CheckBox Month;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.Button exitBtn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button addApptBtn;
        private System.Windows.Forms.TextBox titletextBox;
        private System.Windows.Forms.Label tittleLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox descriptionText;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox apptOrderLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label localTimelabel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label estTimelabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox timetextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox datetextbox;
        private System.Windows.Forms.TextBox textBoxcount;
        private System.Windows.Forms.ComboBox comboBoxappt;
        private System.Windows.Forms.Button logout;
        private System.Windows.Forms.Label labelappt;
        private System.Windows.Forms.Label labeluser;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button mainMenubtn;
        private System.Windows.Forms.Label label8;
    }
}