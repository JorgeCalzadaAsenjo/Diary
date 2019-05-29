namespace Diary
{
    partial class SettingsView
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.comboBoxLanguaje = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Control;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Enabled = false;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(184, 207);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(416, 249);
            this.textBox1.TabIndex = 2;
            this.textBox1.Text = "We are working to improve this functionality and eliminate annoying errors. For t" +
    "he next update this functionality will be ready. Sorry for the inconvenience.";
            this.textBox1.Visible = false;
            // 
            // comboBoxLanguaje
            // 
            this.comboBoxLanguaje.FormattingEnabled = true;
            this.comboBoxLanguaje.Items.AddRange(new object[] {
            "Spanish",
            "English"});
            this.comboBoxLanguaje.Location = new System.Drawing.Point(136, 80);
            this.comboBoxLanguaje.Name = "comboBoxLanguaje";
            this.comboBoxLanguaje.Size = new System.Drawing.Size(121, 21);
            this.comboBoxLanguaje.TabIndex = 4;
            this.comboBoxLanguaje.Text = "English";
            this.comboBoxLanguaje.SelectedIndexChanged += new System.EventHandler(this.comboBoxLanguaje_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(57, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Languaje";
            // 
            // SettingsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxLanguaje);
            this.Controls.Add(this.textBox1);
            this.Name = "SettingsView";
            this.Text = "Diary - Settings";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SettingsView_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox comboBoxLanguaje;
        private System.Windows.Forms.Label label1;
    }
}