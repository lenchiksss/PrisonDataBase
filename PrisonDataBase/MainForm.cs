using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
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

            dataGridView1.Columns[0].Visible = false;

            List<string> genderList = new List<string> { "male", "female", "all" };
            comboBox_Filtration.DataSource = genderList;
            comboBox_Filtration.SelectedIndex = 2;

            comboBox_Filtration.SelectedIndexChanged += new EventHandler(comboBox_Filtration_SelectedIndexChanged);
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

            dataGridView1.Columns[0].Visible = false;

            checkBox1.Visible = true;
            label2.Visible = true;

            comboBox_Filtration.Visible = true;
            label3.Visible = true;

            List<string> genderList = new List<string> { "male", "female", "all" };
            comboBox_Filtration.DataSource = genderList;
            comboBox_Filtration.SelectedIndex = 2;

            comboBox_Filtration.SelectedIndexChanged += new EventHandler(comboBox_Filtration_SelectedIndexChanged);
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

            dataGridView1.Columns[0].Visible = false;

            checkBox1.Visible = false;
            label2.Visible = false;

            comboBox_Filtration.Visible = false;
            label3.Visible = false;
        }

        private void jailerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bindingNavigator1.BindingSource = jailerBindingSource;
            dataGridView1.DataSource = jailerBindingSource;
            label1.Text = "Jailers";

            dataGridView1.Columns[0].Visible = false;

            checkBox1.Visible = true;
            label2.Visible = true;

            comboBox_Filtration.Visible = true;
            label3.Visible = true;

            List<string> genderList = new List<string> { "male", "female", "all" };
            comboBox_Filtration.DataSource = genderList;
            comboBox_Filtration.SelectedIndex = 2;

            comboBox_Filtration.SelectedIndexChanged += new EventHandler(comboBox_Filtration_SelectedIndexChanged);
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

            dataGridView1.Columns[0].Visible = false;

            checkBox1.Visible = false;
            label2.Visible = false;

            comboBox_Filtration.Visible = false;
            label3.Visible = false;
        }

        private void cellToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bindingNavigator1.BindingSource = cellBindingSource;
            dataGridView1.DataSource = cellBindingSource;
            label1.Text = "Cells";

            dataGridView1.Columns[0].Visible = false;

            checkBox1.Visible = false;
            label2.Visible = false;

            comboBox_Filtration.Visible = true;
            label3.Visible = true;

            List<string> genderList = new List<string> { "single", "double", "multiple", "all" };
            comboBox_Filtration.DataSource = genderList;
            comboBox_Filtration.SelectedIndex = 3;

            comboBox_Filtration.SelectedIndexChanged += new EventHandler(comboBox_Filtration_SelectedIndexChanged);
        }

        private void visitorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bindingNavigator1.BindingSource = visitorBindingSource;
            dataGridView1.DataSource = visitorBindingSource;
            label1.Text = "Visitors";

            dataGridView1.Columns[0].Visible = false;

            checkBox1.Visible = true;
            label2.Visible = true;

            comboBox_Filtration.Visible = false;
            label3.Visible = false;
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

            dataGridView1.Columns[0].Visible = false;

            checkBox1.Visible = false;
            label2.Visible = false;

            comboBox_Filtration.Visible = true;
            label3.Visible = true;

            List<string> relationList = new List<string> { "friend", "family", "colleague", "other", "all" };
            comboBox_Filtration.DataSource = relationList;
            comboBox_Filtration.SelectedIndex = 4;

            comboBox_Filtration.SelectedIndexChanged += new EventHandler(comboBox_Filtration_SelectedIndexChanged);
        }

        private void incidentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bindingNavigator1.BindingSource = incidentBindingSource;
            dataGridView1.DataSource = incidentBindingSource;
            label1.Text = "Incidents";

            dataGridView1.Columns[0].Visible = false;

            checkBox1.Visible = false;
            label2.Visible = false;

            comboBox_Filtration.Visible = false;
            label3.Visible = false;
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

            dataGridView1.Columns[0].Visible = false;

            checkBox1.Visible = false;
            label2.Visible = false;

            comboBox_Filtration.Visible = false;
            label3.Visible = false;
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

            dataGridView1.Columns[0].Visible = false;

            checkBox1.Visible = false;
            label2.Visible = false;

            comboBox_Filtration.Visible = false;
            label3.Visible = false;
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

                personTableAdapter.Fill(prisonDataBaseDataSet.Person);
                personBindingSource.ResetBindings(false);
            }

            if (bindingNavigator1.BindingSource == prisonerBindingSource)
            {
                edit = false;
                var edt = new EditPrisoner();
                edt.ShowDialog();
                prisonerTableAdapter.Fill(prisonDataBaseDataSet.Prisoner);
                prisonDataBaseDataSet.AcceptChanges();

                prisonerTableAdapter.Fill(prisonDataBaseDataSet.Prisoner);
                personBindingSource.ResetBindings(false);
            }

            if (bindingNavigator1.BindingSource == jailerBindingSource)
            {
                edit = false;
                var edt = new EditJailer();
                edt.ShowDialog();
                jailerTableAdapter.Fill(prisonDataBaseDataSet.Jailer);
                prisonDataBaseDataSet.AcceptChanges();

                jailerTableAdapter.Fill(prisonDataBaseDataSet.Jailer);
                personBindingSource.ResetBindings(false);
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
                prisonerBindingSource.Filter = $"number_of_article LIKE '%{searchText}%' OR SNP LIKE '%{searchText}%' OR CONVERT(cell_number, System.String) LIKE '%{searchText}%'";
            }

            if (bindingNavigator1.BindingSource == jailerBindingSource)
            {
                jailerBindingSource.Filter = $"SNP LIKE '%{searchText}%' OR email LIKE '%{searchText}%'";
            }

            if (bindingNavigator1.BindingSource == jaileronshiftBindingSource)
            {
                jaileronshiftBindingSource.Filter = $"SNP LIKE '%{searchText}%' OR CONVERT(cell_number, System.String) LIKE '%{searchText}%'";
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
                visitBindingSource.Filter = $"relation_to_the_prisoner LIKE '%{searchText}%'";
            }

            if (bindingNavigator1.BindingSource == incidentBindingSource)
            {
                incidentBindingSource.Filter = $"incident_type LIKE '%{searchText}%' OR incident_description LIKE '%{searchText}%'";
            }

            if (bindingNavigator1.BindingSource == committedincidentBindingSource)
            {
                committedincidentBindingSource.Filter = $"CONVERT(time_of_incident, 'System.String') LIKE '%{searchText}%' OR incident_type LIKE '%{searchText}%'";
            }

            if (bindingNavigator1.BindingSource == participantsoftheincidentBindingSource)
            {
                participantsoftheincidentBindingSource.Filter = $"incident_type LIKE '%{searchText}%' OR Prisoners_SNP LIKE '%{searchText}%'";
            }
        }

        private void formulationOfQueriesstatisticsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var st = new Statistics();
            st.ShowDialog();
        }

        private void button_PrintReport_Click(object sender, EventArgs e)
        {
            if (comboBox_Cells.SelectedItem != null)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Text Files (*.txt)|*.txt";
                saveFileDialog.Title = "Save Text File";
                saveFileDialog.ShowDialog();

                if (saveFileDialog.FileName != "")
                {
                    int selectedCellNumber = (int)((DataRowView)comboBox_Cells.SelectedItem)["cell_number"];
                    string filePath = saveFileDialog.FileName;

                    string cellInfo = GetCellInfo(selectedCellNumber);
                    File.WriteAllText(filePath, cellInfo);

                    MessageBox.Show("The text file was successfully created!");
                }
            }
            else
            {
                MessageBox.Show("Pick a cell number!");
            }
        }

        private SqlConnection sqlConnection;

        private string GetCellInfo(int cellNumber)
        {
            sqlConnection = new SqlConnection(ConnectionString);
            string query = $"SELECT * FROM Cell WHERE cell_number = {cellNumber}";
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            sqlConnection.Open();
            SqlDataReader reader = sqlCommand.ExecuteReader();

            string cellInfo = "";

            if (reader.Read())
            {
                int cellId = (int)reader["cell_id"];
                cellInfo = $"Cell number: {reader["cell_number"]}\r\n";

                cellInfo += GetInmatesInfo(cellId);

                cellInfo += $"\r\nDocument Save Date: {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}\r\n";
            }

            sqlConnection.Close();

            return cellInfo;
        }


        private string GetInmatesInfo(int cellId)
        {
            string inmatesInfo = "\r\nInmates:\r\n";

            using (SqlConnection inmateConnection = new SqlConnection(ConnectionString))
            {
                inmateConnection.Open();

                string query = $"SELECT * FROM Prisoner INNER JOIN Person ON Prisoner.person_id = Person.person_id WHERE cell_id = {cellId}";
                using (SqlCommand inmateCommand = new SqlCommand(query, inmateConnection))
                {
                    using (SqlDataReader inmateReader = inmateCommand.ExecuteReader())
                    {
                        while (inmateReader.Read())
                        {
                            inmatesInfo += $" - SNP: {inmateReader["SNP"]}, Incarceration Date: {inmateReader["incarceration_date"]}, Release Date: {inmateReader["release_date"]}, Article: {inmateReader["number_of_article"]}\r\n";
                        }
                    }
                }
            }

            return inmatesInfo;
        }

        private string previousFilter = "";
        private string previousSort = "";

        private DataTable Query(string connectionString, string query)
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }

            return dataTable;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

            if (bindingNavigator1.BindingSource == personBindingSource)
            {
                string query = "SELECT * FROM Person WHERE 1=1";

                if (checkBox1.Checked)
                {
                    query += " ORDER BY SNP";
                }

                personBindingSource.DataSource = Query(ConnectionString, query);
            }

            //if (bindingNavigator1.BindingSource == prisonerBindingSource)
            //{
            //    string query = "SELECT Prisoner.*, Person.SNP FROM Prisoner " +
            //       "INNER JOIN Person ON Prisoner.person_id = Person.person_id " +
            //       "WHERE 1=1";

            //    if (checkBox1.Checked)
            //    {
            //        query += " ORDER BY Person.SNP";
            //    }

            //    prisonerBindingSource.DataSource = Query(ConnectionString, query);
            //}

            if (bindingNavigator1.BindingSource == jailerBindingSource)
            {
                string query = "SELECT * FROM Jailer WHERE 1=1";

                if (checkBox1.Checked)
                {
                    query += " ORDER BY SNP";
                }

                jailerBindingSource.DataSource = Query(ConnectionString, query);
            }

            //if (bindingNavigator1.BindingSource == jaileronshiftBindingSource)
            //{
            //    string query = "SELECT * FROM Jailer_on_shift WHERE 1=1";

            //    if (checkBox1.Checked)
            //    {
            //        query += " ORDER BY SNP";
            //    }

            //    jaileronshiftBindingSource.DataSource = Query(ConnectionString, query);
            //}

            if (bindingNavigator1.BindingSource == visitorBindingSource)
            {
                string query = "SELECT * FROM Visitor WHERE 1=1";

                if (checkBox1.Checked)
                {
                    query += " ORDER BY SNP";
                }

                visitorBindingSource.DataSource = Query(ConnectionString, query);
            }

            //if (bindingNavigator1.BindingSource == visitBindingSource)
            //{
            //    string query = "SELECT * FROM Visit WHERE 1=1";

            //    if (checkBox1.Checked)
            //    {
            //        query += " ORDER BY SNP";
            //    }

            //    visitBindingSource.DataSource = Query(ConnectionString, query);
            //}

            //if (bindingNavigator1.BindingSource == participantsoftheincidentBindingSource)
            //{
            //    string query = "SELECT * FROM Participants_of_the_incident WHERE 1=1";

            //    if (checkBox1.Checked)
            //    {
            //        query += " ORDER BY SNP";
            //    }

            //    participantsoftheincidentBindingSource.DataSource = Query(ConnectionString, query);
            //}
        }

        private void comboBox_Filtration_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bindingNavigator1.BindingSource == personBindingSource || bindingNavigator1.BindingSource == jailerBindingSource)
            {
                string selectedGender = comboBox_Filtration.SelectedItem.ToString();

                if (selectedGender == "all")
                {
                    ((BindingSource)dataGridView1.DataSource).Filter = "";
                }
                else
                {
                    ((BindingSource)dataGridView1.DataSource).Filter = $"gender = '{selectedGender}'";
                }
            }
            
            if (bindingNavigator1.BindingSource == visitBindingSource)
            {
                string selectedRelation = comboBox_Filtration.SelectedItem.ToString();

                if (selectedRelation == "all")
                {
                    ((BindingSource)dataGridView1.DataSource).Filter = "";
                }
                else
                {
                    ((BindingSource)dataGridView1.DataSource).Filter = $"relation_to_the_prisoner = '{selectedRelation}'";
                }
            }

            if (bindingNavigator1.BindingSource == cellBindingSource)
            {
                string selectedType = comboBox_Filtration.SelectedItem.ToString();

                if (selectedType == "all")
                {
                    ((BindingSource)dataGridView1.DataSource).Filter = "";
                }
                else
                {
                    ((BindingSource)dataGridView1.DataSource).Filter = $"cell_type = '{selectedType}'";
                }
            }
        }

        private void button_PrintReport1_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    string sqlQuery = @"
                        SELECT
                            jailer_id,
                            SNP,
                            date_of_birth,
                            gender,
                            hire_date,
                            phone_number,
                            email,
                            salary
                        FROM
                            Jailer;
                        ";

                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                        {
                            saveFileDialog.Filter = "Text Files (*.txt)|*.txt";
                            saveFileDialog.Title = "Save Text File";
                            saveFileDialog.FileName = "";

                            if (saveFileDialog.ShowDialog() == DialogResult.OK)
                            {
                                string filePath = saveFileDialog.FileName;

                                using (StreamWriter writer = new StreamWriter(filePath))
                                {
                                    using (SqlDataReader reader = command.ExecuteReader())
                                    {
                                        while (reader.Read())
                                        {
                                        writer.WriteLine($"ID: {reader["jailer_id"]}");
                                        writer.WriteLine($"  - SNP: {reader["SNP"]}");
                                        writer.WriteLine($"  - Date of Birth: {reader["date_of_birth"]}");
                                        writer.WriteLine($"  - Gender: {reader["gender"]}");
                                        writer.WriteLine($"  - Hire Date: {reader["hire_date"]}");
                                        writer.WriteLine($"  - Phone Number: {reader["phone_number"]}");
                                        writer.WriteLine($"  - Email: {reader["email"]}");
                                        writer.WriteLine($"  - Salary: {reader["salary"]}");
                                        writer.WriteLine();
                                    }
                                    }
                                writer.WriteLine($"\r\nDocument Save Date: {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}\r\n");
                            }

                                MessageBox.Show("The text file was successfully created!");
                            }
                        }
                    }
                }
        }

        private void crossTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label1.Text = "Prisoners and visits cross-table";
            bindingNavigator1.Visible = false;
            //groupBox1.Visible = false;
            //label3.Visible = false;
            //comboBox_Filtration.Visible = false;
            //label2.Visible = false;
            //checkBox1.Visible = false;

            string query = @"
                DECLARE @columns NVARCHAR(MAX), @sql NVARCHAR(MAX);

                SELECT @columns = STRING_AGG(QUOTENAME(prisoner_name), ', ') 
                FROM (
                    SELECT DISTINCT prisoner_name
                    FROM (
                        SELECT Person.SNP AS prisoner_name
                        FROM Person
                        INNER JOIN Prisoner ON Person.person_id = Prisoner.person_id
                        INNER JOIN Visit ON Prisoner.prisoner_id = Visit.prisoner_id
                    ) AS prisoners
                ) AS prisoner_names;

                SET @sql = '
                    SELECT visitor_SNP as visitor_SNP, ' + @columns + '
                        FROM (
                            SELECT
                            prisoners.prisoner_name,
                            Visitor.SNP AS visitor_SNP,
                            COUNT(*) AS count
                        FROM
                        (
                            SELECT Person.SNP AS prisoner_name, Visit.prisoner_id
                            FROM Person
                            INNER JOIN Prisoner ON Person.person_id = Prisoner.person_id
                            INNER JOIN Visit ON Prisoner.prisoner_id = Visit.prisoner_id
                        ) AS prisoners
                        INNER JOIN Visit ON prisoners.prisoner_id = Visit.prisoner_id
                        INNER JOIN Visitor ON Visit.visitor_id = Visitor.visitor_id
                        GROUP BY
                            prisoners.prisoner_name,
                            Visitor.SNP
                        ) AS source
                        PIVOT (
                            SUM(count)
                            FOR prisoner_name IN (' + @columns + ')
                            ) AS pivot_table';
                        EXEC sp_executesql @sql;
                        ";

            dataGridView1.DataSource = Query(ConnectionString, query);
        }
    }
}