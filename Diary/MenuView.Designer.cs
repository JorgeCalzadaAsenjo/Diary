namespace Diary
{
    partial class MenuView
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuView));
            this.contactButton = new System.Windows.Forms.Button();
            this.calendarButton = new System.Windows.Forms.Button();
            this.notesBbutton = new System.Windows.Forms.Button();
            this.remindersButton = new System.Windows.Forms.Button();
            this.settingsButton = new System.Windows.Forms.Button();
            this.helpButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // contactButton
            // 
            resources.ApplyResources(this.contactButton, "contactButton");
            this.contactButton.Name = "contactButton";
            this.contactButton.UseVisualStyleBackColor = true;
            this.contactButton.Click += new System.EventHandler(this.contactButton_Click);
            // 
            // calendarButton
            // 
            resources.ApplyResources(this.calendarButton, "calendarButton");
            this.calendarButton.Name = "calendarButton";
            this.calendarButton.UseVisualStyleBackColor = true;
            this.calendarButton.Click += new System.EventHandler(this.calendarButton_Click);
            // 
            // notesBbutton
            // 
            resources.ApplyResources(this.notesBbutton, "notesBbutton");
            this.notesBbutton.Name = "notesBbutton";
            this.notesBbutton.UseVisualStyleBackColor = true;
            this.notesBbutton.Click += new System.EventHandler(this.notesBbutton_Click);
            // 
            // remindersButton
            // 
            resources.ApplyResources(this.remindersButton, "remindersButton");
            this.remindersButton.Name = "remindersButton";
            this.remindersButton.UseVisualStyleBackColor = true;
            this.remindersButton.Click += new System.EventHandler(this.remindersButton_Click);
            // 
            // settingsButton
            // 
            resources.ApplyResources(this.settingsButton, "settingsButton");
            this.settingsButton.Name = "settingsButton";
            this.settingsButton.UseVisualStyleBackColor = true;
            this.settingsButton.Click += new System.EventHandler(this.settingsButton_Click);
            // 
            // helpButton
            // 
            resources.ApplyResources(this.helpButton, "helpButton");
            this.helpButton.Name = "helpButton";
            this.helpButton.UseVisualStyleBackColor = true;
            this.helpButton.Click += new System.EventHandler(this.helpButton_Click);
            // 
            // MenuView
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.helpButton);
            this.Controls.Add(this.settingsButton);
            this.Controls.Add(this.remindersButton);
            this.Controls.Add(this.notesBbutton);
            this.Controls.Add(this.calendarButton);
            this.Controls.Add(this.contactButton);
            this.MaximizeBox = false;
            this.Name = "MenuView";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MenuView_FormClosed);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button contactButton;
        private System.Windows.Forms.Button calendarButton;
        private System.Windows.Forms.Button notesBbutton;
        private System.Windows.Forms.Button remindersButton;
        private System.Windows.Forms.Button settingsButton;
        private System.Windows.Forms.Button helpButton;
    }
}

