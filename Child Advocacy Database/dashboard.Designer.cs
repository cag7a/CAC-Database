﻿
namespace Child_Advocacy_Database
{
    partial class Dashboard
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dashboard));
            this.AddButton = new System.Windows.Forms.Button();
            this.QueryButton = new System.Windows.Forms.Button();
            this.searchTip = new System.Windows.Forms.ToolTip(this.components);
            this.QuitButton = new System.Windows.Forms.Button();
            this.PleaseTextBox = new System.Windows.Forms.TextBox();
            this.WelcomeTextBox = new System.Windows.Forms.TextBox();
            this.addTip = new System.Windows.Forms.ToolTip(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // AddButton
            // 
            this.AddButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.AddButton.Location = new System.Drawing.Point(361, 398);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(184, 81);
            this.AddButton.TabIndex = 0;
            this.AddButton.Text = "Add New Case File(s)";
            this.addTip.SetToolTip(this.AddButton, "Add a new case file to the database");
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // QueryButton
            // 
            this.QueryButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.QueryButton.Location = new System.Drawing.Point(576, 398);
            this.QueryButton.Name = "QueryButton";
            this.QueryButton.Size = new System.Drawing.Size(183, 81);
            this.QueryButton.TabIndex = 2;
            this.QueryButton.Text = "Search Database";
            this.searchTip.SetToolTip(this.QueryButton, "Search for a case file to view, edit, or delete");
            this.QueryButton.UseVisualStyleBackColor = true;
            this.QueryButton.Click += new System.EventHandler(this.QueryButton_Click);
            // 
            // searchTip
            // 
            this.searchTip.Tag = "";
            this.searchTip.Popup += new System.Windows.Forms.PopupEventHandler(this.toolTip1_Popup);
            // 
            // QuitButton
            // 
            this.QuitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.QuitButton.Location = new System.Drawing.Point(999, 528);
            this.QuitButton.Name = "QuitButton";
            this.QuitButton.Size = new System.Drawing.Size(123, 34);
            this.QuitButton.TabIndex = 3;
            this.QuitButton.Text = "Quit";
            this.searchTip.SetToolTip(this.QuitButton, "Get outta dodge!");
            this.QuitButton.UseVisualStyleBackColor = true;
            this.QuitButton.Click += new System.EventHandler(this.QuitButton_Click);
            // 
            // PleaseTextBox
            // 
            this.PleaseTextBox.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.PleaseTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.PleaseTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.PleaseTextBox.Location = new System.Drawing.Point(470, 346);
            this.PleaseTextBox.Name = "PleaseTextBox";
            this.PleaseTextBox.Size = new System.Drawing.Size(195, 16);
            this.PleaseTextBox.TabIndex = 4;
            this.PleaseTextBox.Text = "Please choose an action below:";
            // 
            // WelcomeTextBox
            // 
            this.WelcomeTextBox.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.WelcomeTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.WelcomeTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.WelcomeTextBox.Location = new System.Drawing.Point(376, 319);
            this.WelcomeTextBox.Multiline = true;
            this.WelcomeTextBox.Name = "WelcomeTextBox";
            this.WelcomeTextBox.Size = new System.Drawing.Size(383, 21);
            this.WelcomeTextBox.TabIndex = 5;
            this.WelcomeTextBox.Text = "Welcome to the CAC File System Manager!";
            this.WelcomeTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.ImageLocation = "";
            this.pictureBox1.Location = new System.Drawing.Point(313, 54);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(508, 259);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1134, 574);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.WelcomeTextBox);
            this.Controls.Add(this.PleaseTextBox);
            this.Controls.Add(this.QuitButton);
            this.Controls.Add(this.QueryButton);
            this.Controls.Add(this.AddButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Dashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CAC File System Dashboard";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Button QueryButton;
        private System.Windows.Forms.ToolTip searchTip;
        private System.Windows.Forms.Button QuitButton;
        private System.Windows.Forms.TextBox PleaseTextBox;
        private System.Windows.Forms.TextBox WelcomeTextBox;
        private System.Windows.Forms.ToolTip addTip;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}