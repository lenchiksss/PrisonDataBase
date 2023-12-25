namespace PrisonDataBase
{
    partial class EditCell
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
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDown_Capacity = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_CurrentOccupancy = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox_cellType = new System.Windows.Forms.ComboBox();
            this.button_CANCEL = new System.Windows.Forms.Button();
            this.button_OK = new System.Windows.Forms.Button();
            this.numericUpDown_cellNumber = new System.Windows.Forms.NumericUpDown();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.prisonDataBaseDataSet = new PrisonDataBase.PrisonDataBaseDataSet();
            this.cellTableAdapter = new PrisonDataBase.PrisonDataBaseDataSetTableAdapters.CellTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Capacity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_CurrentOccupancy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_cellNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.prisonDataBaseDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Cell";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(83, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "Cell number";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(105, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 18);
            this.label3.TabIndex = 5;
            this.label3.Text = "Capacity";
            // 
            // numericUpDown_Capacity
            // 
            this.numericUpDown_Capacity.Location = new System.Drawing.Point(192, 101);
            this.numericUpDown_Capacity.Name = "numericUpDown_Capacity";
            this.numericUpDown_Capacity.Size = new System.Drawing.Size(230, 22);
            this.numericUpDown_Capacity.TabIndex = 6;
            // 
            // numericUpDown_CurrentOccupancy
            // 
            this.numericUpDown_CurrentOccupancy.Location = new System.Drawing.Point(192, 146);
            this.numericUpDown_CurrentOccupancy.Name = "numericUpDown_CurrentOccupancy";
            this.numericUpDown_CurrentOccupancy.Size = new System.Drawing.Size(230, 22);
            this.numericUpDown_CurrentOccupancy.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(37, 150);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(133, 18);
            this.label4.TabIndex = 8;
            this.label4.Text = "Current occupancy";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(105, 193);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 18);
            this.label5.TabIndex = 9;
            this.label5.Text = "Cell type";
            // 
            // comboBox_cellType
            // 
            this.comboBox_cellType.FormattingEnabled = true;
            this.comboBox_cellType.Items.AddRange(new object[] {
            "single",
            "double",
            "multiple"});
            this.comboBox_cellType.Location = new System.Drawing.Point(192, 193);
            this.comboBox_cellType.Name = "comboBox_cellType";
            this.comboBox_cellType.Size = new System.Drawing.Size(230, 24);
            this.comboBox_cellType.TabIndex = 10;
            // 
            // button_CANCEL
            // 
            this.button_CANCEL.Location = new System.Drawing.Point(285, 248);
            this.button_CANCEL.Name = "button_CANCEL";
            this.button_CANCEL.Size = new System.Drawing.Size(123, 36);
            this.button_CANCEL.TabIndex = 15;
            this.button_CANCEL.Text = "CANCEL";
            this.button_CANCEL.UseVisualStyleBackColor = true;
            // 
            // button_OK
            // 
            this.button_OK.Location = new System.Drawing.Point(57, 248);
            this.button_OK.Name = "button_OK";
            this.button_OK.Size = new System.Drawing.Size(123, 36);
            this.button_OK.TabIndex = 14;
            this.button_OK.Text = "OK";
            this.button_OK.UseVisualStyleBackColor = true;
            this.button_OK.Click += new System.EventHandler(this.button_OK_Click);
            // 
            // numericUpDown_cellNumber
            // 
            this.numericUpDown_cellNumber.Location = new System.Drawing.Point(192, 56);
            this.numericUpDown_cellNumber.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericUpDown_cellNumber.Name = "numericUpDown_cellNumber";
            this.numericUpDown_cellNumber.Size = new System.Drawing.Size(230, 22);
            this.numericUpDown_cellNumber.TabIndex = 16;
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataMember = "Cell";
            this.bindingSource1.DataSource = this.prisonDataBaseDataSet;
            // 
            // prisonDataBaseDataSet
            // 
            this.prisonDataBaseDataSet.DataSetName = "PrisonDataBaseDataSet";
            this.prisonDataBaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // cellTableAdapter
            // 
            this.cellTableAdapter.ClearBeforeFill = true;
            // 
            // EditCell
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 305);
            this.Controls.Add(this.numericUpDown_cellNumber);
            this.Controls.Add(this.button_CANCEL);
            this.Controls.Add(this.button_OK);
            this.Controls.Add(this.comboBox_cellType);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.numericUpDown_CurrentOccupancy);
            this.Controls.Add(this.numericUpDown_Capacity);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "EditCell";
            this.Text = "Edit Cell";
            this.Load += new System.EventHandler(this.EditCell_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Capacity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_CurrentOccupancy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_cellNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.prisonDataBaseDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDown_Capacity;
        private System.Windows.Forms.NumericUpDown numericUpDown_CurrentOccupancy;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox_cellType;
        private System.Windows.Forms.Button button_CANCEL;
        private System.Windows.Forms.Button button_OK;
        private System.Windows.Forms.BindingSource bindingSource1;
        private PrisonDataBaseDataSet prisonDataBaseDataSet;
        private PrisonDataBaseDataSetTableAdapters.CellTableAdapter cellTableAdapter;
        private System.Windows.Forms.NumericUpDown numericUpDown_cellNumber;
    }
}