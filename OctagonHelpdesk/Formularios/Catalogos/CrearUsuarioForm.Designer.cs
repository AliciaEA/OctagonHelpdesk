namespace OctagonHelpdesk.Formularios
{
    partial class CrearUsuarioForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CrearUsuarioForm));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.gbDatosGenerales = new System.Windows.Forms.GroupBox();
            this.tbLastname = new System.Windows.Forms.TextBox();
            this.btnUserLogDat = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbDepartamento = new System.Windows.Forms.ComboBox();
            this.tbName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbEmail = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.cbEmpleado = new System.Windows.Forms.CheckBox();
            this.cbIT = new System.Windows.Forms.CheckBox();
            this.cbAdmin = new System.Windows.Forms.CheckBox();
            this.btnConfirmUserCreation = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.gbUserLog = new System.Windows.Forms.GroupBox();
            this.btnGeneratePassword = new System.Windows.Forms.Button();
            this.btnDatosGenerales = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.cbActiveState = new System.Windows.Forms.CheckBox();
            this.btnActividad = new System.Windows.Forms.Button();
            this.pnlActivity = new System.Windows.Forms.Panel();
            this.lblReactivationDate = new System.Windows.Forms.Label();
            this.lblDeactivationDate = new System.Windows.Forms.Label();
            this.lblLastUpdatedDate = new System.Windows.Forms.Label();
            this.lblCreationDate = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.gbDatosGenerales.SuspendLayout();
            this.gbUserLog.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.pnlActivity.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(-4, -31);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(87, 691);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.BackColor = System.Drawing.Color.Transparent;
            this.lblTitulo.Font = new System.Drawing.Font("MingLiU_HKSCS-ExtB", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(233, 9);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(166, 22);
            this.lblTitulo.TabIndex = 1;
            this.lblTitulo.Text = "Crear Usuario";
            // 
            // gbDatosGenerales
            // 
            this.gbDatosGenerales.Controls.Add(this.tbLastname);
            this.gbDatosGenerales.Controls.Add(this.btnUserLogDat);
            this.gbDatosGenerales.Controls.Add(this.label7);
            this.gbDatosGenerales.Controls.Add(this.cmbDepartamento);
            this.gbDatosGenerales.Controls.Add(this.tbName);
            this.gbDatosGenerales.Controls.Add(this.label5);
            this.gbDatosGenerales.Controls.Add(this.label3);
            this.gbDatosGenerales.Location = new System.Drawing.Point(100, 262);
            this.gbDatosGenerales.Name = "gbDatosGenerales";
            this.gbDatosGenerales.Size = new System.Drawing.Size(501, 285);
            this.gbDatosGenerales.TabIndex = 2;
            this.gbDatosGenerales.TabStop = false;
            // 
            // tbLastname
            // 
            this.tbLastname.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.tbLastname.Location = new System.Drawing.Point(139, 92);
            this.tbLastname.Name = "tbLastname";
            this.tbLastname.Size = new System.Drawing.Size(334, 26);
            this.tbLastname.TabIndex = 2;
            // 
            // btnUserLogDat
            // 
            this.btnUserLogDat.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnUserLogDat.Location = new System.Drawing.Point(426, 217);
            this.btnUserLogDat.Name = "btnUserLogDat";
            this.btnUserLogDat.Size = new System.Drawing.Size(47, 45);
            this.btnUserLogDat.TabIndex = 4;
            this.btnUserLogDat.Text = "→";
            this.btnUserLogDat.UseVisualStyleBackColor = false;
            this.btnUserLogDat.Click += new System.EventHandler(this.btnUserLogDat_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("MingLiU_HKSCS-ExtB", 9F);
            this.label7.Location = new System.Drawing.Point(10, 97);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 12);
            this.label7.TabIndex = 15;
            this.label7.Text = "Apellido:";
            // 
            // cmbDepartamento
            // 
            this.cmbDepartamento.FormattingEnabled = true;
            this.cmbDepartamento.Location = new System.Drawing.Point(139, 152);
            this.cmbDepartamento.Name = "cmbDepartamento";
            this.cmbDepartamento.Size = new System.Drawing.Size(334, 28);
            this.cmbDepartamento.TabIndex = 3;
            this.cmbDepartamento.Text = "...";
            // 
            // tbName
            // 
            this.tbName.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.tbName.Location = new System.Drawing.Point(139, 38);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(334, 26);
            this.tbName.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("MingLiU_HKSCS-ExtB", 9F);
            this.label5.Location = new System.Drawing.Point(10, 157);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 12);
            this.label5.TabIndex = 3;
            this.label5.Text = "Departamento:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("MingLiU_HKSCS-ExtB", 9F);
            this.label3.Location = new System.Drawing.Point(10, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "Nombre:";
            // 
            // tbEmail
            // 
            this.tbEmail.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.tbEmail.Location = new System.Drawing.Point(134, 147);
            this.tbEmail.MaxLength = 50;
            this.tbEmail.Name = "tbEmail";
            this.tbEmail.Size = new System.Drawing.Size(334, 26);
            this.tbEmail.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("MingLiU_HKSCS-ExtB", 9F);
            this.label4.Location = new System.Drawing.Point(10, 150);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "Email:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("MingLiU_HKSCS-ExtB", 9F);
            this.label9.Location = new System.Drawing.Point(8, 93);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(71, 12);
            this.label9.TabIndex = 19;
            this.label9.Text = "Contraseña:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("MingLiU_HKSCS-ExtB", 9F);
            this.label8.Location = new System.Drawing.Point(8, 34);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 18;
            this.label8.Text = "Usuario:";
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtPassword.Location = new System.Drawing.Point(134, 88);
            this.txtPassword.MaxLength = 12;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(292, 26);
            this.txtPassword.TabIndex = 3;
            this.txtPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPassword_KeyPress);
            this.txtPassword.Leave += new System.EventHandler(this.txtPassword_Leave);
            // 
            // txtUsername
            // 
            this.txtUsername.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtUsername.Location = new System.Drawing.Point(134, 34);
            this.txtUsername.MaxLength = 20;
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(334, 26);
            this.txtUsername.TabIndex = 2;
            this.txtUsername.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUsername_KeyPress);
            // 
            // cbEmpleado
            // 
            this.cbEmpleado.AutoSize = true;
            this.cbEmpleado.Font = new System.Drawing.Font("MingLiU_HKSCS-ExtB", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbEmpleado.Location = new System.Drawing.Point(360, 207);
            this.cbEmpleado.Name = "cbEmpleado";
            this.cbEmpleado.Size = new System.Drawing.Size(72, 15);
            this.cbEmpleado.TabIndex = 8;
            this.cbEmpleado.Text = "Empleado";
            this.cbEmpleado.UseVisualStyleBackColor = true;
            // 
            // cbIT
            // 
            this.cbIT.AutoSize = true;
            this.cbIT.Font = new System.Drawing.Font("MingLiU_HKSCS-ExtB", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbIT.Location = new System.Drawing.Point(234, 207);
            this.cbIT.Name = "cbIT";
            this.cbIT.Size = new System.Drawing.Size(84, 15);
            this.cbIT.TabIndex = 7;
            this.cbIT.Text = "Tecnico IT";
            this.cbIT.UseVisualStyleBackColor = true;
            // 
            // cbAdmin
            // 
            this.cbAdmin.AutoSize = true;
            this.cbAdmin.Font = new System.Drawing.Font("MingLiU_HKSCS-ExtB", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbAdmin.Location = new System.Drawing.Point(134, 207);
            this.cbAdmin.Name = "cbAdmin";
            this.cbAdmin.Size = new System.Drawing.Size(54, 15);
            this.cbAdmin.TabIndex = 6;
            this.cbAdmin.Text = "Admin";
            this.cbAdmin.UseVisualStyleBackColor = true;
            // 
            // btnConfirmUserCreation
            // 
            this.btnConfirmUserCreation.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnConfirmUserCreation.Font = new System.Drawing.Font("MingLiU_HKSCS-ExtB", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirmUserCreation.Location = new System.Drawing.Point(340, 262);
            this.btnConfirmUserCreation.Name = "btnConfirmUserCreation";
            this.btnConfirmUserCreation.Size = new System.Drawing.Size(128, 49);
            this.btnConfirmUserCreation.TabIndex = 10;
            this.btnConfirmUserCreation.Text = "Guardar";
            this.btnConfirmUserCreation.UseVisualStyleBackColor = false;
            this.btnConfirmUserCreation.Click += new System.EventHandler(this.btnConfirmUserCreation_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("MingLiU_HKSCS-ExtB", 9F);
            this.label6.Location = new System.Drawing.Point(6, 207);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 12);
            this.label6.TabIndex = 5;
            this.label6.Text = "Permisos:";
            // 
            // gbUserLog
            // 
            this.gbUserLog.Controls.Add(this.btnGeneratePassword);
            this.gbUserLog.Controls.Add(this.btnDatosGenerales);
            this.gbUserLog.Controls.Add(this.label9);
            this.gbUserLog.Controls.Add(this.label8);
            this.gbUserLog.Controls.Add(this.txtUsername);
            this.gbUserLog.Controls.Add(this.cbEmpleado);
            this.gbUserLog.Controls.Add(this.txtPassword);
            this.gbUserLog.Controls.Add(this.tbEmail);
            this.gbUserLog.Controls.Add(this.cbIT);
            this.gbUserLog.Controls.Add(this.label4);
            this.gbUserLog.Controls.Add(this.cbAdmin);
            this.gbUserLog.Controls.Add(this.label6);
            this.gbUserLog.Controls.Add(this.btnConfirmUserCreation);
            this.gbUserLog.Location = new System.Drawing.Point(113, 251);
            this.gbUserLog.Name = "gbUserLog";
            this.gbUserLog.Size = new System.Drawing.Size(482, 340);
            this.gbUserLog.TabIndex = 3;
            this.gbUserLog.TabStop = false;
            this.gbUserLog.Visible = false;
            // 
            // btnGeneratePassword
            // 
            this.btnGeneratePassword.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnGeneratePassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGeneratePassword.Location = new System.Drawing.Point(421, 81);
            this.btnGeneratePassword.Name = "btnGeneratePassword";
            this.btnGeneratePassword.Size = new System.Drawing.Size(46, 37);
            this.btnGeneratePassword.TabIndex = 4;
            this.btnGeneratePassword.Text = "↻";
            this.btnGeneratePassword.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnGeneratePassword.UseVisualStyleBackColor = false;
            this.btnGeneratePassword.Click += new System.EventHandler(this.btnGeneratePassword_Click);
            // 
            // btnDatosGenerales
            // 
            this.btnDatosGenerales.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnDatosGenerales.Location = new System.Drawing.Point(11, 266);
            this.btnDatosGenerales.Name = "btnDatosGenerales";
            this.btnDatosGenerales.Size = new System.Drawing.Size(47, 45);
            this.btnDatosGenerales.TabIndex = 9;
            this.btnDatosGenerales.Text = "←";
            this.btnDatosGenerales.UseVisualStyleBackColor = false;
            this.btnDatosGenerales.Click += new System.EventHandler(this.btnDatosGenerales_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::OctagonHelpdesk.Properties.Resources.kindpng_2697881;
            this.pictureBox2.Location = new System.Drawing.Point(282, 56);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(142, 140);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            // 
            // cbActiveState
            // 
            this.cbActiveState.AutoSize = true;
            this.cbActiveState.BackColor = System.Drawing.Color.SeaGreen;
            this.cbActiveState.Font = new System.Drawing.Font("MingLiU-ExtB", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbActiveState.Location = new System.Drawing.Point(308, 228);
            this.cbActiveState.Name = "cbActiveState";
            this.cbActiveState.Padding = new System.Windows.Forms.Padding(3);
            this.cbActiveState.Size = new System.Drawing.Size(72, 21);
            this.cbActiveState.TabIndex = 1;
            this.cbActiveState.Text = "Activo";
            this.cbActiveState.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cbActiveState.UseVisualStyleBackColor = false;
            this.cbActiveState.CheckStateChanged += new System.EventHandler(this.cbActiveState_CheckStateChanged);
            // 
            // btnActividad
            // 
            this.btnActividad.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnActividad.Image = global::OctagonHelpdesk.Properties.Resources.historial;
            this.btnActividad.Location = new System.Drawing.Point(507, 12);
            this.btnActividad.Name = "btnActividad";
            this.btnActividad.Size = new System.Drawing.Size(61, 61);
            this.btnActividad.TabIndex = 0;
            this.btnActividad.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolTip1.SetToolTip(this.btnActividad, "Auditoria");
            this.btnActividad.UseVisualStyleBackColor = false;
            this.btnActividad.Click += new System.EventHandler(this.btnActividad_Click);
            // 
            // pnlActivity
            // 
            this.pnlActivity.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.pnlActivity.Controls.Add(this.lblReactivationDate);
            this.pnlActivity.Controls.Add(this.lblDeactivationDate);
            this.pnlActivity.Controls.Add(this.lblLastUpdatedDate);
            this.pnlActivity.Controls.Add(this.lblCreationDate);
            this.pnlActivity.Controls.Add(this.label12);
            this.pnlActivity.Controls.Add(this.label11);
            this.pnlActivity.Controls.Add(this.label10);
            this.pnlActivity.Controls.Add(this.label2);
            this.pnlActivity.Location = new System.Drawing.Point(344, 60);
            this.pnlActivity.Name = "pnlActivity";
            this.pnlActivity.Size = new System.Drawing.Size(224, 266);
            this.pnlActivity.TabIndex = 8;
            // 
            // lblReactivationDate
            // 
            this.lblReactivationDate.AutoSize = true;
            this.lblReactivationDate.Font = new System.Drawing.Font("MingLiU-ExtB", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReactivationDate.Location = new System.Drawing.Point(3, 220);
            this.lblReactivationDate.Name = "lblReactivationDate";
            this.lblReactivationDate.Size = new System.Drawing.Size(47, 11);
            this.lblReactivationDate.TabIndex = 27;
            this.lblReactivationDate.Text = "label13";
            this.toolTip1.SetToolTip(this.lblReactivationDate, "Fecha de Reactivacio");
            // 
            // lblDeactivationDate
            // 
            this.lblDeactivationDate.AutoSize = true;
            this.lblDeactivationDate.Font = new System.Drawing.Font("MingLiU-ExtB", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeactivationDate.Location = new System.Drawing.Point(3, 157);
            this.lblDeactivationDate.Name = "lblDeactivationDate";
            this.lblDeactivationDate.Size = new System.Drawing.Size(47, 11);
            this.lblDeactivationDate.TabIndex = 26;
            this.lblDeactivationDate.Text = "label13";
            this.toolTip1.SetToolTip(this.lblDeactivationDate, "Fecha de Desactivacio");
            // 
            // lblLastUpdatedDate
            // 
            this.lblLastUpdatedDate.AutoSize = true;
            this.lblLastUpdatedDate.Font = new System.Drawing.Font("MingLiU-ExtB", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastUpdatedDate.Location = new System.Drawing.Point(3, 96);
            this.lblLastUpdatedDate.Name = "lblLastUpdatedDate";
            this.lblLastUpdatedDate.Size = new System.Drawing.Size(47, 11);
            this.lblLastUpdatedDate.TabIndex = 25;
            this.lblLastUpdatedDate.Text = "label13";
            this.toolTip1.SetToolTip(this.lblLastUpdatedDate, "Fecha de Ultima Modificacion");
            // 
            // lblCreationDate
            // 
            this.lblCreationDate.AutoSize = true;
            this.lblCreationDate.Font = new System.Drawing.Font("MingLiU-ExtB", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreationDate.Location = new System.Drawing.Point(3, 38);
            this.lblCreationDate.Name = "lblCreationDate";
            this.lblCreationDate.Size = new System.Drawing.Size(47, 11);
            this.lblCreationDate.TabIndex = 24;
            this.lblCreationDate.Text = "label13";
            this.toolTip1.SetToolTip(this.lblCreationDate, "Fecha de Creacion");
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("MingLiU_HKSCS-ExtB", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(3, 191);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(89, 11);
            this.label12.TabIndex = 23;
            this.label12.Text = "Reactivacion";
            this.toolTip1.SetToolTip(this.label12, "Fecha de Reactivacio");
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("MingLiU_HKSCS-ExtB", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(0, 129);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(110, 11);
            this.label11.TabIndex = 22;
            this.label11.Text = "Desactivacion: ";
            this.toolTip1.SetToolTip(this.label11, "Fecha de Desactivacion");
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("MingLiU_HKSCS-ExtB", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(3, 71);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(152, 11);
            this.label10.TabIndex = 21;
            this.label10.Text = "Ultima Modificacion: ";
            this.toolTip1.SetToolTip(this.label10, "Fecha de Ultima Modificacion");
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MingLiU_HKSCS-ExtB", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 11);
            this.label2.TabIndex = 20;
            this.label2.Text = "Creado: ";
            this.toolTip1.SetToolTip(this.label2, "Fecha de Creacion");
            // 
            // CrearUsuarioForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(624, 594);
            this.Controls.Add(this.pnlActivity);
            this.Controls.Add(this.btnActividad);
            this.Controls.Add(this.cbActiveState);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.gbUserLog);
            this.Controls.Add(this.gbDatosGenerales);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "CrearUsuarioForm";
            this.Text = "Registro de Empleado - Octagon Helpdesk";
            this.Load += new System.EventHandler(this.CrearUsuarioForm_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.gbDatosGenerales.ResumeLayout(false);
            this.gbDatosGenerales.PerformLayout();
            this.gbUserLog.ResumeLayout(false);
            this.gbUserLog.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.pnlActivity.ResumeLayout(false);
            this.pnlActivity.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.GroupBox gbDatosGenerales;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnConfirmUserCreation;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.TextBox tbEmail;
        private System.Windows.Forms.ComboBox cmbDepartamento;
        private System.Windows.Forms.CheckBox cbEmpleado;
        private System.Windows.Forms.CheckBox cbIT;
        private System.Windows.Forms.CheckBox cbAdmin;
        private System.Windows.Forms.TextBox tbLastname;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox gbUserLog;
        private System.Windows.Forms.Button btnUserLogDat;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btnDatosGenerales;
        private System.Windows.Forms.CheckBox cbActiveState;
        private System.Windows.Forms.Button btnActividad;
        private System.Windows.Forms.Panel pnlActivity;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label lblReactivationDate;
        private System.Windows.Forms.Label lblDeactivationDate;
        private System.Windows.Forms.Label lblLastUpdatedDate;
        private System.Windows.Forms.Label lblCreationDate;
        private System.Windows.Forms.Button btnGeneratePassword;
    }
}