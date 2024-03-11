namespace PIProject
{
    partial class dataProfForm
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
            this.metroTabControlData = new MetroFramework.Controls.MetroTabControl();
            this.mtpSecurity = new MetroFramework.Controls.MetroTabPage();
            this.mtbUnlock = new MetroFramework.Controls.MetroButton();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.mtbPassword = new MetroFramework.Controls.MetroTextBox();
            this.mtpPersonal = new MetroFramework.Controls.MetroTabPage();
            this.flowLayoutPanelData = new System.Windows.Forms.FlowLayoutPanel();
            this.mtpSecret = new MetroFramework.Controls.MetroTabPage();
            this.metroTabControlData.SuspendLayout();
            this.mtpSecurity.SuspendLayout();
            this.mtpPersonal.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroTabControlData
            // 
            this.metroTabControlData.Controls.Add(this.mtpSecurity);
            this.metroTabControlData.Controls.Add(this.mtpPersonal);
            this.metroTabControlData.Controls.Add(this.mtpSecret);
            this.metroTabControlData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroTabControlData.FontSize = MetroFramework.MetroTabControlSize.Small;
            this.metroTabControlData.FontWeight = MetroFramework.MetroTabControlWeight.Bold;
            this.metroTabControlData.Location = new System.Drawing.Point(20, 60);
            this.metroTabControlData.Name = "metroTabControlData";
            this.metroTabControlData.SelectedIndex = 2;
            this.metroTabControlData.Size = new System.Drawing.Size(760, 370);
            this.metroTabControlData.Style = MetroFramework.MetroColorStyle.Green;
            this.metroTabControlData.TabIndex = 0;
            this.metroTabControlData.UseSelectable = true;
            this.metroTabControlData.UseStyleColors = true;
            // 
            // mtpSecurity
            // 
            this.mtpSecurity.Controls.Add(this.mtbUnlock);
            this.mtpSecurity.Controls.Add(this.metroLabel1);
            this.mtpSecurity.Controls.Add(this.mtbPassword);
            this.mtpSecurity.HorizontalScrollbarBarColor = true;
            this.mtpSecurity.HorizontalScrollbarHighlightOnWheel = false;
            this.mtpSecurity.HorizontalScrollbarSize = 10;
            this.mtpSecurity.Location = new System.Drawing.Point(4, 34);
            this.mtpSecurity.Name = "mtpSecurity";
            this.mtpSecurity.Size = new System.Drawing.Size(752, 332);
            this.mtpSecurity.Style = MetroFramework.MetroColorStyle.Green;
            this.mtpSecurity.TabIndex = 0;
            this.mtpSecurity.Text = "Security";
            this.mtpSecurity.VerticalScrollbarBarColor = true;
            this.mtpSecurity.VerticalScrollbarHighlightOnWheel = false;
            this.mtpSecurity.VerticalScrollbarSize = 10;
            // 
            // mtbUnlock
            // 
            this.mtbUnlock.Location = new System.Drawing.Point(238, 109);
            this.mtbUnlock.Name = "mtbUnlock";
            this.mtbUnlock.Size = new System.Drawing.Size(227, 23);
            this.mtbUnlock.TabIndex = 4;
            this.mtbUnlock.Text = "Unlock";
            this.mtbUnlock.UseSelectable = true;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(285, 57);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(131, 20);
            this.metroLabel1.TabIndex = 3;
            this.metroLabel1.Text = "Enter The Password";
            // 
            // mtbPassword
            // 
            // 
            // 
            // 
            this.mtbPassword.CustomButton.Image = null;
            this.mtbPassword.CustomButton.Location = new System.Drawing.Point(205, 1);
            this.mtbPassword.CustomButton.Name = "";
            this.mtbPassword.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.mtbPassword.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.mtbPassword.CustomButton.TabIndex = 1;
            this.mtbPassword.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.mtbPassword.CustomButton.UseSelectable = true;
            this.mtbPassword.CustomButton.Visible = false;
            this.mtbPassword.Lines = new string[0];
            this.mtbPassword.Location = new System.Drawing.Point(238, 80);
            this.mtbPassword.MaxLength = 32767;
            this.mtbPassword.Name = "mtbPassword";
            this.mtbPassword.PasswordChar = '\0';
            this.mtbPassword.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.mtbPassword.SelectedText = "";
            this.mtbPassword.SelectionLength = 0;
            this.mtbPassword.SelectionStart = 0;
            this.mtbPassword.ShortcutsEnabled = true;
            this.mtbPassword.Size = new System.Drawing.Size(227, 23);
            this.mtbPassword.TabIndex = 2;
            this.mtbPassword.UseSelectable = true;
            this.mtbPassword.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.mtbPassword.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // mtpPersonal
            // 
            this.mtpPersonal.Controls.Add(this.flowLayoutPanelData);
            this.mtpPersonal.HorizontalScrollbarBarColor = true;
            this.mtpPersonal.HorizontalScrollbarHighlightOnWheel = false;
            this.mtpPersonal.HorizontalScrollbarSize = 10;
            this.mtpPersonal.Location = new System.Drawing.Point(4, 34);
            this.mtpPersonal.Name = "mtpPersonal";
            this.mtpPersonal.Size = new System.Drawing.Size(752, 332);
            this.mtpPersonal.TabIndex = 1;
            this.mtpPersonal.Text = "Personal Data";
            this.mtpPersonal.VerticalScrollbarBarColor = true;
            this.mtpPersonal.VerticalScrollbarHighlightOnWheel = false;
            this.mtpPersonal.VerticalScrollbarSize = 10;
            // 
            // flowLayoutPanelData
            // 
            this.flowLayoutPanelData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelData.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanelData.Name = "flowLayoutPanelData";
            this.flowLayoutPanelData.Size = new System.Drawing.Size(752, 332);
            this.flowLayoutPanelData.TabIndex = 2;
            // 
            // mtpSecret
            // 
            this.mtpSecret.HorizontalScrollbarBarColor = true;
            this.mtpSecret.HorizontalScrollbarHighlightOnWheel = false;
            this.mtpSecret.HorizontalScrollbarSize = 10;
            this.mtpSecret.Location = new System.Drawing.Point(4, 34);
            this.mtpSecret.Name = "mtpSecret";
            this.mtpSecret.Size = new System.Drawing.Size(752, 332);
            this.mtpSecret.TabIndex = 2;
            this.mtpSecret.Text = "Secret";
            this.mtpSecret.VerticalScrollbarBarColor = true;
            this.mtpSecret.VerticalScrollbarHighlightOnWheel = false;
            this.mtpSecret.VerticalScrollbarSize = 10;
            // 
            // dataProfForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.metroTabControlData);
            this.Name = "dataProfForm";
            this.Style = MetroFramework.MetroColorStyle.Green;
            this.metroTabControlData.ResumeLayout(false);
            this.mtpSecurity.ResumeLayout(false);
            this.mtpSecurity.PerformLayout();
            this.mtpPersonal.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroTabControl metroTabControlData;
        private MetroFramework.Controls.MetroTabPage mtpSecurity;
        private MetroFramework.Controls.MetroTabPage mtpPersonal;
        private MetroFramework.Controls.MetroButton mtbUnlock;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroTextBox mtbPassword;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelData;
        private MetroFramework.Controls.MetroTabPage mtpSecret;
    }
}