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
        public EditJailerOnShift()
        {
            InitializeComponent();
        }

        private void EditJailerOnShift_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "prisonDataBaseDataSet.Cell". При необходимости она может быть перемещена или удалена.
            this.cellTableAdapter.Fill(this.prisonDataBaseDataSet.Cell);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "prisonDataBaseDataSet.Jailer". При необходимости она может быть перемещена или удалена.
            this.jailerTableAdapter.Fill(this.prisonDataBaseDataSet.Jailer);

        }
    }
}
