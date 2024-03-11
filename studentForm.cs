using MetroFramework.Controls;
using MetroFramework.Forms;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;


namespace PIProject
{
    public partial class studentForm : MetroForm
    {
        #region Fields
        private int studentId;
        private UMSContext UmsContext;
        private BindingSource studentBindingSource;
        private bool isGradesSelected = false;
        private bool isAttendanceSelected = false;
        #endregion
        #region Constructor
        public studentForm(int studentId)
        {
            InitializeComponent();
            UmsContext = new UMSContext();
            this.studentId = studentId;
            mTInfo.Click += mTInfo_Click;
            UpdateLabelWithStudentName();
            mTGrades.Click += mTGrades_Click;
            mTAttendance.Click += MTAttendance_Click;
            mTBack.Click += mTBack_Click;
            lightsSwitch(4);
            flowLayoutPanelAttendance.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanelGrades.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanelInfo.FlowDirection = FlowDirection.TopDown;
            mTBack.Visible = false;
            this.Resizable = false;
            this.MaximizeBox = false;

        }
        #endregion
        #region Private Methods
        private void UpdateLabelWithStudentName()
        {
                var student = UmsContext.Students.FirstOrDefault(s => s.StudentID == studentId);

                if (student != null)
                {
                    labelName.Text = $"Hello {student.FirstName},";
                }
                else
                {
                    labelName.Text = "Student not found";
                }

            }
        private void CreateLabelAndTextbox(string labelText, string textboxText)
        {
            int maxWidth = 100;

            TableLayoutPanel panel = new TableLayoutPanel();
            panel.AutoSize = true;

            MetroLabel label = new MetroLabel();
            label.Text = labelText;
            label.AutoSize = true;
            label.Dock = DockStyle.Left;

            int labelWidth = Math.Min(TextRenderer.MeasureText(label.Text, label.Font).Width, maxWidth / 2);
            label.Width = labelWidth;

            MetroTextBox textBox = new MetroTextBox();
            textBox.Text = textboxText;
            textBox.ReadOnly = true;
            textBox.Width = 200;
            textBox.Dock = DockStyle.Fill;

            panel.Controls.Add(label);
            panel.Controls.Add(textBox);

            flowLayoutPanelInfo.Controls.Add(panel);
        }
        private void ClearControls(FlowLayoutPanel flowLayoutPanel)
        {
            flowLayoutPanel.Controls.Clear();
        }
        public void lightsSwitch(int number)
        {
            flowLayoutPanelInfo.Visible = false;
            flowLayoutPanelGrades.Visible = false;
            flowLayoutPanelAttendance.Visible = false;

            switch (number)
            {
                case 1:
                    flowLayoutPanelInfo.Visible = true;
                    break;

                case 2:
                    flowLayoutPanelGrades.Visible = true;
                    break;

                case 3:
                    flowLayoutPanelAttendance.Visible = true;
                    break;
                case 4:
                    flowLayoutPanelInfo.Visible = false;
                    flowLayoutPanelGrades.Visible = false;
                    flowLayoutPanelAttendance.Visible = false;
                    break;
                default:
                    break;
            }
        }
        private string GetCourseName(int courseId)
        {
            var course = UmsContext.Courses.FirstOrDefault(c => c.CourseID == courseId);
            return course != null ? course.CourseName : $"CourseID: {courseId}";
        }

        private string GetFacultyName(int facultyId)
        {
            var faculty = UmsContext.Faculties.FirstOrDefault(f => f.FacultyID == facultyId);
            return faculty != null ? faculty.FacultyName : $"FacultyID: {facultyId}";
        }

        private string GetDepartmentName(int departmentId)
        {
            var department = UmsContext.Departments.FirstOrDefault(d => d.DepartmentID == departmentId);
            return department != null ? department.DepartmentName : $"DepartmentID: {departmentId}";
        }
        private void CreateGradeButton(Grade grade)
        {
            MetroButton button = new MetroButton();
            button.Text = GetCourseName(grade.CourseID);
            int courseID = Convert.ToInt32(grade.CourseID);
            Size textSize = TextRenderer.MeasureText(button.Text, button.Font);
            button.Size = new Size(textSize.Width + 20, textSize.Height + 10);

            button.Click += (sender, e) => ShowGradeDetails(courseID);

            button.Margin = new Padding(0, 0, 0, 5);

            flowLayoutPanelGrades.Controls.Add(button);

            flowLayoutPanelGrades.FlowDirection = FlowDirection.TopDown;
        }

