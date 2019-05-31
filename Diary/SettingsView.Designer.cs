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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsView));
            this.comboBoxLanguaje = new System.Windows.Forms.ComboBox();
            this.labelLanguaje = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboBoxLanguaje
            // 
            this.comboBoxLanguaje.FormattingEnabled = true;
            this.comboBoxLanguaje.Items.AddRange(new object[] {
            "English",
            "Spanish"});
            this.comboBoxLanguaje.Location = new System.Drawing.Point(136, 80);
            this.comboBoxLanguaje.Name = "comboBoxLanguaje";
            this.comboBoxLanguaje.Size = new System.Drawing.Size(121, 21);
            this.comboBoxLanguaje.Sorted = true;
            this.comboBoxLanguaje.TabIndex = 4;
            this.comboBoxLanguaje.Text = "English";
            this.comboBoxLanguaje.SelectedIndexChanged += new System.EventHandler(this.comboBoxLanguaje_SelectedIndexChanged);
            // 
            // labelLanguaje
            // 
            this.labelLanguaje.AutoSize = true;
            this.labelLanguaje.Location = new System.Drawing.Point(57, 83);
            this.labelLanguaje.Name = "labelLanguaje";
            this.labelLanguaje.Size = new System.Drawing.Size(54, 13);
            this.labelLanguaje.TabIndex = 5;
            this.labelLanguaje.Text = "Languaje:";
            // 
            // SettingsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.labelLanguaje);
            this.Controls.Add(this.comboBoxLanguaje);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SettingsView";
            this.Text = "Diary - Settings";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SettingsView_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox comboBoxLanguaje;
        private System.Windows.Forms.Label labelLanguaje;
    }
}