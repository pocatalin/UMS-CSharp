using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Security.AccessControl;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PIProject
{
    public partial class addAttedanceForm : MetroForm
    {
        private UMSContext UmsContext;
        private string selectedWeek;
        private int selectedCourseId;
        private string profiD;
        private professorForm professorform;
        public addAttedanceForm(string profiD, professorForm professorform)
        {
            UmsContext = new UMSContext();
            InitializeComponent();
            mtbStudents.Size = new System.Drawing.Size(200, 30);
            mbAdd.Size = new System.Drawing.Size(75, 30);
            this.profiD = profiD;
            this.professorform= professorform;
            populateComboBoxes();
            PopulateCoursesComboBox();
            metroComboBoxWeek.SelectedIndexChanged += metroComboBoxWeek_SelectedIndexChanged;
            mbAdd.Click += mbAdd_Click;
            setCurrentWeek();
            this.Resizable = false;
            this.MaximizeBox = false;
        }

        private void mbAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string[] studentIdsArray = mtbStudents.Text.Split(',');

                foreach (string studentIdString in studentIdsArray)
                {
                    if (int.TryParse(studentIdString, out int studentId))
                    {
                        string sql = $"UPDATE Attendance SET {selectedWeek} = 1 WHERE StudentID = {studentId} AND CourseID = {selectedCourseId}";
                        UmsContext.Database.ExecuteSqlCommand(sql);
                        professorform.ResetGridBindings();
                    }
                    else
                    {
                        MessageBox.Show($"Invalid student ID: {studentIdString}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                MessageBox.Show("Attendance updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                string failedData = $"CourseID: {selectedCourseId}, Week: {selectedWeek}, Students: {mtbStudents.Text}";
                MessageBox.Show($"Error saving attendance");
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

            metroComboBoxCourse.SelectedIndexChanged += metroComboBoxCourse_SelectedIndexChanged;
        }

        private void setCurrentWeek()
        {
            string currentSelectedWeek = metroComboBoxWeek.SelectedItem?.ToString();

            metroComboBoxWeek.SelectedIndexChanged -= metroComboBoxWeek_SelectedIndexChanged;

            selectedWeek = currentSelectedWeek;

            metroComboBoxWeek.SelectedIndexChanged += metroComboBoxWeek_SelectedIndexChanged;
        }




        private void metroComboBoxCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedCourseId = UmsContext.Courses
               .Where(c => c.CourseName == metroComboBoxCourse.SelectedItem.ToString())
               .Select(c => c.CourseID)
               .FirstOrDefault();

        }

        private void metroComboBoxWeek_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedWeek = metroComboBoxWeek.SelectedItem.ToString();

        }

        private void populateComboBoxes()
        {
            metroComboBoxWeek.Items.Clear();

            for (int i = 1; i <= 14; i++)
            {
                string weekNumber = "W" + i;
                metroComboBoxWeek.Items.Add(weekNumber);
            }
            metroComboBoxWeek.SelectedItem = "W14";
        }
        private int cutWeek(string week)
        {
            string a = week;
            string b = string.Empty;
            int val = 0;

            for (int i = 0; i < a.Length; i++)
            {
                if (Char.IsDigit(a[i]))
                    b += a[i];
            }

            if (b.Length > 0)
                val = int.Parse(b);

            return val;

        }

    }
}
