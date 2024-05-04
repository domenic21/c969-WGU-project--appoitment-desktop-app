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
            this.dayCheckBox = new System.Windows.Forms.CheckBox();
            this.weekCheckBox = new System.Windows.Forms.CheckBox();
            this.Month = new System.Windows.Forms.CheckBox();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.selectBtn = new System.Windows.Forms.Button();
            this.exitBtn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.apptOrderLabel = new System.Windows.Forms.TextBox();
            this.descriptionText = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.addApptBtn = new System.Windows.Forms.Button();
            this.cancelApptBtn = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.NametextBox = new System.Windows.Forms.TextBox();
            this.tittleLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.localTimelabel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.estTimelabel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.starttextBox = new System.Windows.Forms.TextBox();
            this.endTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.datagrid2 = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datagrid2)).BeginInit();
            this.SuspendLayout();
            // 
            // dayCheckBox
            // 
            this.dayCheckBox.AutoSize = true;
            this.dayCheckBox.Location = new System.Drawing.Point(18, 39);
            this.dayCheckBox.Name = "dayCheckBox";
            this.dayCheckBox.Size = new System.Drawing.Size(54, 20);
            this.dayCheckBox.TabIndex = 0;
            this.dayCheckBox.Text = "Day";
            this.dayCheckBox.UseVisualStyleBackColor = true;
            // 
            // weekCheckBox
            // 
            this.weekCheckBox.AutoSize = true;
            this.weekCheckBox.Location = new System.Drawing.Point(18, 65);
            this.weekCheckBox.Name = "weekCheckBox";
            this.weekCheckBox.Size = new System.Drawing.Size(65, 20);
            this.weekCheckBox.TabIndex = 1;
            this.weekCheckBox.Text = "Week";
            this.weekCheckBox.UseVisualStyleBackColor = true;
            // 
            // Month
            // 
            this.Month.AutoSize = true;
            this.Month.Location = new System.Drawing.Point(18, 91);
            this.Month.Name = "Month";
            this.Month.Size = new System.Drawing.Size(65, 20);
            this.Month.TabIndex = 2;
            this.Month.Text = "Month";
            this.Month.UseVisualStyleBackColor = true;
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(18, 117);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 3;
            this.monthCalendar1.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateChanged);
            // 
            // selectBtn
            // 
            this.selectBtn.Location = new System.Drawing.Point(514, 391);
            this.selectBtn.Name = "selectBtn";
            this.selectBtn.Size = new System.Drawing.Size(170, 23);
            this.selectBtn.TabIndex = 4;
            this.selectBtn.Text = "Select  appointment";
            this.selectBtn.UseVisualStyleBackColor = true;
            // 
            // exitBtn
            // 
            this.exitBtn.Location = new System.Drawing.Point(1004, 12);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(75, 23);
            this.exitBtn.TabIndex = 7;
            this.exitBtn.Text = "Exit";
            this.exitBtn.UseVisualStyleBackColor = true;
            this.exitBtn.Click += new System.EventHandler(this.exitBtn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.endTextBox);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.starttextBox);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.apptOrderLabel);
            this.groupBox1.Controls.Add(this.descriptionText);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.addApptBtn);
            this.groupBox1.Controls.Add(this.cancelApptBtn);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.NametextBox);
            this.groupBox1.Controls.Add(this.tittleLabel);
            this.groupBox1.Location = new System.Drawing.Point(735, 58);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(344, 356);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Bahnschrift Condensed", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 250);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 16);
            this.label3.TabIndex = 23;
            this.label3.Text = "Appoitment confirmation";
            // 
            // apptOrderLabel
            // 
            this.apptOrderLabel.Location = new System.Drawing.Point(130, 244);
            this.apptOrderLabel.Name = "apptOrderLabel";
            this.apptOrderLabel.Size = new System.Drawing.Size(208, 22);
            this.apptOrderLabel.TabIndex = 22;
            // 
            // descriptionText
            // 
            this.descriptionText.Location = new System.Drawing.Point(6, 102);
            this.descriptionText.Name = "descriptionText";
            this.descriptionText.Size = new System.Drawing.Size(344, 96);
            this.descriptionText.TabIndex = 21;
            this.descriptionText.Text = "What is this appoitment for?";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(11, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 21);
            this.label2.TabIndex = 20;
            this.label2.Text = "Description";
            // 
            // addApptBtn
            // 
            this.addApptBtn.BackColor = System.Drawing.SystemColors.Info;
            this.addApptBtn.Location = new System.Drawing.Point(79, 285);
            this.addApptBtn.Name = "addApptBtn";
            this.addApptBtn.Size = new System.Drawing.Size(158, 23);
            this.addApptBtn.TabIndex = 18;
            this.addApptBtn.TabStop = false;
            this.addApptBtn.Text = "Create Appoitment";
            this.addApptBtn.UseVisualStyleBackColor = false;
            // 
            // cancelApptBtn
            // 
            this.cancelApptBtn.Location = new System.Drawing.Point(263, 333);
            this.cancelApptBtn.Name = "cancelApptBtn";
            this.cancelApptBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelApptBtn.TabIndex = 18;
            this.cancelApptBtn.Text = "Cancel";
            this.cancelApptBtn.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(127, 337);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(127, 16);
            this.label10.TabIndex = 19;
            this.label10.Text = "Cancel Appoitment?";
            // 
            // NametextBox
            // 
            this.NametextBox.Location = new System.Drawing.Point(112, 33);
            this.NametextBox.Name = "NametextBox";
            this.NametextBox.Size = new System.Drawing.Size(226, 22);
            this.NametextBox.TabIndex = 10;
            this.NametextBox.Text = "What type of appoitment?";
            // 
            // tittleLabel
            // 
            this.tittleLabel.AutoSize = true;
            this.tittleLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tittleLabel.Location = new System.Drawing.Point(11, 34);
            this.tittleLabel.Name = "tittleLabel";
            this.tittleLabel.Size = new System.Drawing.Size(54, 21);
            this.tittleLabel.TabIndex = 4;
            this.tittleLabel.Text = "Tittle";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(316, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(142, 16);
            this.label4.TabIndex = 13;
            this.label4.Text = "Available Appoitments";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // localTimelabel
            // 
            this.localTimelabel.AutoSize = true;
            this.localTimelabel.Location = new System.Drawing.Point(15, 346);
            this.localTimelabel.Name = "localTimelabel";
            this.localTimelabel.Size = new System.Drawing.Size(0, 11);
            this.localTimelabel.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.IndianRed;
            this.label6.Location = new System.Drawing.Point(12, 425);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(370, 16);
            this.label6.TabIndex = 16;
            this.label6.Text = " Business hours of 9:00 a.m. to 5:00 p.m., Monday–Friday, EST";
            // 
            // estTimelabel
            // 
            this.estTimelabel.AutoSize = true;
            this.estTimelabel.Location = new System.Drawing.Point(15, 391);
            this.estTimelabel.Name = "estTimelabel";
            this.estTimelabel.Size = new System.Drawing.Size(0, 11);
            this.estTimelabel.TabIndex = 17;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 212);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 21);
            this.label5.TabIndex = 24;
            this.label5.Text = "Start";
            // 
            // starttextBox
            // 
            this.starttextBox.Location = new System.Drawing.Point(71, 211);
            this.starttextBox.Name = "starttextBox";
            this.starttextBox.Size = new System.Drawing.Size(74, 22);
            this.starttextBox.TabIndex = 25;
            // 
            // endTextBox
            // 
            this.endTextBox.Location = new System.Drawing.Point(254, 210);
            this.endTextBox.Name = "endTextBox";
            this.endTextBox.Size = new System.Drawing.Size(74, 22);
            this.endTextBox.TabIndex = 27;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(204, 211);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 21);
            this.label7.TabIndex = 26;
            this.label7.Text = "End";
            // 
            // datagrid2
            // 
            this.datagrid2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagrid2.Location = new System.Drawing.Point(319, 58);
            this.datagrid2.Name = "datagrid2";
            this.datagrid2.RowHeadersWidth = 51;
            this.datagrid2.RowTemplate.Height = 24;
            this.datagrid2.Size = new System.Drawing.Size(365, 320);
            this.datagrid2.TabIndex = 19;
            // 
            // AppoitmentScheduler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1091, 450);
            this.Controls.Add(this.datagrid2);
            this.Controls.Add(this.estTimelabel);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.localTimelabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.exitBtn);
            this.Controls.Add(this.selectBtn);
            this.Controls.Add(this.monthCalendar1);
            this.Controls.Add(this.Month);
            this.Controls.Add(this.weekCheckBox);
            this.Controls.Add(this.dayCheckBox);
            this.Name = "AppoitmentScheduler";
            this.Text = "AppoitmentScheduler";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datagrid2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox dayCheckBox;
        private System.Windows.Forms.CheckBox weekCheckBox;
        private System.Windows.Forms.CheckBox Month;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.Button selectBtn;
        private System.Windows.Forms.Button exitBtn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button addApptBtn;
        private System.Windows.Forms.Button cancelApptBtn;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox NametextBox;
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
        private System.Windows.Forms.TextBox endTextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox starttextBox;
        private System.Windows.Forms.DataGridView datagrid2;
    }
}