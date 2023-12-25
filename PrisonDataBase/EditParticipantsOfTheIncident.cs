using PrisonDataBase.PrisonDataBaseDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrisonDataBase
{
    public partial class EditParticipantsOfTheIncident : Form
    {
        private const string ConnectionString = "Data Source=DESKTOP-6BKJL0I\\MSSQL;Initial Catalog=PrisonDataBase;Integrated Security=True;Connect Timeout=30; TrustServerCertificate=True";

        private readonly int id;

        readonly bool edit;

        public EditParticipantsOfTheIncident()
        {
            InitializeComponent();

            //this.incidentTableAdapter.Fill(this.prisonDataBaseDataSet.Incident);
            //this.personTableAdapter.Fill(this.prisonDataBaseDataSet.Person);
            this.prisonerTableAdapter.Fill(this.prisonDataBaseDataSet.Prisoner);
            this.committed_incidentTableAdapter.Fill(this.prisonDataBaseDataSet.Committed_incident);

            FillComboBox();
            FillComboBox1();

            edit = false;
        }

        private void EditParticipantsOfTheIncident_Load(object sender, EventArgs e)
        {
            this.participants_of_the_incidentTableAdapter.Fill(this.prisonDataBaseDataSet.Participants_of_the_incident);

            comboBox_SNP.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_Incident.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        public EditParticipantsOfTheIncident(int id, string incident, string SNP)
           : this()
        {
            incidentTableAdapter.Fill(prisonDataBaseDataSet.Incident);
            personTableAdapter.Fill(prisonDataBaseDataSet.Person);
            committed_incidentTableAdapter.Fill(prisonDataBaseDataSet.Committed_incident);

            edit = true;
            this.id = id;
            comboBox_Incident.SelectedValue = incident;
            comboBox_SNP.SelectedValue = SNP;
        }

        private void FillComboBox()
        {
            string query = @"SELECT Prisoner.prisoner_id, Person.SNP FROM Prisoner
                     INNER JOIN Person ON Prisoner.person_id = Person.person_id";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                comboBox_SNP.DataSource = dt;
                comboBox_SNP.DisplayMember = "SNP";
                comboBox_SNP.ValueMember = "prisoner_id";
            }
        }

        private void FillComboBox1()
        {
            string query = @"SELECT Committed_Incident.committed_incident_id, Incident.incident_type 
                     FROM Committed_Incident
                     INNER JOIN Incident ON Committed_Incident.incident_id = Incident.incident_id";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                comboBox_Incident.DataSource = dt;
                comboBox_Incident.DisplayMember = "incident_type";
                comboBox_Incident.ValueMember = "committed_incident_id";
            }
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