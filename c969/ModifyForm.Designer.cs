﻿namespace c969
{
    partial class ModifyForm
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
            this.cancelBtn = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.deleteApptBtn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.userIdLabel = new System.Windows.Forms.Label();
            this.localTimelbl = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Timelabel = new System.Windows.Forms.TextBox();
            this.timeAddBtn = new System.Windows.Forms.Button();
            this.timeMinusBtn = new System.Windows.Forms.Button();
            this.changeApptBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.apptOrderLabel = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.modifyApptBtn = new System.Windows.Forms.Button();
            this.tittleLabel = new System.Windows.Forms.Label();
            this.customerLabel = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(425, 730);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(161, 44);
            this.cancelBtn.TabIndex = 2;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(19, 54);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(352, 29);
            this.textBox1.TabIndex = 5;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(19, 140);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(480, 164);
            this.richTextBox1.TabIndex = 6;
            this.richTextBox1.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(280, 448);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 25);
            this.label1.TabIndex = 7;
            this.label1.Visible = false;
            // 
            // deleteApptBtn
            // 
            this.deleteApptBtn.Location = new System.Drawing.Point(219, 730);
            this.deleteApptBtn.Name = "deleteApptBtn";
            this.deleteApptBtn.Size = new System.Drawing.Size(201, 44);
            this.deleteApptBtn.TabIndex = 8;
            this.deleteApptBtn.Text = "Delete Appointment";
            this.deleteApptBtn.UseVisualStyleBackColor = true;
            this.deleteApptBtn.Click += new System.EventHandler(this.deleteApptBtn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.customerLabel);
            this.groupBox1.Controls.Add(this.userIdLabel);
            this.groupBox1.Controls.Add(this.localTimelbl);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.Timelabel);
            this.groupBox1.Controls.Add(this.timeAddBtn);
            this.groupBox1.Controls.Add(this.timeMinusBtn);
            this.groupBox1.Controls.Add(this.changeApptBtn);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.richTextBox1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.apptOrderLabel);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.modifyApptBtn);
            this.groupBox1.Controls.Add(this.tittleLabel);
            this.groupBox1.Location = new System.Drawing.Point(12, 14);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(572, 710);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            // 
            // userIdLabel
            // 
            this.userIdLabel.AutoSize = true;
            this.userIdLabel.Font = new System.Drawing.Font("Bahnschrift Condensed", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userIdLabel.ForeColor = System.Drawing.Color.IndianRed;
            this.userIdLabel.Location = new System.Drawing.Point(384, 0);
            this.userIdLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.userIdLabel.Name = "userIdLabel";
            this.userIdLabel.Size = new System.Drawing.Size(68, 29);
            this.userIdLabel.TabIndex = 32;
            this.userIdLabel.Text = "UserId:";
            // 
            // localTimelbl
            // 
            this.localTimelbl.AutoSize = true;
            this.localTimelbl.Font = new System.Drawing.Font("Bahnschrift Condensed", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.localTimelbl.ForeColor = System.Drawing.Color.Black;
            this.localTimelbl.Location = new System.Drawing.Point(307, 484);
            this.localTimelbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.localTimelbl.Name = "localTimelbl";
            this.localTimelbl.Size = new System.Drawing.Size(136, 29);
            this.localTimelbl.TabIndex = 31;
            this.localTimelbl.Text = "Your local time:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Bahnschrift Condensed", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.IndianRed;
            this.label4.Location = new System.Drawing.Point(4, 448);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(206, 29);
            this.label4.TabIndex = 30;
            this.label4.Text = "Appointment in EST TIME";
            // 
            // Timelabel
            // 
            this.Timelabel.Location = new System.Drawing.Point(4, 484);
            this.Timelabel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Timelabel.Name = "Timelabel";
            this.Timelabel.Size = new System.Drawing.Size(115, 29);
            this.Timelabel.TabIndex = 29;
            // 
            // timeAddBtn
            // 
            this.timeAddBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeAddBtn.Location = new System.Drawing.Point(139, 483);
            this.timeAddBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.timeAddBtn.Name = "timeAddBtn";
            this.timeAddBtn.Size = new System.Drawing.Size(62, 34);
            this.timeAddBtn.TabIndex = 28;
            this.timeAddBtn.Text = "+";
            this.timeAddBtn.UseVisualStyleBackColor = true;
            this.timeAddBtn.Visible = false;
            this.timeAddBtn.Click += new System.EventHandler(this.timeAddBtn_Click);
            // 
            // timeMinusBtn
            // 
            this.timeMinusBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeMinusBtn.Location = new System.Drawing.Point(206, 483);
            this.timeMinusBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.timeMinusBtn.Name = "timeMinusBtn";
            this.timeMinusBtn.Size = new System.Drawing.Size(62, 34);
            this.timeMinusBtn.TabIndex = 27;
            this.timeMinusBtn.Text = "-";
            this.timeMinusBtn.UseVisualStyleBackColor = true;
            this.timeMinusBtn.Click += new System.EventHandler(this.timeMinusBtn_Click);
            // 
            // changeApptBtn
            // 
            this.changeApptBtn.Location = new System.Drawing.Point(85, 388);
            this.changeApptBtn.Name = "changeApptBtn";
            this.changeApptBtn.Size = new System.Drawing.Size(314, 44);
            this.changeApptBtn.TabIndex = 25;
            this.changeApptBtn.Text = "Change Appointment Time";
            this.changeApptBtn.UseVisualStyleBackColor = true;
            this.changeApptBtn.Click += new System.EventHandler(this.changeApptBtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Bahnschrift Condensed", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(285, 546);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(167, 23);
            this.label3.TabIndex = 23;
            this.label3.Text = "Appoitment confirmation";
            // 
            // apptOrderLabel
            // 
            this.apptOrderLabel.Location = new System.Drawing.Point(447, 542);
            this.apptOrderLabel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.apptOrderLabel.Name = "apptOrderLabel";
            this.apptOrderLabel.Size = new System.Drawing.Size(115, 29);
            this.apptOrderLabel.TabIndex = 22;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(21, 90);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(158, 30);
            this.label2.TabIndex = 20;
            this.label2.Text = "Description";
            // 
            // modifyApptBtn
            // 
            this.modifyApptBtn.BackColor = System.Drawing.SystemColors.Info;
            this.modifyApptBtn.Location = new System.Drawing.Point(94, 610);
            this.modifyApptBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.modifyApptBtn.Name = "modifyApptBtn";
            this.modifyApptBtn.Size = new System.Drawing.Size(345, 46);
            this.modifyApptBtn.TabIndex = 18;
            this.modifyApptBtn.TabStop = false;
            this.modifyApptBtn.Text = "Modify Appoitment";
            this.modifyApptBtn.UseVisualStyleBackColor = false;
            this.modifyApptBtn.Click += new System.EventHandler(this.modifyApptBtn_Click);
            // 
            // tittleLabel
            // 
            this.tittleLabel.AutoSize = true;
            this.tittleLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tittleLabel.Location = new System.Drawing.Point(15, 26);
            this.tittleLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.tittleLabel.Name = "tittleLabel";
            this.tittleLabel.Size = new System.Drawing.Size(76, 30);
            this.tittleLabel.TabIndex = 4;
            this.tittleLabel.Text = "Tittle";
            // 
            // customerLabel
            // 
            this.customerLabel.AutoSize = true;
            this.customerLabel.Font = new System.Drawing.Font("Bahnschrift Condensed", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customerLabel.ForeColor = System.Drawing.Color.IndianRed;
            this.customerLabel.Location = new System.Drawing.Point(382, 29);
            this.customerLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.customerLabel.Name = "customerLabel";
            this.customerLabel.Size = new System.Drawing.Size(108, 29);
            this.customerLabel.TabIndex = 33;
            this.customerLabel.Text = "CustomerId:";
            // 
            // ModifyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(601, 806);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.deleteApptBtn);
            this.Controls.Add(this.cancelBtn);
            this.Name = "ModifyForm";
            this.Text = "ModifyForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button deleteApptBtn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox apptOrderLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button modifyApptBtn;
        private System.Windows.Forms.Label tittleLabel;
        private System.Windows.Forms.Button changeApptBtn;
        private System.Windows.Forms.Button timeMinusBtn;
        private System.Windows.Forms.Button timeAddBtn;
        private System.Windows.Forms.TextBox Timelabel;
        private System.Windows.Forms.Label localTimelbl;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label userIdLabel;
        private System.Windows.Forms.Label customerLabel;
    }
}