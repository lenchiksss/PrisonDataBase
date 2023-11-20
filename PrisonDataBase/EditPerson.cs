using PrisonDataBase.PrisonDataBaseDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrisonDataBase
{
    public partial class EditPerson : Form
    {
        private readonly int id;

        readonly bool edit;

        public EditPerson()
        {
            InitializeComponent();

            edit = false;
        }

        public EditPerson(int id, string SNP, DateTime birth, string gender)
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
        }

        private void EditPerson_Load(object sender, EventArgs e)
        {
            this.personTableAdapter.Fill(this.prisonDataBaseDataSet.Person);
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
                personTableAdapter.UpdateQuery(textBox_SNP.Text,
                          dateTimePicker_DateOfBirth.Value.ToString("yyyy-MM-dd"),
                          gender,
                          id);
            }
            else
            {
                personTableAdapter.InsertQuery(textBox_SNP.Text,
                          dateTimePicker_DateOfBirth.Value.ToString("yyyy-MM-dd"),
                          gender);
            }
            Close();
        }

        private void button_CANCEL_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}