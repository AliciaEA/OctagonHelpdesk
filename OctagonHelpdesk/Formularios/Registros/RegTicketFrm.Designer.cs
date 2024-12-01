namespace OctagonHelpdesk.Formularios
{
    partial class RegTicketFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegTicketFrm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnReportesVistaPrevia = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.DgvRegTickets = new System.Windows.Forms.DataGridView();
            this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.iDTicketDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.activeStateDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.createdByDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.userModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.subjectDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stateProcessDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prioridadDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.asignadoADataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.creationDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastUpdatedDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deactivationDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.reactivationDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.closeDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvRegTickets)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userModelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel1.Controls.Add(this.btnReportesVistaPrevia);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1086, 203);
            this.panel1.TabIndex = 0;
            // 
            // btnReportesVistaPrevia
            // 
            this.btnReportesVistaPrevia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReportesVistaPrevia.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnReportesVistaPrevia.Image = global::OctagonHelpdesk.Properties.Resources.reportesIcon;
            this.btnReportesVistaPrevia.Location = new System.Drawing.Point(1334, 39);
            this.btnReportesVistaPrevia.Name = "btnReportesVistaPrevia";
            this.btnReportesVistaPrevia.Size = new System.Drawing.Size(88, 89);
            this.btnReportesVistaPrevia.TabIndex = 1;
            this.btnReportesVistaPrevia.UseVisualStyleBackColor = false;
            this.btnReportesVistaPrevia.Click += new System.EventHandler(this.btnReportesVistaPrevia_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(106, 91);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(134, 28);
            this.comboBox1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 20);
            this.label1.TabIndex = 18;
            this.label1.Text = "Filtrar por:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(6, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(357, 54);
            this.label6.TabIndex = 17;
            this.label6.Text = "Registro de Tickets";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.bindingNavigator1);
            this.panel2.Controls.Add(this.DgvRegTickets);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 203);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1086, 607);
            this.panel2.TabIndex = 1;
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = null;
            this.bindingNavigator1.BindingSource = this.bindingSource;
            this.bindingNavigator1.CountItem = this.bindingNavigatorCountItem;
            this.bindingNavigator1.DeleteItem = null;
            this.bindingNavigator1.ImageScalingSize = new System.Drawing.Size(24, 24);
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
            this.bindingNavigator1.Location = new System.Drawing.Point(0, 0);
            this.bindingNavigator1.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigator1.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigator1.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigator1.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigator1.Size = new System.Drawing.Size(1086, 38);
            this.bindingNavigator1.TabIndex = 1;
            this.bindingNavigator1.Text = "bindingNavigator1";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(57, 33);
            this.bindingNavigatorCountItem.Text = "de {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Número total de elementos";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(34, 33);
            this.bindingNavigatorMoveFirstItem.Text = "Mover primero";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(34, 33);
            this.bindingNavigatorMovePreviousItem.Text = "Mover anterior";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 38);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Posición";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 31);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Posición actual";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 38);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(34, 33);
            this.bindingNavigatorMoveNextItem.Text = "Mover siguiente";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(34, 33);
            this.bindingNavigatorMoveLastItem.Text = "Mover último";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 38);
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(34, 33);
            this.bindingNavigatorAddNewItem.Text = "Agregar nuevo";
            this.bindingNavigatorAddNewItem.Click += new System.EventHandler(this.bindingNavigatorAddNewItem_Click);
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(34, 33);
            this.bindingNavigatorDeleteItem.Text = "Eliminar";
            this.bindingNavigatorDeleteItem.Click += new System.EventHandler(this.bindingNavigatorDeleteItem_Click);
            // 
            // DgvRegTickets
            // 
            this.DgvRegTickets.AllowUserToAddRows = false;
            this.DgvRegTickets.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.DgvRegTickets.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DgvRegTickets.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DgvRegTickets.AutoGenerateColumns = false;
            this.DgvRegTickets.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DgvRegTickets.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DgvRegTickets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvRegTickets.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDTicketDataGridViewTextBoxColumn,
            this.activeStateDataGridViewCheckBoxColumn,
            this.createdByDataGridViewTextBoxColumn,
            this.subjectDataGridViewTextBoxColumn,
            this.descripcionDataGridViewTextBoxColumn,
            this.stateProcessDataGridViewTextBoxColumn,
            this.prioridadDataGridViewTextBoxColumn,
            this.asignadoADataGridViewTextBoxColumn,
            this.creationDateDataGridViewTextBoxColumn,
            this.lastUpdatedDateDataGridViewTextBoxColumn,
            this.deactivationDateDataGridViewTextBoxColumn,
            this.reactivationDateDataGridViewTextBoxColumn,
            this.closeDateDataGridViewTextBoxColumn});
            this.DgvRegTickets.DataSource = this.bindingSource;
            this.DgvRegTickets.Location = new System.Drawing.Point(3, 63);
            this.DgvRegTickets.Name = "DgvRegTickets";
            this.DgvRegTickets.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.NullValue = "No encontrado";
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvRegTickets.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.DgvRegTickets.RowHeadersWidth = 62;
            dataGridViewCellStyle5.NullValue = "No encontrado";
            this.DgvRegTickets.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.DgvRegTickets.RowTemplate.Height = 28;
            this.DgvRegTickets.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvRegTickets.Size = new System.Drawing.Size(1083, 544);
            this.DgvRegTickets.TabIndex = 2;
            this.DgvRegTickets.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvRegTickets_CellClick);
            this.DgvRegTickets.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvRegTickets_CellDoubleClick);
            // 
            // bindingSource
            // 
            this.bindingSource.AllowNew = true;
            this.bindingSource.DataSource = typeof(OctagonHelpdesk.Models.Ticket);
            // 
            // iDTicketDataGridViewTextBoxColumn
            // 
            this.iDTicketDataGridViewTextBoxColumn.DataPropertyName = "IDTicket";
            this.iDTicketDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDTicketDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.iDTicketDataGridViewTextBoxColumn.Name = "iDTicketDataGridViewTextBoxColumn";
            this.iDTicketDataGridViewTextBoxColumn.ReadOnly = true;
            this.iDTicketDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.iDTicketDataGridViewTextBoxColumn.ToolTipText = "ID del Ticket";
            // 
            // activeStateDataGridViewCheckBoxColumn
            // 
            this.activeStateDataGridViewCheckBoxColumn.DataPropertyName = "ActiveState";
            this.activeStateDataGridViewCheckBoxColumn.HeaderText = "Habilitacion";
            this.activeStateDataGridViewCheckBoxColumn.MinimumWidth = 8;
            this.activeStateDataGridViewCheckBoxColumn.Name = "activeStateDataGridViewCheckBoxColumn";
            this.activeStateDataGridViewCheckBoxColumn.ReadOnly = true;
            this.activeStateDataGridViewCheckBoxColumn.ToolTipText = "Estado del Ticket";
            // 
            // createdByDataGridViewTextBoxColumn
            // 
            this.createdByDataGridViewTextBoxColumn.AutoComplete = false;
            this.createdByDataGridViewTextBoxColumn.DataPropertyName = "CreatedBy";
            this.createdByDataGridViewTextBoxColumn.DataSource = this.userModelBindingSource;
            dataGridViewCellStyle2.NullValue = "No Encontrado";
            this.createdByDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.createdByDataGridViewTextBoxColumn.DisplayMember = "Username";
            this.createdByDataGridViewTextBoxColumn.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.createdByDataGridViewTextBoxColumn.HeaderText = "Creador";
            this.createdByDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.createdByDataGridViewTextBoxColumn.Name = "createdByDataGridViewTextBoxColumn";
            this.createdByDataGridViewTextBoxColumn.ReadOnly = true;
            this.createdByDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.createdByDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.createdByDataGridViewTextBoxColumn.ToolTipText = "Empleado que creo el ticket";
            this.createdByDataGridViewTextBoxColumn.ValueMember = "IDUser";
            // 
            // userModelBindingSource
            // 
            this.userModelBindingSource.DataSource = typeof(OctagonHelpdesk.Models.UserModel);
            // 
            // subjectDataGridViewTextBoxColumn
            // 
            this.subjectDataGridViewTextBoxColumn.DataPropertyName = "Subject";
            this.subjectDataGridViewTextBoxColumn.HeaderText = "Asunto";
            this.subjectDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.subjectDataGridViewTextBoxColumn.Name = "subjectDataGridViewTextBoxColumn";
            this.subjectDataGridViewTextBoxColumn.ReadOnly = true;
            this.subjectDataGridViewTextBoxColumn.ToolTipText = "Asunto del Ticket";
            // 
            // descripcionDataGridViewTextBoxColumn
            // 
            this.descripcionDataGridViewTextBoxColumn.DataPropertyName = "Descripcion";
            this.descripcionDataGridViewTextBoxColumn.HeaderText = "Descripcion";
            this.descripcionDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.descripcionDataGridViewTextBoxColumn.Name = "descripcionDataGridViewTextBoxColumn";
            this.descripcionDataGridViewTextBoxColumn.ReadOnly = true;
            this.descripcionDataGridViewTextBoxColumn.ToolTipText = "Descripcion del Ticket";
            // 
            // stateProcessDataGridViewTextBoxColumn
            // 
            this.stateProcessDataGridViewTextBoxColumn.DataPropertyName = "StateProcess";
            this.stateProcessDataGridViewTextBoxColumn.HeaderText = "Estado";
            this.stateProcessDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.stateProcessDataGridViewTextBoxColumn.Name = "stateProcessDataGridViewTextBoxColumn";
            this.stateProcessDataGridViewTextBoxColumn.ReadOnly = true;
            this.stateProcessDataGridViewTextBoxColumn.ToolTipText = "Estado de resolucion del Ticket";
            // 
            // prioridadDataGridViewTextBoxColumn
            // 
            this.prioridadDataGridViewTextBoxColumn.DataPropertyName = "Prioridad";
            this.prioridadDataGridViewTextBoxColumn.HeaderText = "Prioridad";
            this.prioridadDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.prioridadDataGridViewTextBoxColumn.Name = "prioridadDataGridViewTextBoxColumn";
            this.prioridadDataGridViewTextBoxColumn.ReadOnly = true;
            this.prioridadDataGridViewTextBoxColumn.ToolTipText = "Prioridad del Ticket";
            // 
            // asignadoADataGridViewTextBoxColumn
            // 
            this.asignadoADataGridViewTextBoxColumn.DataPropertyName = "AsignadoA";
            this.asignadoADataGridViewTextBoxColumn.DataSource = this.userModelBindingSource;
            dataGridViewCellStyle3.NullValue = "Sin asignar";
            this.asignadoADataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.asignadoADataGridViewTextBoxColumn.DisplayMember = "Username";
            this.asignadoADataGridViewTextBoxColumn.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.asignadoADataGridViewTextBoxColumn.HeaderText = "Encargado";
            this.asignadoADataGridViewTextBoxColumn.MinimumWidth = 8;
            this.asignadoADataGridViewTextBoxColumn.Name = "asignadoADataGridViewTextBoxColumn";
            this.asignadoADataGridViewTextBoxColumn.ReadOnly = true;
            this.asignadoADataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.asignadoADataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.asignadoADataGridViewTextBoxColumn.ToolTipText = "Asignado a Empleado";
            this.asignadoADataGridViewTextBoxColumn.ValueMember = "IDUser";
            // 
            // creationDateDataGridViewTextBoxColumn
            // 
            this.creationDateDataGridViewTextBoxColumn.DataPropertyName = "CreationDate";
            this.creationDateDataGridViewTextBoxColumn.HeaderText = "Creado";
            this.creationDateDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.creationDateDataGridViewTextBoxColumn.Name = "creationDateDataGridViewTextBoxColumn";
            this.creationDateDataGridViewTextBoxColumn.ReadOnly = true;
            this.creationDateDataGridViewTextBoxColumn.ToolTipText = "Fecha de Creacion";
            // 
            // lastUpdatedDateDataGridViewTextBoxColumn
            // 
            this.lastUpdatedDateDataGridViewTextBoxColumn.DataPropertyName = "LastUpdatedDate";
            this.lastUpdatedDateDataGridViewTextBoxColumn.HeaderText = "Actualizado";
            this.lastUpdatedDateDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.lastUpdatedDateDataGridViewTextBoxColumn.Name = "lastUpdatedDateDataGridViewTextBoxColumn";
            this.lastUpdatedDateDataGridViewTextBoxColumn.ReadOnly = true;
            this.lastUpdatedDateDataGridViewTextBoxColumn.ToolTipText = "Ultima decha de actualizacion";
            // 
            // deactivationDateDataGridViewTextBoxColumn
            // 
            this.deactivationDateDataGridViewTextBoxColumn.DataPropertyName = "DeactivationDate";
            this.deactivationDateDataGridViewTextBoxColumn.HeaderText = "Desactivacion";
            this.deactivationDateDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.deactivationDateDataGridViewTextBoxColumn.Name = "deactivationDateDataGridViewTextBoxColumn";
            this.deactivationDateDataGridViewTextBoxColumn.ReadOnly = true;
            this.deactivationDateDataGridViewTextBoxColumn.ToolTipText = "Fecha de desactivacion";
            // 
            // reactivationDateDataGridViewTextBoxColumn
            // 
            this.reactivationDateDataGridViewTextBoxColumn.DataPropertyName = "ReactivationDate";
            this.reactivationDateDataGridViewTextBoxColumn.HeaderText = "Reactivacion";
            this.reactivationDateDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.reactivationDateDataGridViewTextBoxColumn.Name = "reactivationDateDataGridViewTextBoxColumn";
            this.reactivationDateDataGridViewTextBoxColumn.ReadOnly = true;
            this.reactivationDateDataGridViewTextBoxColumn.ToolTipText = "Fecha de Reactivacion";
            // 
            // closeDateDataGridViewTextBoxColumn
            // 
            this.closeDateDataGridViewTextBoxColumn.DataPropertyName = "CloseDate";
            this.closeDateDataGridViewTextBoxColumn.HeaderText = "Finalización";
            this.closeDateDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.closeDateDataGridViewTextBoxColumn.Name = "closeDateDataGridViewTextBoxColumn";
            this.closeDateDataGridViewTextBoxColumn.ReadOnly = true;
            this.closeDateDataGridViewTextBoxColumn.ToolTipText = "Fecha de finalizacion del Ticket";
            // 
            // RegTicketFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.ClientSize = new System.Drawing.Size(1086, 810);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RegTicketFrm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Text = "Registro de Tickets";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.RegTicketFrm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvRegTickets)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userModelBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView DgvRegTickets;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource bindingSource;
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
        private System.Windows.Forms.Button btnReportesVistaPrevia;
        private System.Windows.Forms.BindingSource userModelBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDTicketDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn activeStateDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn createdByDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn subjectDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn stateProcessDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn prioridadDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn asignadoADataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn creationDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastUpdatedDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn deactivationDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn reactivationDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn closeDateDataGridViewTextBoxColumn;
    }
}