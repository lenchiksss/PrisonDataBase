namespace PrisonDataBase
{
    partial class EditJailerOnShift
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
            this.button_CANCEL = new System.Windows.Forms.Button();
            this.button_OK = new System.Windows.Forms.Button();
            this.comboBox_CellNumber = new System.Windows.Forms.ComboBox();
            this.cellBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.prisonDataBaseDataSet = new PrisonDataBase.PrisonDataBaseDataSet();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBox_SNP = new System.Windows.Forms.ComboBox();
            this.jailerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.dateTimePicker_ShiftDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.jailerTableAdapter = new PrisonDataBase.PrisonDataBaseDataSetTableAdapters.JailerTableAdapter();
            this.cellTableAdapter = new PrisonDataBase.PrisonDataBaseDataSetTableAdapters.CellTableAdapter();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.jailer_on_shiftTableAdapter = new PrisonDataBase.PrisonDataBaseDataSetTableAdapters.Jailer_on_shiftTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.cellBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.prisonDataBaseDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.jailerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Jailer on shift";
            // 
            // button_CANCEL
            // 
            this.button_CANCEL.Location = new System.Drawing.Point(292, 207);
            this.button_CANCEL.Name = "button_CANCEL";
            this.button_CANCEL.Size = new System.Drawing.Size(123, 36);
            this.button_CANCEL.TabIndex = 17;
            this.button_CANCEL.Text = "CANCEL";
            this.button_CANCEL.UseVisualStyleBackColor = true;
            this.button_CANCEL.Click += new System.EventHandler(this.button_CANCEL_Click);
            // 
            // button_OK
            // 
            this.button_OK.Location = new System.Drawing.Point(45, 207);
            this.button_OK.Name = "button_OK";
            this.button_OK.Size = new System.Drawing.Size(123, 36);
            this.button_OK.TabIndex = 16;
            this.button_OK.Text = "OK";
            this.button_OK.UseVisualStyleBackColor = true;
            this.button_OK.Click += new System.EventHandler(this.button_OK_Click);
            // 
            // comboBox_CellNumber
            // 
            this.comboBox_CellNumber.DataSource = this.cellBindingSource;
            this.comboBox_CellNumber.DisplayMember = "cell_number";
            this.comboBox_CellNumber.FormattingEnabled = true;
            this.comboBox_CellNumber.Location = new System.Drawing.Point(158, 103);
            this.comboBox_CellNumber.Name = "comboBox_CellNumber";
            this.comboBox_CellNumber.Size = new System.Drawing.Size(270, 24);
            this.comboBox_CellNumber.TabIndex = 23;
            this.comboBox_CellNumber.ValueMember = "cell_id";
            // 
            // cellBindingSource
            // 
            this.cellBindingSource.DataMember = "Cell";
            this.cellBindingSource.DataSource = this.prisonDataBaseDataSet;
            // 
            // prisonDataBaseDataSet
            // 
            this.prisonDataBaseDataSet.DataSetName = "PrisonDataBaseDataSet";
            this.prisonDataBaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(35, 109);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 18);
            this.label6.TabIndex = 22;
            this.label6.Text = "Cell number";
            // 
            // comboBox_SNP
            // 
            this.comboBox_SNP.DataSource = this.jailerBindingSource;
            this.comboBox_SNP.DisplayMember = "SNP";
            this.comboBox_SNP.FormattingEnabled = true;
            this.comboBox_SNP.Location = new System.Drawing.Point(158, 53);
            this.comboBox_SNP.Name = "comboBox_SNP";
            this.comboBox_SNP.Size = new System.Drawing.Size(270, 24);
            this.comboBox_SNP.TabIndex = 21;
            this.comboBox_SNP.ValueMember = "jailer_id";
            // 
            // jailerBindingSource
            // 
            this.jailerBindingSource.DataMember = "Jailer";
            this.jailerBindingSource.DataSource = this.prisonDataBaseDataSet;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(83, 59);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 18);
            this.label5.TabIndex = 20;
            this.label5.Text = "SNP";
            // 
            // dateTimePicker_ShiftDate
            // 
            this.dateTimePicker_ShiftDate.Location = new System.Drawing.Point(158, 157);
            this.dateTimePicker_ShiftDate.Name = "dateTimePicker_ShiftDate";
            this.dateTimePicker_ShiftDate.Size = new System.Drawing.Size(270, 22);
            this.dateTimePicker_ShiftDate.TabIndex = 19;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(53, 157);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 18);
            this.label2.TabIndex = 18;
            this.label2.Text = "Shift date";
            // 
            // jailerTableAdapter
            // 
            this.jailerTableAdapter.ClearBeforeFill = true;
            // 
            // cellTableAdapter
            // 
            this.cellTableAdapter.ClearBeforeFill = true;
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataMember = "Jailer_on_shift";
            this.bindingSource1.DataSource = this.prisonDataBaseDataSet;
            // 
            // jailer_on_shiftTableAdapter
            // 
            this.jailer_on_shiftTableAdapter.ClearBeforeFill = true;
            // 
            // EditJailerOnShift
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 264);
            this.Controls.Add(this.comboBox_CellNumber);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.comboBox_SNP);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dateTimePicker_ShiftDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button_CANCEL);
            this.Controls.Add(this.button_OK);
            this.Controls.Add(this.label1);
            this.Name = "EditJailerOnShift";
            this.Text = "Edit Jailer On Shift";
            this.Load += new System.EventHandler(this.EditJailerOnShift_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cellBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.prisonDataBaseDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.jailerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_CANCEL;
        private System.Windows.Forms.Button button_OK;
        private System.Windows.Forms.ComboBox comboBox_CellNumber;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBox_SNP;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dateTimePicker_ShiftDate;
        private System.Windows.Forms.Label label2;
        private PrisonDataBaseDataSet prisonDataBaseDataSet;
        private System.Windows.Forms.BindingSource jailerBindingSource;
        private PrisonDataBaseDataSetTableAdapters.JailerTableAdapter jailerTableAdapter;
        private System.Windows.Forms.BindingSource cellBindingSource;
        private PrisonDataBaseDataSetTableAdapters.CellTableAdapter cellTableAdapter;
        private System.Windows.Forms.BindingSource bindingSource1;
        private PrisonDataBaseDataSetTableAdapters.Jailer_on_shiftTableAdapter jailer_on_shiftTableAdapter;
    }
}