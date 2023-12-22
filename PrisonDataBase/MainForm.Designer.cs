namespace PrisonDataBase
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.prisonDataBaseDataSet = new PrisonDataBase.PrisonDataBaseDataSet();
            this.personBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.personTableAdapter = new PrisonDataBase.PrisonDataBaseDataSetTableAdapters.PersonTableAdapter();
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.databaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.personToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.prisonerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.jailerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.jailerOnShiftToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cellToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.visitorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.visitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.incidentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comittedIncidentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.participantsOfTheIncidentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.actionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statisticsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.formulationOfQueriesstatisticsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.infoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.visitsOfPrisonersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.jailerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.jailerTableAdapter = new PrisonDataBase.PrisonDataBaseDataSetTableAdapters.JailerTableAdapter();
            this.cellBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cellTableAdapter = new PrisonDataBase.PrisonDataBaseDataSetTableAdapters.CellTableAdapter();
            this.committedincidentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.committed_incidentTableAdapter = new PrisonDataBase.PrisonDataBaseDataSetTableAdapters.Committed_incidentTableAdapter();
            this.incidentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.incidentTableAdapter = new PrisonDataBase.PrisonDataBaseDataSetTableAdapters.IncidentTableAdapter();
            this.jaileronshiftBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.jailer_on_shiftTableAdapter = new PrisonDataBase.PrisonDataBaseDataSetTableAdapters.Jailer_on_shiftTableAdapter();
            this.participantsoftheincidentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.participants_of_the_incidentTableAdapter = new PrisonDataBase.PrisonDataBaseDataSetTableAdapters.Participants_of_the_incidentTableAdapter();
            this.visitBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.visitTableAdapter = new PrisonDataBase.PrisonDataBaseDataSetTableAdapters.VisitTableAdapter();
            this.visitorBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.visitorTableAdapter = new PrisonDataBase.PrisonDataBaseDataSetTableAdapters.VisitorTableAdapter();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.personidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sNPDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateofbirthDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.genderDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prisonerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.prisonerTableAdapter = new PrisonDataBase.PrisonDataBaseDataSetTableAdapters.PrisonerTableAdapter();
            this.textBox_Search = new System.Windows.Forms.TextBox();
            this.button_PrintReport = new System.Windows.Forms.Button();
            this.comboBox_Cells = new System.Windows.Forms.ComboBox();
            this.label_Sort = new System.Windows.Forms.Label();
            this.checkBox_Sort = new System.Windows.Forms.CheckBox();
            this.comboBox_Filtration = new System.Windows.Forms.ComboBox();
            this.label_Filter = new System.Windows.Forms.Label();
            this.button_PrintReport1 = new System.Windows.Forms.Button();
            this.label_Search = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.checkBox_BirthdayDate = new System.Windows.Forms.CheckBox();
            this.checkBox_ReleaseDate = new System.Windows.Forms.CheckBox();
            this.checkBox_HireDate = new System.Windows.Forms.CheckBox();
            this.checkBox_ShiftDate = new System.Windows.Forms.CheckBox();
            this.checkBox_VisitDate = new System.Windows.Forms.CheckBox();
            this.checkBox_CommittedIncidentDate = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.prisonDataBaseDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.personBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.jailerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cellBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.committedincidentBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.incidentBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.jaileronshiftBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.participantsoftheincidentBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.visitBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.visitorBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.prisonerBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataSource = this.prisonDataBaseDataSet;
            this.bindingSource1.Position = 0;
            // 
            // prisonDataBaseDataSet
            // 
            this.prisonDataBaseDataSet.DataSetName = "PrisonDataBaseDataSet";
            this.prisonDataBaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // personBindingSource
            // 
            this.personBindingSource.DataMember = "Person";
            this.personBindingSource.DataSource = this.bindingSource1;
            // 
            // personTableAdapter
            // 
            this.personTableAdapter.ClearBeforeFill = true;
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = this.bindingNavigatorAddNewItem;
            this.bindingNavigator1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.bindingNavigator1.BindingSource = this.personBindingSource;
            this.bindingNavigator1.CountItem = this.bindingNavigatorCountItem;
            this.bindingNavigator1.DeleteItem = this.bindingNavigatorDeleteItem;
            this.bindingNavigator1.Dock = System.Windows.Forms.DockStyle.None;
            this.bindingNavigator1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.bindingNavigator1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem});
            this.bindingNavigator1.Location = new System.Drawing.Point(12, 532);
            this.bindingNavigator1.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigator1.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigator1.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigator1.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigator1.Size = new System.Drawing.Size(312, 27);
            this.bindingNavigator1.TabIndex = 1;
            this.bindingNavigator1.Text = "bindingNavigator1";
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorAddNewItem.Text = "Добавить";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(55, 24);
            this.bindingNavigatorCountItem.Text = "для {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Общее число элементов";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorDeleteItem.Text = "Удалить";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorMoveFirstItem.Text = "Переместить в начало";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorMovePreviousItem.Text = "Переместить назад";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 27);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Положение";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 27);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Текущее положение";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorMoveNextItem.Text = "Переместить вперед";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorMoveLastItem.Text = "Переместить в конец";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.databaseToolStripMenuItem,
            this.actionsToolStripMenuItem,
            this.statisticsToolStripMenuItem,
            this.infoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1121, 28);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(116, 26);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click_1);
            // 
            // databaseToolStripMenuItem
            // 
            this.databaseToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.personToolStripMenuItem,
            this.prisonerToolStripMenuItem,
            this.jailerToolStripMenuItem,
            this.jailerOnShiftToolStripMenuItem,
            this.cellToolStripMenuItem,
            this.visitorToolStripMenuItem,
            this.visitToolStripMenuItem,
            this.incidentToolStripMenuItem,
            this.comittedIncidentToolStripMenuItem,
            this.participantsOfTheIncidentToolStripMenuItem});
            this.databaseToolStripMenuItem.Name = "databaseToolStripMenuItem";
            this.databaseToolStripMenuItem.Size = new System.Drawing.Size(86, 24);
            this.databaseToolStripMenuItem.Text = "Database";
            // 
            // personToolStripMenuItem
            // 
            this.personToolStripMenuItem.Name = "personToolStripMenuItem";
            this.personToolStripMenuItem.Size = new System.Drawing.Size(274, 26);
            this.personToolStripMenuItem.Text = "Persons";
            this.personToolStripMenuItem.Click += new System.EventHandler(this.personToolStripMenuItem_Click);
            // 
            // prisonerToolStripMenuItem
            // 
            this.prisonerToolStripMenuItem.Name = "prisonerToolStripMenuItem";
            this.prisonerToolStripMenuItem.Size = new System.Drawing.Size(274, 26);
            this.prisonerToolStripMenuItem.Text = "Prisoners";
            this.prisonerToolStripMenuItem.Click += new System.EventHandler(this.prisonerToolStripMenuItem_Click);
            // 
            // jailerToolStripMenuItem
            // 
            this.jailerToolStripMenuItem.Name = "jailerToolStripMenuItem";
            this.jailerToolStripMenuItem.Size = new System.Drawing.Size(274, 26);
            this.jailerToolStripMenuItem.Text = "Jailers";
            this.jailerToolStripMenuItem.Click += new System.EventHandler(this.jailerToolStripMenuItem_Click);
            // 
            // jailerOnShiftToolStripMenuItem
            // 
            this.jailerOnShiftToolStripMenuItem.Name = "jailerOnShiftToolStripMenuItem";
            this.jailerOnShiftToolStripMenuItem.Size = new System.Drawing.Size(274, 26);
            this.jailerOnShiftToolStripMenuItem.Text = "Jailers on shift";
            this.jailerOnShiftToolStripMenuItem.Click += new System.EventHandler(this.jailerOnShiftToolStripMenuItem_Click);
            // 
            // cellToolStripMenuItem
            // 
            this.cellToolStripMenuItem.Name = "cellToolStripMenuItem";
            this.cellToolStripMenuItem.Size = new System.Drawing.Size(274, 26);
            this.cellToolStripMenuItem.Text = "Cells";
            this.cellToolStripMenuItem.Click += new System.EventHandler(this.cellToolStripMenuItem_Click);
            // 
            // visitorToolStripMenuItem
            // 
            this.visitorToolStripMenuItem.Name = "visitorToolStripMenuItem";
            this.visitorToolStripMenuItem.Size = new System.Drawing.Size(274, 26);
            this.visitorToolStripMenuItem.Text = "Visitors";
            this.visitorToolStripMenuItem.Click += new System.EventHandler(this.visitorToolStripMenuItem_Click);
            // 
            // visitToolStripMenuItem
            // 
            this.visitToolStripMenuItem.Name = "visitToolStripMenuItem";
            this.visitToolStripMenuItem.Size = new System.Drawing.Size(274, 26);
            this.visitToolStripMenuItem.Text = "Visits";
            this.visitToolStripMenuItem.Click += new System.EventHandler(this.visitToolStripMenuItem_Click);
            // 
            // incidentToolStripMenuItem
            // 
            this.incidentToolStripMenuItem.Name = "incidentToolStripMenuItem";
            this.incidentToolStripMenuItem.Size = new System.Drawing.Size(274, 26);
            this.incidentToolStripMenuItem.Text = "Incidents";
            this.incidentToolStripMenuItem.Click += new System.EventHandler(this.incidentToolStripMenuItem_Click);
            // 
            // comittedIncidentToolStripMenuItem
            // 
            this.comittedIncidentToolStripMenuItem.Name = "comittedIncidentToolStripMenuItem";
            this.comittedIncidentToolStripMenuItem.Size = new System.Drawing.Size(274, 26);
            this.comittedIncidentToolStripMenuItem.Text = "Comitted incidents";
            this.comittedIncidentToolStripMenuItem.Click += new System.EventHandler(this.comittedIncidentToolStripMenuItem_Click);
            // 
            // participantsOfTheIncidentToolStripMenuItem
            // 
            this.participantsOfTheIncidentToolStripMenuItem.Name = "participantsOfTheIncidentToolStripMenuItem";
            this.participantsOfTheIncidentToolStripMenuItem.Size = new System.Drawing.Size(274, 26);
            this.participantsOfTheIncidentToolStripMenuItem.Text = "Participants of the incidents";
            this.participantsOfTheIncidentToolStripMenuItem.Click += new System.EventHandler(this.participantsOfTheIncidentToolStripMenuItem_Click);
            // 
            // actionsToolStripMenuItem
            // 
            this.actionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem,
            this.updateToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.actionsToolStripMenuItem.Name = "actionsToolStripMenuItem";
            this.actionsToolStripMenuItem.Size = new System.Drawing.Size(72, 24);
            this.actionsToolStripMenuItem.Text = "Actions";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(141, 26);
            this.editToolStripMenuItem.Text = "Add";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.addToolStripMenuItem_Click);
            // 
            // updateToolStripMenuItem
            // 
            this.updateToolStripMenuItem.Name = "updateToolStripMenuItem";
            this.updateToolStripMenuItem.Size = new System.Drawing.Size(141, 26);
            this.updateToolStripMenuItem.Text = "Update";
            this.updateToolStripMenuItem.Click += new System.EventHandler(this.updateToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(141, 26);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // statisticsToolStripMenuItem
            // 
            this.statisticsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.formulationOfQueriesstatisticsToolStripMenuItem});
            this.statisticsToolStripMenuItem.Name = "statisticsToolStripMenuItem";
            this.statisticsToolStripMenuItem.Size = new System.Drawing.Size(81, 24);
            this.statisticsToolStripMenuItem.Text = "Statistics";
            // 
            // formulationOfQueriesstatisticsToolStripMenuItem
            // 
            this.formulationOfQueriesstatisticsToolStripMenuItem.Name = "formulationOfQueriesstatisticsToolStripMenuItem";
            this.formulationOfQueriesstatisticsToolStripMenuItem.Size = new System.Drawing.Size(312, 26);
            this.formulationOfQueriesstatisticsToolStripMenuItem.Text = "Formulation of queries (statistics)";
            this.formulationOfQueriesstatisticsToolStripMenuItem.Click += new System.EventHandler(this.formulationOfQueriesstatisticsToolStripMenuItem_Click);
            // 
            // infoToolStripMenuItem
            // 
            this.infoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.visitsOfPrisonersToolStripMenuItem});
            this.infoToolStripMenuItem.Name = "infoToolStripMenuItem";
            this.infoToolStripMenuItem.Size = new System.Drawing.Size(49, 24);
            this.infoToolStripMenuItem.Text = "Info";
            // 
            // visitsOfPrisonersToolStripMenuItem
            // 
            this.visitsOfPrisonersToolStripMenuItem.Name = "visitsOfPrisonersToolStripMenuItem";
            this.visitsOfPrisonersToolStripMenuItem.Size = new System.Drawing.Size(208, 26);
            this.visitsOfPrisonersToolStripMenuItem.Text = "Visits of prisoners";
            this.visitsOfPrisonersToolStripMenuItem.Click += new System.EventHandler(this.visitsOfPrisonersToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(9, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 18);
            this.label1.TabIndex = 3;
            this.label1.Text = "Persons";
            // 
            // jailerBindingSource
            // 
            this.jailerBindingSource.DataMember = "Jailer";
            this.jailerBindingSource.DataSource = this.bindingSource1;
            // 
            // jailerTableAdapter
            // 
            this.jailerTableAdapter.ClearBeforeFill = true;
            // 
            // cellBindingSource
            // 
            this.cellBindingSource.DataMember = "Cell";
            this.cellBindingSource.DataSource = this.bindingSource1;
            // 
            // cellTableAdapter
            // 
            this.cellTableAdapter.ClearBeforeFill = true;
            // 
            // committedincidentBindingSource
            // 
            this.committedincidentBindingSource.DataMember = "Committed_incident";
            this.committedincidentBindingSource.DataSource = this.bindingSource1;
            // 
            // committed_incidentTableAdapter
            // 
            this.committed_incidentTableAdapter.ClearBeforeFill = true;
            // 
            // incidentBindingSource
            // 
            this.incidentBindingSource.DataMember = "Incident";
            this.incidentBindingSource.DataSource = this.bindingSource1;
            // 
            // incidentTableAdapter
            // 
            this.incidentTableAdapter.ClearBeforeFill = true;
            // 
            // jaileronshiftBindingSource
            // 
            this.jaileronshiftBindingSource.DataMember = "Jailer_on_shift";
            this.jaileronshiftBindingSource.DataSource = this.bindingSource1;
            // 
            // jailer_on_shiftTableAdapter
            // 
            this.jailer_on_shiftTableAdapter.ClearBeforeFill = true;
            // 
            // participantsoftheincidentBindingSource
            // 
            this.participantsoftheincidentBindingSource.DataMember = "Participants_of_the_incident";
            this.participantsoftheincidentBindingSource.DataSource = this.bindingSource1;
            // 
            // participants_of_the_incidentTableAdapter
            // 
            this.participants_of_the_incidentTableAdapter.ClearBeforeFill = true;
            // 
            // visitBindingSource
            // 
            this.visitBindingSource.DataMember = "Visit";
            this.visitBindingSource.DataSource = this.bindingSource1;
            // 
            // visitTableAdapter
            // 
            this.visitTableAdapter.ClearBeforeFill = true;
            // 
            // visitorBindingSource
            // 
            this.visitorBindingSource.DataMember = "Visitor";
            this.visitorBindingSource.DataSource = this.bindingSource1;
            // 
            // visitorTableAdapter
            // 
            this.visitorTableAdapter.ClearBeforeFill = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.personidDataGridViewTextBoxColumn,
            this.sNPDataGridViewTextBoxColumn,
            this.dateofbirthDataGridViewTextBoxColumn,
            this.genderDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.personBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(12, 212);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1092, 302);
            this.dataGridView1.TabIndex = 4;
            // 
            // personidDataGridViewTextBoxColumn
            // 
            this.personidDataGridViewTextBoxColumn.DataPropertyName = "person_id";
            this.personidDataGridViewTextBoxColumn.HeaderText = "person_id";
            this.personidDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.personidDataGridViewTextBoxColumn.Name = "personidDataGridViewTextBoxColumn";
            this.personidDataGridViewTextBoxColumn.ReadOnly = true;
            this.personidDataGridViewTextBoxColumn.Width = 125;
            // 
            // sNPDataGridViewTextBoxColumn
            // 
            this.sNPDataGridViewTextBoxColumn.DataPropertyName = "SNP";
            this.sNPDataGridViewTextBoxColumn.HeaderText = "SNP";
            this.sNPDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.sNPDataGridViewTextBoxColumn.Name = "sNPDataGridViewTextBoxColumn";
            this.sNPDataGridViewTextBoxColumn.Width = 125;
            // 
            // dateofbirthDataGridViewTextBoxColumn
            // 
            this.dateofbirthDataGridViewTextBoxColumn.DataPropertyName = "date_of_birth";
            this.dateofbirthDataGridViewTextBoxColumn.HeaderText = "date_of_birth";
            this.dateofbirthDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.dateofbirthDataGridViewTextBoxColumn.Name = "dateofbirthDataGridViewTextBoxColumn";
            this.dateofbirthDataGridViewTextBoxColumn.Width = 125;
            // 
            // genderDataGridViewTextBoxColumn
            // 
            this.genderDataGridViewTextBoxColumn.DataPropertyName = "gender";
            this.genderDataGridViewTextBoxColumn.HeaderText = "gender";
            this.genderDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.genderDataGridViewTextBoxColumn.Name = "genderDataGridViewTextBoxColumn";
            this.genderDataGridViewTextBoxColumn.Width = 125;
            // 
            // prisonerBindingSource
            // 
            this.prisonerBindingSource.DataMember = "Prisoner";
            this.prisonerBindingSource.DataSource = this.prisonDataBaseDataSet;
            // 
            // prisonerTableAdapter
            // 
            this.prisonerTableAdapter.ClearBeforeFill = true;
            // 
            // textBox_Search
            // 
            this.textBox_Search.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_Search.Location = new System.Drawing.Point(17, 134);
            this.textBox_Search.Name = "textBox_Search";
            this.textBox_Search.Size = new System.Drawing.Size(353, 24);
            this.textBox_Search.TabIndex = 0;
            this.textBox_Search.TextChanged += new System.EventHandler(this.textBox_Search_TextChanged);
            // 
            // button_PrintReport
            // 
            this.button_PrintReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_PrintReport.Location = new System.Drawing.Point(867, 99);
            this.button_PrintReport.Name = "button_PrintReport";
            this.button_PrintReport.Size = new System.Drawing.Size(237, 45);
            this.button_PrintReport.TabIndex = 6;
            this.button_PrintReport.Text = "Print a report with information about cells";
            this.button_PrintReport.UseVisualStyleBackColor = true;
            this.button_PrintReport.Click += new System.EventHandler(this.button_PrintReport_Click);
            // 
            // comboBox_Cells
            // 
            this.comboBox_Cells.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_Cells.DataSource = this.cellBindingSource;
            this.comboBox_Cells.DisplayMember = "cell_number";
            this.comboBox_Cells.FormattingEnabled = true;
            this.comboBox_Cells.Location = new System.Drawing.Point(747, 99);
            this.comboBox_Cells.Name = "comboBox_Cells";
            this.comboBox_Cells.Size = new System.Drawing.Size(105, 24);
            this.comboBox_Cells.TabIndex = 7;
            this.comboBox_Cells.ValueMember = "cell_id";
            // 
            // label_Sort
            // 
            this.label_Sort.AutoSize = true;
            this.label_Sort.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_Sort.Location = new System.Drawing.Point(14, 179);
            this.label_Sort.Name = "label_Sort";
            this.label_Sort.Size = new System.Drawing.Size(59, 18);
            this.label_Sort.TabIndex = 8;
            this.label_Sort.Text = "Sort by:";
            // 
            // checkBox_Sort
            // 
            this.checkBox_Sort.AutoSize = true;
            this.checkBox_Sort.Location = new System.Drawing.Point(79, 180);
            this.checkBox_Sort.Name = "checkBox_Sort";
            this.checkBox_Sort.Size = new System.Drawing.Size(57, 20);
            this.checkBox_Sort.TabIndex = 9;
            this.checkBox_Sort.Text = "SNP";
            this.checkBox_Sort.UseVisualStyleBackColor = true;
            this.checkBox_Sort.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // comboBox_Filtration
            // 
            this.comboBox_Filtration.FormattingEnabled = true;
            this.comboBox_Filtration.Location = new System.Drawing.Point(405, 99);
            this.comboBox_Filtration.Name = "comboBox_Filtration";
            this.comboBox_Filtration.Size = new System.Drawing.Size(136, 24);
            this.comboBox_Filtration.TabIndex = 10;
            this.comboBox_Filtration.SelectedIndexChanged += new System.EventHandler(this.comboBox_Filtration_SelectedIndexChanged);
            // 
            // label_Filter
            // 
            this.label_Filter.AutoSize = true;
            this.label_Filter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_Filter.Location = new System.Drawing.Point(402, 73);
            this.label_Filter.Name = "label_Filter";
            this.label_Filter.Size = new System.Drawing.Size(63, 18);
            this.label_Filter.TabIndex = 11;
            this.label_Filter.Text = "Filter by:";
            // 
            // button_PrintReport1
            // 
            this.button_PrintReport1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_PrintReport1.Location = new System.Drawing.Point(867, 150);
            this.button_PrintReport1.Name = "button_PrintReport1";
            this.button_PrintReport1.Size = new System.Drawing.Size(237, 50);
            this.button_PrintReport1.TabIndex = 12;
            this.button_PrintReport1.Text = "Print a report with information about jailers";
            this.button_PrintReport1.UseVisualStyleBackColor = true;
            this.button_PrintReport1.Click += new System.EventHandler(this.button_PrintReport1_Click);
            // 
            // label_Search
            // 
            this.label_Search.AutoSize = true;
            this.label_Search.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_Search.Location = new System.Drawing.Point(14, 79);
            this.label_Search.Name = "label_Search";
            this.label_Search.Size = new System.Drawing.Size(78, 18);
            this.label_Search.TabIndex = 13;
            this.label_Search.Text = "Search by:";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(108, 75);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(57, 20);
            this.checkBox1.TabIndex = 14;
            this.checkBox1.Text = "SNP";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(108, 107);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(52, 20);
            this.checkBox2.TabIndex = 15;
            this.checkBox2.Text = "Cell";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(455, 131);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(104, 22);
            this.dateTimePicker1.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(401, 134);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 18);
            this.label2.TabIndex = 17;
            this.label2.Text = "From:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(565, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 18);
            this.label3.TabIndex = 19;
            this.label3.Text = "To:";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(601, 130);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(104, 22);
            this.dateTimePicker2.TabIndex = 18;
            // 
            // checkBox_BirthdayDate
            // 
            this.checkBox_BirthdayDate.AutoSize = true;
            this.checkBox_BirthdayDate.Location = new System.Drawing.Point(404, 161);
            this.checkBox_BirthdayDate.Name = "checkBox_BirthdayDate";
            this.checkBox_BirthdayDate.Size = new System.Drawing.Size(109, 20);
            this.checkBox_BirthdayDate.TabIndex = 20;
            this.checkBox_BirthdayDate.Text = "Filter by date:";
            this.checkBox_BirthdayDate.UseVisualStyleBackColor = true;
            this.checkBox_BirthdayDate.CheckedChanged += new System.EventHandler(this.checkBox_Date_CheckedChanged);
            // 
            // checkBox_ReleaseDate
            // 
            this.checkBox_ReleaseDate.AutoSize = true;
            this.checkBox_ReleaseDate.Location = new System.Drawing.Point(519, 161);
            this.checkBox_ReleaseDate.Name = "checkBox_ReleaseDate";
            this.checkBox_ReleaseDate.Size = new System.Drawing.Size(109, 20);
            this.checkBox_ReleaseDate.TabIndex = 21;
            this.checkBox_ReleaseDate.Text = "Filter by date:";
            this.checkBox_ReleaseDate.UseVisualStyleBackColor = true;
            this.checkBox_ReleaseDate.CheckedChanged += new System.EventHandler(this.checkBox_ReleaseDate_CheckedChanged);
            // 
            // checkBox_HireDate
            // 
            this.checkBox_HireDate.AutoSize = true;
            this.checkBox_HireDate.Location = new System.Drawing.Point(634, 160);
            this.checkBox_HireDate.Name = "checkBox_HireDate";
            this.checkBox_HireDate.Size = new System.Drawing.Size(109, 20);
            this.checkBox_HireDate.TabIndex = 22;
            this.checkBox_HireDate.Text = "Filter by date:";
            this.checkBox_HireDate.UseVisualStyleBackColor = true;
            this.checkBox_HireDate.CheckedChanged += new System.EventHandler(this.checkBox_HireDate_CheckedChanged);
            // 
            // checkBox_ShiftDate
            // 
            this.checkBox_ShiftDate.AutoSize = true;
            this.checkBox_ShiftDate.Location = new System.Drawing.Point(404, 186);
            this.checkBox_ShiftDate.Name = "checkBox_ShiftDate";
            this.checkBox_ShiftDate.Size = new System.Drawing.Size(109, 20);
            this.checkBox_ShiftDate.TabIndex = 23;
            this.checkBox_ShiftDate.Text = "Filter by date:";
            this.checkBox_ShiftDate.UseVisualStyleBackColor = true;
            this.checkBox_ShiftDate.CheckedChanged += new System.EventHandler(this.checkBox_ShiftDate_CheckedChanged);
            // 
            // checkBox_VisitDate
            // 
            this.checkBox_VisitDate.AutoSize = true;
            this.checkBox_VisitDate.Location = new System.Drawing.Point(519, 187);
            this.checkBox_VisitDate.Name = "checkBox_VisitDate";
            this.checkBox_VisitDate.Size = new System.Drawing.Size(109, 20);
            this.checkBox_VisitDate.TabIndex = 24;
            this.checkBox_VisitDate.Text = "Filter by date:";
            this.checkBox_VisitDate.UseVisualStyleBackColor = true;
            this.checkBox_VisitDate.CheckedChanged += new System.EventHandler(this.checkBox_VisitDate_CheckedChanged);
            // 
            // checkBox_CommittedIncidentDate
            // 
            this.checkBox_CommittedIncidentDate.AutoSize = true;
            this.checkBox_CommittedIncidentDate.Location = new System.Drawing.Point(635, 187);
            this.checkBox_CommittedIncidentDate.Name = "checkBox_CommittedIncidentDate";
            this.checkBox_CommittedIncidentDate.Size = new System.Drawing.Size(109, 20);
            this.checkBox_CommittedIncidentDate.TabIndex = 25;
            this.checkBox_CommittedIncidentDate.Text = "Filter by date:";
            this.checkBox_CommittedIncidentDate.UseVisualStyleBackColor = true;
            this.checkBox_CommittedIncidentDate.CheckedChanged += new System.EventHandler(this.checkBox_CommittedIncidentDate_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(747, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(299, 18);
            this.label4.TabIndex = 26;
            this.label4.Text = "Select the needed camera to print the report:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1121, 577);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.checkBox_CommittedIncidentDate);
            this.Controls.Add(this.checkBox_VisitDate);
            this.Controls.Add(this.checkBox_ShiftDate);
            this.Controls.Add(this.checkBox_HireDate);
            this.Controls.Add(this.checkBox_ReleaseDate);
            this.Controls.Add(this.checkBox_BirthdayDate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label_Search);
            this.Controls.Add(this.textBox_Search);
            this.Controls.Add(this.button_PrintReport1);
            this.Controls.Add(this.label_Filter);
            this.Controls.Add(this.comboBox_Filtration);
            this.Controls.Add(this.checkBox_Sort);
            this.Controls.Add(this.label_Sort);
            this.Controls.Add(this.comboBox_Cells);
            this.Controls.Add(this.button_PrintReport);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bindingNavigator1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "MainForm";
            this.Text = "Prison administrator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.prisonDataBaseDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.personBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.jailerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cellBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.committedincidentBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.incidentBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.jaileronshiftBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.participantsoftheincidentBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.visitBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.visitorBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.prisonerBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource bindingSource1;
        private PrisonDataBaseDataSet prisonDataBaseDataSet;
        private System.Windows.Forms.BindingSource personBindingSource;
        private PrisonDataBaseDataSetTableAdapters.PersonTableAdapter personTableAdapter;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem databaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem personToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem prisonerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem jailerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem jailerOnShiftToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cellToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem visitorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem visitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem incidentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem comittedIncidentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem participantsOfTheIncidentToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource jailerBindingSource;
        private PrisonDataBaseDataSetTableAdapters.JailerTableAdapter jailerTableAdapter;
        private System.Windows.Forms.BindingSource cellBindingSource;
        private PrisonDataBaseDataSetTableAdapters.CellTableAdapter cellTableAdapter;
        private System.Windows.Forms.BindingSource committedincidentBindingSource;
        private PrisonDataBaseDataSetTableAdapters.Committed_incidentTableAdapter committed_incidentTableAdapter;
        private System.Windows.Forms.BindingSource incidentBindingSource;
        private PrisonDataBaseDataSetTableAdapters.IncidentTableAdapter incidentTableAdapter;
        private System.Windows.Forms.BindingSource jaileronshiftBindingSource;
        private PrisonDataBaseDataSetTableAdapters.Jailer_on_shiftTableAdapter jailer_on_shiftTableAdapter;
        private System.Windows.Forms.BindingSource participantsoftheincidentBindingSource;
        private PrisonDataBaseDataSetTableAdapters.Participants_of_the_incidentTableAdapter participants_of_the_incidentTableAdapter;
        private System.Windows.Forms.BindingSource visitBindingSource;
        private PrisonDataBaseDataSetTableAdapters.VisitTableAdapter visitTableAdapter;
        private System.Windows.Forms.BindingSource visitorBindingSource;
        private PrisonDataBaseDataSetTableAdapters.VisitorTableAdapter visitorTableAdapter;
        private System.Windows.Forms.ToolStripMenuItem actionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource prisonerBindingSource;
        private PrisonDataBaseDataSetTableAdapters.PrisonerTableAdapter prisonerTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn personidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sNPDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateofbirthDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn genderDataGridViewTextBoxColumn;
        private System.Windows.Forms.TextBox textBox_Search;
        private System.Windows.Forms.ToolStripMenuItem statisticsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem formulationOfQueriesstatisticsToolStripMenuItem;
        private System.Windows.Forms.Button button_PrintReport;
        private System.Windows.Forms.ComboBox comboBox_Cells;
        private System.Windows.Forms.Label label_Sort;
        private System.Windows.Forms.CheckBox checkBox_Sort;
        private System.Windows.Forms.ComboBox comboBox_Filtration;
        private System.Windows.Forms.Label label_Filter;
        private System.Windows.Forms.Button button_PrintReport1;
        private System.Windows.Forms.ToolStripMenuItem infoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem visitsOfPrisonersToolStripMenuItem;
        private System.Windows.Forms.Label label_Search;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.CheckBox checkBox_BirthdayDate;
        private System.Windows.Forms.CheckBox checkBox_ReleaseDate;
        private System.Windows.Forms.CheckBox checkBox_HireDate;
        private System.Windows.Forms.CheckBox checkBox_ShiftDate;
        private System.Windows.Forms.CheckBox checkBox_VisitDate;
        private System.Windows.Forms.CheckBox checkBox_CommittedIncidentDate;
        private System.Windows.Forms.Label label4;
    }
}

