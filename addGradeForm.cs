using MetroFramework.Controls;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Windows.Forms;


namespace PIProject
{
    public partial class addGradeForm : MetroForm
    {
        private UMSContext UmsContext;
        private string profiD;
        private int selectedCourseId;
        private int selectedStudentId;
        private int labGrade = 0;
        private int courseGrade = 0;
        private professorForm professorform;
        public addGradeForm(string profiD, professorForm professorform)
        {

            InitializeComponent();
            UmsContext = new UMSContext();
            this.profiD = profiD;
            this.professorform = professorform;
            mbAdd.Click += mbAdd_Click;
            PopulateCoursesComboBox();
            InitializeTextBoxes();
            mbAdd.Size = new System.Drawing.Size(75, 30);
            this.Resizable = false;
            this.MaximizeBox = false;
            this.professorform = professorform;
        }

        private void mbAdd_Click(object sender, EventArgs e)
        {
            try
            {
                int labGradeValue = (int)labGrade; 
                int courseGradeValue = (int)courseGrade; 

                string insertSql = $"INSERT INTO Grades (StudentID, CourseID, LabGrade, CourseGrade) " +
                                   $"VALUES ({selectedStudentId}, {selectedCourseId}, {labGradeValue}, {courseGradeValue})";

                UmsContext.Database.ExecuteSqlCommand(insertSql);
                professorform.ResetGridBindings();
                MessageBox.Show("Grades saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                string failedData = $"CourseID: {selectedCourseId}, StudentID: {selectedStudentId}, LabGrade: {(int)labGrade}, CourseGrade: {(int)courseGrade}";
                MessageBox.Show($"Error saving grades");
            }
            professorform.ResetGridBindings();
        }








        private void PopulateCoursesComboBox()
        {
            var professorCourses = UmsContext.Courses
                .Where(c => c.ProfessorID == profiD)
                .ToList();

            metroComboBoxCourse.Items.Clear();

            foreach (var course in professorCourses)
            {
                metroComboBoxCourse.Items.Add(course.CourseName);
            }

            metroComboBoxCourse.SelectedIndexChanged += MetroComboBoxCourse_SelectedIndexChanged;
        }


        private void MetroComboBoxCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedCourseId = UmsContext.Courses
                .Where(c => c.CourseName == metroComboBoxCourse.SelectedItem.ToString())
                .Select(c => c.CourseID)
                .FirstOrDefault();

            PopulateStudentsComboBox(selectedCourseId);
        }

        private void PopulateStudentsComboBox(int courseId)
        {
            var enrolledStudents = UmsContext.ProfessorCourseStudents
                .Include(pcs => pcs.Student)
                .Where(pcs => pcs.CourseID == courseId)
                .ToList();

            metroComboBoxStudent.Items.Clear();

            foreach (var enrolledStudent in enrolledStudents)
            {
                string fullName = $"{enrolledStudent.Student.FirstName} {enrolledStudent.Student.LastName}";
                metroComboBoxStudent.Items.Add(fullName);
            }

            metroComboBoxStudent.SelectedIndexChanged += MetroComboBoxStudent_SelectedIndexChanged;
        }


        private void MetroComboBoxStudent_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedFullName = metroComboBoxStudent.SelectedItem.ToString();

            string[] names = selectedFullName.Split(' ');

            string selectedFirstName = names[0];
            string selectedLastName = names.Length > 1 ? names[1] : "";

            selectedStudentId = UmsContext.Students
                .Where(s => s.FirstName == selectedFirstName && s.LastName == selectedLastName)
                .Select(s => s.StudentID)
                .FirstOrDefault();
           
        }

        private void InitializeTextBoxes()
        {
            mtbLabGrade.Size = new System.Drawing.Size(75, 30);
            mtbCourseGrade.Size = new System.Drawing.Size(75, 30);
            mtbFinalGrade.Size = new System.Drawing.Size(75, 30);


            mtbLabGrade.Text = "0";
            mtbCourseGrade.Text = "0";
            mtbFinalGrade.Text = "0";

            mtbLabGrade.KeyPress += TextBox_KeyPress;
            mtbCourseGrade.KeyPress += TextBox_KeyPress;

            mtbLabGrade.TextChanged += mtbLabGrade_TextChanged;
            mtbCourseGrade.TextChanged += mtbCourseGrade_TextChanged;

            mtbLabGrade.Enter += mtbLabGrade_Enter;
            mtbCourseGrade.Enter += mtbCourseGrade_Enter;

            mtbLabGrade.Leave += mtbLabGrade_Leave;
            mtbCourseGrade.Leave += mtbCourseGrade_Leave;
        }

        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != '.' && e.KeyChar != ',' && e.KeyChar != 127) // 8 is the ASCII code for Backspace, 127 is the ASCII code for Delete
            {
                e.Handled = true;
            }
            else
            {
                if ((e.KeyChar == '.' || e.KeyChar == ',') && ((MetroTextBox)sender).Text.Contains(".") && !((MetroTextBox)sender).SelectedText.Contains("."))
                {
                    e.Handled = true;
                }
                else
                {
                    if (e.KeyChar == 8)
                    {
                        return;
                    }

                    double currentValue;
                    if (double.TryParse(((MetroTextBox)sender).Text + e.KeyChar, out currentValue))
                    {
                        e.Handled = currentValue < 0 || currentValue > 10;
                    }
                    else
                    {
                        e.Handled = true;
                    }
                }
            }
        }

        private void CalculateFinalGrade()
        {
            if (double.TryParse(mtbLabGrade.Text, out double labGrade) && double.TryParse(mtbCourseGrade.Text, out double courseGrade))
            {
                labGrade = Math.Max(0, Math.Min(labGrade, 10));
                courseGrade = Math.Max(0, Math.Min(courseGrade, 10));

                labGrade = Math.Round(labGrade, 2);
                courseGrade = Math.Round(courseGrade, 2);

                double finalGrade = (labGrade * 0.7) + (courseGrade * 0.3);
                mtbFinalGrade.Text = finalGrade.ToString("0.00");
            }
        }



        private void mtbLabGrade_TextChanged(object sender, EventArgs e)
        {
            CalculateFinalGrade();
        }

        private void mtbCourseGrade_TextChanged(object sender, EventArgs e)
        {
            CalculateFinalGrade();
        }

        private void mtbLabGrade_Enter(object sender, EventArgs e)
        {
            HandleTextBoxEnter((MetroTextBox)sender);
        }

        private void mtbCourseGrade_Enter(object sender, EventArgs e)
        {
            HandleTextBoxEnter((MetroTextBox)sender);
        }

        private void mtbLabGrade_Leave(object sender, EventArgs e)
        {
            HandleTextBoxLeave((MetroTextBox)sender);
        }

        private void mtbCourseGrade_Leave(object sender, EventArgs e)
        {
            HandleTextBoxLeave((MetroTextBox)sender);
        }

        private void HandleTextBoxEnter(MetroTextBox textBox)
        {
            if (textBox.Text == "0")
            {
                textBox.Text = "";
            }
        }

        private void HandleTextBoxLeave(MetroTextBox textBox)
        {
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = "0";
            }
        }

    
    }
}
