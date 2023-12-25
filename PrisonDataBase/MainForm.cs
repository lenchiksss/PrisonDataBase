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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;


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

            comboBox_Filtration.DropDownStyle = ComboBoxStyle.DropDownList;

            List<string> genderList = new List<string> { "male", "female", "all" };
            comboBox_Filtration.DataSource = genderList;
            comboBox_Filtration.SelectedIndex = 2;

            comboBox_Filtration.SelectedIndexChanged += new EventHandler(comboBox_Filtration_SelectedIndexChanged);

            label_Search.Text = "Search by Person's SNP:";

            checkBox1.Visible = false;
            checkBox2.Visible = false;

            checkBox_ReleaseDate.Visible = false;

            checkBox_HireDate.Visible = false;

            checkBox_ShiftDate.Visible = false;

            checkBox_VisitDate.Visible = false;

            checkBox_CommittedIncidentDate.Visible = false;

            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            label4.Visible = false;
            comboBox_Cells.Visible = false;
            button_PrintReport.Visible = false;
            button_PrintReport1.Visible = false;

            bindingNavigator1.Items.Remove(bindingNavigatorAddNewItem);
            bindingNavigator1.Items.Remove(bindingNavigatorDeleteItem);

            dataGridView1.Location = new Point(12, 180);

            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Right;
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
            personLoad();
        }

        private void personLoad()
        {
            search = "";

            bindingNavigator1.Visible = true;

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

            textBox_Search.Visible = true;
            label_Search.Visible = true;

            checkBox1.Checked = false;
            checkBox2.Checked = false;

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            label4.Visible = false;
            comboBox_Cells.Visible = false;
            button_PrintReport.Visible = false;
            button_PrintReport1.Visible = false;

            bindingNavigator1.Items.Remove(bindingNavigatorAddNewItem);
            bindingNavigator1.Items.Remove(bindingNavigatorDeleteItem);

            dataGridView1.Location = new Point(12, 180);

            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Right;
        }

        private void prisonerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            prisonerLoad();
        }

        private void prisonerLoad()
        {
            search = "";

            bindingNavigator1.Visible = true;

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
            dataGridView1.Columns["cell_number"].DisplayIndex = 4;

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
            textBox_Search.Visible = true;
            label_Search.Visible = true;

            checkBox1.Checked = false;
            checkBox2.Checked = false;

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            label4.Visible = false;
            comboBox_Cells.Visible = false;
            button_PrintReport.Visible = false;
            button_PrintReport1.Visible = false;

            bindingNavigator1.Items.Remove(bindingNavigatorAddNewItem);
            bindingNavigator1.Items.Remove(bindingNavigatorDeleteItem);

            dataGridView1.Location = new Point(12, 180);

            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Right;
        }

        private void jailerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            jailerLoad();
        }

        private void jailerLoad()
        {
            search = "";

            bindingNavigator1.Visible = true;

            bindingNavigator1.BindingSource = jailerBindingSource;
            dataGridView1.DataSource = jailerBindingSource;
            label1.Text = "Jailers";

            //dataGridView1.Columns[0].Visible = false;

            dataGridView1.Columns["jailer_id"].Visible = false;

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
            textBox_Search.Visible = true;
            label_Search.Visible = true;

            checkBox1.Checked = false;
            checkBox2.Checked = false;

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            label4.Visible = false;
            comboBox_Cells.Visible = false;
            button_PrintReport.Visible = false;
            button_PrintReport1.Visible = true;

            bindingNavigator1.Items.Remove(bindingNavigatorAddNewItem);
            bindingNavigator1.Items.Remove(bindingNavigatorDeleteItem);

            dataGridView1.Location = new Point(12, 180);

            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Right;
        }

        private void jailerOnShiftToolStripMenuItem_Click(object sender, EventArgs e)
        {
            jailerOnShiftLoad();
        }

        private void jailerOnShiftLoad()
        {
            search = "";

            bindingNavigator1.Visible = true;

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

            dataGridView1.Columns[0].Visible = false;

            dataGridView1.Columns["SNP"].DisplayIndex = 0;
            dataGridView1.Columns["cell_number"].DisplayIndex = 1;
            dataGridView1.Columns["shift_date"].DisplayIndex = 2;

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
            textBox_Search.Visible = true;
            label_Search.Visible = true;

            checkBox1.Checked = false;
            checkBox2.Checked = false;

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            label4.Visible = false;
            comboBox_Cells.Visible = false;
            button_PrintReport.Visible = false;
            button_PrintReport1.Visible = false;

            bindingNavigator1.Items.Remove(bindingNavigatorAddNewItem);
            bindingNavigator1.Items.Remove(bindingNavigatorDeleteItem);

            dataGridView1.Location = new Point(12, 180);

            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Right;
        }

        private void cellToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cellLoad();
        }

        private void cellLoad()
        {
            search = "";

            bindingNavigator1.Visible = true;

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
            textBox_Search.Visible = true;
            label_Search.Visible = true;

            checkBox1.Checked = false;
            checkBox2.Checked = false;

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            comboBox_Cells.DropDownStyle = ComboBoxStyle.DropDownList;
            label4.Visible = true;
            comboBox_Cells.Visible = true;
            button_PrintReport.Visible = true;
            button_PrintReport1.Visible = false;

            bindingNavigator1.Items.Remove(bindingNavigatorAddNewItem);
            bindingNavigator1.Items.Remove(bindingNavigatorDeleteItem);

            dataGridView1.Location = new Point(12, 180);

            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Right;
        }

        private void visitorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            visitorLoad();
        }

        private void visitorLoad()
        {
            search = "";

            bindingNavigator1.Visible = true;

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
            textBox_Search.Visible = true;
            label_Search.Visible = true;

            checkBox1.Checked = false;
            checkBox2.Checked = false;

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            label4.Visible = false;
            comboBox_Cells.Visible = false;
            button_PrintReport.Visible = false;
            button_PrintReport1.Visible = false;

            bindingNavigator1.Items.Remove(bindingNavigatorAddNewItem);
            bindingNavigator1.Items.Remove(bindingNavigatorDeleteItem);

            dataGridView1.Location = new Point(12, 180);

            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Right;
        }

        private void visitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            visitLoad();
        }

        private void visitLoad()
        {
            search = "";

            bindingNavigator1.Visible = true;

            bindingNavigator1.BindingSource = visitBindingSource;
            dataGridView1.DataSource = visitBindingSource;
            label1.Text = "Visits";

            string query = @"
                SELECT Visit.visit_id, Visit.relation_to_the_prisoner, Visit.date_of_visit, Visit.time_of_visit,
                Visitor.SNP AS Visitors_SNP, Person.SNP AS Prisoners_SNP
                FROM Visit
                LEFT JOIN Visitor ON Visit.visitor_id = Visitor.visitor_id
                LEFT JOIN Prisoner ON Visit.prisoner_id = Prisoner.prisoner_id
                LEFT JOIN Person ON Prisoner.person_id = Person.person_id
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

            dataGridView1.Columns[0].Visible = false;

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
            textBox_Search.Visible = true;
            label_Search.Visible = true;

            checkBox1.Checked = false;
            checkBox2.Checked = false;

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            label4.Visible = false;
            comboBox_Cells.Visible = false;
            button_PrintReport.Visible = false;
            button_PrintReport1.Visible = false;

            bindingNavigator1.Items.Remove(bindingNavigatorAddNewItem);
            bindingNavigator1.Items.Remove(bindingNavigatorDeleteItem);

            dataGridView1.Location = new Point(12, 180);

            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Right;
        }

        private void incidentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            incidentLoad();
        }

        private void incidentLoad()
        {
            search = "";

            bindingNavigator1.Visible = true;

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
            textBox_Search.Visible = true;
            label_Search.Visible = true;

            checkBox1.Checked = false;
            checkBox2.Checked = false;

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            label4.Visible = false;
            comboBox_Cells.Visible = false;
            button_PrintReport.Visible = false;
            button_PrintReport1.Visible = false;

            bindingNavigator1.Items.Remove(bindingNavigatorAddNewItem);
            bindingNavigator1.Items.Remove(bindingNavigatorDeleteItem);

            dataGridView1.Location = new Point(12, 180);

            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Right;
        }

        private void committedIncidentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            committedIncidentLoad();
        }

        private void committedIncidentLoad()
        {
            search = "";

            bindingNavigator1.Visible = true;

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

            dataGridView1.Columns["Incident_type"].DisplayIndex = 0;
            dataGridView1.Columns["date_of_incident"].DisplayIndex = 1;
            dataGridView1.Columns["time_of_incident"].DisplayIndex = 2;

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
            textBox_Search.Visible = true;
            label_Search.Visible = true;

            checkBox1.Checked = false;
            checkBox2.Checked = false;

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            label4.Visible = false;
            comboBox_Cells.Visible = false;
            button_PrintReport.Visible = false;
            button_PrintReport1.Visible = false;

            bindingNavigator1.Items.Remove(bindingNavigatorAddNewItem);
            bindingNavigator1.Items.Remove(bindingNavigatorDeleteItem);

            dataGridView1.Location = new Point(12, 180);

            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Right;
        }

        private void participantsOfTheIncidentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            participantsOfTheIncidentLoad();
        }

        private void participantsOfTheIncidentLoad()
        {
            search = "";

            bindingNavigator1.Visible = true;

            bindingNavigator1.BindingSource = participantsoftheincidentBindingSource;
            dataGridView1.DataSource = participantsoftheincidentBindingSource;
            label1.Text = "Participants of the incidents";

            string query = @"
                SELECT Participants_of_the_incident.committed_incident_id,
                Incident.incident_type AS Incident_type, Person.SNP AS Prisoners_SNP
                FROM Participants_of_the_incident
                LEFT JOIN Incident ON Participants_of_the_incident.committed_incident_id = Incident.incident_id
                LEFT JOIN Prisoner ON Participants_of_the_incident.prisoner_id = Prisoner.prisoner_id
                LEFT JOIN Person ON Prisoner.person_id = Person.person_id

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

            dataGridView1.Columns["Prisoners_SNP"].DisplayIndex = 0;
            dataGridView1.Columns["Incident_type"].DisplayIndex = 1;

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
            textBox_Search.Visible = true;
            label_Search.Visible = true;

            checkBox1.Checked = false;
            checkBox2.Checked = false;

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            label4.Visible = false;
            comboBox_Cells.Visible = false;
            button_PrintReport.Visible = false;
            button_PrintReport1.Visible = false;

            bindingNavigator1.Items.Remove(bindingNavigatorAddNewItem);
            bindingNavigator1.Items.Remove(bindingNavigatorDeleteItem);

            dataGridView1.Location = new Point(12, 180);

            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Right;
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

                personLoad();
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

                prisonerLoad();
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

                jailerLoad();
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

                cellLoad();
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

                jailerOnShiftLoad();
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

                visitLoad();
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

                visitorLoad();
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

                participantsOfTheIncidentLoad();
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

                committedIncidentLoad();
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

                incidentLoad();
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

                personLoad();
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

                prisonerLoad();
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

                    jailerLoad();
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

                cellLoad();
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

                jailerOnShiftLoad();
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

                visitLoad();
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

                visitorLoad();
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

                participantsOfTheIncidentLoad();
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
                    row[2].ToString(),
                    Convert.ToInt32(row[3])
                );
                edt.ShowDialog();
                committed_incidentTableAdapter.Fill(prisonDataBaseDataSet.Committed_incident);
                prisonDataBaseDataSet.AcceptChanges();

                committedIncidentLoad();
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

                incidentLoad();
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bindingNavigator1.BindingSource == personBindingSource)
            {
                int personId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);

                if (!HasDependenciesForPerson(personId))
                {
                    DialogResult result = MessageBox.Show("Are you sure you want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        personTableAdapter.DeleteQuery(personId);
                        personTableAdapter.Fill(prisonDataBaseDataSet.Person);
                        prisonDataBaseDataSet.AcceptChanges();

                        personLoad();

                        MessageBox.Show("Record deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("This person record has dependencies and cannot be deleted.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            else if (bindingNavigator1.BindingSource == prisonerBindingSource)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete this record? All dependent records will be deleted automatically.", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    prisonerTableAdapter.DeleteQuery(Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value));
                    prisonerTableAdapter.Fill(prisonDataBaseDataSet.Prisoner);
                    prisonDataBaseDataSet.AcceptChanges();

                    prisonerLoad();

                    MessageBox.Show("Record deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            else if (bindingNavigator1.BindingSource == jailerBindingSource)
            {
                int jailerId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);

                if (!HasDependenciesForJailer(jailerId))
                {
                    DialogResult result = MessageBox.Show("Are you sure you want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        jailerTableAdapter.DeleteQuery(jailerId);
                        jailerTableAdapter.Fill(prisonDataBaseDataSet.Jailer);
                        prisonDataBaseDataSet.AcceptChanges();

                        jailerLoad();

                        MessageBox.Show("Record deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("This jailer record has dependencies and cannot be deleted.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (bindingNavigator1.BindingSource == cellBindingSource)
            {
                int cellId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);

                if (!HasDependenciesForCell(cellId))
                {
                    DialogResult result = MessageBox.Show("Are you sure you want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        cellTableAdapter.DeleteQuery(Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value));
                        cellTableAdapter.Fill(prisonDataBaseDataSet.Cell);
                        prisonDataBaseDataSet.AcceptChanges();

                        cellLoad();

                        MessageBox.Show("Record deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("This cell record has dependencies and cannot be deleted.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (bindingNavigator1.BindingSource == jaileronshiftBindingSource)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    jailer_on_shiftTableAdapter.DeleteQuery(Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value));
                    jailer_on_shiftTableAdapter.Fill(prisonDataBaseDataSet.Jailer_on_shift);
                    prisonDataBaseDataSet.AcceptChanges();

                    jailerOnShiftLoad();

                    MessageBox.Show("Record deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            if (bindingNavigator1.BindingSource == visitBindingSource)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    visitTableAdapter.DeleteQuery(Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value));
                    visitTableAdapter.Fill(prisonDataBaseDataSet.Visit);
                    prisonDataBaseDataSet.AcceptChanges();

                    visitLoad();

                    MessageBox.Show("Record deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            if (bindingNavigator1.BindingSource == visitorBindingSource)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete this record? All dependent records will be deleted automatically.", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    visitorTableAdapter.DeleteQuery(Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value));
                    visitorTableAdapter.Fill(prisonDataBaseDataSet.Visitor);
                    prisonDataBaseDataSet.AcceptChanges();

                    visitorLoad();

                    MessageBox.Show("Record deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            if (bindingNavigator1.BindingSource == participantsoftheincidentBindingSource)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    participants_of_the_incidentTableAdapter.DeleteQuery(Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value));
                    participants_of_the_incidentTableAdapter.Fill(prisonDataBaseDataSet.Participants_of_the_incident);
                    prisonDataBaseDataSet.AcceptChanges();

                    participantsOfTheIncidentLoad();

                    MessageBox.Show("Record deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            if (bindingNavigator1.BindingSource == committedincidentBindingSource)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete this record? All dependent records will be deleted automatically.", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    committed_incidentTableAdapter.DeleteQuery(Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value));
                    committed_incidentTableAdapter.Fill(prisonDataBaseDataSet.Committed_incident);
                    prisonDataBaseDataSet.AcceptChanges();

                    committedIncidentLoad();

                    MessageBox.Show("Record deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            if (bindingNavigator1.BindingSource == incidentBindingSource)
            {
                int incidentId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);

                if (!HasDependenciesForIncident(incidentId))
                {
                    DialogResult result = MessageBox.Show("Are you sure you want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        incidentTableAdapter.DeleteQuery(Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value));
                        incidentTableAdapter.Fill(prisonDataBaseDataSet.Incident);
                        prisonDataBaseDataSet.AcceptChanges();

                        incidentLoad();

                        MessageBox.Show("Record deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("This incident record has dependencies and cannot be deleted.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool HasDependenciesForPerson(int personId)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;

                    command.CommandText = "SELECT COUNT(*) FROM Prisoner WHERE person_id = @personId";
                    command.Parameters.AddWithValue("@personId", personId);

                    int prisonerCount = (int)command.ExecuteScalar();

                    if (prisonerCount > 0)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private bool HasDependenciesForJailer(int jailerId)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;

                    command.CommandText = "SELECT COUNT(*) FROM Jailer_on_shift WHERE jailer_id = @jailerId";
                    command.Parameters.AddWithValue("@jailerId", jailerId);

                    int jailerOnShiftCount = (int)command.ExecuteScalar();

                    if (jailerOnShiftCount > 0)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private bool HasDependenciesForCell(int cellId)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;

                    command.CommandText = "SELECT COUNT(*) FROM Prisoner WHERE cell_id = @cellId";
                    command.Parameters.AddWithValue("@cellId", cellId);

                    int prisonerCount = (int)command.ExecuteScalar();

                    command.CommandText = "SELECT COUNT(*) FROM Jailer_on_shift WHERE cell_id = @cellId";
                    int jailerOnShiftCount = (int)command.ExecuteScalar();

                    if (prisonerCount > 0 || jailerOnShiftCount > 0)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private bool HasDependenciesForIncident(int incidentId)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;

                    command.CommandText = "SELECT COUNT(*) FROM Committed_incident WHERE incident_id = @incidentId";
                    command.Parameters.AddWithValue("@incidentId", incidentId);

                    int incidentCount = (int)command.ExecuteScalar();

                    if (incidentCount > 0)
                    {
                        return true;
                    }
                }
            }

            return false;
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

                    MessageBox.Show("The text file was successfully created!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private string orderBy = "";

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

            if (bindingNavigator1.BindingSource == personBindingSource)
            {
                orderBy = "";
                orderBy = "SELECT * FROM Person WHERE 1=1";

                if (checkBox_Sort.Checked)
                {
                    orderBy += " ORDER BY SNP";
                }

                personBindingSource.DataSource = Query(ConnectionString, orderBy);
            }

            if (bindingNavigator1.BindingSource == jailerBindingSource)
            {
                orderBy = "";
                orderBy = "SELECT * FROM Jailer WHERE 1=1";

                if (checkBox_Sort.Checked)
                {
                    orderBy += " ORDER BY SNP";
                }

                jailerBindingSource.DataSource = Query(ConnectionString, orderBy);
            }

            if (bindingNavigator1.BindingSource == visitorBindingSource)
            {
                orderBy = "";
                orderBy = "SELECT * FROM Visitor WHERE 1=1";

                if (checkBox_Sort.Checked)
                {
                    orderBy += " ORDER BY SNP";
                }

                visitorBindingSource.DataSource = Query(ConnectionString, orderBy);
            }
        }

        private string filter = "";

        private void comboBox_Filtration_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bindingNavigator1.BindingSource == personBindingSource)
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

            if (bindingNavigator1.BindingSource == jailerBindingSource)
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

                string sqlQuery = "SELECT * FROM Jailer";

                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    if (!string.IsNullOrEmpty(filter))
                    {
                        sqlQuery += " WHERE " + filter;
                    }

                    if (checkBox_HireDate.Checked)
                    {
                        DateTime startDate = dateTimePicker1.Value;
                        DateTime endDate = dateTimePicker2.Value;

                        string startDateString = $"'{startDate:yyyy-MM-dd}'";
                        string endDateString = $"'{endDate:yyyy-MM-dd}'";

                        sqlQuery += string.IsNullOrEmpty(filter) ? " WHERE " : " AND ";
                        sqlQuery += $"hire_date >= {startDateString} AND hire_date <= {endDateString}";
                    }

                    if (checkBox_Sort.Checked)
                    {
                        sqlQuery += " ORDER BY SNP";
                    }

                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
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

                            MessageBox.Show("The text file was successfully created!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
        }

        private void visitsOfPrisonersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label1.Text = "Prisoners and visits";

            label_Filter.Visible = false;
            label3.Visible = false;
            comboBox_Filtration.Visible = false;
            dateTimePicker1.Visible = false;
            dateTimePicker2.Visible = false;
            label2.Visible = false;
            checkBox1.Visible = false;
            checkBox_BirthdayDate.Visible = false;
            checkBox_ShiftDate.Visible = false;
            checkBox_ReleaseDate.Visible = false;
            checkBox_VisitDate.Visible = false;
            checkBox_HireDate.Visible = false;
            checkBox_CommittedIncidentDate.Visible = false;
            label4.Visible = false;
            comboBox_Cells.Visible = false;
            button_PrintReport.Visible = false;
            button_PrintReport1.Visible = false;
            label_Search.Visible = false;
            checkBox2.Visible = false;
            textBox_Search.Visible = false;
            label_Sort.Visible = false;
            checkBox_Sort.Visible = false;
            bindingNavigator1.Visible = false;

            dataGridView1.Location = new Point(15, 80);

            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Right;

            string query = @"
                DECLARE @columns NVARCHAR(MAX), @sql NVARCHAR(MAX);

                SELECT @columns = STRING_AGG(QUOTENAME(prisoner_name), ', ')
                FROM (
                    SELECT DISTINCT Person.SNP AS prisoner_name
                    FROM Person 
                    INNER JOIN Prisoner ON Person.person_id = Prisoner.person_id
                    INNER JOIN Visit ON Prisoner.prisoner_id = Visit.prisoner_id
                ) AS prisoner_names;

                SET @sql = N'
                    SELECT visitor_SNP, ' + @columns + ' 
                    FROM (
                        SELECT
                            Person.SNP AS prisoner_name,
                            Visitor.SNP AS visitor_SNP,
                            COUNT(*) AS visit_count -- Підрахунок кількості відвідувань
                            FROM Person
                            INNER JOIN Prisoner ON Person.person_id = Prisoner.person_id
                            INNER JOIN Visit ON Prisoner.prisoner_id = Visit.prisoner_id
                            INNER JOIN Visitor ON Visit.visitor_id = Visitor.visitor_id
                            GROUP BY 
                                Person.SNP,
                                Visitor.SNP
                    ) AS source_table
                    PIVOT (
                        SUM(visit_count) FOR prisoner_name IN (' + @columns + ')  
                    ) AS pivot_table;
                ';
                EXEC sp_executesql @sql;
            ";

            dataGridView1.DataSource = Query(ConnectionString, query);
        }

        private void exitToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private string combinedFilter;

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

            combinedFilter = string.Join(" AND ", filters);

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
            if (!checkBox_CommittedIncidentDate.Checked)
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

        private DateTime previousDateTimePicker1Value;
        private DateTime previousDateTimePicker2Value;

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (bindingNavigator1.BindingSource == personBindingSource)
            {
                if (dateTimePicker1.Value != previousDateTimePicker1Value)
                {
                    checkBox_BirthdayDate.Checked = false;
                }
                previousDateTimePicker1Value = dateTimePicker1.Value;
            }

            else if (bindingNavigator1.BindingSource == prisonerBindingSource)
            {
                if (dateTimePicker1.Value != previousDateTimePicker1Value)
                {
                    checkBox_ReleaseDate.Checked = false;
                }
                previousDateTimePicker1Value = dateTimePicker1.Value;
            }

            else if (bindingNavigator1.BindingSource == jailerBindingSource)
            {
                if (dateTimePicker1.Value != previousDateTimePicker1Value)
                {
                    checkBox_HireDate.Checked = false;
                }
                previousDateTimePicker1Value = dateTimePicker1.Value;
            }

            else if (bindingNavigator1.BindingSource == jaileronshiftBindingSource)
            {
                if (dateTimePicker1.Value != previousDateTimePicker1Value)
                {
                    checkBox_ShiftDate.Checked = false;
                }
                previousDateTimePicker1Value = dateTimePicker1.Value;
            }

            else if (bindingNavigator1.BindingSource == visitBindingSource)
            {
                if (dateTimePicker1.Value != previousDateTimePicker1Value)
                {
                    checkBox_VisitDate.Checked = false;
                }
                previousDateTimePicker1Value = dateTimePicker1.Value;
            }

            else if (bindingNavigator1.BindingSource == committedincidentBindingSource)
            {
                if (dateTimePicker1.Value != previousDateTimePicker1Value)
                {
                    checkBox_CommittedIncidentDate.Checked = false;
                }
                previousDateTimePicker1Value = dateTimePicker1.Value;
            }     
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            if (bindingNavigator1.BindingSource == personBindingSource)
            {
                if (dateTimePicker2.Value != previousDateTimePicker2Value)
                {
                    checkBox_BirthdayDate.Checked = false;
                }
                previousDateTimePicker2Value = dateTimePicker2.Value;
            }

            else if (bindingNavigator1.BindingSource == prisonerBindingSource)
            {
                if (dateTimePicker2.Value != previousDateTimePicker2Value)
                {
                    checkBox_ReleaseDate.Checked = false;
                }
                previousDateTimePicker2Value = dateTimePicker2.Value;
            }

            else if (bindingNavigator1.BindingSource == jailerBindingSource)
            {
                if (dateTimePicker2.Value != previousDateTimePicker2Value)
                {
                    checkBox_HireDate.Checked = false;
                }
                previousDateTimePicker2Value = dateTimePicker2.Value;
            }

            else if (bindingNavigator1.BindingSource == jaileronshiftBindingSource)
            {
                if (dateTimePicker2.Value != previousDateTimePicker2Value)
                {
                    checkBox_ShiftDate.Checked = false;
                }
                previousDateTimePicker2Value = dateTimePicker2.Value;
            }

            else if (bindingNavigator1.BindingSource == visitBindingSource)
            {
                if (dateTimePicker2.Value != previousDateTimePicker2Value)
                {
                    checkBox_VisitDate.Checked = false;
                }
                previousDateTimePicker1Value = dateTimePicker2.Value;
            }

            else if (bindingNavigator1.BindingSource == committedincidentBindingSource)
            {
                if (dateTimePicker2.Value != previousDateTimePicker2Value)
                {
                    checkBox_CommittedIncidentDate.Checked = false;
                }
                previousDateTimePicker2Value = dateTimePicker2.Value;
            }
        }
    }
}