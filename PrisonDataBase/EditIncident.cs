using PrisonDataBase.PrisonDataBaseDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrisonDataBase
{
    public partial class EditIncident : Form
    {
        private readonly int id;

        readonly bool edit;

        public EditIncident()
        {
            InitializeComponent();

            edit = false;
        }

        private void EditIncident_Load(object sender, EventArgs e)
        {
            this.incidentTableAdapter.Fill(this.prisonDataBaseDataSet.Incident);
        }

        public EditIncident(int id, string type, string description)
           : this()
        {
            edit = true;
            this.id = id;

            textBox_Type.Text = type;
            textBox_Description.Text = description;
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(textBox_Type.Text))
            {
                MessageBox.Show("Type cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (Regex.IsMatch(textBox_Type.Text, @"\d"))
            {
                MessageBox.Show("SNP cannot contain numbers.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (textBox_Type.Text.Length < 3)
            {
                MessageBox.Show("Type must be at least 5 characters long.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(textBox_Description.Text))
            {
                MessageBox.Show("Description cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (textBox_Type.Text.Length < 3)
            {
                MessageBox.Show("Description must be at least 5 characters long.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    incidentTableAdapter.UpdateQuery(textBox_Type.Text,
                          textBox_Description.Text,
                          id);
                    MessageBox.Show("Record updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            else
            {
                incidentTableAdapter.InsertQuery(textBox_Type.Text,
                          textBox_Description.Text);
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