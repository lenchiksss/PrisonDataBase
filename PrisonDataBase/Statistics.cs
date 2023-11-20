using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrisonDataBase
{
    public partial class Statistics : Form
    {
        private const string ConnectionString = "Data Source=DESKTOP-6BKJL0I\\MSSQL;Initial Catalog=PrisonDataBase;Integrated Security=True;Connect Timeout=30; TrustServerCertificate=True";

        public Statistics()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query1 = @"
                SELECT TOP 1 WITH TIES Person.SNP, COUNT(Participants_of_the_incident.committed_incident_id) AS Incidents_count
                FROM Prisoner
                JOIN Participants_of_the_incident ON Prisoner.prisoner_id = Participants_of_the_incident.prisoner_id
                JOIN Person ON Prisoner.person_id = Person.person_id
                GROUP BY Person.SNP
                ORDER BY Incidents_count DESC;
            ";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query1, connection);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string query2 = @"
                SELECT SNP, Salary
                FROM Jailer
                WHERE salary = (SELECT MAX(salary) FROM Jailer)
                ORDER BY SNP ASC;
            ";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query2, connection);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string query3 = @"
                SELECT TOP 1 WITH TIES Visitor.SNP AS SNP, COUNT(Prisoner.prisoner_id) AS Prisoners_count
                FROM Visit
                JOIN Prisoner ON Visit.prisoner_id = Prisoner.prisoner_id
                JOIN Visitor ON Visit.visitor_id = Visitor.visitor_id
                GROUP BY Visitor.SNP
                ORDER BY Prisoners_count DESC;
            ";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query3, connection);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string query4 = @"
                SELECT TOP 1 WITH TIES Jailer.SNP, COUNT(DISTINCT Jailer_on_shift.cell_id) AS Cells
                FROM Jailer
                JOIN Jailer_on_shift ON Jailer.jailer_id = Jailer_on_shift.jailer_id
                GROUP BY Jailer.SNP
                ORDER BY Cells DESC;
            ";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query4, connection);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
            }
        }
    }
}