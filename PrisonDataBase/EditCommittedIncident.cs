using PrisonDataBase.PrisonDataBaseDataSetTableAdapters;
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

namespace PrisonDataBase
{
    public partial class EditCommittedIncident : Form
    {
        private readonly int id;

        readonly bool edit;

        public EditCommittedIncident()
        {
            InitializeComponent();

            edit = false;
        }

        private void EditCommittedIncident_Load(object sender, EventArgs e)
        {
            this.committed_incidentTableAdapter.Fill(this.prisonDataBaseDataSet.Committed_incident);
            this.incidentTableAdapter.Fill(this.prisonDataBaseDataSet.Incident);
        }

        public EditCommittedIncident(int id, DateTime dateOfIncident, string timeOfIncident, int type)
           : this()
        {
            incidentTableAdapter.Fill(prisonDataBaseDataSet.Incident);

            edit = true;
            this.id = id;

            dateTimePicker_IncidentDate.Value = dateOfIncident;
            textBox_TimeOfIncident.Text = timeOfIncident;
            comboBox_Type.SelectedIndex = type;
        }

        private bool ValidateInput()
        {
            string[] formats = { "HH:mm:ss" };
            DateTime result;

            if (DateTime.TryParseExact(textBox_TimeOfIncident.Text, formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out result))
            {
                return true;
            }
            else
            {
                MessageBox.Show("The time format is incorrect. Enter the time in the format 'hh:mm:ss'.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
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
                    committed_incidentTableAdapter.UpdateQuery(dateTimePicker_IncidentDate.Value.ToString("yyyy-MM-dd"),
                          textBox_TimeOfIncident.Text,
                          Convert.ToInt32(comboBox_Type.SelectedValue),
                          id);
                    MessageBox.Show("Record updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }

            else
            {
                committed_incidentTableAdapter.InsertQuery(dateTimePicker_IncidentDate.Value.ToString("yyyy-MM-dd"),
                          textBox_TimeOfIncident.Text,
                          Convert.ToInt32(comboBox_Type.SelectedValue));
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