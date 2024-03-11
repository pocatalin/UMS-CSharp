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
    public partial class addDepartment : MetroForm
    {
        private string mtbNameValue;
        private int mcbFacultyValue;
        private UMSContext UmsContext;
        private adminForm AdminForm;
        public addDepartment(adminForm adminForm)
        {
            UmsContext = new UMSContext();
            this.AdminForm = adminForm;
            InitializeComponent();
            mbAdd.Click += mbAdd_Click;
            PopulateFacultyComboBox();
            this.Resizable = false;
            this.MaximizeBox = false;
        }

        private void mbAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(mtbName.Text) ||
                string.IsNullOrWhiteSpace(mcbFaculty.Text))
            {
                MessageBox.Show("Please fill in all required fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            mtbNameValue= mtbName.Text;
            mcbFacultyValue=GetFacultyIdByName(mcbFaculty.Text);

            Department newDept = new Department
            {
                DepartmentName=mtbNameValue,
                FacultyID=mcbFacultyValue
            };

            UmsContext.Departments.Add(newDept);
            UmsContext.SaveChanges();
            AdminForm.RefreshAllGrids();
            MessageBox.Show("Department added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        private int GetFacultyIdByName(string facultyName)
        {
            var faculty = UmsContext.Faculties.FirstOrDefault(f => f.FacultyName == facultyName);

            if (faculty != null)
            {
                return faculty.FacultyID;
            }
            return -1;
        }
    }
}
