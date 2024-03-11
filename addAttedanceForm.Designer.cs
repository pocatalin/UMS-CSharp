namespace PIProject
{
    partial class addAttedanceForm
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
            this.metroComboBoxWeek = new MetroFramework.Controls.MetroComboBox();
            this.metroComboBoxCourse = new MetroFramework.Controls.MetroComboBox();
            this.mtbStudents = new MetroFramework.Controls.MetroTextBox();
            this.mbAdd = new MetroFramework.Controls.MetroButton();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.SuspendLayout();
            // 
            // metroComboBoxWeek
            // 
            this.metroComboBoxWeek.FormattingEnabled = true;
            this.metroComboBoxWeek.ItemHeight = 24;
            this.metroComboBoxWeek.Location = new System.Drawing.Point(9, 57);
            this.metroComboBoxWeek.Name = "metroComboBoxWeek";
            this.metroComboBoxWeek.Size = new System.Drawing.Size(70, 30);
            this.metroComboBoxWeek.TabIndex = 0;
            this.metroComboBoxWeek.UseSelectable = true;
            // 
            // metroComboBoxCourse
            // 
            this.metroComboBoxCourse.FormattingEnabled = true;
            this.metroComboBoxCourse.ItemHeight = 24;
            this.metroComboBoxCourse.Location = new System.Drawing.Point(85, 57);
            this.metroComboBoxCourse.Name = "metroComboBoxCourse";
            this.metroComboBoxCourse.Size = new System.Drawing.Size(121, 30);
            this.metroComboBoxCourse.TabIndex = 1;
            this.metroComboBoxCourse.UseSelectable = true;
            // 
            // mtbStudents
            // 
            // 
            // 
            // 
            this.mtbStudents.CustomButton.Image = null;
            this.mtbStudents.CustomButton.Location = new System.Drawing.Point(237, 2);
            this.mtbStudents.CustomButton.Name = "";
            this.mtbStudents.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.mtbStudents.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.mtbStudents.CustomButton.TabIndex = 1;
            this.mtbStudents.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.mtbStudents.CustomButton.UseSelectable = true;
            this.mtbStudents.CustomButton.Visible = false;
            this.mtbStudents.Lines = new string[0];
            this.mtbStudents.Location = new System.Drawing.Point(212, 57);
            this.mtbStudents.MaxLength = 32767;
            this.mtbStudents.Name = "mtbStudents";
            this.mtbStudents.PasswordChar = '\0';
            this.mtbStudents.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.mtbStudents.SelectedText = "";
            this.mtbStudents.SelectionLength = 0;
            this.mtbStudents.SelectionStart = 0;
            this.mtbStudents.ShortcutsEnabled = true;
            this.mtbStudents.Size = new System.Drawing.Size(265, 30);
            this.mtbStudents.TabIndex = 2;
            this.mtbStudents.UseSelectable = true;
            this.mtbStudents.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.mtbStudents.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // mbAdd
            // 
            this.mbAdd.Location = new System.Drawing.Point(483, 57);
            this.mbAdd.Name = "mbAdd";
            this.mbAdd.Size = new System.Drawing.Size(75, 30);
            this.mbAdd.TabIndex = 3;
            this.mbAdd.Text = "Add";
            this.mbAdd.UseSelectable = true;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(9, 25);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(44, 20);
            this.metroLabel1.TabIndex = 4;
            this.metroLabel1.Text = "Week";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(85, 25);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(94, 20);
            this.metroLabel2.TabIndex = 5;
            this.metroLabel2.Text = "Select Course";
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(212, 25);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(122, 20);
            this.metroLabel3.TabIndex = 6;
            this.metroLabel3.Text = "Enter Students IDs";
            // 
            // addAttedanceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(595, 110);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.mbAdd);
            this.Controls.Add(this.mtbStudents);
            this.Controls.Add(this.metroComboBoxCourse);
            this.Controls.Add(this.metroComboBoxWeek);
            this.Name = "addAttedanceForm";
            this.Style = MetroFramework.MetroColorStyle.Green;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroComboBox metroComboBoxWeek;
        private MetroFramework.Controls.MetroComboBox metroComboBoxCourse;
        private MetroFramework.Controls.MetroTextBox mtbStudents;
        private MetroFramework.Controls.MetroButton mbAdd;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel3;
    }
}