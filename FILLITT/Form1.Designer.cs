﻿
namespace FILLITT
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
            this.lbFirstName = new System.Windows.Forms.ListBox();
            this.search = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tbFirstNameAdd = new System.Windows.Forms.TextBox();
            this.enterPerson = new System.Windows.Forms.Button();
            this.tbLastNameAdd = new System.Windows.Forms.TextBox();
            this.tbBirthdateAdd = new System.Windows.Forms.TextBox();
            this.tbDateOfDeathAdd = new System.Windows.Forms.TextBox();
            this.tbMotherAdd = new System.Windows.Forms.TextBox();
            this.tbFatherAdd = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbLastName = new System.Windows.Forms.ListBox();
            this.lbBirthDate = new System.Windows.Forms.ListBox();
            this.lbYearOfDeath = new System.Windows.Forms.ListBox();
            this.lbMother = new System.Windows.Forms.ListBox();
            this.lbFather = new System.Windows.Forms.ListBox();
            this.listBox7 = new System.Windows.Forms.ListBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.tbFatherUpdate = new System.Windows.Forms.TextBox();
            this.tbMotherUpdate = new System.Windows.Forms.TextBox();
            this.tbDateOfDeathUpdate = new System.Windows.Forms.TextBox();
            this.tbBirthdateUpdate = new System.Windows.Forms.TextBox();
            this.tbLastNameUpdate = new System.Windows.Forms.TextBox();
            this.deletePerson = new System.Windows.Forms.Button();
            this.tbFirstNameUpdate = new System.Windows.Forms.TextBox();
            this.updatePerson = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.lbSiblings = new System.Windows.Forms.ListBox();
            this.lbGrandparents = new System.Windows.Forms.ListBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbFirstName
            // 
            this.lbFirstName.FormattingEnabled = true;
            this.lbFirstName.Location = new System.Drawing.Point(44, 392);
            this.lbFirstName.Name = "lbFirstName";
            this.lbFirstName.Size = new System.Drawing.Size(86, 173);
            this.lbFirstName.TabIndex = 0;
            // 
            // search
            // 
            this.search.Location = new System.Drawing.Point(153, 363);
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(75, 23);
            this.search.TabIndex = 1;
            this.search.Text = "Search";
            this.search.UseVisualStyleBackColor = true;
            this.search.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 365);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(135, 20);
            this.textBox1.TabIndex = 2;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // tbFirstNameAdd
            // 
            this.tbFirstNameAdd.Location = new System.Drawing.Point(86, 159);
            this.tbFirstNameAdd.Name = "tbFirstNameAdd";
            this.tbFirstNameAdd.Size = new System.Drawing.Size(114, 20);
            this.tbFirstNameAdd.TabIndex = 3;
            // 
            // enterPerson
            // 
            this.enterPerson.Location = new System.Drawing.Point(86, 317);
            this.enterPerson.Name = "enterPerson";
            this.enterPerson.Size = new System.Drawing.Size(114, 23);
            this.enterPerson.TabIndex = 5;
            this.enterPerson.Text = "Enter person to DB";
            this.enterPerson.UseVisualStyleBackColor = true;
            this.enterPerson.Click += new System.EventHandler(this.button2_Click);
            // 
            // tbLastNameAdd
            // 
            this.tbLastNameAdd.Location = new System.Drawing.Point(86, 185);
            this.tbLastNameAdd.Name = "tbLastNameAdd";
            this.tbLastNameAdd.Size = new System.Drawing.Size(114, 20);
            this.tbLastNameAdd.TabIndex = 6;
            // 
            // tbBirthdateAdd
            // 
            this.tbBirthdateAdd.Location = new System.Drawing.Point(86, 211);
            this.tbBirthdateAdd.Name = "tbBirthdateAdd";
            this.tbBirthdateAdd.Size = new System.Drawing.Size(114, 20);
            this.tbBirthdateAdd.TabIndex = 7;
            // 
            // tbDateOfDeathAdd
            // 
            this.tbDateOfDeathAdd.Location = new System.Drawing.Point(86, 237);
            this.tbDateOfDeathAdd.Name = "tbDateOfDeathAdd";
            this.tbDateOfDeathAdd.Size = new System.Drawing.Size(114, 20);
            this.tbDateOfDeathAdd.TabIndex = 8;
            // 
            // tbMotherAdd
            // 
            this.tbMotherAdd.Location = new System.Drawing.Point(86, 263);
            this.tbMotherAdd.Name = "tbMotherAdd";
            this.tbMotherAdd.Size = new System.Drawing.Size(114, 20);
            this.tbMotherAdd.TabIndex = 9;
            // 
            // tbFatherAdd
            // 
            this.tbFatherAdd.Location = new System.Drawing.Point(86, 289);
            this.tbFatherAdd.Name = "tbFatherAdd";
            this.tbFatherAdd.Size = new System.Drawing.Size(114, 20);
            this.tbFatherAdd.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 159);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "First name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 188);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Last name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 214);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Birthdate";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 240);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Date of death";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 266);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Mother";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 292);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Father";
            // 
            // lbLastName
            // 
            this.lbLastName.FormattingEnabled = true;
            this.lbLastName.Location = new System.Drawing.Point(136, 392);
            this.lbLastName.Name = "lbLastName";
            this.lbLastName.Size = new System.Drawing.Size(85, 173);
            this.lbLastName.TabIndex = 17;
            // 
            // lbBirthDate
            // 
            this.lbBirthDate.FormattingEnabled = true;
            this.lbBirthDate.Location = new System.Drawing.Point(227, 392);
            this.lbBirthDate.Name = "lbBirthDate";
            this.lbBirthDate.Size = new System.Drawing.Size(85, 173);
            this.lbBirthDate.TabIndex = 18;
            // 
            // lbYearOfDeath
            // 
            this.lbYearOfDeath.FormattingEnabled = true;
            this.lbYearOfDeath.Location = new System.Drawing.Point(318, 392);
            this.lbYearOfDeath.Name = "lbYearOfDeath";
            this.lbYearOfDeath.Size = new System.Drawing.Size(85, 173);
            this.lbYearOfDeath.TabIndex = 19;
            // 
            // lbMother
            // 
            this.lbMother.FormattingEnabled = true;
            this.lbMother.Location = new System.Drawing.Point(409, 392);
            this.lbMother.Name = "lbMother";
            this.lbMother.Size = new System.Drawing.Size(85, 173);
            this.lbMother.TabIndex = 20;
            // 
            // lbFather
            // 
            this.lbFather.FormattingEnabled = true;
            this.lbFather.Location = new System.Drawing.Point(500, 392);
            this.lbFather.Name = "lbFather";
            this.lbFather.Size = new System.Drawing.Size(85, 173);
            this.lbFather.TabIndex = 21;
            // 
            // listBox7
            // 
            this.listBox7.FormattingEnabled = true;
            this.listBox7.Location = new System.Drawing.Point(12, 392);
            this.listBox7.Name = "listBox7";
            this.listBox7.Size = new System.Drawing.Size(26, 173);
            this.listBox7.TabIndex = 22;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(668, 109);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 23;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(598, 277);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 13);
            this.label7.TabIndex = 36;
            this.label7.Text = "Father";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(598, 251);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 13);
            this.label8.TabIndex = 35;
            this.label8.Text = "Mother";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(598, 225);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 13);
            this.label9.TabIndex = 34;
            this.label9.Text = "Date of death";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(598, 199);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(49, 13);
            this.label10.TabIndex = 33;
            this.label10.Text = "Birthdate";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(598, 173);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(56, 13);
            this.label11.TabIndex = 32;
            this.label11.Text = "Last name";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(598, 144);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(55, 13);
            this.label12.TabIndex = 31;
            this.label12.Text = "First name";
            // 
            // tbFatherUpdate
            // 
            this.tbFatherUpdate.Location = new System.Drawing.Point(672, 274);
            this.tbFatherUpdate.Name = "tbFatherUpdate";
            this.tbFatherUpdate.Size = new System.Drawing.Size(114, 20);
            this.tbFatherUpdate.TabIndex = 30;
            // 
            // tbMotherUpdate
            // 
            this.tbMotherUpdate.Location = new System.Drawing.Point(672, 248);
            this.tbMotherUpdate.Name = "tbMotherUpdate";
            this.tbMotherUpdate.Size = new System.Drawing.Size(114, 20);
            this.tbMotherUpdate.TabIndex = 29;
            // 
            // tbDateOfDeathUpdate
            // 
            this.tbDateOfDeathUpdate.Location = new System.Drawing.Point(672, 222);
            this.tbDateOfDeathUpdate.Name = "tbDateOfDeathUpdate";
            this.tbDateOfDeathUpdate.Size = new System.Drawing.Size(114, 20);
            this.tbDateOfDeathUpdate.TabIndex = 28;
            // 
            // tbBirthdateUpdate
            // 
            this.tbBirthdateUpdate.Location = new System.Drawing.Point(672, 196);
            this.tbBirthdateUpdate.Name = "tbBirthdateUpdate";
            this.tbBirthdateUpdate.Size = new System.Drawing.Size(114, 20);
            this.tbBirthdateUpdate.TabIndex = 27;
            // 
            // tbLastNameUpdate
            // 
            this.tbLastNameUpdate.Location = new System.Drawing.Point(672, 170);
            this.tbLastNameUpdate.Name = "tbLastNameUpdate";
            this.tbLastNameUpdate.Size = new System.Drawing.Size(114, 20);
            this.tbLastNameUpdate.TabIndex = 26;
            // 
            // deletePerson
            // 
            this.deletePerson.Location = new System.Drawing.Point(672, 328);
            this.deletePerson.Name = "deletePerson";
            this.deletePerson.Size = new System.Drawing.Size(88, 23);
            this.deletePerson.TabIndex = 25;
            this.deletePerson.Text = "Delete person";
            this.deletePerson.UseVisualStyleBackColor = true;
            this.deletePerson.Click += new System.EventHandler(this.deletePerson_Click);
            // 
            // tbFirstNameUpdate
            // 
            this.tbFirstNameUpdate.Location = new System.Drawing.Point(672, 144);
            this.tbFirstNameUpdate.Name = "tbFirstNameUpdate";
            this.tbFirstNameUpdate.Size = new System.Drawing.Size(114, 20);
            this.tbFirstNameUpdate.TabIndex = 24;
            // 
            // updatePerson
            // 
            this.updatePerson.Location = new System.Drawing.Point(672, 299);
            this.updatePerson.Name = "updatePerson";
            this.updatePerson.Size = new System.Drawing.Size(88, 23);
            this.updatePerson.TabIndex = 37;
            this.updatePerson.Text = "Update person";
            this.updatePerson.UseVisualStyleBackColor = true;
            this.updatePerson.Click += new System.EventHandler(this.updatePerson_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(590, 112);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(72, 13);
            this.label13.TabIndex = 38;
            this.label13.Text = "Select person";
            // 
            // lbSiblings
            // 
            this.lbSiblings.FormattingEnabled = true;
            this.lbSiblings.Location = new System.Drawing.Point(668, 385);
            this.lbSiblings.Name = "lbSiblings";
            this.lbSiblings.Size = new System.Drawing.Size(120, 82);
            this.lbSiblings.TabIndex = 39;
            // 
            // lbGrandparents
            // 
            this.lbGrandparents.FormattingEnabled = true;
            this.lbGrandparents.Location = new System.Drawing.Point(668, 492);
            this.lbGrandparents.Name = "lbGrandparents";
            this.lbGrandparents.Size = new System.Drawing.Size(120, 69);
            this.lbGrandparents.TabIndex = 40;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(669, 365);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(43, 13);
            this.label14.TabIndex = 41;
            this.label14.Text = "Siblings";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(669, 472);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(71, 13);
            this.label15.TabIndex = 42;
            this.label15.Text = "Grandparents";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 576);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.lbGrandparents);
            this.Controls.Add(this.lbSiblings);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.updatePerson);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.tbFatherUpdate);
            this.Controls.Add(this.tbMotherUpdate);
            this.Controls.Add(this.tbDateOfDeathUpdate);
            this.Controls.Add(this.tbBirthdateUpdate);
            this.Controls.Add(this.tbLastNameUpdate);
            this.Controls.Add(this.deletePerson);
            this.Controls.Add(this.tbFirstNameUpdate);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.listBox7);
            this.Controls.Add(this.lbFather);
            this.Controls.Add(this.lbMother);
            this.Controls.Add(this.lbYearOfDeath);
            this.Controls.Add(this.lbBirthDate);
            this.Controls.Add(this.lbLastName);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbFatherAdd);
            this.Controls.Add(this.tbMotherAdd);
            this.Controls.Add(this.tbDateOfDeathAdd);
            this.Controls.Add(this.tbBirthdateAdd);
            this.Controls.Add(this.tbLastNameAdd);
            this.Controls.Add(this.enterPerson);
            this.Controls.Add(this.tbFirstNameAdd);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.search);
            this.Controls.Add(this.lbFirstName);
            this.Name = "Form1";
            this.Text = "First name";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbFirstName;
        private System.Windows.Forms.Button search;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox tbFirstNameAdd;
        private System.Windows.Forms.Button enterPerson;
        private System.Windows.Forms.TextBox tbLastNameAdd;
        private System.Windows.Forms.TextBox tbBirthdateAdd;
        private System.Windows.Forms.TextBox tbDateOfDeathAdd;
        private System.Windows.Forms.TextBox tbMotherAdd;
        private System.Windows.Forms.TextBox tbFatherAdd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListBox lbLastName;
        private System.Windows.Forms.ListBox lbBirthDate;
        private System.Windows.Forms.ListBox lbYearOfDeath;
        private System.Windows.Forms.ListBox lbMother;
        private System.Windows.Forms.ListBox lbFather;
        private System.Windows.Forms.ListBox listBox7;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox tbFatherUpdate;
        private System.Windows.Forms.TextBox tbMotherUpdate;
        private System.Windows.Forms.TextBox tbDateOfDeathUpdate;
        private System.Windows.Forms.TextBox tbBirthdateUpdate;
        private System.Windows.Forms.TextBox tbLastNameUpdate;
        private System.Windows.Forms.Button deletePerson;
        private System.Windows.Forms.TextBox tbFirstNameUpdate;
        private System.Windows.Forms.Button updatePerson;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ListBox lbSiblings;
        private System.Windows.Forms.ListBox lbGrandparents;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
    }
}

