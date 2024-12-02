namespace OctagonHelpdesk.Formularios
{
    partial class CmpTicketFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CmpTicketFrm));
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCreatedBy = new System.Windows.Forms.TextBox();
            this.txtSubject = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.cmbState = new System.Windows.Forms.ComboBox();
            this.cmbAsigned = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.filelabel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.filepicturebox = new System.Windows.Forms.PictureBox();
            this.btnAttachments = new System.Windows.Forms.Button();
            this.cmbPriority = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lblTicketID = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.filepicturebox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MingLiU_HKSCS-ExtB", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(46, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Creado por:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MingLiU_HKSCS-ExtB", 9F);
            this.label1.Location = new System.Drawing.Point(51, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "Asunto:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("MingLiU_HKSCS-ExtB", 9F);
            this.label3.Location = new System.Drawing.Point(46, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 18);
            this.label3.TabIndex = 3;
            this.label3.Text = "Descripción:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("MingLiU_HKSCS-ExtB", 9F);
            this.label4.Location = new System.Drawing.Point(51, 291);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 18);
            this.label4.TabIndex = 4;
            this.label4.Text = "Estado:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("MingLiU_HKSCS-ExtB", 9F);
            this.label5.Location = new System.Drawing.Point(51, 344);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 18);
            this.label5.TabIndex = 5;
            this.label5.Text = "Asignado a:";
            // 
            // txtCreatedBy
            // 
            this.txtCreatedBy.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtCreatedBy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCreatedBy.Location = new System.Drawing.Point(198, 38);
            this.txtCreatedBy.Name = "txtCreatedBy";
            this.txtCreatedBy.Size = new System.Drawing.Size(363, 29);
            this.txtCreatedBy.TabIndex = 0;
            this.txtCreatedBy.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCreatedBy_KeyPress);
            // 
            // txtSubject
            // 
            this.txtSubject.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtSubject.Location = new System.Drawing.Point(198, 84);
            this.txtSubject.MaxLength = 60;
            this.txtSubject.Name = "txtSubject";
            this.txtSubject.Size = new System.Drawing.Size(363, 29);
            this.txtSubject.TabIndex = 1;
            this.txtSubject.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSubject_KeyPress);
            // 
            // txtDescription
            // 
            this.txtDescription.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtDescription.Location = new System.Drawing.Point(198, 126);
            this.txtDescription.MaxLength = 200;
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescription.Size = new System.Drawing.Size(363, 79);
            this.txtDescription.TabIndex = 2;
            this.txtDescription.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDescription_KeyPress);
            // 
            // cmbState
            // 
            this.cmbState.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.cmbState.FormattingEnabled = true;
            this.cmbState.Location = new System.Drawing.Point(198, 289);
            this.cmbState.Name = "cmbState";
            this.cmbState.Size = new System.Drawing.Size(363, 29);
            this.cmbState.TabIndex = 4;
            this.cmbState.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbState_KeyPress);
            // 
            // cmbAsigned
            // 
            this.cmbAsigned.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.cmbAsigned.ForeColor = System.Drawing.Color.Black;
            this.cmbAsigned.FormattingEnabled = true;
            this.cmbAsigned.Location = new System.Drawing.Point(198, 341);
            this.cmbAsigned.Name = "cmbAsigned";
            this.cmbAsigned.Size = new System.Drawing.Size(363, 29);
            this.cmbAsigned.TabIndex = 5;
            this.cmbAsigned.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbAsigned_KeyPress);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnSave.Font = new System.Drawing.Font("MingLiU_HKSCS-ExtB", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(18, 444);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(146, 54);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Guardar";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel1.Controls.Add(this.filelabel);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.filepicturebox);
            this.panel1.Controls.Add(this.btnAttachments);
            this.panel1.Controls.Add(this.cmbPriority);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.txtCreatedBy);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cmbAsigned);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cmbState);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtDescription);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtSubject);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Location = new System.Drawing.Point(167, 54);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(592, 651);
            this.panel1.TabIndex = 14;
            // 
            // filelabel
            // 
            this.filelabel.AutoSize = true;
            this.filelabel.Location = new System.Drawing.Point(164, 424);
            this.filelabel.Name = "filelabel";
            this.filelabel.Size = new System.Drawing.Size(0, 21);
            this.filelabel.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(164, 373);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 21);
            this.label6.TabIndex = 16;
            this.label6.Text = "Path:";
            // 
            // filepicturebox
            // 
            this.filepicturebox.Location = new System.Drawing.Point(189, 397);
            this.filepicturebox.Name = "filepicturebox";
            this.filepicturebox.Size = new System.Drawing.Size(284, 194);
            this.filepicturebox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.filepicturebox.TabIndex = 15;
            this.filepicturebox.TabStop = false;
            // 
            // btnAttachments
            // 
            this.btnAttachments.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnAttachments.Image = global::OctagonHelpdesk.Properties.Resources.adjuntar_archivo;
            this.btnAttachments.Location = new System.Drawing.Point(48, 392);
            this.btnAttachments.Name = "btnAttachments";
            this.btnAttachments.Size = new System.Drawing.Size(55, 46);
            this.btnAttachments.TabIndex = 6;
            this.btnAttachments.UseVisualStyleBackColor = false;
            this.btnAttachments.Click += new System.EventHandler(this.btnAttachments_Click);
            // 
            // cmbPriority
            // 
            this.cmbPriority.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.cmbPriority.FormattingEnabled = true;
            this.cmbPriority.Location = new System.Drawing.Point(198, 230);
            this.cmbPriority.Name = "cmbPriority";
            this.cmbPriority.Size = new System.Drawing.Size(363, 29);
            this.cmbPriority.TabIndex = 3;
            this.cmbPriority.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbPriority_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("MingLiU_HKSCS-ExtB", 9F);
            this.label7.Location = new System.Drawing.Point(51, 232);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(98, 18);
            this.label7.TabIndex = 14;
            this.label7.Text = "Prioridad:";
            // 
            // lblTicketID
            // 
            this.lblTicketID.AutoSize = true;
            this.lblTicketID.BackColor = System.Drawing.Color.Transparent;
            this.lblTicketID.Font = new System.Drawing.Font("MingLiU_HKSCS-ExtB", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTicketID.Location = new System.Drawing.Point(207, 9);
            this.lblTicketID.Name = "lblTicketID";
            this.lblTicketID.Size = new System.Drawing.Size(235, 32);
            this.lblTicketID.TabIndex = 16;
            this.lblTicketID.Text = "Crear Ticket:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Image = global::OctagonHelpdesk.Properties.Resources.wavebckg;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(132, 711);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 17;
            this.pictureBox1.TabStop = false;
            // 
            // CmpTicketFrm
            // 
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(783, 711);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblTicketID);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CmpTicketFrm";
            this.Text = "Ticket";
            this.Load += new System.EventHandler(this.CmpTicketFrm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.filepicturebox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCreatedBy;
        private System.Windows.Forms.TextBox txtSubject;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.ComboBox cmbState;
        private System.Windows.Forms.ComboBox cmbAsigned;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTicketID;
        private System.Windows.Forms.ComboBox cmbPriority;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnAttachments;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label filelabel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox filepicturebox;
    }
}