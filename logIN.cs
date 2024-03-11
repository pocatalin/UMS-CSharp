using MetroFramework;
using MetroFramework.Forms;
using System;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Windows.Forms;

namespace PIProject
{
    public partial class logIN : MetroForm
    {
        private UMSContext UmsContext;
        private bool isPasswordVisible = false;
        private studentForm studentform;
        private professorForm professorform;
        private adminForm adminform;
        public logIN()
        {
            InitializeComponent();

            UmsContext = new UMSContext();
            btLogIn.Click += btLogIn_Click;
            tbUserID.KeyDown += tbUserID_KeyDown;
            tbPassword.KeyDown += tbPassword_KeyDown;
            tileShow.Click += tileShow_Click;
            labelOptions.Click += labelOptions_Click;
            tbPassword.PasswordChar = '*';
            this.Load += logIN_Load;
            isPasswordVisible = false;
            tileShow.TileImage = Properties.Resources.hidepass251;
            this.Resizable = false;
            this.MaximizeBox = false;

        }
        private void logIN_Load(object sender, EventArgs e)
        {
            tbUserID.Focus();

        }
        private void Studentform_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            this.Close();
            this.Dispose();
            this.Visible = false;
            Application.Exit();
        }
        private void Professorform_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            this.Close();

        }
        private void Adminform_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            this.Close();

        }
        private void tileShow_Click(object sender, EventArgs e)
        {
            isPasswordVisible = !isPasswordVisible;
            
            tileShow.TileImage = isPasswordVisible
                ? Properties.Resources.showpass25
                : Properties.Resources.hidepass251; 

            tbPassword.PasswordChar = isPasswordVisible ? '\0' : '*';
        }


        private void labelOptions_Click(object sender, EventArgs e)
        {
            options optionsLogInform =new options();
            optionsLogInform.ShowDialog();
        }
        private void tbUserID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btLogIn.PerformClick();
            }
        }

        private void tbPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btLogIn.PerformClick();
            }
        }


        private void btLogIn_Click(object sender, EventArgs e)
        {
            string enteredId = tbUserID.Text;
            string enteredPassword = tbPassword.Text;

            if (string.IsNullOrEmpty(enteredId) && string.IsNullOrEmpty(enteredPassword))
            {
                MessageBox.Show("User ID and Password must not be empty");
                return;
            }
            else if (string.IsNullOrEmpty(enteredId))
            {
                MessageBox.Show("User ID must not be empty");
                return;
            }
            else if (string.IsNullOrEmpty(enteredPassword))
            {
                MessageBox.Show("Password must not be empty");
                return;
            }
    


                if (!int.TryParse(enteredId, out int parsedId))
            {
                var professor = UmsContext.Professors.FirstOrDefault(p =>
                    p.ProfessorID == enteredId && p.ProfessorPassword == enteredPassword);

                if (professor != null)
                {
                    professorform = new professorForm(enteredId);
                    professorform.FormClosed += Professorform_FormClosed;
                    professorform.ShowDialog();
                    this.Hide();
                    return;
                }

                var admin = UmsContext.Admins.FirstOrDefault(a =>
                    a.AdminID == enteredId && a.AdminPassword == enteredPassword);

                if (admin != null)
                {
                    adminform = new adminForm(enteredId);
                    adminform.FormClosed += Adminform_FormClosed;
                    adminform.ShowDialog();
                    this.Hide();
                    return;
                }

                MessageBox.Show("Invalid login credentials.");
            }
            else
            {
                var student = UmsContext.Students.FirstOrDefault(s =>
                s.StudentID == parsedId && s.StudentPassword == enteredPassword);

                if (student != null)
                {
                    studentform = new studentForm(parsedId);
                    studentform.FormClosed += Studentform_FormClosed; 
                    studentform.ShowDialog();
                    this.Hide();
                    Application.Exit();
                    Environment.Exit(0);
                    return;
                }


                MessageBox.Show("Invalid login credentials.");
            }
       
        }

    
    }

}
