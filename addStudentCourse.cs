using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PIProject
{
    public partial class addStudentCourse : MetroForm
    {
        private int mcbCourseValue;
        private int mcbDepartmentValue;
        private UMSContext UmsContext;
        private adminForm AdminForm;
        public addStudentCourse(adminForm adminForm)
        {
            UmsContext = new UMSContext();
            this.AdminForm = adminForm;
            InitializeComponent();
            mcbDepartment.SelectedIndexChanged += mcbDepartment_SelectedIndexChanged;
            mbAdd.Click += mbAdd_Click;
            this.Resizable = false;
            this.MaximizeBox = false;
            PopulateDepartmentComboBox();
            PopulateCoursesComboBox();
        }

        private void mbAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(mtbStudents.Text) ||
                string.IsNullOrWhiteSpace(mcbCourses.Text) ||
                string.IsNullOrWhiteSpace(mcbDepartment.Text))
            {
                MessageBox.Show("Please fill in all required fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            mcbCourseValue = GetCourseIdByName(mcbCourses.Text);
            mcbDepartmentValue = GetDepartmentIdByName(mcbDepartment.Text);

            string studentsInput = mtbStudents.Text;

            if (!string.IsNullOrEmpty(studentsInput))
            {
                string[] studentIds = studentsInput.Split(',');

                foreach (string studentId in studentIds)
                {
                    if (int.TryParse(studentId.Trim(), out int studentIdValue))
                    {
                        StudentCours newSC = new StudentCours
                        {
                            CourseID = mcbCourseValue,  
                            StudentID = studentIdValue,
                        };

                        try
                        {
                            UmsContext.StudentCourses.Add(newSC);
                            UmsContext.SaveChanges();
                            AdminForm.RefreshAllGrids();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Failed to add students. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid student ID: " + studentId.Trim() + ". Please enter a valid numeric student ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                MessageBox.Show("Students added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Please enter student IDs.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void mcbDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateCoursesComboBox();
        }
        private void PopulateDepartmentComboBox()
        {
            var years = UmsContext.Departments.ToList();

            mcbDepartment.Items.Clear();

            foreach (var year in years)
            {
                mcbDepartment.Items.Add(year.DepartmentName);
            }
        }
        private void PopulateCoursesComboBox()
        {
            mcbCourses.Items.Clear();

            string selectedDepartment = mcbDepartment.SelectedItem?.ToString();

            if (!string.IsNullOrEmpty(selectedDepartment))
            {
                int departmentId = GetDepartmentIdByName(selectedDepartment);

                var courses = UmsContext.Courses.Where(c => c.DepartmentID == departmentId).ToList();

                foreach (var course in courses)
                {
                    mcbCourses.Items.Add(course.CourseName);
                }
            }
        }

        private int GetDepartmentIdByName(string facultyName)
        {
            var faculty = UmsContext.Departments.FirstOrDefault(f => f.DepartmentName == facultyName);

            if (faculty != null)
            {
                return faculty.DepartmentID;
            }
            return -1;
        }
        private int GetCourseIdByName(string facultyName)
        {
            var faculty = UmsContext.Courses.FirstOrDefault(f => f.CourseName == facultyName);

            if (faculty != null)
            {
                return faculty.CourseID;
            }
            return -1;
        }

    }
}
