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
    public partial class EditParticipantsOfTheIncident : Form
    {
        private readonly int id;

        readonly bool edit;

        public EditParticipantsOfTheIncident()
        {
            InitializeComponent();

            edit = false;
        }

        private void EditParticipantsOfTheIncident_Load(object sender, EventArgs e)
        {
            this.participants_of_the_incidentTableAdapter.Fill(this.prisonDataBaseDataSet.Participants_of_the_incident);
            this.incidentTableAdapter.Fill(this.prisonDataBaseDataSet.Incident);
            this.personTableAdapter.Fill(this.prisonDataBaseDataSet.Person);
        }

        public EditParticipantsOfTheIncident(int id, string incident, string SNP)
           : this()
        {
            incidentTableAdapter.Fill(prisonDataBaseDataSet.Incident);
            personTableAdapter.Fill(prisonDataBaseDataSet.Person);

            edit = true;
            this.id = id;
            comboBox_Incident.SelectedValue = incident;
            comboBox_SNP.SelectedValue = SNP;
        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            if (edit)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to make these changes?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    participants_of_the_incidentTableAdapter.UpdateQuery(Convert.ToInt32(comboBox_Incident.SelectedValue),
                        Convert.ToInt32(comboBox_SNP.SelectedValue),
                        id);
                    MessageBox.Show("Record updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }

            else
            {
                participants_of_the_incidentTableAdapter.InsertQuery(Convert.ToInt32(comboBox_Incident.SelectedValue),
                        Convert.ToInt32(comboBox_SNP.SelectedValue));
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