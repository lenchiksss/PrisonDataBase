using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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

            label_Filter.Visible = true;
            comboBox_Filtration.Visible = true;

            label_Filter.Text = "Filter by Gender and Date of birth:";
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";

            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "dd/MM/yyyy";
            label2.Visible = true;
            label3.Visible = true;
            dateTimePicker1.Visible = true;
            dateTimePicker2.Visible = true;
            checkBox_BirthdayDate.Visible = true;

            List<string> genderList = new List<string> { "male", "female", "all" };
            comboBox_Filtration.DataSource = genderList;
            comboBox_Filtration.SelectedIndex = 2;

            comboBox_Filtration.SelectedIndexChanged += new EventHandler(comboBox_Filtration_SelectedIndexChanged);

            label_Search.Text = "Search by Person's SNP:";

            checkBox1.Visible = false;
            checkBox2.Visible = false;

            //textBox_Search.Location = new Point(17, 105);

            checkBox_ReleaseDate.Visible = false;

            checkBox_HireDate.Visible = false;

            checkBox_ShiftDate.Visible = false;

            checkBox_VisitDate.Visible = false;

            checkBox_CommittedIncidentDate.Visible = false;

            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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

            checkBox_Sort.Visible = true;
            label_Sort.Visible = true;

            comboBox_Filtration.Visible = true;
            label_Filter.Visible = true;

            List<string> genderList = new List<string> { "male", "female", "all" };
            comboBox_Filtration.DataSource = genderList;
            comboBox_Filtration.SelectedIndex = 2;

            comboBox_Filtration.SelectedIndexChanged += new EventHandler(comboBox_Filtration_SelectedIndexChanged);

            label_Search.Text = "Search by Person's SNP:";

            checkBox1.Visible = false;
            checkBox2.Visible = false;

            label_Filter.Text = "Filter by Gender and Date of birth:";
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";

            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "dd/MM/yyyy";
            label2.Visible = true;
            label3.Visible = true;
            dateTimePicker1.Visible = true;
            dateTimePicker2.Visible = true;
            checkBox_BirthdayDate.Visible = true;

            checkBox_ReleaseDate.Visible = false;

            checkBox_HireDate.Visible = false;

            checkBox_ShiftDate.Visible = false;

            checkBox_VisitDate.Visible = false;

            checkBox_CommittedIncidentDate.Visible = false;

            checkBox_Sort.Checked = false;

            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;

            textBox_Search.Text = string.Empty;

            checkBox1.Checked = false;
            checkBox2.Checked = false;

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void prisonerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bindingNavigator1.BindingSource = prisonerBindingSource;
            dataGridView1.DataSource = prisonerBindingSource;
            label1.Text = "Prisoners";

            string query = @"
                SELECT Prisoner.prisoner_id,
                Person.SNP, Prisoner.incarceration_date, Prisoner.release_date, Prisoner.number_of_article, Cell.cell_number
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

            dataGridView1.Columns["SNP"].DisplayIndex = 0;
            dataGridView1.Columns["incarceration_date"].DisplayIndex = 1;
            dataGridView1.Columns["release_date"].DisplayIndex = 2;
            dataGridView1.Columns["number_of_article"].DisplayIndex = 3;
            dataGridView1.Columns["cell_number"].DisplayIndex = 3;

            checkBox_Sort.Visible = false;
            label_Sort.Visible = false;

            comboBox_Filtration.Visible = false;
            label_Filter.Visible = false;

            label_Search.Text = "Search by:";
            checkBox1.Visible = true;
            checkBox2.Visible = true;

            label_Filter.Visible = true;
            label_Filter.Text = "Filter by Release date:";
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";

            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "dd/MM/yyyy";
            label2.Visible = true;
            label3.Visible = true;
            dateTimePicker1.Visible = true;
            dateTimePicker2.Visible = true;
            checkBox_BirthdayDate.Visible = false;

            checkBox_ReleaseDate.Visible = true;

            checkBox_HireDate.Visible = false;

            checkBox_ShiftDate.Visible = false;

            checkBox_VisitDate.Visible = false;

            checkBox_CommittedIncidentDate.Visible = false;

            checkBox_Sort.Checked = false;

            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;

            textBox_Search.Text = string.Empty;

            checkBox1.Checked = false;
            checkBox2.Checked = false;

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void jailerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bindingNavigator1.BindingSource = jailerBindingSource;
            dataGridView1.DataSource = jailerBindingSource;
            label1.Text = "Jailers";

            dataGridView1.Columns[0].Visible = false;

            checkBox_Sort.Visible = true;
            label_Sort.Visible = true;

            comboBox_Filtration.Visible = true;
            label_Filter.Visible = true;

            List<string> genderList = new List<string> { "male", "female", "all" };
            comboBox_Filtration.DataSource = genderList;
            comboBox_Filtration.SelectedIndex = 2;

            comboBox_Filtration.SelectedIndexChanged += new EventHandler(comboBox_Filtration_SelectedIndexChanged);

            label_Search.Text = "Search by Jailer's SNP:";
            checkBox1.Visible = false;
            checkBox2.Visible = false;

            label_Filter.Text = "Filter by Gender and Hire date:";
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";

            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "dd/MM/yyyy";
            label2.Visible = true;
            label3.Visible = true;
            dateTimePicker1.Visible = true;
            dateTimePicker2.Visible = true;
            checkBox_BirthdayDate.Visible = false;

            checkBox_ReleaseDate.Visible = false;

            checkBox_HireDate.Visible = true;

            checkBox_ShiftDate.Visible = false;

            checkBox_VisitDate.Visible = false;

            checkBox_CommittedIncidentDate.Visible = false;

            checkBox_Sort.Checked = false;

            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;

            textBox_Search.Text = string.Empty;

            checkBox1.Checked = false;
            checkBox2.Checked = false;

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void jailerOnShiftToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bindingNavigator1.BindingSource = jaileronshiftBindingSource;
            dataGridView1.DataSource = jaileronshiftBindingSource;
            label1.Text = "Jailers on shift";

            string query = @"
                SELECT Jailer_on_shift.jailer_on_shift_id,
                Jailer.SNP, Cell.cell_number, Jailer_on_shift.shift_date
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

            //dataGridView1.Columns[0].Visible = false;

            dataGridView1.Columns["SNP"].DisplayIndex = 0;
            dataGridView1.Columns["cell_number"].DisplayIndex = 1;
            dataGridView1.Columns["shift_date"].DisplayIndex = 2;
            dataGridView1.Columns["jailer_on_shift_id"].Visible = false;

            checkBox_Sort.Visible = false;
            label_Sort.Visible = false;

            comboBox_Filtration.Visible = false;

            label_Search.Text = "Search by:";
            checkBox1.Visible = true;

            checkBox2.Text = "Cell";
            checkBox2.Visible = true;

            label_Filter.Visible = true;
            label_Filter.Text = "Filter by Shift date:";
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";

            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "dd/MM/yyyy";
            label2.Visible = true;
            label3.Visible = true;
            dateTimePicker1.Visible = true;
            dateTimePicker2.Visible = true;
            checkBox_BirthdayDate.Visible = false;

            checkBox_ReleaseDate.Visible = false;

            checkBox_HireDate.Visible = false;

            checkBox_ShiftDate.Visible = true;

            checkBox_VisitDate.Visible = false;

            checkBox_CommittedIncidentDate.Visible = false;

            checkBox_Sort.Checked = false;

            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;

            textBox_Search.Text = string.Empty;

            checkBox1.Checked = false;
            checkBox2.Checked = false;

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void cellToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bindingNavigator1.BindingSource = cellBindingSource;
            dataGridView1.DataSource = cellBindingSource;
            label1.Text = "Cells";

            dataGridView1.Columns[0].Visible = false;

            checkBox_Sort.Visible = false;
            label_Sort.Visible = false;

            comboBox_Filtration.Visible = true;
            label_Filter.Visible = true;
            label_Filter.Text = "Filter by Cell type:";

            List<string> typeList = new List<string> { "single", "double", "multiple", "all" };
            comboBox_Filtration.DataSource = typeList;
            comboBox_Filtration.SelectedIndex = 3;

            comboBox_Filtration.SelectedIndexChanged += new EventHandler(comboBox_Filtration_SelectedIndexChanged);

            label_Search.Text = "Search by Cell number:";
            checkBox1.Visible = false;
            checkBox2.Visible = false;

            label2.Visible = false;
            label3.Visible = false;
            dateTimePicker1.Visible = false;
            dateTimePicker2.Visible = false;
            checkBox_BirthdayDate.Visible = false;

            checkBox_ReleaseDate.Visible = false;

            checkBox_HireDate.Visible = false;

            checkBox_ShiftDate.Visible = false;

            checkBox_VisitDate.Visible = false;

            checkBox_CommittedIncidentDate.Visible = false;

            checkBox_Sort.Checked = false;

            textBox_Search.Text = string.Empty;

            checkBox1.Checked = false;
            checkBox2.Checked = false;

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void visitorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bindingNavigator1.BindingSource = visitorBindingSource;
            dataGridView1.DataSource = visitorBindingSource;
            label1.Text = "Visitors";

            dataGridView1.Columns[0].Visible = false;

            checkBox_Sort.Visible = true;
            label_Sort.Visible = true;

            comboBox_Filtration.Visible = false;
            label_Filter.Visible = false;

            label_Search.Text = "Search by Visitor's SNP:";
            checkBox1.Visible = false;
            checkBox2.Visible = false;

            label_Filter.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            dateTimePicker1.Visible = false;
            dateTimePicker2.Visible = false;
            checkBox_BirthdayDate.Visible = false;

            checkBox_ReleaseDate.Visible = false;

            checkBox_HireDate.Visible = false;

            checkBox_ShiftDate.Visible = false;

            checkBox_VisitDate.Visible = false;

            checkBox_CommittedIncidentDate.Visible = false;

            checkBox_Sort.Checked = false;

            textBox_Search.Text = string.Empty;
            
            checkBox1.Checked = false;
            checkBox2.Checked = false;

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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

            dataGridView1.Columns["Visitors_SNP"].DisplayIndex = 0;
            dataGridView1.Columns["Prisoners_SNP"].DisplayIndex = 1;
            dataGridView1.Columns["relation_to_the_prisoner"].DisplayIndex = 2;
            dataGridView1.Columns["date_of_visit"].DisplayIndex = 3;
            dataGridView1.Columns["time_of_visit"].DisplayIndex = 4;
            dataGridView1.Columns["visit_id"].Visible = false;

            //dataGridView1.Columns[0].Visible = false;

            checkBox_Sort.Visible = false;
            label_Sort.Visible = false;

            comboBox_Filtration.Visible = true;
            label_Filter.Visible = true;

            List<string> relationList = new List<string> { "friend", "family", "colleague", "other", "all" };
            comboBox_Filtration.DataSource = relationList;
            comboBox_Filtration.SelectedIndex = 4;

            comboBox_Filtration.SelectedIndexChanged += new EventHandler(comboBox_Filtration_SelectedIndexChanged);

            label_Search.Text = "Search by Visitor's SNP or Prisoner's SNP:";

            checkBox1.Visible = false;
            checkBox2.Visible = false;

            label_Filter.Text = "Filter by Relation and Date of visit:";
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";

            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "dd/MM/yyyy";
            label2.Visible = true;
            label3.Visible = true;
            dateTimePicker1.Visible = true;
            dateTimePicker2.Visible = true;
            checkBox_BirthdayDate.Visible = false;

            checkBox_ReleaseDate.Visible = false;

            checkBox_HireDate.Visible = false;

            checkBox_ShiftDate.Visible = false;

            checkBox_VisitDate.Visible = true;

            checkBox_CommittedIncidentDate.Visible = false;

            checkBox_Sort.Checked = false;

            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;

            textBox_Search.Text = string.Empty;

            checkBox1.Checked = false;
            checkBox2.Checked = false;

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void incidentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bindingNavigator1.BindingSource = incidentBindingSource;
            dataGridView1.DataSource = incidentBindingSource;
            label1.Text = "Incidents";

            dataGridView1.Columns[0].Visible = false;

            checkBox_Sort.Visible = false;
            label_Sort.Visible = false;

            comboBox_Filtration.Visible = false;

            label_Search.Text = "Search by Incident type:";

            checkBox1.Visible = false;
            checkBox2.Visible = false;

            label_Filter.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            dateTimePicker1.Visible = false;
            dateTimePicker2.Visible = false;
            checkBox_BirthdayDate.Visible = false;

            checkBox_ReleaseDate.Visible = false;

            checkBox_HireDate.Visible = false;

            checkBox_ShiftDate.Visible = false;

            checkBox_VisitDate.Visible = false;

            checkBox_CommittedIncidentDate.Visible = false;

            checkBox_Sort.Checked = false;

            textBox_Search.Text = string.Empty;

            checkBox1.Checked = false;
            checkBox2.Checked = false;

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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

            checkBox_Sort.Visible = false;
            label_Sort.Visible = false;

            comboBox_Filtration.Visible = false;
            label_Filter.Visible = true;

            label_Search.Text = "Search by Incident type:";
            checkBox1.Visible = false;
            checkBox2.Visible = false;

            label_Filter.Text = "Filter by Date of committed incident:";
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";

            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "dd/MM/yyyy";
            label2.Visible = true;
            label3.Visible = true;
            dateTimePicker1.Visible = true;
            dateTimePicker2.Visible = true;
            checkBox_BirthdayDate.Visible = false;

            checkBox_ReleaseDate.Visible = false;

            checkBox_HireDate.Visible = false;

            checkBox_ShiftDate.Visible = false;

            checkBox_VisitDate.Visible = false;

            checkBox_CommittedIncidentDate.Visible = true;

            checkBox_Sort.Checked = false;

            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;

            textBox_Search.Text = string.Empty;

            checkBox1.Checked = false;
            checkBox2.Checked = false;

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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

            checkBox_Sort.Visible = false;
            label_Sort.Visible = false;

            comboBox_Filtration.Visible = false;
            label_Filter.Visible = false;

            label_Search.Text = "Search by Prisoner's SNP:";
            checkBox1.Visible = false;
            checkBox2.Visible = false;

            label2.Visible = false;
            label3.Visible = false;
            dateTimePicker1.Visible = false;
            dateTimePicker2.Visible = false;
            checkBox_BirthdayDate.Visible = false;

            checkBox_ReleaseDate.Visible = false;

            checkBox_HireDate.Visible = false;

            checkBox_ShiftDate.Visible = false;

            checkBox_VisitDate.Visible = false;

            checkBox_CommittedIncidentDate.Visible = false;

            checkBox_Sort.Checked = false;

            textBox_Search.Text = string.Empty;

            checkBox1.Checked = false;
            checkBox2.Checked = false;

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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
                prisonerBindingSource.ResetBindings(false);
            }

            if (bindingNavigator1.BindingSource == jailerBindingSource)
            {
                edit = false;
                var edt = new EditJailer();
                edt.ShowDialog();
                jailerTableAdapter.Fill(prisonDataBaseDataSet.Jailer);
                prisonDataBaseDataSet.AcceptChanges();

                jailerTableAdapter.Fill(prisonDataBaseDataSet.Jailer);
                jailerBindingSource.ResetBindings(false);
            }

            if (bindingNavigator1.BindingSource == cellBindingSource)
            {
                edit = false;
                var edt = new EditCell();
                edt.ShowDialog();
                cellTableAdapter.Fill(prisonDataBaseDataSet.Cell);
                prisonDataBaseDataSet.AcceptChanges();

                cellTableAdapter.Fill(prisonDataBaseDataSet.Cell);
                cellBindingSource.ResetBindings(false);
            }

            if (bindingNavigator1.BindingSource == jaileronshiftBindingSource)
            {
                edit = false;
                var edt = new EditJailerOnShift();
                edt.ShowDialog();
                jailer_on_shiftTableAdapter.Fill(prisonDataBaseDataSet.Jailer_on_shift);
                prisonDataBaseDataSet.AcceptChanges();

                jailer_on_shiftTableAdapter.Fill(prisonDataBaseDataSet.Jailer_on_shift);
                jaileronshiftBindingSource.ResetBindings(false);
            }

            if (bindingNavigator1.BindingSource == visitBindingSource)
            {
                edit = false;
                var edt = new EditVisit();
                edt.ShowDialog();
                visitTableAdapter.Fill(prisonDataBaseDataSet.Visit);
                prisonDataBaseDataSet.AcceptChanges();

                visitTableAdapter.Fill(prisonDataBaseDataSet.Visit);
                visitBindingSource.ResetBindings(false);
            }

            if (bindingNavigator1.BindingSource == visitorBindingSource)
            {
                edit = false;
                var edt = new EditVisitor();
                edt.ShowDialog();
                visitorTableAdapter.Fill(prisonDataBaseDataSet.Visitor);
                prisonDataBaseDataSet.AcceptChanges();

                visitorTableAdapter.Fill(prisonDataBaseDataSet.Visitor);
                visitorBindingSource.ResetBindings(false);
            }

            if (bindingNavigator1.BindingSource == participantsoftheincidentBindingSource)
            {
                edit = false;
                var edt = new EditParticipantsOfTheIncident();
                edt.ShowDialog();
                participants_of_the_incidentTableAdapter.Fill(prisonDataBaseDataSet.Participants_of_the_incident);
                prisonDataBaseDataSet.AcceptChanges();

                participants_of_the_incidentTableAdapter.Fill(prisonDataBaseDataSet.Participants_of_the_incident);
                participantsoftheincidentBindingSource.ResetBindings(false);
            }

            if (bindingNavigator1.BindingSource == committedincidentBindingSource)
            {
                edit = false;
                var edt = new EditCommittedIncident();
                edt.ShowDialog();
                committed_incidentTableAdapter.Fill(prisonDataBaseDataSet.Committed_incident);
                prisonDataBaseDataSet.AcceptChanges();

                committed_incidentTableAdapter.Fill(prisonDataBaseDataSet.Committed_incident);
                committedincidentBindingSource.ResetBindings(false);
            }

            if (bindingNavigator1.BindingSource == incidentBindingSource)
            {
                edit = false;
                var edt = new EditIncident();
                edt.ShowDialog();
                incidentTableAdapter.Fill(prisonDataBaseDataSet.Incident);
                prisonDataBaseDataSet.AcceptChanges();

                incidentTableAdapter.Fill(prisonDataBaseDataSet.Incident);
                incidentBindingSource.ResetBindings(false);
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

            if (bindingNavigator1.BindingSource == cellBindingSource)
            {
                var st = new PrisonDataBaseDataSet.CellDataTable();
                cellTableAdapter.FillBy(st,
                Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value));
                object[] row = st.Rows[0].ItemArray;
                var edt = new EditCell(
                    Convert.ToInt32(row[0]),
                    Convert.ToInt32(row[1]),
                    Convert.ToInt32(row[2]),
                    Convert.ToInt32(row[3]),
                    row[4].ToString()
                );
                edt.ShowDialog();
                cellTableAdapter.Fill(prisonDataBaseDataSet.Cell);
                prisonDataBaseDataSet.AcceptChanges();
            }

            if (bindingNavigator1.BindingSource == jaileronshiftBindingSource)
            {
                var st = new PrisonDataBaseDataSet.Jailer_on_shiftDataTable();
                jailer_on_shiftTableAdapter.FillBy(st,
                Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value));
                object[] row = st.Rows[0].ItemArray;
                var edt = new EditJailerOnShift(
                    Convert.ToInt32(row[0]),
                    Convert.ToDateTime(row[1]),
                    Convert.ToInt32(row[2]),
                    Convert.ToInt32(row[3])
                );
                edt.ShowDialog();
                jailer_on_shiftTableAdapter.Fill(prisonDataBaseDataSet.Jailer_on_shift);
                prisonDataBaseDataSet.AcceptChanges();
            }

            if (bindingNavigator1.BindingSource == visitBindingSource)
            {
                var st = new PrisonDataBaseDataSet.VisitDataTable();
                visitTableAdapter.FillBy(st,
                Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value));
                object[] row = st.Rows[0].ItemArray;
                var edt = new EditVisit(
                    Convert.ToInt32(row[0]),
                    row[1].ToString(),
                    Convert.ToDateTime(row[2]),
                    row[3].ToString(),
                    row[4].ToString(),
                    row[5].ToString()
                );
                edt.ShowDialog();
                visitTableAdapter.Fill(prisonDataBaseDataSet.Visit);
                prisonDataBaseDataSet.AcceptChanges();
            }

            if (bindingNavigator1.BindingSource == visitorBindingSource)
            {
                var st = new PrisonDataBaseDataSet.VisitorDataTable();
                visitorTableAdapter.FillBy(st,
                Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value));
                object[] row = st.Rows[0].ItemArray;
                var edt = new EditVisitor(
                    Convert.ToInt32(row[0]),
                    row[1].ToString(),
                    Convert.ToDateTime(row[2]),
                    row[3].ToString()
                );
                edt.ShowDialog();
                visitorTableAdapter.Fill(prisonDataBaseDataSet.Visitor);
                prisonDataBaseDataSet.AcceptChanges();
            }

            if (bindingNavigator1.BindingSource == participantsoftheincidentBindingSource)
            {
                var st = new PrisonDataBaseDataSet.Participants_of_the_incidentDataTable();
                participants_of_the_incidentTableAdapter.FillBy(st,
                Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value));
                object[] row = st.Rows[0].ItemArray;
                var edt = new EditParticipantsOfTheIncident(
                    Convert.ToInt32(row[0]),
                    row[1].ToString(),
                    row[2].ToString()
                );
                edt.ShowDialog();
                participants_of_the_incidentTableAdapter.Fill(prisonDataBaseDataSet.Participants_of_the_incident);
                prisonDataBaseDataSet.AcceptChanges();
            }

            if (bindingNavigator1.BindingSource == committedincidentBindingSource)
            {
                var st = new PrisonDataBaseDataSet.Committed_incidentDataTable();
                committed_incidentTableAdapter.FillBy(st,
                Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value));
                object[] row = st.Rows[0].ItemArray;
                var edt = new EditCommittedIncident(
                    Convert.ToInt32(row[0]),
                    Convert.ToDateTime(row[1]),
                    row[1].ToString(),
                    row[2].ToString()
                );
                edt.ShowDialog();
                committed_incidentTableAdapter.Fill(prisonDataBaseDataSet.Committed_incident);
                prisonDataBaseDataSet.AcceptChanges();
            }

            if (bindingNavigator1.BindingSource == incidentBindingSource)
            {
                var st = new PrisonDataBaseDataSet.IncidentDataTable();
                incidentTableAdapter.FillBy(st,
                Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value));
                object[] row = st.Rows[0].ItemArray;
                var edt = new EditIncident(
                    Convert.ToInt32(row[0]),
                    row[1].ToString(),
                    row[2].ToString()
                );
                edt.ShowDialog();
                incidentTableAdapter.Fill(prisonDataBaseDataSet.Incident);
                prisonDataBaseDataSet.AcceptChanges();
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

            if (bindingNavigator1.BindingSource == cellBindingSource)
            {
                cellTableAdapter.DeleteQuery(Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value));
                cellTableAdapter.Fill(prisonDataBaseDataSet.Cell);
                prisonDataBaseDataSet.AcceptChanges();
            }

            if (bindingNavigator1.BindingSource == jaileronshiftBindingSource)
            {
                jailer_on_shiftTableAdapter.DeleteQuery(Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value));
                jailer_on_shiftTableAdapter.Fill(prisonDataBaseDataSet.Jailer_on_shift);
                prisonDataBaseDataSet.AcceptChanges();
            }

            if (bindingNavigator1.BindingSource == visitBindingSource)
            {
                visitTableAdapter.DeleteQuery(Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value));
                visitTableAdapter.Fill(prisonDataBaseDataSet.Visit);
                prisonDataBaseDataSet.AcceptChanges();
            }

            if (bindingNavigator1.BindingSource == visitorBindingSource)
            {
                visitorTableAdapter.DeleteQuery(Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value));
                visitorTableAdapter.Fill(prisonDataBaseDataSet.Visitor);
                prisonDataBaseDataSet.AcceptChanges();
            }

            if (bindingNavigator1.BindingSource == participantsoftheincidentBindingSource)
            {
                participants_of_the_incidentTableAdapter.DeleteQuery(Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value));
                participants_of_the_incidentTableAdapter.Fill(prisonDataBaseDataSet.Participants_of_the_incident);
                prisonDataBaseDataSet.AcceptChanges();
            }

            if (bindingNavigator1.BindingSource == committedincidentBindingSource)
            {
                committed_incidentTableAdapter.DeleteQuery(Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value));
                committed_incidentTableAdapter.Fill(prisonDataBaseDataSet.Committed_incident);
                prisonDataBaseDataSet.AcceptChanges();
            }

            if (bindingNavigator1.BindingSource == incidentBindingSource)
            {
                incidentTableAdapter.DeleteQuery(Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value));
                incidentTableAdapter.Fill(prisonDataBaseDataSet.Incident);
                prisonDataBaseDataSet.AcceptChanges();
            }
        }

        private string search = "";

        private void textBox_Search_TextChanged(object sender, EventArgs e)
        {
            string searchText = textBox_Search.Text.Trim();

            if (bindingNavigator1.BindingSource == personBindingSource)
            {
                search = personBindingSource.Filter = $"SNP LIKE '%{searchText}%'";
            }

            else if (bindingNavigator1.BindingSource == prisonerBindingSource)
            {
                if (checkBox1.Checked)
                {
                    search = prisonerBindingSource.Filter = $"SNP LIKE '%{searchText}%'";
                }
                if (checkBox2.Checked)
                {
                    search = prisonerBindingSource.Filter = $"CONVERT(cell_number, System.String) LIKE '%{searchText}%'";
                }
            }

            else if (bindingNavigator1.BindingSource == jailerBindingSource)
            {
                search = jailerBindingSource.Filter = $"SNP LIKE '%{searchText}%'";
            }

            else if (bindingNavigator1.BindingSource == jaileronshiftBindingSource)
            {
                if (checkBox1.Checked)
                {
                    search = jaileronshiftBindingSource.Filter = $"SNP LIKE '%{searchText}%'";
                }
                if (checkBox2.Checked)
                {
                    search = jaileronshiftBindingSource.Filter = $"CONVERT(cell_number, System.String) LIKE '%{searchText}%'";
                }
            }

            else if (bindingNavigator1.BindingSource == cellBindingSource)
            {
                search = cellBindingSource.Filter = $"CONVERT(cell_number, 'System.String') LIKE '%{searchText}%'";
            }

            else if (bindingNavigator1.BindingSource == visitorBindingSource)
            {
                search = visitorBindingSource.Filter = $"SNP LIKE '%{searchText}%'";
            }

            else if (bindingNavigator1.BindingSource == visitBindingSource)
            {
                search = visitBindingSource.Filter = $"Visitors_SNP LIKE '%{searchText}%' OR Prisoners_SNP LIKE '%{searchText}%'";
            }

            else if (bindingNavigator1.BindingSource == incidentBindingSource)
            {
                search = incidentBindingSource.Filter = $"incident_type LIKE '%{searchText}%'";
            }

            else if (bindingNavigator1.BindingSource == committedincidentBindingSource)
            {
                search = committedincidentBindingSource.Filter = $"incident_type LIKE '%{searchText}%'";
            }

            else if (bindingNavigator1.BindingSource == participantsoftheincidentBindingSource)
            {
                search = participantsoftheincidentBindingSource.Filter = $"Prisoners_SNP LIKE '%{searchText}%'";
            }

            ApplyFilters();
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

        private string query = "";

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

            if (bindingNavigator1.BindingSource == personBindingSource)
            {
                query = "";
                query = "SELECT * FROM Person WHERE 1=1";

                if (checkBox_Sort.Checked)
                {
                    query += " ORDER BY SNP";
                }

                personBindingSource.DataSource = Query(ConnectionString, query);
            }

            if (bindingNavigator1.BindingSource == jailerBindingSource)
            {
                query = "";
                query = "SELECT * FROM Jailer WHERE 1=1";

                if (checkBox_Sort.Checked)
                {
                    query += " ORDER BY SNP";
                }

                jailerBindingSource.DataSource = Query(ConnectionString, query);
            }

            if (bindingNavigator1.BindingSource == visitorBindingSource)
            {
                query = "";
                query = "SELECT * FROM Visitor WHERE 1=1";

                if (checkBox_Sort.Checked)
                {
                    query += " ORDER BY SNP";
                }

                visitorBindingSource.DataSource = Query(ConnectionString, query);
            }
        }

        private string filter = "";

        private void comboBox_Filtration_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bindingNavigator1.BindingSource == personBindingSource || bindingNavigator1.BindingSource == jailerBindingSource)
            {
                filter = "";

                string selectedGender = comboBox_Filtration.SelectedItem.ToString();

                if (selectedGender == "all")
                {
                    filter = "";
                }
                else
                {
                    filter = $"gender = '{selectedGender}'";
                }
            }

            if (bindingNavigator1.BindingSource == visitBindingSource)
            {
                filter = "";

                string selectedRelation = comboBox_Filtration.SelectedItem.ToString();

                if (selectedRelation == "all")
                {
                    filter = "";
                }
                else
                {
                    filter = $"relation_to_the_prisoner = '{selectedRelation}'";
                }
            }

            if (bindingNavigator1.BindingSource == cellBindingSource)
            {
                filter = "";

                string selectedType = comboBox_Filtration.SelectedItem.ToString();

                if (selectedType == "all")
                {
                    filter = "";
                }
                else
                {
                    filter = $"cell_type = '{selectedType}'";
                }
            }

            ApplyFilters();
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

        private void visitsOfPrisonersToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void exitToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ApplyFilters()
        {
            List<string> filters = new List<string>();

            if (!string.IsNullOrEmpty(filter)) filters.Add(filter);

            if (!string.IsNullOrEmpty(search)) filters.Add(search);

            if (bindingNavigator1.BindingSource == personBindingSource)
            {
                if (!string.IsNullOrEmpty(birthdayFilter)) filters.Add(birthdayFilter);
            }

            else if (bindingNavigator1.BindingSource == prisonerBindingSource)
            {
                if (!string.IsNullOrEmpty(releaseFilter)) filters.Add(releaseFilter);
            }

            else if (bindingNavigator1.BindingSource == jailerBindingSource)
            {
                if (!string.IsNullOrEmpty(hireFilter)) filters.Add(hireFilter);
            }

            else if (bindingNavigator1.BindingSource == jaileronshiftBindingSource)
            {
                if (!string.IsNullOrEmpty(shiftFilter)) filters.Add(shiftFilter);
            }

            else if (bindingNavigator1.BindingSource == visitBindingSource)
            {
                if (!string.IsNullOrEmpty(visitFilter)) filters.Add(visitFilter);
            }


            else if (bindingNavigator1.BindingSource == committedincidentBindingSource)
            {
                if (!string.IsNullOrEmpty(incidentFilter)) filters.Add(incidentFilter);
            }

            string combinedFilter = string.Join(" AND ", filters);

            ((BindingSource)dataGridView1.DataSource).Filter = combinedFilter;
        }

        private string birthdayFilter = "";

        private void checkBox_Date_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBox_BirthdayDate.Checked)
            {
                birthdayFilter = "";
                ApplyFilters();
                return;
            }

            DateTime startDate = dateTimePicker1.Value;
            DateTime endDate = dateTimePicker2.Value;

            birthdayFilter = $"date_of_birth >= #{startDate:MM/dd/yyyy}# AND date_of_birth <= #{endDate:MM/dd/yyyy}#";

            ApplyFilters();
        }

        private string releaseFilter = "";

        private void checkBox_ReleaseDate_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBox_ReleaseDate.Checked)
            {
                releaseFilter = "";
                ApplyFilters();
                return;
            }

            DateTime startDate = dateTimePicker1.Value;
            DateTime endDate = dateTimePicker2.Value;

            releaseFilter = $"release_date >= #{startDate:MM/dd/yyyy}# AND release_date <= #{endDate:MM/dd/yyyy}#";

            ApplyFilters();
        }

        private string hireFilter = "";

        private void checkBox_HireDate_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBox_HireDate.Checked)
            {
                hireFilter = "";
                ApplyFilters();
                return;
            }

            DateTime startDate = dateTimePicker1.Value;
            DateTime endDate = dateTimePicker2.Value;

            hireFilter = $"hire_date >= #{startDate:MM/dd/yyyy}# AND hire_date <= #{endDate:MM/dd/yyyy}#";

            ApplyFilters();
        }

        private string shiftFilter = "";

        private void checkBox_ShiftDate_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBox_ShiftDate.Checked)
            {
                shiftFilter = "";
                ApplyFilters();
                return;
            }

            DateTime startDate = dateTimePicker1.Value;
            DateTime endDate = dateTimePicker2.Value;

            shiftFilter = $"shift_date >= #{startDate:MM/dd/yyyy}# AND shift_date <= #{endDate:MM/dd/yyyy}#";

            ApplyFilters();
        }

        private string visitFilter = "";

        private void checkBox_VisitDate_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBox_VisitDate.Checked)
            {
                visitFilter = "";
                ApplyFilters();
                return;
            }

            DateTime startDate = dateTimePicker1.Value;
            DateTime endDate = dateTimePicker2.Value;

            visitFilter = $"date_of_visit >= #{startDate:MM/dd/yyyy}# AND date_of_visit <= #{endDate:MM/dd/yyyy}#";

            ApplyFilters();
        }

        private string incidentFilter = "";

        private void checkBox_CommittedIncidentDate_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBox_VisitDate.Checked)
            {
                incidentFilter = "";
                ApplyFilters();
                return;
            }

            DateTime startDate = dateTimePicker1.Value;
            DateTime endDate = dateTimePicker2.Value;

            incidentFilter = $"date_of_incident >= #{startDate:MM/dd/yyyy}# AND date_of_incident <= #{endDate:MM/dd/yyyy}#";

            ApplyFilters();
        }
    }
}