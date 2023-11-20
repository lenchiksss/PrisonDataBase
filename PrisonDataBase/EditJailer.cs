using PrisonDataBase.PrisonDataBaseDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrisonDataBase
{
    public partial class EditJailer : Form
    {
        private readonly int id;

        readonly bool edit;

        public EditJailer()
        {
            InitializeComponent();
            numericUpDown_Salary.Minimum = 0;

            edit = false;
        }

        public EditJailer(int id, string SNP, DateTime birth, string gender, DateTime hireDate, string phoneNumber, string email, decimal salary)
           : this()
        {
            edit = true;
            this.id = id;
            textBox_SNP.Text = SNP;
            dateTimePicker_DateOfBirth.Value = birth;

            switch (gender.ToLower())
            {
                case "male":
                    comboBox_Gender.SelectedIndex = 0;
                    break;
                case "female":
                    comboBox_Gender.SelectedIndex = 1;
                    break;
                default:
                    comboBox_Gender.SelectedIndex = 0;
                    break;
            }

            dateTimePicker_HireDate.Value = hireDate;
            textBox_PhoneNumber.Text = phoneNumber;
            textBox_Email.Text = email;
            numericUpDown_Salary.Text = salary.ToString();
        }

        private bool IsAdult(DateTime birthDate)
        {
            int age = DateTime.Now.Year - birthDate.Year;
            if (DateTime.Now.Month < birthDate.Month || (DateTime.Now.Month == birthDate.Month && DateTime.Now.Day < birthDate.Day))
            {
                age--;
            }
            return age >= 18;
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(textBox_SNP.Text))
            {
                MessageBox.Show("SNP cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (dateTimePicker_DateOfBirth.Value > DateTime.Now)
            {
                MessageBox.Show("Date of Birth cannot be in the future.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (dateTimePicker_HireDate.Value > DateTime.Now || dateTimePicker_HireDate.Value < dateTimePicker_DateOfBirth.Value)
            {
                MessageBox.Show("Hire Date is invalid.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!Regex.IsMatch(textBox_PhoneNumber.Text, @"^\d{10}$"))
            {
                MessageBox.Show("Invalid phone number format. Please enter 10 digits.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!IsAdult(dateTimePicker_DateOfBirth.Value))
            {
                MessageBox.Show("Person must be 18 years or older.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }


        private void button_OK_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
            {
                return;
            }

            string gender = "";
            if (comboBox_Gender.SelectedIndex == 0)
            {
                gender = "male";
            }
            else if (comboBox_Gender.SelectedIndex == 1)
            {
                gender = "female";
            }

            if (edit)
            {
                if (decimal.TryParse(numericUpDown_Salary.Text, out decimal salaryValue))
                {
                    jailerTableAdapter.UpdateQuery(textBox_SNP.Text,
                        dateTimePicker_DateOfBirth.Value.ToString("yyyy-MM-dd"),
                        gender,
                        dateTimePicker_HireDate.Value.ToString("yyyy-MM-dd"),
                        textBox_PhoneNumber.Text,
                        textBox_Email.Text,
                        salaryValue,
                        id);
                }
            }
            else
            {
                if (decimal.TryParse(numericUpDown_Salary.Text, out decimal salaryValue))
                {
                    jailerTableAdapter.InsertQuery(textBox_SNP.Text,
                        dateTimePicker_DateOfBirth.Value.ToString("yyyy-MM-dd"),
                        gender,
                        dateTimePicker_HireDate.Value.ToString("yyyy-MM-dd"),
                        textBox_PhoneNumber.Text,
                        textBox_Email.Text,
                        salaryValue);
                }
            }
            Close();
        }

        private void EditJailer_Load(object sender, EventArgs e)
        {
            this.jailerTableAdapter.Fill(this.prisonDataBaseDataSet.Jailer);
        }
    }
}