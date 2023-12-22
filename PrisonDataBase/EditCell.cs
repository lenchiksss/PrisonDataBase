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
    public partial class EditCell : Form
    {
        private readonly int id;

        readonly bool edit;

        public EditCell()
        {
            InitializeComponent();

            numericUpDown_cellNumber.Minimum = 1;
            numericUpDown_Capacity.Minimum = 0;
            numericUpDown_CurrentOccupancy.Minimum = 0;

            edit = false;
        }

        public EditCell(int id, int cellNumber, int capacity, int currentOccupancy, string type)
           : this()
        {
            edit = true;
            this.id = id;
            numericUpDown_cellNumber.Text = cellNumber.ToString();
            numericUpDown_Capacity.Text = capacity.ToString();
            numericUpDown_CurrentOccupancy.Text = currentOccupancy.ToString();

            switch (type.ToLower())
            {
                case "single":
                    comboBox_cellType.SelectedIndex = 0;
                    break;
                case "double":
                    comboBox_cellType.SelectedIndex = 1;
                    break;
                case "multiple":
                    comboBox_cellType.SelectedIndex = 2;
                    break;
                default:
                    comboBox_cellType.SelectedIndex = 0;
                    break;
            }
        }

        private bool IsCellNumberExists(int cellNumber)
        {
            DataTable cellDataTable = prisonDataBaseDataSet.Tables["Cell"];

            var existingCell = cellDataTable.AsEnumerable().FirstOrDefault(row => (int)row["cell_number"] == cellNumber);

            return existingCell != null;
        }

        private int GetMaxOccupancyByType(string type)
        {
            switch (type.ToLower())
            {
                case "single":
                    return 1;
                case "double":
                    return 2;
                case "multiple":
                    return 6;
                default:
                    return 0;
            }
        }

        private bool ValidateInput()
        {
            int cellNumber = (int)numericUpDown_cellNumber.Value;
            int capacity = (int)numericUpDown_Capacity.Value;
            int currentOccupancy = (int)numericUpDown_CurrentOccupancy.Value;

            if (!edit && IsCellNumberExists(cellNumber))
            {
                MessageBox.Show("A cell with this number already exists.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (currentOccupancy > capacity)
            {
                MessageBox.Show("The current number of inmates cannot exceed the total capacity of the cell.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            string selectedType = comboBox_cellType.Text;
            int maxOccupancyByType = GetMaxOccupancyByType(selectedType);
            if (maxOccupancyByType > 0 && capacity > maxOccupancyByType)
            {
                MessageBox.Show($"The current number of inmates exceeds the maximum allowed for the selected cell type ({selectedType}).", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
            {
                return;
            }

            string type = "";
            if (comboBox_cellType.SelectedIndex == 0)
            {
                type = "single";
            }
            else if (comboBox_cellType.SelectedIndex == 1)
            {
                type = "double";
            }
            else if (comboBox_cellType.SelectedIndex == 2)
            {
                type = "multiple";
            }

            if (edit)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to make these changes?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    cellTableAdapter.UpdateQuery(Convert.ToInt32(numericUpDown_cellNumber.Value),
                              Convert.ToInt32(numericUpDown_Capacity.Value),
                              Convert.ToInt32(numericUpDown_CurrentOccupancy.Value),
                              type,
                              id);
                    MessageBox.Show("Record updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            else
            {
                cellTableAdapter.InsertQuery(Convert.ToInt32(numericUpDown_cellNumber.Value),
                              Convert.ToInt32(numericUpDown_Capacity.Value),
                              Convert.ToInt32(numericUpDown_CurrentOccupancy.Value),
                              type);
                MessageBox.Show("Record added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            Close();
        }

        private void EditCell_Load(object sender, EventArgs e)
        {
            this.cellTableAdapter.Fill(this.prisonDataBaseDataSet.Cell);
        }
    }
}