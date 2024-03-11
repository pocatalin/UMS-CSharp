using MetroFramework.Controls;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Validation;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace PIProject
{
    public partial class adminForm : MetroForm
    {
        private string adminID;
        private UMSContext UmsContext;
        private BindingSource gridBindingSource;
        private DataGridView selectedDataGridView;
        private addStudentForm addStudentFormInstance;
        public adminForm(string adminID)
        {
            InitializeComponent();
            UmsContext = new UMSContext();
            this.adminID = adminID;
            gridBindingSource = new BindingSource();

            InitializeGrid();
            mbEdit.Click += mbEdit_Click;
            mbSave.Click += mbSave_Click;
            mbRemove.Click += mbRemove_Click;
            mbAddStudent.Click += mbAddStudent_Click;
            mbAddProfessor.Click += mbAddProfessor_Click;
            mbRefresh.Click += MbRefresh_Click;
            mbAddCourse.Click += mbAddCourse_Click;
            mbAddAttedance.Click += mbAddAttedance_Click;
            mbAddFaculty.Click += mbAddFaculty_Click;
            mbAddGroup.Click += mbAddGroup_Click;
            mbAddDepartment.Click += mbAddDepartment_Click;
            mbAddStudentCourses.Click += mbAddStudentCourses_Click;
            this.Resizable = false;
            this.MaximizeBox = false;
        }

        private void mbAddStudentCourses_Click(object sender, EventArgs e)
        {
            addStudentCourse addsudentcourse = new addStudentCourse(this);
            addsudentcourse.ShowDialog();
        }

        private void mbAddDepartment_Click(object sender, EventArgs e)
        {
            addDepartment adddepartment= new addDepartment(this);
            adddepartment.ShowDialog();
        }
        private void mbAddGroup_Click(object sender, EventArgs e)
        {
            var lastGroupNumber = UmsContext.Groups
          .OrderByDescending(g => g.GroupNumber)
          .Select(g => g.GroupNumber)
          .FirstOrDefault();

            using (UmsContext)
            {

                Group newGroup = new Group
                {
                    GroupNumber = lastGroupNumber + 1
                };

                UmsContext.Groups.Add(newGroup);
                UmsContext.SaveChanges();

                MessageBox.Show($"Group '{lastGroupNumber + 1}' added successfully!");

                RefreshAllGrids();
            }
        }


        private void mbAddFaculty_Click(object sender, EventArgs e)
        {
            MetroTextBox textBox = new MetroTextBox();
            MetroButton saveButton = new MetroButton();

            MetroForm inputForm = new MetroForm();
            inputForm.Text = "Faculty Name";
            inputForm.Size = new Size(250, 120);
            inputForm.Controls.Add(textBox);
            inputForm.Controls.Add(saveButton);
            inputForm.Style = MetroFramework.MetroColorStyle.Silver;

            textBox.Size = new Size(200, 20);
            textBox.Location = new Point((inputForm.Width - textBox.Width) / 2, (inputForm.Height - textBox.Height) / 2);

            saveButton.Size = new Size(75, 23);
            saveButton.Text = "Add";
            saveButton.Location = new Point(inputForm.Width - saveButton.Width - 10, inputForm.Height - saveButton.Height - 10);

            textBox.Style=MetroFramework.MetroColorStyle.Silver;
            saveButton.Style = MetroFramework.MetroColorStyle.Silver;
            saveButton.Click += (s, args) =>
            {
                if (!string.IsNullOrWhiteSpace(textBox.Text))
                {
                    SaveFaculty(inputForm, textBox.Text);
                }
                else
                {
                    MessageBox.Show("Please enter a valid faculty name.");
                }
            };

            DialogResult result = inputForm.ShowDialog();
        }

        private void SaveFaculty(MetroForm inputForm, string facultyName)
        {
            using (UmsContext)
            {
                if (UmsContext.Faculties.Any(f => f.FacultyName == facultyName))
                {
                    MessageBox.Show($"Faculty '{facultyName}' already exists!");
                }
                else
                {
                    Faculty newFaculty = new Faculty
                    {
                        FacultyName = facultyName,
                        TotalStudents = 0
                    };

                    UmsContext.Faculties.Add(newFaculty);
                    UmsContext.SaveChanges();

                    MessageBox.Show($"Faculty '{facultyName}' added successfully!");

                    RefreshAllGrids();
                }
            }

            inputForm.Close();
        }



        private void mbAddAttedance_Click(object sender, EventArgs e)
        {
            using (UMSContext context = new UMSContext())
            {
                var studentCourses = context.StudentCourses;

                int expectedRows = 0;
                int insertedRows = 0;
                int existingRows = 0;

                foreach (var studentCourse in studentCourses)
                {
                    int studentID = studentCourse.StudentID;
                    int courseID = studentCourse.CourseID;
                    expectedRows++;

                    Attendance existingAttendance = context.Attendances
                        .FirstOrDefault(a => a.StudentID == studentID && a.CourseID == courseID);

                    if (existingAttendance == null)
                    {
                        Attendance newAttendance = new Attendance
                        {
                            StudentID = studentID,
                            CourseID = courseID,
                            W1 = 0,
                            W2 = 0,
                            W3 = 0,
                            W4 = 0,
                            W5 = 0,
                            W6 = 0,
                            W7 = 0,
                            W8 = 0,
                            W9 = 0,
                            W10 = 0,
                            W11 = 0,
                            W12 = 0,
                            W13 = 0,
                            W14 = 0
                        };

                        context.Attendances.Add(newAttendance);
                        insertedRows++;
                    }
                    else
                    {
                        existingRows++;
                    }
                }

                int saveChangesResult = context.SaveChanges();

                if (saveChangesResult > 0)
                {
                    RefreshAllGrids();
                    MessageBox.Show($"{insertedRows} new attendance records inserted, {existingRows} records already existed.");
                }
                else
                {
                    MessageBox.Show("No changes were saved.");
                }
            }
        }


        private void mbAddCourse_Click(object sender, EventArgs e)
        {
            addCourse addcourse = new addCourse(this);
            addcourse.ShowDialog();
        }

        private void MbRefresh_Click(object sender, EventArgs e)
        {
            RefreshAllGrids();
        }

        private void mbAddProfessor_Click(object sender, EventArgs e)
        {
            addProfessorForm addprofessorForm = new addProfessorForm(this);
            addprofessorForm.ShowDialog();
        }

        private void mbAddStudent_Click(object sender, EventArgs e)
        {
            addStudentForm addstudentForm = new addStudentForm(this);
            addstudentForm.ShowDialog();
        }

        private void InitializeGrid()
        {

        }


        private void mtpProfessorsCourses_Click(object sender, EventArgs e)
        {

        }

        private void adminForm_Load(object sender, EventArgs e)
        {
            this.facultiesTableAdapter.Fill(this.uMSDataSet.Faculties);
            this.studentDepartmentTableAdapter.Fill(this.uMSDataSet.StudentDepartment);
            this.departmentsTableAdapter.Fill(this.uMSDataSet.Departments);
            this.studentYearTableAdapter.Fill(this.uMSDataSet.StudentYear);
            this.yearTableTableAdapter.Fill(this.uMSDataSet.YearTable);
            this.gradesTableAdapter.Fill(this.uMSDataSet.Grades);
            this.attendanceTableAdapter.Fill(this.uMSDataSet.Attendance);
            this.studentGroupTableAdapter.Fill(this.uMSDataSet.StudentGroup);
            this.studentCoursesTableAdapter.Fill(this.uMSDataSet.StudentCourses);
            this.professorCoursesTableAdapter.Fill(this.uMSDataSet.ProfessorCourses);
            this.coursesTableAdapter.Fill(this.uMSDataSet.Courses);
            this.professorsTableAdapter.Fill(this.uMSDataSet.Professors);
            this.professorCourseStudentsTableAdapter.Fill(this.uMSDataSet.ProfessorCourseStudents);
            this.studentsTableAdapter.Fill(this.uMSDataSet.Students);
            this.groupsTableAdapter.Fill(this.uMSDataSet.Groups);



        }

        private void mbEdit_Click(object sender, EventArgs e)
        {
            TabPage currentTab = mtcAdmin.SelectedTab;
            DataGridView selectedDataGridView = null;
            DataGridView selectedDataGridViewCopy = null;
            foreach (Control control in currentTab.Controls)
            {
                if (control is DataGridView dataGridView)
                {
                    selectedDataGridView = dataGridView;
                    break;
                }
            }
            selectedDataGridViewCopy = selectedDataGridView;

            if (selectedDataGridView != null && selectedDataGridView.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = selectedDataGridView.SelectedRows[0];
                string tableName = currentTab.Text;

                editRowForm editrowForm = new editRowForm(tableName, selectedRow, selectedDataGridView.DataSource as DataTable, this, selectedDataGridViewCopy);
                editrowForm.ShowDialog();


            }
        }
        public void UpdateDataTable(string tableName, int rowIndex, Object[] editedValues, DataGridView selectedgrid)
        {
            BindingSource bindingSource = (BindingSource)selectedgrid.DataSource;

            if (bindingSource != null)
            {
                DataSet dataSet = (DataSet)bindingSource.DataSource;

                if (dataSet.Tables.Contains(tableName))
                {
                    DataTable dataTable = dataSet.Tables[tableName];

                    if (rowIndex >= 0 && rowIndex < dataTable.Rows.Count)
                    {
                        DataRow rowToUpdate = dataTable.Rows[rowIndex];

                        for (int i = 0; i < editedValues.Length; i++)
                        {
                            if (!dataTable.Columns[i].ReadOnly)
                            {
                                rowToUpdate[i] = editedValues[i];
                            }
                        }

                    }
                }
            }
        }


        private void mbSave_Click(object sender, EventArgs e)
        {
            TabPage currentTab = mtcAdmin.SelectedTab;

            foreach (Control control in currentTab.Controls)
            {
                if (control is DataGridView dataGridView)
                {
                    switch (dataGridView.Name)
                    {
                        case "mgProfessors":
                            SaveChangesToSelectedGrid<Professor>(dataGridView);
                            break;
                        case "mgStudents":
                            SaveChangesToSelectedGrid<Student>(dataGridView);
                            break;
                        case "mgGroups":
                            SaveChangesToSelectedGrid<Group>(dataGridView);
                            break;
                        case "mgProfessorCourseStudents":
                            SaveChangesToSelectedGrid<ProfessorCourseStudent>(dataGridView);
                            break;
                        case "mgDepartments":
                            SaveChangesToSelectedGrid<Department>(dataGridView);
                            break;
                        case "mgFaculties":
                            SaveChangesToSelectedGrid<Faculty>(dataGridView);
                            break;
                        case "mgGrades":
                            SaveChangesToSelectedGrid<Grade>(dataGridView);
                            break;
                        case "mgProfessorsCourses":
                            //SaveChangesToSelectedGrid<ProfessorCourse>(dataGridView);
                            break;
                        case "mgStudentCourses":
                            SaveChangesToSelectedGrid<StudentCours>(dataGridView);
                            break;
                        case "mgStudentDepartments":
                            //SaveChangesToSelectedGrid<StudentDepartment>(dataGridView);
                            break;
                        case "mgStudentGroup":
                            //SaveChangesToSelectedGrid<StudentGroup>(dataGridView);
                            break;
                        case "mgStudentYear":
                            SaveChangesToSelectedGrid<StudentYear>(dataGridView);
                            break;
                        case "mgYearTable":
                            SaveChangesToSelectedGrid<YearTable>(dataGridView);
                            break;
                        case "mgAttendance":
                            SaveChangesToSelectedGrid<Attendance>(dataGridView);
                            break;
                        case "mgCourses":
                            SaveChangesToSelectedGrid<Cours>(dataGridView);
                            break;

                        default:
                            break;
                    }
                    break;
                }
            }
        }

        private void SaveChangesToSelectedGrid<T>(DataGridView selectedDataGridView) where T : class
        {
            using (UMSContext dbContext = new UMSContext())
            {
                foreach (DataGridViewRow row in selectedDataGridView.Rows)
                {
                    if (row.Cells[0].Value != null)
                    {
                        if (typeof(T) == typeof(Professor))
                        {
                            string entityID = Convert.ToString(row.Cells[0].Value);
                            T entity = dbContext.Set<T>().Find(entityID);

                            if (entity != null)
                            {
                                UpdateEntityProperties(entity, selectedDataGridView, row);
                            }
                        }
                        else
                        {
                            int entityID = Convert.ToInt32(row.Cells[0].Value);
                            T entity = dbContext.Set<T>().Find(entityID);

                            if (entity != null)
                            {
                                UpdateEntityProperties(entity, selectedDataGridView, row);
                            }
                        }
                    }
                }

                dbContext.SaveChanges();
            }
        }

        private void UpdateEntityProperties<T>(T entity, DataGridView selectedDataGridView, DataGridViewRow row) where T : class
        {
            foreach (DataGridViewCell cell in row.Cells)
            {
                string columnName = selectedDataGridView.Columns[cell.ColumnIndex].DataPropertyName;
                object cellValue = cell.Value;

                var property = entity.GetType().GetProperty(columnName);
                property?.SetValue(entity, cellValue);
            }
        }

        private void mbRemove_Click(object sender, EventArgs e)
        {
            TabPage currentTab = mtcAdmin.SelectedTab;
            DataGridView selectedDataGridView = null;

            foreach (Control control in currentTab.Controls)
            {
                if (control is DataGridView dataGridView)
                {
                    selectedDataGridView = dataGridView;
                    break;
                }
            }

            if (selectedDataGridView != null && selectedDataGridView.SelectedRows.Count > 0)
            {
                int rowIndex = selectedDataGridView.SelectedRows[0].Index;

                selectedDataGridView.Rows.RemoveAt(rowIndex);
            }
        }

        public void RefreshAllGrids()
        {
            this.facultiesTableAdapter.Fill(this.uMSDataSet.Faculties);
            this.studentDepartmentTableAdapter.Fill(this.uMSDataSet.StudentDepartment);
            this.departmentsTableAdapter.Fill(this.uMSDataSet.Departments);
            this.studentYearTableAdapter.Fill(this.uMSDataSet.StudentYear);
            this.yearTableTableAdapter.Fill(this.uMSDataSet.YearTable);
            this.gradesTableAdapter.Fill(this.uMSDataSet.Grades);
            this.attendanceTableAdapter.Fill(this.uMSDataSet.Attendance);
            this.studentGroupTableAdapter.Fill(this.uMSDataSet.StudentGroup);
            this.studentCoursesTableAdapter.Fill(this.uMSDataSet.StudentCourses);
            this.professorCoursesTableAdapter.Fill(this.uMSDataSet.ProfessorCourses);
            this.coursesTableAdapter.Fill(this.uMSDataSet.Courses);
            this.professorsTableAdapter.Fill(this.uMSDataSet.Professors);
            this.professorCourseStudentsTableAdapter.Fill(this.uMSDataSet.ProfessorCourseStudents);
            this.studentsTableAdapter.Fill(this.uMSDataSet.Students);
            this.groupsTableAdapter.Fill(this.uMSDataSet.Groups);
        }

      
    }
}
