namespace Diary
{
    partial class NoteView
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
            this.titleNote = new System.Windows.Forms.TextBox();
            this.contentTextNote = new System.Windows.Forms.TextBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.cancelNote = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // titleNote
            // 
            this.titleNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleNote.Location = new System.Drawing.Point(66, 37);
            this.titleNote.Name = "titleNote";
            this.titleNote.Size = new System.Drawing.Size(647, 29);
            this.titleNote.TabIndex = 0;
            this.titleNote.Enter += new System.EventHandler(this.titleNote_Enter);
            this.titleNote.Leave += new System.EventHandler(this.titleNote_Leave);
            // 
            // contentTextNote
            // 
            this.contentTextNote.Location = new System.Drawing.Point(66, 95);
            this.contentTextNote.Multiline = true;
            this.contentTextNote.Name = "contentTextNote";
            this.contentTextNote.Size = new System.Drawing.Size(647, 249);
            this.contentTextNote.TabIndex = 1;
            this.contentTextNote.Enter += new System.EventHandler(this.contentTextNote_Enter);
            this.contentTextNote.Leave += new System.EventHandler(this.contentTextNote_Leave);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(94, 398);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 2;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // cancelNote
            // 
            this.cancelNote.Location = new System.Drawing.Point(600, 398);
            this.cancelNote.Name = "cancelNote";
            this.cancelNote.Size = new System.Drawing.Size(75, 23);
            this.cancelNote.TabIndex = 3;
            this.cancelNote.Text = "Cancel";
            this.cancelNote.UseVisualStyleBackColor = true;
            this.cancelNote.Click += new System.EventHandler(this.cancelNote_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(63, 361);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Created: 03/05/2019 16:15";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label3.Location = new System.Drawing.Point(559, 361);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(154, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Last modify: 23/12/2019 12:15";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(337, 398);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Lock";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // NoteView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cancelNote);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.contentTextNote);
            this.Controls.Add(this.titleNote);
            this.Name = "NoteView";
            this.Text = "noteView";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.noteView_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.noteView_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox titleNote;
        private System.Windows.Forms.TextBox contentTextNote;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button cancelNote;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
    }
}