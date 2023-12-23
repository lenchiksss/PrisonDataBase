namespace PrisonDataBase
{
    partial class EditCommittedIncident
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
            this.comboBox_Type = new System.Windows.Forms.ComboBox();
            this.incidentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.prisonDataBaseDataSet = new PrisonDataBase.PrisonDataBaseDataSet();
            this.incidentTableAdapter = new PrisonDataBase.PrisonDataBaseDataSetTableAdapters.IncidentTableAdapter();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.committed_incidentTableAdapter = new PrisonDataBase.PrisonDataBaseDataSetTableAdapters.Committed_incidentTableAdapter();
            this.dateTimePicker_IncidentDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.button_CANCEL = new System.Windows.Forms.Button();
            this.button_OK = new System.Windows.Forms.Button();
            this.textBox_TimeOfIncident = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.incidentBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.prisonDataBaseDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 20);
            this.label1.TabIndex = 18;
            this.label1.Text = "Committed incident";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(35, 163);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 18);
            this.label2.TabIndex = 26;
            this.label2.Text = "Incident type";
            // 
            // comboBox_Type
            // 
            this.comboBox_Type.DataSource = this.incidentBindingSource;
            this.comboBox_Type.DisplayMember = "incident_type";
            this.comboBox_Type.FormattingEnabled = true;
            this.comboBox_Type.Location = new System.Drawing.Point(163, 162);
            this.comboBox_Type.Name = "comboBox_Type";
            this.comboBox_Type.Size = new System.Drawing.Size(262, 24);
            this.comboBox_Type.TabIndex = 28;
            this.comboBox_Type.ValueMember = "incident_id";
            // 
            // incidentBindingSource
            // 
            this.incidentBindingSource.DataMember = "Incident";
            this.incidentBindingSource.DataSource = this.prisonDataBaseDataSet;
            // 
            // prisonDataBaseDataSet
            // 
            this.prisonDataBaseDataSet.DataSetName = "PrisonDataBaseDataSet";
            this.prisonDataBaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // incidentTableAdapter
            // 
            this.incidentTableAdapter.ClearBeforeFill = true;
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataMember = "Committed_incident";
            this.bindingSource1.DataSource = this.prisonDataBaseDataSet;
            // 
            // committed_incidentTableAdapter
            // 
            this.committed_incidentTableAdapter.ClearBeforeFill = true;
            // 
            // dateTimePicker_IncidentDate
            // 
            this.dateTimePicker_IncidentDate.Location = new System.Drawing.Point(163, 53);
            this.dateTimePicker_IncidentDate.Name = "dateTimePicker_IncidentDate";
            this.dateTimePicker_IncidentDate.Size = new System.Drawing.Size(262, 22);
            this.dateTimePicker_IncidentDate.TabIndex = 32;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(34, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 18);
            this.label3.TabIndex = 31;
            this.label3.Text = "Incident date";
            // 
            // button_CANCEL
            // 
            this.button_CANCEL.Location = new System.Drawing.Point(293, 215);
            this.button_CANCEL.Name = "button_CANCEL";
            this.button_CANCEL.Size = new System.Drawing.Size(123, 36);
            this.button_CANCEL.TabIndex = 30;
            this.button_CANCEL.Text = "CANCEL";
            this.button_CANCEL.UseVisualStyleBackColor = true;
            this.button_CANCEL.Click += new System.EventHandler(this.button_CANCEL_Click);
            // 
            // button_OK
            // 
            this.button_OK.Location = new System.Drawing.Point(46, 215);
            this.button_OK.Name = "button_OK";
            this.button_OK.Size = new System.Drawing.Size(123, 36);
            this.button_OK.TabIndex = 29;
            this.button_OK.Text = "OK";
            this.button_OK.UseVisualStyleBackColor = true;
            this.button_OK.Click += new System.EventHandler(this.button_OK_Click);
            // 
            // textBox_TimeOfIncident
            // 
            this.textBox_TimeOfIncident.Location = new System.Drawing.Point(163, 106);
            this.textBox_TimeOfIncident.Name = "textBox_TimeOfIncident";
            this.textBox_TimeOfIncident.Size = new System.Drawing.Size(262, 22);
            this.textBox_TimeOfIncident.TabIndex = 34;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(12, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 18);
            this.label4.TabIndex = 33;
            this.label4.Text = "Time of incident";
            // 
            // EditCommittedIncident
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 283);
            this.Controls.Add(this.textBox_TimeOfIncident);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dateTimePicker_IncidentDate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button_CANCEL);
            this.Controls.Add(this.button_OK);
            this.Controls.Add(this.comboBox_Type);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "EditCommittedIncident";
            this.Text = "Edit Committed Incident";
            this.Load += new System.EventHandler(this.EditCommittedIncident_Load);
            ((System.ComponentModel.ISupportInitialize)(this.incidentBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.prisonDataBaseDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox_Type;
        private PrisonDataBaseDataSet prisonDataBaseDataSet;
        private System.Windows.Forms.BindingSource incidentBindingSource;
        private PrisonDataBaseDataSetTableAdapters.IncidentTableAdapter incidentTableAdapter;
        private System.Windows.Forms.BindingSource bindingSource1;
        private PrisonDataBaseDataSetTableAdapters.Committed_incidentTableAdapter committed_incidentTableAdapter;
        private System.Windows.Forms.DateTimePicker dateTimePicker_IncidentDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button_CANCEL;
        private System.Windows.Forms.Button button_OK;
        private System.Windows.Forms.TextBox textBox_TimeOfIncident;
        private System.Windows.Forms.Label label4;
    }
}