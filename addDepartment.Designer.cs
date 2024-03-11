namespace PIProject
{
    partial class addDepartment
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
            this.mtbName = new MetroFramework.Controls.MetroTextBox();
            this.mcbFaculty = new MetroFramework.Controls.MetroComboBox();
            this.mbAdd = new MetroFramework.Controls.MetroButton();
            this.metroLabel10 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.SuspendLayout();
            // 
            // mtbName
            // 
            // 
            // 
            // 
            this.mtbName.CustomButton.Image = null;
            this.mtbName.CustomButton.Location = new System.Drawing.Point(116, 1);
            this.mtbName.CustomButton.Name = "";
            this.mtbName.CustomButton.Size = new System.Drawing.Size(33, 33);
            this.mtbName.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.mtbName.CustomButton.TabIndex = 1;
            this.mtbName.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.mtbName.CustomButton.UseSelectable = true;
            this.mtbName.CustomButton.Visible = false;
            this.mtbName.Lines = new string[] {
        "Department Of"};
            this.mtbName.Location = new System.Drawing.Point(23, 63);
            this.mtbName.MaxLength = 32767;
            this.mtbName.Name = "mtbName";
            this.mtbName.PasswordChar = '\0';
            this.mtbName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.mtbName.SelectedText = "";
            this.mtbName.SelectionLength = 0;
            this.mtbName.SelectionStart = 0;
            this.mtbName.ShortcutsEnabled = true;
            this.mtbName.Size = new System.Drawing.Size(150, 35);
            this.mtbName.Style = MetroFramework.MetroColorStyle.Silver;
            this.mtbName.TabIndex = 0;
            this.mtbName.Text = "Department Of";
            this.mtbName.UseSelectable = true;
            this.mtbName.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.mtbName.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // mcbFaculty
            // 
            this.mcbFaculty.FormattingEnabled = true;
            this.mcbFaculty.ItemHeight = 24;
            this.mcbFaculty.Location = new System.Drawing.Point(179, 63);
            this.mcbFaculty.Name = "mcbFaculty";
            this.mcbFaculty.Size = new System.Drawing.Size(121, 30);
            this.mcbFaculty.Style = MetroFramework.MetroColorStyle.Silver;
            this.mcbFaculty.TabIndex = 1;
            this.mcbFaculty.UseSelectable = true;
            // 
            // mbAdd
            // 
            this.mbAdd.Location = new System.Drawing.Point(306, 63);
            this.mbAdd.Name = "mbAdd";
            this.mbAdd.Size = new System.Drawing.Size(75, 35);
            this.mbAdd.Style = MetroFramework.MetroColorStyle.Silver;
            this.mbAdd.TabIndex = 2;
            this.mbAdd.Text = "Add";
            this.mbAdd.UseSelectable = true;
            // 
            // metroLabel10
            // 
            this.metroLabel10.AutoSize = true;
            this.metroLabel10.Location = new System.Drawing.Point(23, 40);
            this.metroLabel10.Name = "metroLabel10";
            this.metroLabel10.Size = new System.Drawing.Size(126, 20);
            this.metroLabel10.Style = MetroFramework.MetroColorStyle.Silver;
            this.metroLabel10.TabIndex = 39;
            this.metroLabel10.Text = "Department Name";
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(179, 40);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(51, 20);
            this.metroLabel1.Style = MetroFramework.MetroColorStyle.Silver;
            this.metroLabel1.TabIndex = 40;
            this.metroLabel1.Text = "Faculty";
            // 
            // addDepartment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 125);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.metroLabel10);
            this.Controls.Add(this.mbAdd);
            this.Controls.Add(this.mcbFaculty);
            this.Controls.Add(this.mtbName);
            this.Name = "addDepartment";
            this.Style = MetroFramework.MetroColorStyle.Silver;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroTextBox mtbName;
        private MetroFramework.Controls.MetroComboBox mcbFaculty;
        private MetroFramework.Controls.MetroButton mbAdd;
        private MetroFramework.Controls.MetroLabel metroLabel10;
        private MetroFramework.Controls.MetroLabel metroLabel1;
    }
}