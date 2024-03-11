using MetroFramework.Forms;
using System;
using System.Linq;
using System.Net.NetworkInformation;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

namespace PIProject
{
    public partial class options : MetroForm
    {
        private UMSContext UmsContext;
        private bool isOldPasswordVisible = false;
        private bool isNewPasswordVisible = false;

        public options()
        {
           

            InitializeComponent();
            UmsContext = new UMSContext();
            UmsContext = new UMSContext();
            btSave.Click += btSave_Click;
            tbOldPassword.PasswordChar = '*';
            tbNewPassword.PasswordChar = '*';
            tbNewPassword.MaxLength = 6;
            tileShowOld.Click += tileShowOld_Click;
            tileShowNew.Click += tileShowNew_Click;

            isNewPasswordVisible = false;
            isOldPasswordVisible = false;
            tileShowOld.TileImage = Properties.Resources.hidepass251;
            tileShowNew.TileImage = Properties.Resources.hidepass251;
            this.Resizable = false;
            this.MaximizeBox = false;

        }
      
        private void tileShowOld_Click(object sender, EventArgs e)
        {
            isOldPasswordVisible = !isOldPasswordVisible;

            tileShowOld.TileImage = isOldPasswordVisible
                ? Properties.Resources.showpass25
                : Properties.Resources.hidepass251;

            tbOldPassword.PasswordChar = isOldPasswordVisible ? '\0' : '*';
        }
        private void tileShowNew_Click(object sender, EventArgs e)
        {
            isNewPasswordVisible = !isNewPasswordVisible;

            tileShowNew.TileImage = isNewPasswordVisible
                ? Properties.Resources.showpass25
                : Properties.Resources.hidepass251;

            tbNewPassword.PasswordChar = isNewPasswordVisible ? '\0' : '*';
        }


        private void btSave_Click(object sender, EventArgs e)
        {
            string enteredId = tbUserID.Text;
            string enteredOldPassword = tbOldPassword.Text;
            string newpassword = tbNewPassword.Text;

            if (string.IsNullOrEmpty(enteredId) || string.IsNullOrEmpty(enteredOldPassword) || string.IsNullOrEmpty(newpassword))
            {
                MessageBox.Show("All fields must be filled");
                return;
            }

            if (newpassword.Length < 6)
            {
                MessageBox.Show("New password must be at least 6 characters long.");
                return;
            }

            if (newpassword == enteredOldPassword)
            {
                MessageBox.Show("New password must be different from the old one.");
                return;
            }

            string missingRequirements = "";

            if (!HasSymbol(newpassword))
            {
                missingRequirements += "Symbols, ";
            }

            if (!HasLowerCase(newpassword))
            {
                missingRequirements += "Lowercase letters, ";
            }

            if (!HasUpperCase(newpassword))
            {
                missingRequirements += "Uppercase letters, ";
            }

            if (!HasDigit(newpassword))
            {
                missingRequirements += "Numbers, ";
            }

            if (!string.IsNullOrEmpty(missingRequirements))
            {
                missingRequirements = missingRequirements.TrimEnd(',', ' ');

                MessageBox.Show($"New password must contain {missingRequirements}.");
                return;
            }

            if (!int.TryParse(enteredId, out int parsedId))
            {
                var professor = UmsContext.Professors.FirstOrDefault(p =>
                    p.ProfessorID == enteredId && p.ProfessorPassword == enteredOldPassword);

                if (professor != null)
                {
                    professor.ProfessorPassword = newpassword;
                    UmsContext.SaveChanges();
                    MessageBox.Show("Password updated successfully for professor.");
                    return;
                }

                var admin = UmsContext.Admins.FirstOrDefault(a =>
                    a.AdminID == enteredId && a.AdminPassword == enteredOldPassword);

                if (admin != null)
                {
                    admin.AdminPassword = newpassword;
                    UmsContext.SaveChanges();
                    MessageBox.Show("Password updated successfully for admin.");
                    return;
                }

                MessageBox.Show("Invalid credentials.");
            }
            else
            {
                var student = UmsContext.Students.FirstOrDefault(s =>
                    s.StudentID == parsedId && s.StudentPassword == enteredOldPassword);

                if (student != null)
                {
                    student.StudentPassword = newpassword;
                    UmsContext.SaveChanges();
                    MessageBox.Show("Password updated successfully for student.");
                    return;
                }

                MessageBox.Show("Invalid credentials.");
            }
        }

        private bool HasSymbol(string password)
        {
            string symbols = "!@#$%^&*()_+<>,./?;'[]\\:\"{}|";
            return password.Any(c => symbols.Contains(c));
        }

        private bool HasLowerCase(string password)
        {
            return password.Any(char.IsLower);
        }

        private bool HasUpperCase(string password)
        {
            return password.Any(char.IsUpper);
        }

        private bool HasDigit(string password)
        {
            return password.Any(char.IsDigit);
        }
    }
}
