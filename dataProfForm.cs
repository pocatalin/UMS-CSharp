using MetroFramework.Controls;
using MetroFramework.Forms;
using System;
using System.Linq;
using System.Windows.Forms;

namespace PIProject
{
    public partial class dataProfForm : MetroForm
    {
        private string profID;
        private UMSContext UmsContext;
        private int firstNameClickCount = 0;
        private PictureBox secretPictureBox;
        public dataProfForm(string profID)
        {
            InitializeComponent();
            UmsContext = new UMSContext();
            this.profID = profID;
            mtbPassword.PasswordChar = '*';
            mtbUnlock.Click += MtbUnlock_Click;
            flowLayoutPanelData.FlowDirection = FlowDirection.TopDown;
            metroTabControlData.TabPages.Remove(mtpPersonal);
            metroTabControlData.TabPages.Remove(mtpSecret);
            
            mtbPassword.KeyDown += MtbPassword_KeyDown;

            secretPictureBox = new PictureBox();
            secretPictureBox.Dock = DockStyle.Fill;
            secretPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            secretPictureBox.Image = Properties.Resources.secret;

            mtpSecret.Controls.Add(secretPictureBox);
        }

        private void MtbPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                mtbUnlock.PerformClick();
            }
        }



        private void MtbUnlock_Click(object sender, EventArgs e)
        {
            var professor = UmsContext.Professors.FirstOrDefault(p => p.ProfessorID == profID);

            if (professor != null)
            {
                string correctPassword = professor.ProfessorPassword;

                if (mtbPassword.Text == correctPassword)
                {
                    metroTabControlData.TabPages.Add(mtpPersonal);
                    metroTabControlData.SelectedTab = mtpPersonal;

                    DisplayDataInFlowLayoutPanelData();
                }
                else
                {
                    MessageBox.Show("Incorrect password. BYE");
                    Application.Exit();
                }
            }
            else
            {
                MessageBox.Show("Professor not found.");
            }
        }

        private void DisplayDataInFlowLayoutPanelData()
        {
            var professor = UmsContext.Professors.FirstOrDefault(s => s.ProfessorID == profID);

            if (professor != null)
            {
                CreateLabelAndTextbox("First Name", professor.FirstName);
                CreateLabelAndTextbox("Last Name", professor.LastName);
                CreateLabelAndTextbox("CNP", professor.CNP.ToString());
                CreateLabelAndTextbox("Date of Birth", professor.DateOfBirth.ToString("yyyy-MM-dd"));
                CreateLabelAndTextbox("Email", professor.Email);
                CreateLabelAndTextbox("Phone Number", professor.PhoneNumber);
                CreateLabelAndTextbox("Address", professor.Address);
                CreateLabelAndTextbox("Faculty", GetFacultyName(professor.FacultyID).ToString());
                CreateLabelAndTextbox("Department", GetDepartmentName(professor.DepartmentID).ToString());
            }
            else
            {
                MessageBox.Show("Professor not found");
            }
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

        private void CreateLabelAndTextbox(string labelText, string textboxText)
        {
            int maxWidth = 60;

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
            textBox.Width = 175;
            textBox.Dock = DockStyle.Fill;

            label.Click += Label_Click;

            panel.Controls.Add(label);
            panel.Controls.Add(textBox);

            flowLayoutPanelData.Controls.Add(panel);
        }
        private void Label_Click(object sender, EventArgs e)
        {
            MetroLabel clickedLabel = (MetroLabel)sender;
            if (clickedLabel.Text == "First Name")
            {
                firstNameClickCount++;

                if (firstNameClickCount == 5)
                {
                    metroTabControlData.TabPages.Add(mtpSecret);
                }
            }
        }


        }
}
