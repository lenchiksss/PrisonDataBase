using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrisonDataBase
{
    public partial class MainForm : Form
    {
        private const string ConnectionString = "Data Source=DESKTOP-6BKJL0I\\MSSQL;Initial Catalog=PrisonDataBase;Integrated Security=True;Connect Timeout=30; TrustServerCertificate=True";

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //string query = "UPDATE Prisoner " +
            //   "SET person_id = Person.SNP " +
            //   "FROM Prisoner " +
            //   "JOIN Person ON Prisoner.person_id = Person.person_id";

            //using (SqlConnection connection = new SqlConnection(ConnectionString))
            //{
            //    connection.Open();

            //    // Используйте SqlDataAdapter для выполнения запроса и заполнения DataTable
            //    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
            //    DataTable dataTable = new DataTable();
            //    dataAdapter.Fill(dataTable);

            //    // Установка источника данных для DataGridView
            //    dataGridView1.DataSource = dataTable;
            //}

            this.prisonerTableAdapter.Fill(this.prisonDataBaseDataSet.Prisoner);
            this.visitorTableAdapter.Fill(this.prisonDataBaseDataSet.Visitor);
            this.visitTableAdapter.Fill(this.prisonDataBaseDataSet.Visit);  
            this.participants_of_the_incidentTableAdapter.Fill(this.prisonDataBaseDataSet.Participants_of_the_incident);  
            this.jailer_on_shiftTableAdapter.Fill(this.prisonDataBaseDataSet.Jailer_on_shift);
            this.incidentTableAdapter.Fill(this.prisonDataBaseDataSet.Incident);
            this.committed_incidentTableAdapter.Fill(this.prisonDataBaseDataSet.Committed_incident);
            this.cellTableAdapter.Fill(this.prisonDataBaseDataSet.Cell);
            this.jailerTableAdapter.Fill(this.prisonDataBaseDataSet.Jailer);
            this.prisonerTableAdapter.Fill(this.prisonDataBaseDataSet.Prisoner);
            this.personTableAdapter.Fill(this.prisonDataBaseDataSet.Person);

            dataGridView1.AutoGenerateColumns = true;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            personTableAdapter.Update(prisonDataBaseDataSet);
            prisonerTableAdapter.Update(prisonDataBaseDataSet);
            jailerTableAdapter.Update(prisonDataBaseDataSet);
            cellTableAdapter.Update(prisonDataBaseDataSet);
            committed_incidentTableAdapter.Update(prisonDataBaseDataSet);
            incidentTableAdapter.Update(prisonDataBaseDataSet);
            jailer_on_shiftTableAdapter.Update(prisonDataBaseDataSet);
            participants_of_the_incidentTableAdapter.Update(prisonDataBaseDataSet);
            visitTableAdapter.Update(prisonDataBaseDataSet);
            visitorTableAdapter.Update(prisonDataBaseDataSet);
        }

        private void personToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bindingNavigator1.BindingSource = personBindingSource;
            dataGridView1.DataSource = personBindingSource;
            label1.Text = "Persons";
        }

        private void prisonerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bindingNavigator1.BindingSource = prisonerBindingSource;
            dataGridView1.DataSource = prisonerBindingSource;
            label1.Text = "Prisoners";

            string query = @"
                SELECT Prisoner.prisoner_id,
                Prisoner.incarceration_date, Prisoner.release_date, Prisoner.number_of_article,
                Person.SNP, Cell.cell_number
                FROM Prisoner
                LEFT JOIN Person ON Prisoner.person_id = Person.person_id
                LEFT JOIN Cell ON Prisoner.cell_id = Cell.cell_id
            ";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                prisonerBindingSource.DataSource = dataTable;
                bindingNavigator1.BindingSource = prisonerBindingSource;
                dataGridView1.DataSource = prisonerBindingSource;
            }
        }

        private void jailerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bindingNavigator1.BindingSource = jailerBindingSource;
            dataGridView1.DataSource = jailerBindingSource;
            label1.Text = "Jailers";
        }

        private void jailerOnShiftToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bindingNavigator1.BindingSource = jaileronshiftBindingSource;
            dataGridView1.DataSource = jaileronshiftBindingSource;
            label1.Text = "Jailers on shift";

            string query = @"
                SELECT Jailer_on_shift.jailer_on_shift_id,
                Jailer_on_shift.shift_date,
                Jailer.SNP, Cell.cell_number
                FROM Jailer_on_shift
                LEFT JOIN Jailer ON Jailer_on_shift.jailer_id = Jailer.jailer_id
                LEFT JOIN Cell ON Jailer_on_shift.cell_id = Cell.cell_id
            ";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                jaileronshiftBindingSource.DataSource = dataTable;
                bindingNavigator1.BindingSource = jaileronshiftBindingSource;
                dataGridView1.DataSource = jaileronshiftBindingSource;
            }
        }

        private void cellToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bindingNavigator1.BindingSource = cellBindingSource;
            dataGridView1.DataSource = cellBindingSource;
            label1.Text = "Cells";
        }

        private void visitorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bindingNavigator1.BindingSource = visitorBindingSource;
            dataGridView1.DataSource = visitorBindingSource;
            label1.Text = "Visitors";
        }

        private void visitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bindingNavigator1.BindingSource = visitBindingSource;
            dataGridView1.DataSource = visitBindingSource;
            label1.Text = "Visits";

            string query = @"
                SELECT Visit.visit_id, Visit.relation_to_the_prisoner, Visit.date_of_visit, Visit.time_of_visit,
                Visitor.SNP AS Visitors_SNP, Person.SNP AS Prisoners_SNP
                FROM Visit
                LEFT JOIN Visitor ON Visit.visitor_id = Visitor.visitor_id
                LEFT JOIN Person ON Visit.prisoner_id = Person.person_id
            ";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                visitBindingSource.DataSource = dataTable;
                bindingNavigator1.BindingSource = visitBindingSource;
                dataGridView1.DataSource = visitBindingSource;
            }
        }

        private void incidentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bindingNavigator1.BindingSource = incidentBindingSource;
            dataGridView1.DataSource = incidentBindingSource;
            label1.Text = "Incidents";
        }

        private void comittedIncidentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bindingNavigator1.BindingSource = committedincidentBindingSource;
            dataGridView1.DataSource = committedincidentBindingSource;
            label1.Text = "Committed incidents";

            string query = @"
                SELECT Committed_incident.committed_incident_id, Committed_incident.date_of_incident, Committed_incident.time_of_incident,
                Incident.incident_type AS Incident_type
                FROM Committed_incident
                LEFT JOIN Incident ON Committed_incident.incident_id = Incident.incident_id
            ";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                committedincidentBindingSource.DataSource = dataTable;
                bindingNavigator1.BindingSource = committedincidentBindingSource;
                dataGridView1.DataSource = committedincidentBindingSource;
            }
        }

        private void participantsOfTheIncidentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bindingNavigator1.BindingSource = participantsoftheincidentBindingSource;
            dataGridView1.DataSource = participantsoftheincidentBindingSource;
            label1.Text = "Participants of the incidents";

            string query = @"
                SELECT Participants_of_the_incident.committed_incident_id,
                Incident.incident_type AS Incident_type, Person.SNP AS Prisoners_SNP
                FROM Participants_of_the_incident
                LEFT JOIN Incident ON Participants_of_the_incident.committed_incident_id = Incident.incident_id
                LEFT JOIN Person ON Participants_of_the_incident.prisoner_id = Person.person_id
            ";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                participantsoftheincidentBindingSource.DataSource = dataTable;
                bindingNavigator1.BindingSource = participantsoftheincidentBindingSource;
                dataGridView1.DataSource = participantsoftheincidentBindingSource;
            }
        }

        private bool edit;

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bindingNavigator1.BindingSource == personBindingSource)
            {
                edit = false;
                var edt = new EditPerson();
                edt.ShowDialog();
                personTableAdapter.Fill(prisonDataBaseDataSet.Person);
                prisonDataBaseDataSet.AcceptChanges();
            }

            if (bindingNavigator1.BindingSource == prisonerBindingSource)
            {
                edit = false;
                var edt = new EditPrisoner();
                edt.ShowDialog();
                prisonerTableAdapter.Fill(prisonDataBaseDataSet.Prisoner);
                prisonDataBaseDataSet.AcceptChanges();
            }

            if (bindingNavigator1.BindingSource == jailerBindingSource)
            {
                edit = false;
                var edt = new EditJailer();
                edt.ShowDialog();
                jailerTableAdapter.Fill(prisonDataBaseDataSet.Jailer);
                prisonDataBaseDataSet.AcceptChanges();
            }
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            edit = true;

            if (bindingNavigator1.BindingSource == personBindingSource)
            {
                var st = new PrisonDataBaseDataSet.PersonDataTable();
                personTableAdapter.FillBy(st,
                Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value));
                object[] row = st.Rows[0].ItemArray;
                var edt = new EditPerson(
                    Convert.ToInt32(row[0]),
                    row[1].ToString(),
                    Convert.ToDateTime(row[2]),
                    row[3].ToString()
                );
                edt.ShowDialog();
                personTableAdapter.Fill(prisonDataBaseDataSet.Person);
                prisonDataBaseDataSet.AcceptChanges();
            }

            if (bindingNavigator1.BindingSource == prisonerBindingSource)
            {
                var st = new PrisonDataBaseDataSet.PrisonerDataTable();
                prisonerTableAdapter.FillBy(st,
                Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value));
                object[] row = st.Rows[0].ItemArray;
                var edt = new EditPrisoner(
                    Convert.ToInt32(row[0]),
                    Convert.ToDateTime(row[1]),
                    Convert.ToDateTime(row[2]),
                    row[3].ToString(),
                    row[4].ToString(),
                    Convert.ToInt32(row[5])
                );
                edt.ShowDialog();
                prisonerTableAdapter.Fill(prisonDataBaseDataSet.Prisoner);
                prisonDataBaseDataSet.AcceptChanges();
            }

            if (bindingNavigator1.BindingSource == jailerBindingSource)
            {
                var st = new PrisonDataBaseDataSet.JailerDataTable();
                jailerTableAdapter.FillBy(st,
                Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value));
                object[] row = st.Rows[0].ItemArray;
                decimal decimalValue;
                if (decimal.TryParse(row[7].ToString(), out decimalValue))
                {
                    var edt = new EditJailer(
                        Convert.ToInt32(row[0]),
                        row[1].ToString(),
                        Convert.ToDateTime(row[2]),
                        row[3].ToString(),
                        Convert.ToDateTime(row[4]),
                        row[5].ToString(),
                        row[6].ToString(),
                        decimalValue
                    );

                    edt.ShowDialog();
                    jailerTableAdapter.Fill(prisonDataBaseDataSet.Jailer);
                    prisonDataBaseDataSet.AcceptChanges();
                }
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bindingNavigator1.BindingSource == personBindingSource)
            {
                personTableAdapter.DeleteQuery(Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value));
                personTableAdapter.Fill(prisonDataBaseDataSet.Person);
                prisonDataBaseDataSet.AcceptChanges();
            }

            if (bindingNavigator1.BindingSource == prisonerBindingSource)
            {
                prisonerTableAdapter.DeleteQuery(Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value));
                prisonerTableAdapter.Fill(prisonDataBaseDataSet.Prisoner);
                prisonDataBaseDataSet.AcceptChanges();
            }

            if (bindingNavigator1.BindingSource == jailerBindingSource)
            {
                jailerTableAdapter.DeleteQuery(Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value));
                jailerTableAdapter.Fill(prisonDataBaseDataSet.Jailer);
                prisonDataBaseDataSet.AcceptChanges();
            }
        }

        private void textBox_Search_TextChanged(object sender, EventArgs e)
        {
            string searchText = textBox_Search.Text.Trim();

            if (bindingNavigator1.BindingSource == personBindingSource)
            {
                personBindingSource.Filter = $"SNP LIKE '%{searchText}%'";
            }

            if (bindingNavigator1.BindingSource == prisonerBindingSource)
            {
                prisonerBindingSource.Filter = $"number_of_article LIKE '%{searchText}%'";
            }

            if (bindingNavigator1.BindingSource == jailerBindingSource)
            {
                jailerBindingSource.Filter = $"SNP LIKE '%{searchText}%' OR email LIKE '%{searchText}%'";
            }

            if (bindingNavigator1.BindingSource == jaileronshiftBindingSource)
            {
                //jaileronshiftBindingSource.Filter = $"shift_date LIKE '%{searchText}%'";
            }

            if (bindingNavigator1.BindingSource == cellBindingSource)
            {
                cellBindingSource.Filter = $"CONVERT(cell_number, 'System.String') LIKE '%{searchText}%' OR cell_type LIKE '%{searchText}%'";
            }

            if (bindingNavigator1.BindingSource == visitorBindingSource)
            {
                visitorBindingSource.Filter = $"SNP LIKE '%{searchText}%'";
            }

            if (bindingNavigator1.BindingSource == visitBindingSource)
            {
                //visitBindingSource.Filter = $"number_of_article LIKE '%{searchText}%'";
            }

            if (bindingNavigator1.BindingSource == incidentBindingSource)
            {
                incidentBindingSource.Filter = $"incident_type LIKE '%{searchText}%' OR incident_description LIKE '%{searchText}%'";
            }

            if (bindingNavigator1.BindingSource == committedincidentBindingSource)
            {
                committedincidentBindingSource.Filter = $"CONVERT(time_of_incident, 'System.String') LIKE '%{searchText}%'";
            }

            if (bindingNavigator1.BindingSource == participantsoftheincidentBindingSource)
            {
                //participantsoftheincidentBindingSource.Filter = $"number_of_article LIKE '%{searchText}%'";
            }
        }

        private void formulationOfQueriesstatisticsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var st = new Statistics();
            st.ShowDialog();
        }

        private void FillComboBoxWithCellNumbers()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string query = "SELECT DISTINCT cell_number FROM Cell";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        comboBox_Cells.Items.Add(reader["cell_number"]);
                    }
                }
            }
        }

        private void button_PrintReport_Click(object sender, EventArgs e)
        {

        }
    }
}