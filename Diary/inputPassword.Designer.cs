namespace Diary
{
    partial class InputPassword
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InputPassword));
            this.textBoxPasswd = new System.Windows.Forms.TextBox();
            this.buttonUnlock = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.labelPasswd = new System.Windows.Forms.Label();
            this.checkBoxShowPasswd = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // textBoxPasswd
            // 
            this.textBoxPasswd.Location = new System.Drawing.Point(127, 22);
            this.textBoxPasswd.Name = "textBoxPasswd";
            this.textBoxPasswd.PasswordChar = '*';
            this.textBoxPasswd.Size = new System.Drawing.Size(206, 20);
            this.textBoxPasswd.TabIndex = 0;
            // 
            // buttonUnlock
            // 
            this.buttonUnlock.Location = new System.Drawing.Point(258, 64);
            this.buttonUnlock.Name = "buttonUnlock";
            this.buttonUnlock.Size = new System.Drawing.Size(75, 23);
            this.buttonUnlock.TabIndex = 1;
            this.buttonUnlock.Text = "Unlock";
            this.buttonUnlock.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(166, 64);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // labelPasswd
            // 
            this.labelPasswd.AutoSize = true;
            this.labelPasswd.Location = new System.Drawing.Point(15, 21);
            this.labelPasswd.Name = "labelPasswd";
            this.labelPasswd.Size = new System.Drawing.Size(80, 13);
            this.labelPasswd.TabIndex = 3;
            this.labelPasswd.Text = "Enter password";
            // 
            // checkBoxShowPasswd
            // 
            this.checkBoxShowPasswd.AutoSize = true;
            this.checkBoxShowPasswd.Location = new System.Drawing.Point(18, 64);
            this.checkBoxShowPasswd.Name = "checkBoxShowPasswd";
            this.checkBoxShowPasswd.Size = new System.Drawing.Size(101, 17);
            this.checkBoxShowPasswd.TabIndex = 4;
            this.checkBoxShowPasswd.Text = "Show password";
            this.checkBoxShowPasswd.UseVisualStyleBackColor = true;
            this.checkBoxShowPasswd.CheckedChanged += new System.EventHandler(this.checkBoxShowPasswd_CheckedChanged);
            // 
            // InputPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(345, 99);
            this.Controls.Add(this.checkBoxShowPasswd);
            this.Controls.Add(this.labelPasswd);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonUnlock);
            this.Controls.Add(this.textBoxPasswd);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(361, 138);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(361, 138);
            this.Name = "InputPassword";
            this.Text = "Password";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.InputPassword_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label labelPasswd;
        private System.Windows.Forms.CheckBox checkBoxShowPasswd;
        public System.Windows.Forms.TextBox textBoxPasswd;
        public System.Windows.Forms.Button buttonUnlock;
    }
}