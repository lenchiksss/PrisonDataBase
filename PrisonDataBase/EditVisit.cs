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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PrisonDataBase
{
    public partial class EditVisit : Form
    {
        private const string ConnectionString = "Data Source=DESKTOP-6BKJL0I\\MSSQL;Initial Catalog=PrisonDataBase;Integrated Security=True;Connect Timeout=30; TrustServerCertificate=True";

        private readonly int id;

        readonly bool edit;

        public EditVisit()
        {
            InitializeComponent();

            //this.personTableAdapter.Fill(this.prisonDataBaseDataSet.Person);
            this.visitorTableAdapter.Fill(this.prisonDataBaseDataSet.Visitor);
            this.prisonerTableAdapter.Fill(this.prisonDataBaseDataSet.Prisoner);

            FillComboBox();

            edit = false;
        }

        private void EditVisit_Load(object sender, EventArgs e)
        {
            this.visitTableAdapter.Fill(this.prisonDataBaseDataSet.Visit);

            comboBox_VisitorsSNP.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_PrisonersSNP.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_RelationToThePrisoner.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        public EditVisit(int id, string relation, DateTime dateOfVisit, string timeOfVisit, string visitorsSNP, string prisonersSNP)
           : this()
        {
            //personTableAdapter.Fill(prisonDataBaseDataSet.Person);
            visitorTableAdapter.Fill(prisonDataBaseDataSet.Visitor);
            prisonerTableAdapter.Fill(prisonDataBaseDataSet.Prisoner);

            edit = true;
            this.id = id;
            comboBox_VisitorsSNP.SelectedValue = visitorsSNP;
            comboBox_PrisonersSNP.SelectedValue = prisonersSNP;

            switch (relation.ToLower())
            {
                case "friend":
                    comboBox_RelationToThePrisoner.SelectedIndex = 0;
                    break;
                case "family":
                    comboBox_RelationToThePrisoner.SelectedIndex = 1;
                    break;
                case "colleague":
                    comboBox_RelationToThePrisoner.SelectedIndex = 2;
                    break;
                case "other":
                    comboBox_RelationToThePrisoner.SelectedIndex = 3;
                    break;
                default:
                    comboBox_RelationToThePrisoner.SelectedIndex = 0;
                    break;
            }

            dateTimePicker_DateOfVisit.Value = dateOfVisit;
            textBox_TimeOfVisit.Text = timeOfVisit;
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

                comboBox_PrisonersSNP.DataSource = dt;
                comboBox_PrisonersSNP.DisplayMember = "SNP";
                comboBox_PrisonersSNP.ValueMember = "prisoner_id";
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(comboBox_RelationToThePrisoner.Text))
            {
                MessageBox.Show("Gender cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            string[] formats = { "HH:mm:ss" };
            DateTime result;

            if (DateTime.TryParseExact(textBox_TimeOfVisit.Text, formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out result))
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

            string relation = "";
            if (comboBox_RelationToThePrisoner.SelectedIndex == 0)
            {
                relation = "friend";
            }
            else if (comboBox_RelationToThePrisoner.SelectedIndex == 1)
            {
                relation = "family";
            }
            else if (comboBox_RelationToThePrisoner.SelectedIndex == 2)
            {
                relation = "colleague";
            }
            else if (comboBox_RelationToThePrisoner.SelectedIndex == 3)
            {
                relation = "other";
            }

            if (edit)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to make these changes?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    visitTableAdapter.UpdateQuery(relation,
                          dateTimePicker_DateOfVisit.Value.ToString("yyyy-MM-dd"),
                          textBox_TimeOfVisit.Text,
                          Convert.ToInt32(comboBox_VisitorsSNP.SelectedValue),
                          Convert.ToInt32(comboBox_PrisonersSNP.SelectedValue),
                          id);
                    MessageBox.Show("Record updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }

            else
            {
                visitTableAdapter.InsertQuery(relation,
                          dateTimePicker_DateOfVisit.Value.ToString("yyyy-MM-dd"),
                          textBox_TimeOfVisit.Text,
                          Convert.ToInt32(comboBox_VisitorsSNP.SelectedValue),
                          Convert.ToInt32(comboBox_PrisonersSNP.SelectedValue));
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