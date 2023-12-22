namespace PrisonDataBase
{
    partial class EditParticipantsOfTheIncident
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
            this.comboBox_SNP = new System.Windows.Forms.ComboBox();
            this.personBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.prisonDataBaseDataSet = new PrisonDataBase.PrisonDataBaseDataSet();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox_Incident = new System.Windows.Forms.ComboBox();
            this.incidentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.personTableAdapter = new PrisonDataBase.PrisonDataBaseDataSetTableAdapters.PersonTableAdapter();
            this.incidentTableAdapter = new PrisonDataBase.PrisonDataBaseDataSetTableAdapters.IncidentTableAdapter();
            this.button_CANCEL = new System.Windows.Forms.Button();
            this.button_OK = new System.Windows.Forms.Button();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.participants_of_the_incidentTableAdapter = new PrisonDataBase.PrisonDataBaseDataSetTableAdapters.Participants_of_the_incidentTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.personBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.prisonDataBaseDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.incidentBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(208, 20);
            this.label1.TabIndex = 17;
            this.label1.Text = "Participants of the incident";
            // 
            // comboBox_SNP
            // 
            this.comboBox_SNP.DataSource = this.personBindingSource;
            this.comboBox_SNP.DisplayMember = "SNP";
            this.comboBox_SNP.FormattingEnabled = true;
            this.comboBox_SNP.Location = new System.Drawing.Point(173, 51);
            this.comboBox_SNP.Name = "comboBox_SNP";
            this.comboBox_SNP.Size = new System.Drawing.Size(253, 24);
            this.comboBox_SNP.TabIndex = 27;
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(21, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(135, 18);
            this.label3.TabIndex = 26;
            this.label3.Text = "Committed incident";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(46, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 18);
            this.label2.TabIndex = 25;
            this.label2.Text = "Prisoner\'s SNP";
            // 
            // comboBox_Incident
            // 
            this.comboBox_Incident.DataSource = this.incidentBindingSource;
            this.comboBox_Incident.DisplayMember = "incident_type";
            this.comboBox_Incident.FormattingEnabled = true;
            this.comboBox_Incident.Location = new System.Drawing.Point(173, 103);
            this.comboBox_Incident.Name = "comboBox_Incident";
            this.comboBox_Incident.Size = new System.Drawing.Size(253, 24);
            this.comboBox_Incident.TabIndex = 28;
            this.comboBox_Incident.ValueMember = "incident_id";
            // 
            // incidentBindingSource
            // 
            this.incidentBindingSource.DataMember = "Incident";
            this.incidentBindingSource.DataSource = this.prisonDataBaseDataSet;
            // 
            // personTableAdapter
            // 
            this.personTableAdapter.ClearBeforeFill = true;
            // 
            // incidentTableAdapter
            // 
            this.incidentTableAdapter.ClearBeforeFill = true;
            // 
            // button_CANCEL
            // 
            this.button_CANCEL.Location = new System.Drawing.Point(290, 146);
            this.button_CANCEL.Name = "button_CANCEL";
            this.button_CANCEL.Size = new System.Drawing.Size(123, 36);
            this.button_CANCEL.TabIndex = 30;
            this.button_CANCEL.Text = "CANCEL";
            this.button_CANCEL.UseVisualStyleBackColor = true;
            this.button_CANCEL.Click += new System.EventHandler(this.button_CANCEL_Click);
            // 
            // button_OK
            // 
            this.button_OK.Location = new System.Drawing.Point(49, 146);
            this.button_OK.Name = "button_OK";
            this.button_OK.Size = new System.Drawing.Size(123, 36);
            this.button_OK.TabIndex = 29;
            this.button_OK.Text = "OK";
            this.button_OK.UseVisualStyleBackColor = true;
            this.button_OK.Click += new System.EventHandler(this.button_OK_Click);
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataMember = "Participants_of_the_incident";
            this.bindingSource1.DataSource = this.prisonDataBaseDataSet;
            // 
            // participants_of_the_incidentTableAdapter
            // 
            this.participants_of_the_incidentTableAdapter.ClearBeforeFill = true;
            // 
            // EditParticipantsOfTheIncident
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 207);
            this.Controls.Add(this.button_CANCEL);
            this.Controls.Add(this.button_OK);
            this.Controls.Add(this.comboBox_Incident);
            this.Controls.Add(this.comboBox_SNP);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "EditParticipantsOfTheIncident";
            this.Text = "Edit Participants Of The Incident";
            this.Load += new System.EventHandler(this.EditParticipantsOfTheIncident_Load);
            ((System.ComponentModel.ISupportInitialize)(this.personBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.prisonDataBaseDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.incidentBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox_SNP;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private PrisonDataBaseDataSet prisonDataBaseDataSet;
        private System.Windows.Forms.ComboBox comboBox_Incident;
        private System.Windows.Forms.BindingSource personBindingSource;
        private PrisonDataBaseDataSetTableAdapters.PersonTableAdapter personTableAdapter;
        private System.Windows.Forms.BindingSource incidentBindingSource;
        private PrisonDataBaseDataSetTableAdapters.IncidentTableAdapter incidentTableAdapter;
        private System.Windows.Forms.Button button_CANCEL;
        private System.Windows.Forms.Button button_OK;
        private System.Windows.Forms.BindingSource bindingSource1;
        private PrisonDataBaseDataSetTableAdapters.Participants_of_the_incidentTableAdapter participants_of_the_incidentTableAdapter;
    }
}