﻿using PrisonDataBase.PrisonDataBaseDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrisonDataBase
{
    public partial class EditVisitor : Form
    {
        private const string ConnectionString = "Data Source=DESKTOP-6BKJL0I\\MSSQL;Initial Catalog=PrisonDataBase;Integrated Security=True;Connect Timeout=30; TrustServerCertificate=True";

        private readonly int id;

        readonly bool edit;

        public EditVisitor()
        {
            InitializeComponent();

            edit = false;
        }

        private void EditVisitor_Load(object sender, EventArgs e)
        {
            this.visitorTableAdapter.Fill(this.prisonDataBaseDataSet.Visitor);
        }

        public EditVisitor(int id, string SNP, DateTime birth, string phoneNumber)
           : this()
        {
            edit = true;
            this.id = id;
            textBox_SNP.Text = SNP;
            dateTimePicker_DateOfBirth.Value = birth;
            textBox_PhoneNumber.Text = phoneNumber;
        }

        private bool IsPhoneNumberUnique(string phoneNumber)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string sqlQuery = "SELECT COUNT(*) FROM Visitor WHERE phone_number = @PhoneNumber";

                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@PhoneNumber", phoneNumber);

                    int count = (int)command.ExecuteScalar();

                    return count == 0;
                }
            }
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

            if (Regex.IsMatch(textBox_SNP.Text, @"\d"))
            {
                MessageBox.Show("SNP cannot contain numbers.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (textBox_SNP.Text.Length < 5)
            {
                MessageBox.Show("SNP must be at least 5 characters long.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!IsAdult(dateTimePicker_DateOfBirth.Value))
            {
                MessageBox.Show("Person must be 18 years or older.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (dateTimePicker_DateOfBirth.Value > DateTime.Now)
            {
                MessageBox.Show("Date of Birth cannot be in the future.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!Regex.IsMatch(textBox_PhoneNumber.Text, @"^\d{10}$"))
            {
                MessageBox.Show("Invalid phone number format. Please enter 10 digits.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            string phoneNumber = textBox_PhoneNumber.Text;

            if (!IsPhoneNumberUnique(phoneNumber))
            {
                MessageBox.Show("Phone number is already in use.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            if (edit)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to make these changes?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    visitorTableAdapter.UpdateQuery(textBox_SNP.Text,
                        dateTimePicker_DateOfBirth.Value.ToString("yyyy-MM-dd"),
                        textBox_PhoneNumber.Text,
                        id);
                    MessageBox.Show("Record updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }

            else
            {
                visitorTableAdapter.InsertQuery(textBox_SNP.Text,
                        dateTimePicker_DateOfBirth.Value.ToString("yyyy-MM-dd"),
                        textBox_PhoneNumber.Text);
                MessageBox.Show("Record added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            Close();
        }

        private void button_CANCEL_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}