        private void ShowGradeDetails(int courseID)
        {
            var context = new UMSContext();

            var selectedGrade = context.Grades
                .Where(g => g.StudentID == studentId && g.CourseID == courseID)
                .FirstOrDefault();

            ClearControls(flowLayoutPanelGrades);

            if (selectedGrade != null)
            {
                string displayText = $"Course: {GetCourseName(selectedGrade.CourseID)}\r\n" +
                                     $"Lab Grade: {selectedGrade.LabGrade}\r\n" +
                                     $"Course Grade: {selectedGrade.CourseGrade}\r\n" +
                                     $"Final Grade: {selectedGrade.FinalGrade}\r\n" +
                                     $"Credits: {selectedGrade.Credits}\r\n" +
                                     $"Credit Points: {selectedGrade.CreditPoints}";

                MetroLabel label = new MetroLabel();
                label.Text = displayText;
                label.AutoSize = true;
                label.Margin = new Padding(0, 0, 5, 0);
                label.TextAlign = ContentAlignment.MiddleLeft;
                label.Font = new Font(label.Font.FontFamily, 14, label.Font.Style);
                flowLayoutPanelGrades.Controls.Add(label);
                mTBack.Visible = true;
            }
            else
            {
                MessageBox.Show("Grade details not found.");
            }
        }
        private void CreateAttendanceButton(Attendance attendance)
        {
            MetroButton button = new MetroButton();
            button.Text = GetCourseName(attendance.CourseID);
            int courseID = Convert.ToInt32(attendance.CourseID);
            Size textSize = TextRenderer.MeasureText(button.Text, button.Font);
            button.Size = new Size(textSize.Width + 20, textSize.Height + 10);

            button.Click += (sender, e) => ShowAttendanceDetails(courseID);

            button.Margin = new Padding(0, 0, 0, 5);

            button.Location = new Point(104, 103);

            flowLayoutPanelAttendance.Controls.Add(button);

            flowLayoutPanelAttendance.FlowDirection = FlowDirection.TopDown;
        }
        private void ShowAttendanceDetails(int courseID)
        {
            var context = new UMSContext();
            var selectedAttendance = context.Attendances
                .Where(a => a.StudentID == studentId && a.CourseID == courseID)
                .FirstOrDefault();

            ClearControls(flowLayoutPanelAttendance);

            if (selectedAttendance != null)
            {
                string displayText = $"Course: {GetCourseName(selectedAttendance.CourseID)}\r\n" +
                                     $"W1: {selectedAttendance.W1}\r\n" +
                                     $"W2: {selectedAttendance.W2}\r\n" +
                                     $"W3: {selectedAttendance.W3}\r\n" +
                                     $"W4: {selectedAttendance.W4}\r\n" +
                                     $"W5: {selectedAttendance.W5}\r\n" +
                                     $"W6: {selectedAttendance.W6}\r\n" +
                                     $"W7: {selectedAttendance.W7}\r\n" +
                                     $"W8: {selectedAttendance.W8}\r\n" +
                                     $"W9: {selectedAttendance.W9}\r\n" +
                                     $"W10: {selectedAttendance.W10}\r\n" +
                                     $"W11: {selectedAttendance.W11}\r\n" +
                                     $"W12: {selectedAttendance.W12}\r\n" +
                                     $"W13: {selectedAttendance.W13}\r\n" +
                                     $"W14: {selectedAttendance.W14}\r\n" +
                                     $"TotalAttendance: {selectedAttendance.TotalAttendance}";

                MetroLabel label = new MetroLabel();
                label.Text = displayText;
                label.AutoSize = true;
                label.Margin = new Padding(0, 0, 5, 0);
                label.TextAlign = ContentAlignment.MiddleLeft;
                label.Font = new Font(label.Font.FontFamily, 14, label.Font.Style);
                flowLayoutPanelAttendance.Controls.Add(label);

                mTBack.Visible = true;

            }
            else
            {
                MessageBox.Show("Attendance details not found.");
            }
        }
        #endregion
        #region Event Handlers
        private void mTInfo_Click(object sender, EventArgs e)
        {

            var student = UmsContext.Students.FirstOrDefault(s => s.StudentID == studentId);
            mTBack.Visible = false;
            ClearControls(flowLayoutPanelInfo);
            if (student != null)
            {
                CreateLabelAndTextbox("First Name", student.FirstName);
                CreateLabelAndTextbox("Last Name", student.LastName);
                CreateLabelAndTextbox("CNP", student.CNP.ToString());
                CreateLabelAndTextbox("Date of Birth", student.DateOfBirth.ToString("yyyy-MM-dd")); 
                CreateLabelAndTextbox("Email", student.Email);
                CreateLabelAndTextbox("Phone Number", student.PhoneNumber);
                CreateLabelAndTextbox("Address", student.Address);
                CreateLabelAndTextbox("Faculty", GetFacultyName(student.FacultyID).ToString());
                CreateLabelAndTextbox("Department",  GetDepartmentName(student.DepartmentID).ToString());
                CreateLabelAndTextbox("Year ID", student.YearID.ToString());
                CreateLabelAndTextbox("Group Number", student.GroupNumber.ToString());

                lightsSwitch(1);
            }
            else
            {
                MessageBox.Show("Student not found");
            }
        }
        private void mTGrades_Click(object sender, EventArgs e)
        {
            ClearControls(flowLayoutPanelGrades);
            mTBack.Visible = false;
            var grades = UmsContext.Grades.Where(g => g.StudentID == studentId).ToList();
            if (grades.Any())
            {
                lightsSwitch(2);
                isGradesSelected = true; 
                isAttendanceSelected = false;
                foreach (var grade in grades)
                {
                    CreateGradeButton(grade);
                }

            }
            else
            {
                MessageBox.Show("No grades found for the student.");
            }
        }
        private void MTAttendance_Click(object sender, EventArgs e)
        {
            ClearControls(flowLayoutPanelAttendance);
            mTBack.Visible = false;
            var attendances = UmsContext.Attendances.Where(g => g.StudentID == studentId).ToList();
            if (attendances.Any())
            {
                lightsSwitch(3);
                isAttendanceSelected = true;
                isGradesSelected = false;
                foreach (var attendance in attendances)
                {
                    CreateAttendanceButton(attendance);
                }

            }
            else
            {
                MessageBox.Show("No attendances found for the student.");
            }
        }
        private void mTBack_Click(object sender, EventArgs e)
        {
            if (isGradesSelected)
            {
                mTGrades_Click(sender, e);
                mTBack.Visible = false;
            }
            else if (isAttendanceSelected)
            {
                MTAttendance_Click(sender, e);
                mTBack.Visible = false;
            }
            else
            {
                lightsSwitch(4);
            }
        }


        #endregion

      
    }
}
