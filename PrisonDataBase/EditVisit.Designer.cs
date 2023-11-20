namespace PrisonDataBase
{
    partial class EditVisit
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
            this.comboBox_RelationToThePrisoner = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePicker_DateOfVisit = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox_PrisonersSNP = new System.Windows.Forms.ComboBox();
            this.personBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.prisonDataBaseDataSet = new PrisonDataBase.PrisonDataBaseDataSet();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBox_VisitorsSNP = new System.Windows.Forms.ComboBox();
            this.visitorBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.visitorTableAdapter = new PrisonDataBase.PrisonDataBaseDataSetTableAdapters.VisitorTableAdapter();
            this.personTableAdapter = new PrisonDataBase.PrisonDataBaseDataSetTableAdapters.PersonTableAdapter();
            this.button_CANCEL = new System.Windows.Forms.Button();
            this.button_OK = new System.Windows.Forms.Button();
            this.textBox_TimeOfVisit = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.personBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.prisonDataBaseDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.visitorBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Visit";
            // 
            // comboBox_RelationToThePrisoner
            // 
            this.comboBox_RelationToThePrisoner.FormattingEnabled = true;
            this.comboBox_RelationToThePrisoner.Items.AddRange(new object[] {
            "friend",
            "family",
            "colleague",
            "other"});
            this.comboBox_RelationToThePrisoner.Location = new System.Drawing.Point(209, 50);
            this.comboBox_RelationToThePrisoner.Name = "comboBox_RelationToThePrisoner";
            this.comboBox_RelationToThePrisoner.Size = new System.Drawing.Size(223, 24);
            this.comboBox_RelationToThePrisoner.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(27, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(161, 18);
            this.label2.TabIndex = 4;
            this.label2.Text = "Relation to the prisoner";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(103, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 18);
            this.label3.TabIndex = 5;
            this.label3.Text = "Date of visit";
            // 
            // dateTimePicker_DateOfVisit
            // 
            this.dateTimePicker_DateOfVisit.Location = new System.Drawing.Point(209, 89);
            this.dateTimePicker_DateOfVisit.Name = "dateTimePicker_DateOfVisit";
            this.dateTimePicker_DateOfVisit.Size = new System.Drawing.Size(223, 22);
            this.dateTimePicker_DateOfVisit.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(101, 139);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 18);
            this.label4.TabIndex = 7;
            this.label4.Text = "Time of visit";
            // 
            // comboBox_PrisonersSNP
            // 
            this.comboBox_PrisonersSNP.DataSource = this.personBindingSource;
            this.comboBox_PrisonersSNP.DisplayMember = "person_id";
            this.comboBox_PrisonersSNP.FormattingEnabled = true;
            this.comboBox_PrisonersSNP.Location = new System.Drawing.Point(209, 228);
            this.comboBox_PrisonersSNP.Name = "comboBox_PrisonersSNP";
            this.comboBox_PrisonersSNP.Size = new System.Drawing.Size(223, 24);
            this.comboBox_PrisonersSNP.TabIndex = 27;
            this.comboBox_PrisonersSNP.ValueMember = "person_id";
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
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(70, 228);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(110, 18);
            this.label6.TabIndex = 26;
            this.label6.Text = "Prisoner\'s SNP";
            // 
            // comboBox_VisitorsSNP
            // 
            this.comboBox_VisitorsSNP.DataSource = this.visitorBindingSource;
            this.comboBox_VisitorsSNP.DisplayMember = "SNP";
            this.comboBox_VisitorsSNP.FormattingEnabled = true;
            this.comboBox_VisitorsSNP.Location = new System.Drawing.Point(209, 179);
            this.comboBox_VisitorsSNP.Name = "comboBox_VisitorsSNP";
            this.comboBox_VisitorsSNP.Size = new System.Drawing.Size(223, 24);
            this.comboBox_VisitorsSNP.TabIndex = 25;
            this.comboBox_VisitorsSNP.ValueMember = "visitor_id";
            // 
            // visitorBindingSource
            // 
            this.visitorBindingSource.DataMember = "Visitor";
            this.visitorBindingSource.DataSource = this.prisonDataBaseDataSet;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(93, 185);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 18);
            this.label5.TabIndex = 24;
            this.label5.Text = "Visitor\'s SNP";
            // 
            // visitorTableAdapter
            // 
            this.visitorTableAdapter.ClearBeforeFill = true;
            // 
            // personTableAdapter
            // 
            this.personTableAdapter.ClearBeforeFill = true;
            // 
            // button_CANCEL
            // 
            this.button_CANCEL.Location = new System.Drawing.Point(278, 279);
            this.button_CANCEL.Name = "button_CANCEL";
            this.button_CANCEL.Size = new System.Drawing.Size(123, 36);
            this.button_CANCEL.TabIndex = 29;
            this.button_CANCEL.Text = "CANCEL";
            this.button_CANCEL.UseVisualStyleBackColor = true;
            // 
            // button_OK
            // 
            this.button_OK.Location = new System.Drawing.Point(58, 279);
            this.button_OK.Name = "button_OK";
            this.button_OK.Size = new System.Drawing.Size(123, 36);
            this.button_OK.TabIndex = 28;
            this.button_OK.Text = "OK";
            this.button_OK.UseVisualStyleBackColor = true;
            // 
            // textBox_TimeOfVisit
            // 
            this.textBox_TimeOfVisit.Location = new System.Drawing.Point(209, 134);
            this.textBox_TimeOfVisit.Name = "textBox_TimeOfVisit";
            this.textBox_TimeOfVisit.Size = new System.Drawing.Size(223, 22);
            this.textBox_TimeOfVisit.TabIndex = 30;
            // 
            // EditVisit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 348);
            this.Controls.Add(this.textBox_TimeOfVisit);
            this.Controls.Add(this.button_CANCEL);
            this.Controls.Add(this.button_OK);
            this.Controls.Add(this.comboBox_PrisonersSNP);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.comboBox_VisitorsSNP);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dateTimePicker_DateOfVisit);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox_RelationToThePrisoner);
            this.Controls.Add(this.label1);
            this.Name = "EditVisit";
            this.Text = "Edit Visit";
            this.Load += new System.EventHandler(this.EditVisit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.personBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.prisonDataBaseDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.visitorBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox_RelationToThePrisoner;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTimePicker_DateOfVisit;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox_PrisonersSNP;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBox_VisitorsSNP;
        private System.Windows.Forms.Label label5;
        private PrisonDataBaseDataSet prisonDataBaseDataSet;
        private System.Windows.Forms.BindingSource visitorBindingSource;
        private PrisonDataBaseDataSetTableAdapters.VisitorTableAdapter visitorTableAdapter;
        private System.Windows.Forms.BindingSource personBindingSource;
        private PrisonDataBaseDataSetTableAdapters.PersonTableAdapter personTableAdapter;
        private System.Windows.Forms.Button button_CANCEL;
        private System.Windows.Forms.Button button_OK;
        private System.Windows.Forms.TextBox textBox_TimeOfVisit;
    }
}