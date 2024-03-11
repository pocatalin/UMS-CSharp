using MetroFramework.Controls;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;

namespace PIProject
{
    public partial class professorForm : MetroForm
    {
        private string profiD;
        private UMSContext UmsContext;
        private BindingSource gridBindingSource;
        private addGradeForm addGradeform;
        private addAttedanceForm addAttedanceform;
        private dataProfForm dataProfform;
        private Point mtAttaLocation;


        public professorForm(string profiD)
        {
            InitializeComponent();
            UmsContext = new UMSContext();
            this.profiD = profiD;
            metroGrid.Visible = false;
            UpdateLabelWithProfessorName();
            metroComboBoxGrades.Visible = false;
            gridBindingSource = new BindingSource();
            mtGrades.Click += mtGrades_Click;
            mtBack.Click += mtBack_Click;
            mtAttendance.Click += mtAttendance_Click;
            mtData.Click += mtData_Click;
            metroComboBoxGrades.Visible = false;
            metroComboBoxAttendance.Visible = false;
            flowLayoutPanelViewGrades.Visible = false;
            flowLayoutPanelAttedance.Visible = false;
            mtBack.Visible = false;
            metroComboBoxGrades.Items.Add("Add Grade");
            metroComboBoxGrades.Items.Add("View Grades");
            metroComboBoxAttendance.Items.Add("Add Attendance");
            metroComboBoxAttendance.Items.Add("View Attendances");
            flowLayoutPanelViewGrades.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanelAttedance.FlowDirection = FlowDirection.TopDown;
            mtAttaLocation = mtAttendance.Location;

            metroComboBoxGrades.SelectedIndexChanged += MetroComboBoxGrades_SelectedIndexChanged;
            metroComboBoxAttendance.SelectedIndexChanged += MetroComboBoxAttendance_SelectedIndexChanged;
            InitializeGrid();

            this.Resizable = false;
            this.MaximizeBox = false;


        }
        public void ResetGridBindings()
        {
            gridBindingSource.DataSource = null;
            metroGrid.DataSource = gridBindingSource;
            metroGrid.Visible = true;
        }

        private void mtData_Click(object sender, EventArgs e)
        {
            dataProfform = new dataProfForm(profiD);
            dataProfform.ShowDialog();
        }

        private void mtBack_Click(object sender, EventArgs e)
        {


            if (metroComboBoxGrades.Visible)
            {
                metroComboBoxGrades.Visible = false;
                mtAttendance.Visible = true;
                mtData.Visible = true;
                mtBack.Visible = false;
                gridBindingSource.DataSource = null;

            }
            else if (flowLayoutPanelViewGrades.Visible)
            {
                flowLayoutPanelViewGrades.Visible = false;
                metroComboBoxGrades.Visible = true;
                mtBack.Visible = true;
                metroComboBoxAttendance.Visible = false;
            }

            if (metroComboBoxAttendance.Visible)
            {
                metroComboBoxAttendance.Visible = false;
                mtGrades.Visible = true;
                mtBack.Visible = false;
                mtData.Visible = true;
                mtAttendance.Location = mtAttaLocation;
                gridBindingSource.DataSource = null;
            }
            else if (flowLayoutPanelAttedance.Visible)
            {
                flowLayoutPanelAttedance.Visible = false;
                metroComboBoxAttendance.Visible = true;
                mtBack.Visible = true;
                metroComboBoxGrades.Visible = false;
            }
           

        }
        private void mtGrades_Click(object sender, EventArgs e)
        {
            mtAttendance.Visible = false;
            mtData.Visible = false;
            mtBack.Visible = true;
            metroComboBoxGrades.Visible = true;
            metroGrid.Visible = true;
            if (metroComboBoxGrades.Visible)
            {
                metroComboBoxGrades.Location = new Point(17, 90);
            }
        }
        private void mtAttendance_Click(object sender, EventArgs e)
        {
            mtData.Visible = false;
            mtBack.Visible = true;
            mtGrades.Visible = false;
            metroGrid.Visible = true;
            mtAttendance.Location = mtGrades.Location;
            metroComboBoxAttendance.Visible = true;

            if (metroComboBoxAttendance.Visible)
            {
                metroComboBoxAttendance.Location = new Point(17, 90);
            }

            metroGridGrades.Visible = false;
        }
       
