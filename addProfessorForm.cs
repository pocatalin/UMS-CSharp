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
    public partial class addProfessorForm : MetroForm
    {
        private string mtbFirstNameValue;
        private string mtbLastNameValue;
        private int mtbCNPValue;
        private DateTime mdtBirthDateValue;
        private string mtbEmailValue;
        private string mtbPhoneNumberValue;
        private string mtbAddressValue;
        private int mcbFacultyValue;
        private int mcbDepartmentValue;
        private UMSContext UmsContext;
        private adminForm AdminForm;
        public addProfessorForm(adminForm adminForm)
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

            PopulateFacultyComboBox();
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
                string.IsNullOrWhiteSpace(mcbFaculty.Text) ||
                string.IsNullOrWhiteSpace(mcbDepartment.Text)) 
           
            {
                MessageBox.Show("Please fill in all required fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DateTime formattedBirthDate = DateTime.ParseExact(mdtBirthDate.Value.ToString("yyyy-MM-dd"), "yyyy-MM-dd", CultureInfo.InvariantCulture);

            string nextProfessorId = GetNextProfessorId();
            mtbFirstNameValue = mtbFirstName.Text;
            mtbLastNameValue = mtbLastName.Text;
            mtbCNPValue = int.Parse(mtbCNP.Text);
            mdtBirthDateValue = formattedBirthDate;
            mtbEmailValue = mtbEmail.Text;
            mtbPhoneNumberValue = mtbPhoneNumber.Text;
            mtbAddressValue = mtbAddress.Text;
            mcbFacultyValue = GetFacultyIdByName(mcbFaculty.Text);
            mcbDepartmentValue = GetDepartmentIdByName(mcbDepartment.Text);

            Professor newProfessor = new Professor
            {
                ProfessorID=nextProfessorId,
                FirstName = mtbFirstName.Text,
                LastName = mtbLastName.Text,
                CNP = mtbCNPValue,
                DateOfBirth = formattedBirthDate,
                Email = mtbEmail.Text,
                PhoneNumber = mtbPhoneNumberValue,
                Address = mtbAddress.Text,
                FacultyID = mcbFacultyValue,
                DepartmentID = mcbDepartmentValue,
            };

            UmsContext.Professors.Add(newProfessor);
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

        private string GetNextProfessorId()
        {
            var lastProfessor = UmsContext.Professors
                                        .OrderByDescending(p => p.ProfessorID)
                                        .FirstOrDefault();

            if (lastProfessor == null)
            {
                return "P1";
            }

            string lastId = lastProfessor.ProfessorID;
            string numericPart = lastId.Substring(1); 
            if (int.TryParse(numericPart, out int numericValue))
            {
                numericValue++; 
                return "P" + numericValue.ToString();
            }

            return "P1";
        }

    }
}
