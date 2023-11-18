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
    public partial class EditVisit : Form
    {
        public EditVisit()
        {
            InitializeComponent();
        }

        private void EditVisit_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "prisonDataBaseDataSet.Person". При необходимости она может быть перемещена или удалена.
            this.personTableAdapter.Fill(this.prisonDataBaseDataSet.Person);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "prisonDataBaseDataSet.Visitor". При необходимости она может быть перемещена или удалена.
            this.visitorTableAdapter.Fill(this.prisonDataBaseDataSet.Visitor);

        }
    }
}