        private void makeStats(string profID)
        {
            gridBindingSource.DataSource = null;

            var courseData = UmsContext.Courses
                .Join(
                    UmsContext.Professors,
                    c => c.ProfessorID,
                    p => p.ProfessorID,
                    (c, p) => new
                    {
                        Course = c,
                        Professor = p
                    }
                )
                .Join(
                    UmsContext.Departments,
                    cp => cp.Course.DepartmentID,
                    d => d.DepartmentID,
                    (cp, d) => new
                    {
                        Course = cp.Course,
                        Professor = cp.Professor,
                        Department = d
                    }
                )
                .Join(
                    UmsContext.StudentCourses,
                    cpd => cpd.Course.CourseID,
                    sc => sc.CourseID,
                    (cpd, sc) => new
                    {
                        Course = cpd.Course,
                        Professor = cpd.Professor,
                        Department = cpd.Department,
                        StudentCourse = sc
                    }
                )
                .GroupJoin(
                    UmsContext.Grades,
                    scg => new { scg.Course.CourseID, scg.StudentCourse.StudentID },
                    g => new { g.CourseID, g.StudentID },
                    (scg, grades) => new
                    {
                        Course = scg.Course,
                        Professor = scg.Professor,
                        Department = scg.Department,
                        StudentCourse = scg.StudentCourse,
                        TotalGradesRecorded = grades.Count(),
                        AverageGrade = grades.Average(g => g.CourseGrade)
                    }
                )
                .GroupJoin(
                    UmsContext.Attendances,
                    scga => new { scga.Course.CourseID, scga.StudentCourse.StudentID },
                    a => new { a.CourseID, a.StudentID },
                    (scga, attendance) => new
                    {
                        Course = scga.Course,
                        Professor = scga.Professor,
                        Department = scga.Department,
                        StudentCourse = scga.StudentCourse,
                        TotalGradesRecorded = scga.TotalGradesRecorded,
                        AverageGrade = scga.AverageGrade,
                        TotalAttendance = attendance.Count(),
                        AverageAttendance = attendance.Average(a => a.TotalAttendance)
                    }
                )
                .Where(result => result.Professor.ProfessorID == profID)
                .Select(result => new
                {
                    result.Course.CourseName,
                    result.Course.Credits,
                    result.Department.DepartmentName,
                    result.StudentCourse.StudentID,
                    TotalEnrolledStudents = UmsContext.StudentCourses.Count(sc => sc.CourseID == result.Course.CourseID),
                    result.TotalGradesRecorded,
                    result.AverageGrade,
                    AverageAttendance = result.TotalAttendance != null ? result.AverageAttendance : (double?)0
                })
.ToList();


            gridBindingSource.DataSource = courseData;

            foreach (DataGridViewColumn column in metroGrid.Columns)
            {
                column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }
        private void seeStudents(string professorID)
        {
            gridBindingSource.DataSource = null;

            var studentData = (
                from student in UmsContext.Students
                join studentCourse in UmsContext.StudentCourses on student.StudentID equals studentCourse.StudentID
                join course in UmsContext.Courses on studentCourse.CourseID equals course.CourseID
                join grade in UmsContext.Grades on new { student.StudentID, course.CourseID } equals new { grade.StudentID, grade.CourseID }
                join attendance in UmsContext.Attendances on new { student.StudentID, course.CourseID } equals new { attendance.StudentID, attendance.CourseID }
                join professor in UmsContext.Professors on course.ProfessorID equals professor.ProfessorID
                where professor.ProfessorID == professorID
                select new
                {
                    FullName = student.FirstName + " " + student.LastName,
                    grade.LabGrade,
                    grade.CourseGrade,
                    grade.FinalGrade,
                    attendance.TotalAttendance
                }
            ).ToList();

            gridBindingSource.DataSource = studentData;

            foreach (DataGridViewColumn column in metroGrid.Columns)
            {
                column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }
        
        
        private void UpdateLabelWithProfessorName()
        {
            var professor = UmsContext.Professors.FirstOrDefault(s => s.ProfessorID == profiD);

            if (professor != null)
            {
                labelName.Text = $"Hello {professor.FirstName} {professor.LastName},";
            }
            else
            {
                labelName.Text = "Professor not found";
            }
        }
        private void InitializeGrid()
        {
            metroGrid.DataSource = gridBindingSource;
            metroGrid.DataSource = gridBindingSource;

            UmsContext.Courses.Load();

            var gradeData = UmsContext.Grades.Local
                .Select(g => new
                {
                    StudentFullName = $"{GetStudentFullName(g.StudentID)}",
                    g.LabGrade,
                    g.CourseGrade,
                    g.FinalGrade
                })
                .ToList();

            gridBindingSource.DataSource = gradeData;
        }
        private void MetroComboBoxGrades_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedOption = metroComboBoxGrades.SelectedItem?.ToString();

            switch (selectedOption)
            {
                case "Add Grade":
                    addGradeform = new addGradeForm(profiD,this);
                    addGradeform.ShowDialog();
                    break;
                case "View Grades":
                    metroComboBoxGrades.Visible = false;
                    flowLayoutPanelViewGrades.Location = new Point(17, 90);
                    flowLayoutPanelViewGrades.Visible = true;
                    ClearControls(flowLayoutPanelViewGrades);
                    var courses = UmsContext.Courses.Where(g => g.ProfessorID == profiD).ToList();
                    if (courses.Any())
                    {
                        foreach (var course in courses)
                        {
                            CreateCourseButton(course);
                        }

                    }
                    else
                    {
                        MessageBox.Show("No courses found for the student.");
                    }
                    break;
            }
        }
        private void MetroComboBoxAttendance_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedOption = metroComboBoxAttendance.SelectedItem?.ToString();

            switch (selectedOption)
            {
                case "Add Attendance":
                    addAttedanceform = new addAttedanceForm(profiD, this);
                    addAttedanceform.ShowDialog();
                    break;
                case "View Attendances":
                    metroComboBoxAttendance.Visible = false;
                    flowLayoutPanelAttedance.Location = new Point(17, 90);
                    flowLayoutPanelAttedance.Visible = true;
                    ClearControls(flowLayoutPanelAttedance);

                    var courseIDs = UmsContext.Courses
                        .Where(c => c.ProfessorID == profiD)
                        .Select(c => c.CourseID)
                        .Distinct()
                        .ToList();

                    if (courseIDs.Any())
                    {
                        foreach (var courseID in courseIDs)
                        {
                            CreateAttendancesButton(courseID);
                        }
                    }
                    else
                    {
                        MessageBox.Show("No courses found for the professor.");
                    }
                    break;
            }
        }
        private void CreateAttendancesButton(int courseID)
        {
            MetroButton button = new MetroButton();
            button.Text = GetCourseName(courseID);
            Size textSize = TextRenderer.MeasureText(button.Text, button.Font);
            button.Size = new Size(textSize.Width + 20, textSize.Height + 10);
            button.Click += (sender, e) => { LoadDataForAttendance(courseID); };
            button.Margin = new Padding(0, 0, 0, 5);

            flowLayoutPanelAttedance.Controls.Add(button);
            flowLayoutPanelAttedance.FlowDirection = FlowDirection.TopDown;
        }
        private void CreateCourseButton(Cours course)
        {
            MetroButton button = new MetroButton();
            button.Text = GetCourseName(course.CourseID);
            int courseID = Convert.ToInt32(course.CourseID);
            Size textSize = TextRenderer.MeasureText(button.Text, button.Font);
            button.Size = new Size(textSize.Width + 20, textSize.Height + 10);

            button.Margin = new Padding(0, 0, 0, 5);
            button.Click += (sender, e) => { LoadDataForCourse(courseID); };

            flowLayoutPanelViewGrades.Controls.Add(button);

            flowLayoutPanelViewGrades.FlowDirection = FlowDirection.TopDown;
        }
        void LoadDataForCourse(int courseID)
        {
            gridBindingSource.DataSource = null;
            var gradeData = UmsContext.Grades
                .Where(g => g.CourseID == courseID)
                .Join(
                    UmsContext.Students,
                    g => g.StudentID,
                    s => s.StudentID,
                    (g, s) => new
                    {
                        StudentName = s.FirstName + " " + s.LastName,
                        g.LabGrade,
                        g.CourseGrade,
                        g.FinalGrade
                    }
                )
                .ToList();

            var gradeDataWithCourseName = gradeData.Select(g => new
            {
                g.StudentName,
                g.LabGrade,
                g.CourseGrade,
                g.FinalGrade
            });

            gridBindingSource.DataSource = gradeDataWithCourseName.ToList();

            foreach (DataGridViewColumn column in metroGrid.Columns)
            {
                column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

        }
        private void LoadDataForAttendance(int courseID)
        {
            gridBindingSource.DataSource = null;

            var attendanceData = UmsContext.Attendances
                .Where(A => A.CourseID == courseID)
                .Join(
                    UmsContext.Students,
                    A => A.StudentID,
                    S => S.StudentID,
                    (A, S) => new
                    {
                        StudentName = S.FirstName + " " + S.LastName,
                        A.W1,
                        A.W2,
                        A.W3,
                        A.W4,
                        A.W5,
                        A.W6,
                        A.W7,
                        A.W8,
                        A.W9,
                        A.W10,
                        A.W11,
                        A.W12,
                        A.W13,
                        A.W14,
                        A.TotalAttendance
                    }
                )
                .ToList();

            var attendanceDataWithCourseName = attendanceData.Select(a => new
            {
                a.StudentName,
                a.W1,
                a.W2,
                a.W3,
                a.W4,
                a.W5,
                a.W6,
                a.W7,
                a.W8,
                a.W9,
                a.W10,
                a.W11,
                a.W12,
                a.W13,
                a.W14,
                a.TotalAttendance
            });

            gridBindingSource.DataSource = attendanceDataWithCourseName.ToList();

            for (int i = 1; i <= 14; i++)
            {
                string columnName = "W" + i;
                var column = metroGrid.Columns[columnName];
                column.Width = 25;

                column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            var nameColumn = metroGrid.Columns["StudentName"];
            nameColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            nameColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            var totalColumn = metroGrid.Columns["TotalAttendance"];
            totalColumn.Width = 90;
            totalColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            totalColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
        private void ClearControls(FlowLayoutPanel flowLayoutPanel)
        {
            flowLayoutPanel.Controls.Clear();
        }
        private string GetCourseName(int courseId)
        {
            var course = UmsContext.Courses.FirstOrDefault(c => c.CourseID == courseId);
            return course != null ? course.CourseName : $"CourseID: {courseId}";
        }
        private string GetStudentFullName(int studentID)
        {
            var student = UmsContext.Students.FirstOrDefault(s => s.StudentID == studentID);
            return student != null ? $"{student.FirstName} {student.LastName}" : "Unknown";
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


    }
}
