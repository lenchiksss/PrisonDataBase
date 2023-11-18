﻿using PrisonDataBase.PrisonDataBaseDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PrisonDataBase
{
    public partial class EditPrisoner : Form
    {
        private readonly int id;

        readonly bool edit;

        public EditPrisoner()
        {
            InitializeComponent();

            personTableAdapter.Fill(prisonDataBaseDataSet.Person);
            cellTableAdapter.Fill(prisonDataBaseDataSet.Cell);

            edit = false;
        }

        private void EditPrisoner_Load(object sender, EventArgs e)
        {
            this.prisonerTableAdapter.Fill(this.prisonDataBaseDataSet.Prisoner);
            this.cellTableAdapter.Fill(this.prisonDataBaseDataSet.Cell);
            this.personTableAdapter.Fill(this.prisonDataBaseDataSet.Person);
        }

        public EditPrisoner(int id, DateTime incarcerationDate, DateTime releaseDate, string numberOfArticle, string personSNP, int cellNumber)
           : this()
        {
            personTableAdapter.Fill(prisonDataBaseDataSet.Person);
            cellTableAdapter.Fill(prisonDataBaseDataSet.Cell);

            edit = true;
            this.id = id;
            dateTimePicker_IncarcerationDate.Value = incarcerationDate;
            dateTimePicker_ReleaseDate.Value = releaseDate;
            textBox_NumberOfArticle.Text = numberOfArticle;
            comboBox_SNP.SelectedValue = personSNP;
            comboBox_CellNumber.SelectedValue = cellNumber;
        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            if (edit)
            {
                prisonerTableAdapter.UpdateQuery(dateTimePicker_IncarcerationDate.Value.ToString("yyyy-MM-dd"),
                          dateTimePicker_ReleaseDate.Value.ToString("yyyy-MM-dd"),
                          textBox_NumberOfArticle.Text,
                          Convert.ToInt32(comboBox_SNP.SelectedValue),
                          Convert.ToInt32(comboBox_CellNumber.SelectedValue),
                          id);
            }
            else
            {
                prisonerTableAdapter.InsertQuery(dateTimePicker_IncarcerationDate.Value.ToString("yyyy-MM-dd"),
                          dateTimePicker_ReleaseDate.Value.ToString("yyyy-MM-dd"),
                          textBox_NumberOfArticle.Text,
                          Convert.ToInt32(comboBox_SNP.SelectedValue),
                          Convert.ToInt32(comboBox_CellNumber.SelectedValue));
            }
            Close();
        }

        private void button_CANCEL_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}