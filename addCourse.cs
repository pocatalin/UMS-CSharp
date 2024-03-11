using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PIProject
{
    public partial class addCourse : MetroForm
    {
        private string mtbCourseNameValue;
        private int mtbCreditsValue;
        private string mcbProfessorValue;
        private int mcbDepartmentValue;
        private UMSContext UmsContext;
        private adminForm AdminForm;
        public addCourse(adminForm adminForm)
        {
            InitializeComponent();
            UmsContext = new UMSContext();
            this.AdminForm = adminForm;
            mtbCredits.KeyPress += TextBoxNumber_KeyPress;
            mcbDepartment.SelectedIndexChanged += McbDepartment_SelectedIndexChanged;
            mbAdd.Click += mbAdd_Click;
            mtbCredits.MaxLength = 10;
            this.Resizable = false;
            this.MaximizeBox = false;
            PopulateProfessorComboBox();
            PopulateDepartmentComboBox();
        }


        private void McbDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateProfessorComboBox();
        }
        private void TextBoxNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void mbAdd_Click(object sender, EventArgs e)
        {
            if (
                string.IsNullOrWhiteSpace(mcbDepartment.Text) ||
                string.IsNullOrWhiteSpace(mtbCredits.Text)||
                string.IsNullOrWhiteSpace(mtbCourseName.Text)||
                string.IsNullOrWhiteSpace(mcbProfessor.Text)
                )

            {
                MessageBox.Show("Please fill in all required fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            mtbCreditsValue = int.Parse(mtbCredits.Text);
            mtbCourseNameValue=mtbCourseName.Text;
            mcbDepartmentValue = GetDepartmentIdByName(mcbDepartment.Text);
            mcbProfessorValue = GetProfessorIdByName(mcbProfessor.Text, mcbDepartmentValue);

            Cours newCourse = new Cours
            {
                CourseName = mtbCourseNameValue,
                DepartmentID=mcbDepartmentValue,
                ProfessorID=mcbProfessorValue,
                Credits=mtbCreditsValue
            };

            UmsContext.Courses.Add(newCourse);
            UmsContext.SaveChanges();
            AdminForm.RefreshAllGrids();
            MessageBox.Show("Student added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        private int GetDepartmentIdByName(string facultyName)
        {
            var faculty = UmsContext.Departments.FirstOrDefault(f => f.DepartmentName == facultyName);

            if (faculty != null)
            {
                return faculty.DepartmentID;
            }
            return -1;
        }
        private string GetProfessorIdByName(string professorName, int departmentId)
        {
            string[] names = professorName.Split(' ');

            if (names.Length == 2)
            {
                string firstName = names[0];
                string lastName = names[1];

                var teacher = UmsContext.Professors
                    .FirstOrDefault(t => t.FirstName == firstName && t.LastName == lastName && t.DepartmentID == departmentId);

                if (teacher != null)
                {
                    return teacher.ProfessorID;
                }
            }

            return null; 
        }
    private void PopulateProfessorComboBox()
        {
            mcbProfessor.Items.Clear();

            string selectedDepartment = mcbDepartment.Text;

            if (!string.IsNullOrWhiteSpace(selectedDepartment))
            {
                int departmentId = GetDepartmentIdByName(selectedDepartment);

                if (departmentId != -1)
                {
                    var professors = UmsContext.Professors
                        .Where(p => p.DepartmentID == departmentId)
                        .ToList();

                    foreach (var professor in professors)
                    {
                        string fullName = $"{professor.FirstName} {professor.LastName}";
                        mcbProfessor.Items.Add(fullName);
                    }
                }

            }
        }



    }
}
