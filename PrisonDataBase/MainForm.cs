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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "prisonDataBaseDataSet.Prisoner". При необходимости она может быть перемещена или удалена.
            this.prisonerTableAdapter.Fill(this.prisonDataBaseDataSet.Prisoner);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "prisonDataBaseDataSet.Visitor". При необходимости она может быть перемещена или удалена.
            this.visitorTableAdapter.Fill(this.prisonDataBaseDataSet.Visitor);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "prisonDataBaseDataSet.Visit". При необходимости она может быть перемещена или удалена.
            this.visitTableAdapter.Fill(this.prisonDataBaseDataSet.Visit);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "prisonDataBaseDataSet.Participants_of_the_incident". При необходимости она может быть перемещена или удалена.
            this.participants_of_the_incidentTableAdapter.Fill(this.prisonDataBaseDataSet.Participants_of_the_incident);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "prisonDataBaseDataSet.Jailer_on_shift". При необходимости она может быть перемещена или удалена.
            this.jailer_on_shiftTableAdapter.Fill(this.prisonDataBaseDataSet.Jailer_on_shift);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "prisonDataBaseDataSet.Incident". При необходимости она может быть перемещена или удалена.
            this.incidentTableAdapter.Fill(this.prisonDataBaseDataSet.Incident);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "prisonDataBaseDataSet.Committed_incident". При необходимости она может быть перемещена или удалена.
            this.committed_incidentTableAdapter.Fill(this.prisonDataBaseDataSet.Committed_incident);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "prisonDataBaseDataSet.Cell". При необходимости она может быть перемещена или удалена.
            this.cellTableAdapter.Fill(this.prisonDataBaseDataSet.Cell);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "prisonDataBaseDataSet.Jailer". При необходимости она может быть перемещена или удалена.
            this.jailerTableAdapter.Fill(this.prisonDataBaseDataSet.Jailer);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "prisonDataBaseDataSet.Prisoner". При необходимости она может быть перемещена или удалена.
            this.prisonerTableAdapter.Fill(this.prisonDataBaseDataSet.Prisoner);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "prisonDataBaseDataSet.Person". При необходимости она может быть перемещена или удалена.
            this.personTableAdapter.Fill(this.prisonDataBaseDataSet.Person);

            dataGridView1.AutoGenerateColumns = true;

            dataGridView1.Columns[0].Visible = false;
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
        }

        private void prisonerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bindingNavigator1.BindingSource = prisonerBindingSource;
            dataGridView1.DataSource = prisonerBindingSource;
            label1.Text = "Prisoners";

            dataGridView1.Columns[0].Visible = false;
        }

        private void jailerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bindingNavigator1.BindingSource = jailerBindingSource;
            dataGridView1.DataSource = jailerBindingSource;
            label1.Text = "Jailers";

            dataGridView1.Columns[0].Visible = false;
        }

        private void jailerOnShiftToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bindingNavigator1.BindingSource = jaileronshiftBindingSource;
            dataGridView1.DataSource = jaileronshiftBindingSource;
            label1.Text = "Jailers on shift";

            dataGridView1.Columns[0].Visible = false;
        }

        private void cellToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bindingNavigator1.BindingSource = cellBindingSource;
            dataGridView1.DataSource = cellBindingSource;
            label1.Text = "Cells";

            dataGridView1.Columns[0].Visible = false;
        }

        private void visitorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bindingNavigator1.BindingSource = visitorBindingSource;
            dataGridView1.DataSource = visitorBindingSource;
            label1.Text = "Visitors";

            dataGridView1.Columns[0].Visible = false;
        }

        private void visitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bindingNavigator1.BindingSource = visitBindingSource;
            dataGridView1.DataSource = visitBindingSource;
            label1.Text = "Visits";

            dataGridView1.Columns[0].Visible = false;
        }

        private void incidentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bindingNavigator1.BindingSource = incidentBindingSource;
            dataGridView1.DataSource = incidentBindingSource;
            label1.Text = "Incidents";

            dataGridView1.Columns[0].Visible = false;
        }

        private void comittedIncidentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bindingNavigator1.BindingSource = committedincidentBindingSource;
            dataGridView1.DataSource = committedincidentBindingSource;
            label1.Text = "Committed incidents";

            dataGridView1.Columns[0].Visible = false;
        }

        private void participantsOfTheIncidentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bindingNavigator1.BindingSource = participantsoftheincidentBindingSource;
            dataGridView1.DataSource = participantsoftheincidentBindingSource;
            label1.Text = "Participants of the incidents";

            dataGridView1.Columns[0].Visible = false;
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
        }
    }
}