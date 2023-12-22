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
    public partial class EditVisit : Form
    {
        private readonly int id;

        readonly bool edit;

        public EditVisit()
        {
            InitializeComponent();

            edit = false;
        }

        private void EditVisit_Load(object sender, EventArgs e)
        {
            this.visitTableAdapter.Fill(this.prisonDataBaseDataSet.Visit);
            this.personTableAdapter.Fill(this.prisonDataBaseDataSet.Person);
            this.visitorTableAdapter.Fill(this.prisonDataBaseDataSet.Visitor);
        }

        public EditVisit(int id, string relation, DateTime dateOfVisit, string timeOfVisit, string visitorsSNP, string prisonersSNP)
           : this()
        {
            personTableAdapter.Fill(prisonDataBaseDataSet.Person);
            visitorTableAdapter.Fill(prisonDataBaseDataSet.Visitor);

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

        private bool ValidateInput()
        {
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
                visitTableAdapter.UpdateQuery(relation,
                          dateTimePicker_DateOfVisit.Value.ToString("yyyy-MM-dd"),
                          textBox_TimeOfVisit.Text,
                          Convert.ToInt32(comboBox_VisitorsSNP.SelectedValue),
                          Convert.ToInt32(comboBox_PrisonersSNP.SelectedValue),
                          id);
            }
            else
            {
                visitTableAdapter.InsertQuery(relation,
                          dateTimePicker_DateOfVisit.Value.ToString("yyyy-MM-dd"),
                          textBox_TimeOfVisit.Text,
                          Convert.ToInt32(comboBox_VisitorsSNP.SelectedValue),
                          Convert.ToInt32(comboBox_PrisonersSNP.SelectedValue));
            }
            Close();
        }

        private void button_CANCEL_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}