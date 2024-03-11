namespace PIProject
{
    partial class editRowForm
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
            this.fLPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.mtbSave = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // fLPanel
            // 
            this.fLPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fLPanel.Location = new System.Drawing.Point(20, 60);
            this.fLPanel.Name = "fLPanel";
            this.fLPanel.Size = new System.Drawing.Size(994, 370);
            this.fLPanel.TabIndex = 0;
            // 
            // mtbSave
            // 
            this.mtbSave.Location = new System.Drawing.Point(939, 31);
            this.mtbSave.Name = "mtbSave";
            this.mtbSave.Size = new System.Drawing.Size(75, 23);
            this.mtbSave.TabIndex = 1;
            this.mtbSave.Text = "Save";
            this.mtbSave.UseSelectable = true;
            // 
            // editRowForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1034, 450);
            this.Controls.Add(this.mtbSave);
            this.Controls.Add(this.fLPanel);
            this.Name = "editRowForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel fLPanel;
        private MetroFramework.Controls.MetroButton mtbSave;
    }
}