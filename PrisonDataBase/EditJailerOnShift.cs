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
    public partial class EditJailerOnShift : Form
    {
        private readonly int id;

        readonly bool edit;

        public EditJailerOnShift()
        {
            InitializeComponent();

            edit = false;
        }

        private void EditJailerOnShift_Load(object sender, EventArgs e)
        {
            this.jailer_on_shiftTableAdapter.Fill(this.prisonDataBaseDataSet.Jailer_on_shift);
            this.cellTableAdapter.Fill(this.prisonDataBaseDataSet.Cell);
            this.jailerTableAdapter.Fill(this.prisonDataBaseDataSet.Jailer);
        }

        public EditJailerOnShift(int id, DateTime shiftDate, int snp, int cellNumber)
           : this()
        {
            jailerTableAdapter.Fill(prisonDataBaseDataSet.Jailer);
            cellTableAdapter.Fill(prisonDataBaseDataSet.Cell);

            edit = true;
            this.id = id;
            comboBox_SNP.SelectedValue = snp;
            dateTimePicker_ShiftDate.Value = shiftDate;
            comboBox_CellNumber.SelectedValue = cellNumber;
        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            if (edit)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to make these changes?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    jailer_on_shiftTableAdapter.UpdateQuery(dateTimePicker_ShiftDate.Value.ToString("yyyy-MM-dd"),
                          Convert.ToInt32(comboBox_SNP.SelectedValue),
                          Convert.ToInt32(comboBox_CellNumber.SelectedValue),
                          id);
                    MessageBox.Show("Record updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }

            else
            {
                jailer_on_shiftTableAdapter.InsertQuery(dateTimePicker_ShiftDate.Value.ToString("yyyy-MM-dd"),
                          Convert.ToInt32(comboBox_SNP.SelectedValue),
                          Convert.ToInt32(comboBox_CellNumber.SelectedValue));
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