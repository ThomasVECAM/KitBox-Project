﻿namespace Interface_5
{
    partial class UserControl5
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.orderNbLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.postalCode = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.adress = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tvaPannel = new System.Windows.Forms.Panel();
            this.tvaNumber = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.city = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.name = new System.Windows.Forms.TextBox();
            this.checkBoxCompany = new System.Windows.Forms.CheckBox();
            this.checkBoxParticular = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.phoneNumber = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.email = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.confirmButton = new System.Windows.Forms.Button();
            this.userControlPannel = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.tvaPannel.SuspendLayout();
            this.userControlPannel.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(183, 56);
            this.label1.TabIndex = 0;
            this.label1.Text = "Order :";
            // 
            // orderNbLabel
            // 
            this.orderNbLabel.AutoSize = true;
            this.orderNbLabel.Font = new System.Drawing.Font("Century Gothic", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.orderNbLabel.Location = new System.Drawing.Point(185, 9);
            this.orderNbLabel.Name = "orderNbLabel";
            this.orderNbLabel.Size = new System.Drawing.Size(174, 56);
            this.orderNbLabel.TabIndex = 1;
            this.orderNbLabel.Text = " #1245";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.postalCode);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.adress);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.tvaPannel);
            this.panel1.Controls.Add(this.city);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.name);
            this.panel1.Controls.Add(this.checkBoxCompany);
            this.panel1.Controls.Add(this.checkBoxParticular);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.phoneNumber);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.email);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(13, 113);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(805, 404);
            this.panel1.TabIndex = 26;
            // 
            // postalCode
            // 
            this.postalCode.BackColor = System.Drawing.Color.White;
            this.postalCode.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.postalCode.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.postalCode.ForeColor = System.Drawing.Color.Red;
            this.postalCode.Location = new System.Drawing.Point(562, 175);
            this.postalCode.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.postalCode.Multiline = true;
            this.postalCode.Name = "postalCode";
            this.postalCode.Size = new System.Drawing.Size(224, 43);
            this.postalCode.TabIndex = 40;
            this.postalCode.TextChanged += new System.EventHandler(this.postalCode_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(364, 175);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(192, 34);
            this.label11.TabIndex = 39;
            this.label11.Text = "Postal code :";
            // 
            // adress
            // 
            this.adress.BackColor = System.Drawing.Color.White;
            this.adress.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.adress.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.adress.ForeColor = System.Drawing.Color.Red;
            this.adress.Location = new System.Drawing.Point(562, 22);
            this.adress.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.adress.Multiline = true;
            this.adress.Name = "adress";
            this.adress.Size = new System.Drawing.Size(224, 40);
            this.adress.TabIndex = 38;
            this.adress.TextChanged += new System.EventHandler(this.adress_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(438, 22);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(118, 34);
            this.label10.TabIndex = 37;
            this.label10.Text = "Adress :";
            // 
            // tvaPannel
            // 
            this.tvaPannel.Controls.Add(this.tvaNumber);
            this.tvaPannel.Controls.Add(this.label7);
            this.tvaPannel.Location = new System.Drawing.Point(21, 321);
            this.tvaPannel.Name = "tvaPannel";
            this.tvaPannel.Size = new System.Drawing.Size(440, 71);
            this.tvaPannel.TabIndex = 36;
            // 
            // tvaNumber
            // 
            this.tvaNumber.BackColor = System.Drawing.Color.White;
            this.tvaNumber.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tvaNumber.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tvaNumber.ForeColor = System.Drawing.Color.Red;
            this.tvaNumber.Location = new System.Drawing.Point(205, 6);
            this.tvaNumber.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tvaNumber.Multiline = true;
            this.tvaNumber.Name = "tvaNumber";
            this.tvaNumber.Size = new System.Drawing.Size(192, 45);
            this.tvaNumber.TabIndex = 33;
            this.tvaNumber.TextChanged += new System.EventHandler(this.tvaNumber_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(3, 6);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(196, 34);
            this.label7.TabIndex = 32;
            this.label7.Text = "TVA number :";
            // 
            // city
            // 
            this.city.BackColor = System.Drawing.Color.White;
            this.city.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.city.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.city.ForeColor = System.Drawing.Color.Red;
            this.city.Location = new System.Drawing.Point(562, 102);
            this.city.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.city.Multiline = true;
            this.city.Name = "city";
            this.city.Size = new System.Drawing.Size(224, 41);
            this.city.TabIndex = 35;
            this.city.TextChanged += new System.EventHandler(this.city_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(467, 104);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(85, 34);
            this.label8.TabIndex = 34;
            this.label8.Text = "City :";
            // 
            // name
            // 
            this.name.BackColor = System.Drawing.Color.White;
            this.name.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.name.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.name.ForeColor = System.Drawing.Color.Red;
            this.name.Location = new System.Drawing.Point(129, 22);
            this.name.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.name.Multiline = true;
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(224, 40);
            this.name.TabIndex = 22;
            this.name.TextChanged += new System.EventHandler(this.lastname_TextChanged);
            // 
            // checkBoxCompany
            // 
            this.checkBoxCompany.AutoSize = true;
            this.checkBoxCompany.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxCompany.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxCompany.ForeColor = System.Drawing.Color.White;
            this.checkBoxCompany.Location = new System.Drawing.Point(311, 260);
            this.checkBoxCompany.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBoxCompany.Name = "checkBoxCompany";
            this.checkBoxCompany.Size = new System.Drawing.Size(175, 34);
            this.checkBoxCompany.TabIndex = 28;
            this.checkBoxCompany.Text = "A company";
            this.checkBoxCompany.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxCompany.UseVisualStyleBackColor = true;
            this.checkBoxCompany.CheckedChanged += new System.EventHandler(this.checkBoxCompany_CheckedChanged);
            // 
            // checkBoxParticular
            // 
            this.checkBoxParticular.AutoSize = true;
            this.checkBoxParticular.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxParticular.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxParticular.ForeColor = System.Drawing.Color.White;
            this.checkBoxParticular.Location = new System.Drawing.Point(129, 260);
            this.checkBoxParticular.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBoxParticular.Name = "checkBoxParticular";
            this.checkBoxParticular.Size = new System.Drawing.Size(172, 34);
            this.checkBoxParticular.TabIndex = 27;
            this.checkBoxParticular.Text = "A particular";
            this.checkBoxParticular.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxParticular.UseVisualStyleBackColor = true;
            this.checkBoxParticular.CheckedChanged += new System.EventHandler(this.checkBoxParticular_CheckedChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(16, 264);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(80, 30);
            this.label9.TabIndex = 27;
            this.label9.Text = "I am :";
            // 
            // phoneNumber
            // 
            this.phoneNumber.BackColor = System.Drawing.Color.White;
            this.phoneNumber.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.phoneNumber.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phoneNumber.ForeColor = System.Drawing.Color.Red;
            this.phoneNumber.Location = new System.Drawing.Point(129, 175);
            this.phoneNumber.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.phoneNumber.Multiline = true;
            this.phoneNumber.Name = "phoneNumber";
            this.phoneNumber.Size = new System.Drawing.Size(224, 43);
            this.phoneNumber.TabIndex = 31;
            this.phoneNumber.TextChanged += new System.EventHandler(this.phoneNumber_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(17, 175);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(117, 34);
            this.label6.TabIndex = 30;
            this.label6.Text = "Phone :";
            // 
            // email
            // 
            this.email.BackColor = System.Drawing.Color.White;
            this.email.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.email.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.email.ForeColor = System.Drawing.Color.Red;
            this.email.Location = new System.Drawing.Point(129, 102);
            this.email.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.email.Multiline = true;
            this.email.Name = "email";
            this.email.Size = new System.Drawing.Size(224, 41);
            this.email.TabIndex = 29;
            this.email.TextChanged += new System.EventHandler(this.email_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(15, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 34);
            this.label4.TabIndex = 28;
            this.label4.Text = "Email : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(12, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 34);
            this.label3.TabIndex = 27;
            this.label3.Text = "Name :";
            // 
            // confirmButton
            // 
            this.confirmButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(120)))), ((int)(((byte)(138)))));
            this.confirmButton.FlatAppearance.BorderSize = 0;
            this.confirmButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.confirmButton.ForeColor = System.Drawing.Color.White;
            this.confirmButton.Location = new System.Drawing.Point(700, 522);
            this.confirmButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.confirmButton.Name = "confirmButton";
            this.confirmButton.Size = new System.Drawing.Size(178, 60);
            this.confirmButton.TabIndex = 27;
            this.confirmButton.Text = "Confirm order";
            this.confirmButton.UseVisualStyleBackColor = false;
            this.confirmButton.Click += new System.EventHandler(this.confirmButton_Click);
            // 
            // userControlPannel
            // 
            this.userControlPannel.Controls.Add(this.label1);
            this.userControlPannel.Controls.Add(this.confirmButton);
            this.userControlPannel.Controls.Add(this.orderNbLabel);
            this.userControlPannel.Controls.Add(this.panel1);
            this.userControlPannel.Location = new System.Drawing.Point(3, 4);
            this.userControlPannel.Name = "userControlPannel";
            this.userControlPannel.Size = new System.Drawing.Size(897, 593);
            this.userControlPannel.TabIndex = 29;
            // 
            // UserControl5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(81)))), ((int)(((byte)(84)))), ((int)(((byte)(91)))));
            this.Controls.Add(this.userControlPannel);
            this.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.ForeColor = System.Drawing.Color.White;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "UserControl5";
            this.Size = new System.Drawing.Size(900, 600);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tvaPannel.ResumeLayout(false);
            this.tvaPannel.PerformLayout();
            this.userControlPannel.ResumeLayout(false);
            this.userControlPannel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label orderNbLabel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox email;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox name;
        private System.Windows.Forms.TextBox tvaNumber;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox phoneNumber;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel tvaPannel;
        private System.Windows.Forms.CheckBox checkBoxCompany;
        private System.Windows.Forms.CheckBox checkBoxParticular;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button confirmButton;
        private System.Windows.Forms.TextBox postalCode;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox adress;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox city;
        private System.Windows.Forms.Panel userControlPannel;
    }
}
