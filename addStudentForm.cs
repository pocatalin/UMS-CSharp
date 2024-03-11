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
    public partial class addStudentForm : MetroForm
    {
        private string mtbFirstNameValue;
        private string mtbLastNameValue;
        private int mtbCNPValue;
        private DateTime mdtBirthDateValue;
        private string mtbEmailValue;
        private string mtbPhoneNumberValue;
        private string mtbAddressValue;
        private DateTime mtdRegDateValue;
        private int mcbFacultyValue;
        private int mcbDepartmentValue;
        private int mcbYearValue;
        private int mcbGroupValue;
        private UMSContext UmsContext;
        private adminForm AdminForm;
        public addStudentForm(adminForm adminForm)
        {
            UmsContext = new UMSContext();
            this.AdminForm = adminForm;
            InitializeComponent();
            mtbFirstName.KeyPress += TextBoxLetter_KeyPress;
            mtbLastName.KeyPress += TextBoxLetter_KeyPress;
            mtbCNP.KeyPress += TextBoxNumber_KeyPress;
            mtbPhoneNumber.KeyPress += TextBoxNumber_KeyPress;
            mbAdd.Click += mbAdd_Click;
            mcbFaculty.SelectedIndexChanged += mcbFaculty_SelectedIndexChanged;

            mtbCNP.MaxLength = 9; 
            mtbPhoneNumber.MaxLength = 10;
            this.Resizable = false;
            this.MaximizeBox = false;
            PopulateYearComboBox();
            PopulateFacultyComboBox();
            PopulateGroupComboBox();
        }

        private void mcbFaculty_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedFaculty = mcbFaculty.Text;

            if (!string.IsNullOrWhiteSpace(selectedFaculty))
            {
                int facultyId = GetFacultyIdByName(selectedFaculty);

                if (facultyId != -1)
                {
                    PopulateDepartmentComboBox(facultyId);
                }
                else
                {
                    MessageBox.Show("Invalid faculty selection.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void mbAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(mtbFirstName.Text) ||
                string.IsNullOrWhiteSpace(mtbLastName.Text) ||
                string.IsNullOrWhiteSpace(mtbCNP.Text) ||
                string.IsNullOrWhiteSpace(mdtBirthDate.Text) ||
                string.IsNullOrWhiteSpace(mtbEmail.Text) ||
                string.IsNullOrWhiteSpace(mtbPhoneNumber.Text) ||
                string.IsNullOrWhiteSpace(mtbAddress.Text) ||
                string.IsNullOrWhiteSpace(mtdRegDate.Text) ||
                string.IsNullOrWhiteSpace(mcbFaculty.Text) ||
                string.IsNullOrWhiteSpace(mcbDepartment.Text) ||
                string.IsNullOrWhiteSpace(mcbGroup.Text) ||
                string.IsNullOrWhiteSpace(mcbYear.Text))
            {
                MessageBox.Show("Please fill in all required fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; 
            }

            DateTime formattedBirthDate = DateTime.ParseExact(mdtBirthDate.Value.ToString("yyyy-MM-dd"), "yyyy-MM-dd", CultureInfo.InvariantCulture);
            DateTime formattedRegDate = DateTime.ParseExact(mtdRegDate.Value.ToString("yyyy-MM-dd"), "yyyy-MM-dd", CultureInfo.InvariantCulture);

            mtbFirstNameValue = mtbFirstName.Text;
            mtbLastNameValue = mtbLastName.Text;
            mtbCNPValue = int.Parse(mtbCNP.Text);
            mdtBirthDateValue = formattedBirthDate;
            mtbEmailValue = mtbEmail.Text;
            mtbPhoneNumberValue = mtbPhoneNumber.Text;
            mtbAddressValue = mtbAddress.Text;
            mtdRegDateValue = formattedRegDate;
            mcbFacultyValue = GetFacultyIdByName(mcbFaculty.Text);
            mcbDepartmentValue = GetDepartmentIdByName(mcbDepartment.Text);
            mcbGroupValue = int.Parse(mcbGroup.Text);
            mcbYearValue = int.Parse(mcbYear.Text);

            Student newStudent = new Student
            {
                FirstName = mtbFirstName.Text,
                LastName = mtbLastName.Text,
                CNP = mtbCNPValue,
                DateOfBirth = formattedBirthDate,
                Email = mtbEmail.Text,
                PhoneNumber = mtbPhoneNumberValue,
                Address = mtbAddress.Text,
                RegistrationDate = formattedRegDate,
                FacultyID = mcbFacultyValue,
                DepartmentID = mcbDepartmentValue,
                GroupNumber = mcbGroupValue,
                YearID = mcbYearValue
            };

            UmsContext.Students.Add(newStudent);
            UmsContext.SaveChanges();
            AdminForm.RefreshAllGrids();
            MessageBox.Show("Student added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void TextBoxLetter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void TextBoxNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void PopulateYearComboBox()
        {
            var years = UmsContext.YearTables.ToList();

            mcbYear.Items.Clear();

            foreach (var year in years)
            {
                mcbYear.Items.Add(year.YearID); 
            }
        }
        private void PopulateFacultyComboBox()
        {
            var years = UmsContext.Faculties.ToList();

            mcbFaculty.Items.Clear();

            foreach (var year in years)
            {
                mcbFaculty.Items.Add(year.FacultyName);
            }
        }
        private void PopulateDepartmentComboBox(int facultyId)
        {
            var departments = UmsContext.Departments.Where(d => d.FacultyID == facultyId).ToList();

            mcbDepartment.Items.Clear();

            foreach (var department in departments)
            {
                mcbDepartment.Items.Add(department.DepartmentName);
            }
        }
        private void PopulateGroupComboBox()
        {
            var years = UmsContext.Groups.ToList();

           mcbGroup.Items.Clear();

            foreach (var year in years)
            {
                mcbGroup.Items.Add(year.GroupNumber);
            }
        }

        private int GetFacultyIdByName(string facultyName)
        {
            var faculty = UmsContext.Faculties.FirstOrDefault(f => f.FacultyName == facultyName);

            if (faculty != null)
            {
                return faculty.FacultyID;
            }
            return -1;
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

     
    }
}
