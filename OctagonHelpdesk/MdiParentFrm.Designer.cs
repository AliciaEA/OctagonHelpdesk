namespace OctagonHelpdesk
{
    partial class MdiParentFrm
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MdiParentFrm));
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.animationTimer = new System.Windows.Forms.Timer(this.components);
            this.sidebar = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.btnMenu = new System.Windows.Forms.ToolStripButton();
            this.btnRegTickets = new System.Windows.Forms.ToolStripButton();
            this.btnRegUsuarios = new System.Windows.Forms.ToolStripButton();
            this.statusStrip.SuspendLayout();
            this.sidebar.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 603);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Padding = new System.Windows.Forms.Padding(2, 0, 21, 0);
            this.statusStrip.Size = new System.Drawing.Size(855, 32);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "StatusStrip";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(66, 25);
            this.toolStripStatusLabel.Text = "Estado";
            // 
            // animationTimer
            // 
            this.animationTimer.Tick += new System.EventHandler(this.animationTimer_Tick);
            // 
            // sidebar
            // 
            this.sidebar.AutoSize = false;
            this.sidebar.BackColor = System.Drawing.SystemColors.HotTrack;
            this.sidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.sidebar.Font = new System.Drawing.Font("MingLiU-ExtB", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sidebar.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.sidebar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.btnMenu,
            this.btnRegTickets,
            this.btnRegUsuarios});
            this.sidebar.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.sidebar.Location = new System.Drawing.Point(0, 0);
            this.sidebar.Name = "sidebar";
            this.sidebar.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.sidebar.Size = new System.Drawing.Size(75, 603);
            this.sidebar.TabIndex = 4;
            this.sidebar.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(71, 4);
            this.toolStripButton1.Text = "toolStripButton1";
            // 
            // btnMenu
            // 
            this.btnMenu.AutoSize = false;
            this.btnMenu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnMenu.Image = global::OctagonHelpdesk.Properties.Resources.menu_1_;
            this.btnMenu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Size = new System.Drawing.Size(63, 40);
            this.btnMenu.Text = "toolStripButton2";
            this.btnMenu.ToolTipText = "Menu";
            this.btnMenu.Click += new System.EventHandler(this.btnMenu_Click);
            this.btnMenu.MouseHover += new System.EventHandler(this.btnMenu_MouseHover);
            // 
            // btnRegTickets
            // 
            this.btnRegTickets.AutoSize = false;
            this.btnRegTickets.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnRegTickets.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnRegTickets.Image = global::OctagonHelpdesk.Properties.Resources.boleto;
            this.btnRegTickets.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRegTickets.Name = "btnRegTickets";
            this.btnRegTickets.Size = new System.Drawing.Size(63, 40);
            this.btnRegTickets.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRegTickets.ToolTipText = "Registro de Tickets";
            this.btnRegTickets.Click += new System.EventHandler(this.btnRegTickets_Click);
            this.btnRegTickets.MouseHover += new System.EventHandler(this.btnRegTickets_MouseHover);
            // 
            // btnRegUsuarios
            // 
            this.btnRegUsuarios.AutoSize = false;
            this.btnRegUsuarios.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnRegUsuarios.Image = global::OctagonHelpdesk.Properties.Resources.usuariosNoFocus;
            this.btnRegUsuarios.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRegUsuarios.Name = "btnRegUsuarios";
            this.btnRegUsuarios.Size = new System.Drawing.Size(63, 40);
            this.btnRegUsuarios.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRegUsuarios.ToolTipText = "Registro de Usuarios";
            this.btnRegUsuarios.Click += new System.EventHandler(this.btnRegUsuarios_Click);
            this.btnRegUsuarios.MouseHover += new System.EventHandler(this.btnRegUsuarios_MouseHover);
            // 
            // MdiParentFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(855, 635);
            this.Controls.Add(this.sidebar);
            this.Controls.Add(this.statusStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximumSize = new System.Drawing.Size(2866, 1622);
            this.Name = "MdiParentFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Octagon Helpdesk";
            this.Load += new System.EventHandler(this.On_Load);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.sidebar.ResumeLayout(false);
            this.sidebar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ToolStrip sidebar;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton btnMenu;
        private System.Windows.Forms.Timer animationTimer;
        private System.Windows.Forms.ToolStripButton btnRegTickets;
        private System.Windows.Forms.ToolStripButton btnRegUsuarios;
    }
}



