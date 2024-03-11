namespace PIProject
{
    partial class addStudentCourse
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
            this.mcbDepartment = new MetroFramework.Controls.MetroComboBox();
            this.mcbCourses = new MetroFramework.Controls.MetroComboBox();
            this.mtbStudents = new MetroFramework.Controls.MetroTextBox();
            this.mbAdd = new MetroFramework.Controls.MetroButton();
            this.metroLabel10 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.SuspendLayout();
            // 
            // mcbDepartment
            // 
            this.mcbDepartment.FormattingEnabled = true;
            this.mcbDepartment.ItemHeight = 24;
            this.mcbDepartment.Location = new System.Drawing.Point(23, 63);
            this.mcbDepartment.Name = "mcbDepartment";
            this.mcbDepartment.Size = new System.Drawing.Size(121, 30);
            this.mcbDepartment.Style = MetroFramework.MetroColorStyle.Silver;
            this.mcbDepartment.TabIndex = 0;
            this.mcbDepartment.UseSelectable = true;
            // 
            // mcbCourses
            // 
            this.mcbCourses.FormattingEnabled = true;
            this.mcbCourses.ItemHeight = 24;
            this.mcbCourses.Location = new System.Drawing.Point(150, 63);
            this.mcbCourses.Name = "mcbCourses";
            this.mcbCourses.Size = new System.Drawing.Size(121, 30);
            this.mcbCourses.Style = MetroFramework.MetroColorStyle.Silver;
            this.mcbCourses.TabIndex = 1;
            this.mcbCourses.UseSelectable = true;
            // 
            // mtbStudents
            // 
            // 
            // 
            // 
            this.mtbStudents.CustomButton.Image = null;
            this.mtbStudents.CustomButton.Location = new System.Drawing.Point(166, 1);
            this.mtbStudents.CustomButton.Name = "";
            this.mtbStudents.CustomButton.Size = new System.Drawing.Size(33, 33);
            this.mtbStudents.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.mtbStudents.CustomButton.TabIndex = 1;
            this.mtbStudents.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.mtbStudents.CustomButton.UseSelectable = true;
            this.mtbStudents.CustomButton.Visible = false;
            this.mtbStudents.Lines = new string[0];
            this.mtbStudents.Location = new System.Drawing.Point(277, 63);
            this.mtbStudents.MaxLength = 32767;
            this.mtbStudents.Name = "mtbStudents";
            this.mtbStudents.PasswordChar = '\0';
            this.mtbStudents.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.mtbStudents.SelectedText = "";
            this.mtbStudents.SelectionLength = 0;
            this.mtbStudents.SelectionStart = 0;
            this.mtbStudents.ShortcutsEnabled = true;
            this.mtbStudents.Size = new System.Drawing.Size(200, 35);
            this.mtbStudents.Style = MetroFramework.MetroColorStyle.Silver;
            this.mtbStudents.TabIndex = 2;
            this.mtbStudents.UseSelectable = true;
            this.mtbStudents.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.mtbStudents.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // mbAdd
            // 
            this.mbAdd.Location = new System.Drawing.Point(483, 63);
            this.mbAdd.Name = "mbAdd";
            this.mbAdd.Size = new System.Drawing.Size(75, 35);
            this.mbAdd.Style = MetroFramework.MetroColorStyle.Silver;
            this.mbAdd.TabIndex = 3;
            this.mbAdd.Text = "Add";
            this.mbAdd.UseSelectable = true;
            // 
            // metroLabel10
            // 
            this.metroLabel10.AutoSize = true;
            this.metroLabel10.Location = new System.Drawing.Point(23, 40);
            this.metroLabel10.Name = "metroLabel10";
            this.metroLabel10.Size = new System.Drawing.Size(84, 20);
            this.metroLabel10.Style = MetroFramework.MetroColorStyle.Silver;
            this.metroLabel10.TabIndex = 38;
            this.metroLabel10.Text = "Department";
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(150, 40);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(53, 20);
            this.metroLabel1.Style = MetroFramework.MetroColorStyle.Silver;
            this.metroLabel1.TabIndex = 39;
            this.metroLabel1.Text = "Course";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(277, 40);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(75, 20);
            this.metroLabel2.Style = MetroFramework.MetroColorStyle.Silver;
            this.metroLabel2.TabIndex = 40;
            this.metroLabel2.Text = "StudentIDs";
            // 
            // addStudentCourse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 125);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.metroLabel10);
            this.Controls.Add(this.mbAdd);
            this.Controls.Add(this.mtbStudents);
            this.Controls.Add(this.mcbCourses);
            this.Controls.Add(this.mcbDepartment);
            this.Name = "addStudentCourse";
            this.Style = MetroFramework.MetroColorStyle.Silver;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroComboBox mcbDepartment;
        private MetroFramework.Controls.MetroComboBox mcbCourses;
        private MetroFramework.Controls.MetroTextBox mtbStudents;
        private MetroFramework.Controls.MetroButton mbAdd;
        private MetroFramework.Controls.MetroLabel metroLabel10;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
    }
}