﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OctagonHelpdesk.Formularios;
using OctagonHelpdesk.Models;

namespace OctagonHelpdesk
{
    public partial class MdiParentFrm : Form
    {
        private int childFormNumber = 0;
        UserModel currentuser { get;set; }
        public MdiParentFrm()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Ventana " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void On_Load(object sender, EventArgs e)
        {
            using (LoginFrm loginForm = new LoginFrm())
            {
                if (!(loginForm.ShowDialog(this) == DialogResult.OK))
                {
                    this.Close();
                }

                currentuser = loginForm.CurrentUser;
                
            }
        }

        
        

        private void ticketToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegTicketFrm regTicketFrm = Application.OpenForms.OfType<RegTicketFrm>().FirstOrDefault();
            /*busca si ya existe una instancia de RegTicketFrm abierta. Si encuentra una, la asigna a regTicketFrm.*/

            if (regTicketFrm != null)
            {
                // Si el formulario ya está abierto, lo trae al frente y lo maximiza
                regTicketFrm.WindowState = FormWindowState.Maximized;
                regTicketFrm.BringToFront();
            }
            else
            {
                // Si el formulario no está abierto, crea una nueva instancia
                regTicketFrm = new RegTicketFrm();
                regTicketFrm.MdiParent = this;
                regTicketFrm.WindowState = FormWindowState.Minimized; // Minimiza el formulario inmediatamente
                regTicketFrm.Show();
                regTicketFrm.WindowState = FormWindowState.Maximized; // Luego lo maximiza
            }

        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {

            // Verifica si el formulario ya está abierto
            RegEmpleadosFrm regEmpleadosFrm = Application.OpenForms.OfType<RegEmpleadosFrm>().FirstOrDefault();

            if (regEmpleadosFrm != null)
            {
                // Si el formulario ya está abierto, lo trae al frente y lo maximiza
                regEmpleadosFrm.WindowState = FormWindowState.Maximized;
                regEmpleadosFrm.BringToFront();
            }
            else
            {
                // Si el formulario no está abierto, crea una nueva instancia
                regEmpleadosFrm = new RegEmpleadosFrm();
                regEmpleadosFrm.MdiParent = this;
                regEmpleadosFrm.WindowState = FormWindowState.Minimized; // Minimiza el formulario inmediatamente
                regEmpleadosFrm.Show();
                regEmpleadosFrm.WindowState = FormWindowState.Maximized; // Luego lo maximiza
            }
        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frame frame = new Frame();
            frame.Show();
        }

        

        
    }
}
