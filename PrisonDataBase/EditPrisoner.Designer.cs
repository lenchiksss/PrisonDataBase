namespace PrisonDataBase
{
    partial class EditPrisoner
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePicker_IncarcerationDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePicker_ReleaseDate = new System.Windows.Forms.DateTimePicker();
            this.textBox_NumberOfArticle = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox_SNP = new System.Windows.Forms.ComboBox();
            this.personBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.prisonDataBaseDataSet = new PrisonDataBase.PrisonDataBaseDataSet();
            this.personTableAdapter = new PrisonDataBase.PrisonDataBaseDataSetTableAdapters.PersonTableAdapter();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBox_CellNumber = new System.Windows.Forms.ComboBox();
            this.cellBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cellTableAdapter = new PrisonDataBase.PrisonDataBaseDataSetTableAdapters.CellTableAdapter();
            this.button_CANCEL = new System.Windows.Forms.Button();
            this.button_OK = new System.Windows.Forms.Button();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.prisonerTableAdapter = new PrisonDataBase.PrisonDataBaseDataSetTableAdapters.PrisonerTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.personBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.prisonDataBaseDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cellBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Prisoner";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(30, 191);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Incarceration date";
            // 
            // dateTimePicker_IncarcerationDate
            // 
            this.dateTimePicker_IncarcerationDate.Location = new System.Drawing.Point(200, 191);
            this.dateTimePicker_IncarcerationDate.Name = "dateTimePicker_IncarcerationDate";
            this.dateTimePicker_IncarcerationDate.Size = new System.Drawing.Size(223, 22);
            this.dateTimePicker_IncarcerationDate.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(61, 235);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 18);
            this.label3.TabIndex = 4;
            this.label3.Text = "Release date";
            // 
            // dateTimePicker_ReleaseDate
            // 
            this.dateTimePicker_ReleaseDate.Location = new System.Drawing.Point(200, 235);
            this.dateTimePicker_ReleaseDate.Name = "dateTimePicker_ReleaseDate";
            this.dateTimePicker_ReleaseDate.Size = new System.Drawing.Size(223, 22);
            this.dateTimePicker_ReleaseDate.TabIndex = 5;
            // 
            // textBox_NumberOfArticle
            // 
            this.textBox_NumberOfArticle.Location = new System.Drawing.Point(200, 141);
            this.textBox_NumberOfArticle.Name = "textBox_NumberOfArticle";
            this.textBox_NumberOfArticle.Size = new System.Drawing.Size(223, 22);
            this.textBox_NumberOfArticle.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(34, 142);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 18);
            this.label4.TabIndex = 7;
            this.label4.Text = "Number of article";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(116, 46);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 18);
            this.label5.TabIndex = 8;
            this.label5.Text = "SNP";
            // 
            // comboBox_SNP
            // 
            this.comboBox_SNP.DataSource = this.personBindingSource;
            this.comboBox_SNP.DisplayMember = "SNP";
            this.comboBox_SNP.FormattingEnabled = true;
            this.comboBox_SNP.Location = new System.Drawing.Point(200, 45);
            this.comboBox_SNP.Name = "comboBox_SNP";
            this.comboBox_SNP.Size = new System.Drawing.Size(223, 24);
            this.comboBox_SNP.TabIndex = 9;
            this.comboBox_SNP.ValueMember = "person_id";
            // 
            // personBindingSource
            // 
            this.personBindingSource.DataMember = "Person";
            this.personBindingSource.DataSource = this.prisonDataBaseDataSet;
            // 
            // prisonDataBaseDataSet
            // 
            this.prisonDataBaseDataSet.DataSetName = "PrisonDataBaseDataSet";
            this.prisonDataBaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // personTableAdapter
            // 
            this.personTableAdapter.ClearBeforeFill = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(68, 93);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 18);
            this.label6.TabIndex = 10;
            this.label6.Text = "Cell number";
            // 
            // comboBox_CellNumber
            // 
            this.comboBox_CellNumber.DataSource = this.cellBindingSource;
            this.comboBox_CellNumber.DisplayMember = "cell_number";
            this.comboBox_CellNumber.FormattingEnabled = true;
            this.comboBox_CellNumber.Location = new System.Drawing.Point(200, 93);
            this.comboBox_CellNumber.Name = "comboBox_CellNumber";
            this.comboBox_CellNumber.Size = new System.Drawing.Size(223, 24);
            this.comboBox_CellNumber.TabIndex = 11;
            this.comboBox_CellNumber.ValueMember = "cell_id";
            // 
            // cellBindingSource
            // 
            this.cellBindingSource.DataMember = "Cell";
            this.cellBindingSource.DataSource = this.prisonDataBaseDataSet;
            // 
            // cellTableAdapter
            // 
            this.cellTableAdapter.ClearBeforeFill = true;
            // 
            // button_CANCEL
            // 
            this.button_CANCEL.Location = new System.Drawing.Point(277, 282);
            this.button_CANCEL.Name = "button_CANCEL";
            this.button_CANCEL.Size = new System.Drawing.Size(123, 36);
            this.button_CANCEL.TabIndex = 13;
            this.button_CANCEL.Text = "CANCEL";
            this.button_CANCEL.UseVisualStyleBackColor = true;
            this.button_CANCEL.Click += new System.EventHandler(this.button_CANCEL_Click);
            // 
            // button_OK
            // 
            this.button_OK.Location = new System.Drawing.Point(58, 282);
            this.button_OK.Name = "button_OK";
            this.button_OK.Size = new System.Drawing.Size(123, 36);
            this.button_OK.TabIndex = 12;
            this.button_OK.Text = "OK";
            this.button_OK.UseVisualStyleBackColor = true;
            this.button_OK.Click += new System.EventHandler(this.button_OK_Click);
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataMember = "Prisoner";
            this.bindingSource1.DataSource = this.prisonDataBaseDataSet;
            // 
            // prisonerTableAdapter
            // 
            this.prisonerTableAdapter.ClearBeforeFill = true;
            // 
            // EditPrisoner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 342);
            this.Controls.Add(this.button_CANCEL);
            this.Controls.Add(this.button_OK);
            this.Controls.Add(this.comboBox_CellNumber);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.comboBox_SNP);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox_NumberOfArticle);
            this.Controls.Add(this.dateTimePicker_ReleaseDate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dateTimePicker_IncarcerationDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "EditPrisoner";
            this.Text = "Edit Prisoner";
            this.Load += new System.EventHandler(this.EditPrisoner_Load);
            ((System.ComponentModel.ISupportInitialize)(this.personBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.prisonDataBaseDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cellBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePicker_IncarcerationDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTimePicker_ReleaseDate;
        private System.Windows.Forms.TextBox textBox_NumberOfArticle;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox_SNP;
        private PrisonDataBaseDataSet prisonDataBaseDataSet;
        private System.Windows.Forms.BindingSource personBindingSource;
        private PrisonDataBaseDataSetTableAdapters.PersonTableAdapter personTableAdapter;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBox_CellNumber;
        private System.Windows.Forms.BindingSource cellBindingSource;
        private PrisonDataBaseDataSetTableAdapters.CellTableAdapter cellTableAdapter;
        private System.Windows.Forms.Button button_CANCEL;
        private System.Windows.Forms.Button button_OK;
        private System.Windows.Forms.BindingSource bindingSource1;
        private PrisonDataBaseDataSetTableAdapters.PrisonerTableAdapter prisonerTableAdapter;
    }
}