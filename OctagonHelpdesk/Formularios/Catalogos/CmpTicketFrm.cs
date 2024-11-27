using OctagonHelpdesk.Models;
using OctagonHelpdesk.Models.Enum;
using OctagonHelpdesk.Services;
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace OctagonHelpdesk.Formularios
{
    public partial class CmpTicketFrm : Form
    {
        public event Action<Ticket> TicketCreated;
        private readonly TicketDao ticketDaoLocal;
        public Ticket ticket = new Ticket();
        public Ticket ticketSel = new Ticket();
        UserModel currentUser { get; set; }
        string sourceFilePath;
        string targetFilePath;
        string editedFilepath;
        bool preloadedticket;
        bool ticketimage_wompwomp;

        // Constructor para crear un nuevo ticket
        public CmpTicketFrm(TicketDao ticketDao, UserModel currentUser)
        {
            InitializeComponent();
            ticketDaoLocal = ticketDao;
            this.currentUser = currentUser;
            txtCreatedBy.Text = currentUser.Name;
            InitializeFormWithoutTicketData();
            

        }

        // Constructor para editar un ticket existente
        public CmpTicketFrm(TicketDao ticketService, Ticket ticketSelected, UserModel currentUser)
        {
            InitializeComponent();
            ticketDaoLocal = ticketService;
            ticketSel = ticketSelected;
            this.currentUser = currentUser;
            txtCreatedBy.Text = currentUser.Name;
           
        }
        
        

        // Inicializar el formulario para crear un nuevo ticket
        private void InitializeFormWithoutTicketData()
        {
            ticket.IDTicket = ticketDaoLocal.AutogeneradorID();
            lblTicketID.Text = $"Ticket # {ticket.IDTicket}";
            ticket.CreationDate = DateTime.Now;
            ticket.ActiveState = true;
            cmbAsigned.SelectedValue = 0;
        }

        // Inicializar el formulario para editar un ticket existente
        private void InitializeFormWithTicketData()
        {
            if (ticketSel != null)
            {
                ticket = ticketSel;

                lblTicketID.Text = $"Ticket # {ticketSel.IDTicket}";
                txtSubject.Text = ticketSel.Subject;
                txtDescription.Text = ticketSel.Descripcion;
                cmbState.SelectedItem = ticketSel.StateProcess;
                cmbPriority.SelectedItem = ticketSel.Prioridad;

                if (File.Exists(Path.Combine("data\\images", ticket.imagepath))) {
                    filepicturebox.ImageLocation = Path.Combine("data\\images", ticket.imagepath);
                    Console.WriteLine("Debug #3" + filepicturebox.ImageLocation.ToString());
                }
                else
                {
                    filelabel.Text = "File non existent";
                    ticket.imagepath = string.Empty;
                    ticketimage_wompwomp = true;
                    Console.WriteLine($"Debug #3.1: ticket with ID {ticket.IDTicket} invalid filepath, setting to empty on save");
                    

                }
                

                // Asignar el valor seleccionado después de que el ComboBox esté cargado
                cmbAsigned.SelectedValue = ticketSel.AsignadoA;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool ticketValid = false;
            string subject = txtSubject.Text;
            string description = txtDescription.Text;

            ticketValid = ValidarDatos();

            try
            {
                if (ticketValid)
                {
                    ticket.CreatedBy = currentUser.IDUser;
                    ticket.Subject = subject;
                    ticket.Descripcion = description;
                    ticket.StateProcess = cmbState.SelectedItem != null ? (State)cmbState.SelectedItem : State.Creado;
                    ticket.Prioridad = (Priority)cmbPriority.SelectedItem;
                    ticket.AsignadoA = (int)cmbAsigned.SelectedValue;

                    if (ticket.StateProcess == State.Cerrado)
                    {
                        ticket.CloseDate = DateTime.Now;
                    }

                    TicketCreated?.Invoke(ticket);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Revise el Formato de los Datos Ingresados", "¡Cuidado!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar el ticket"+ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public bool ValidarDatos()
        {
            if (string.IsNullOrEmpty(txtSubject.Text) || string.IsNullOrEmpty(txtDescription.Text) || cmbState.SelectedIndex == -1 || cmbPriority.SelectedIndex == -1)
            {
                return false;
            }
            return true;
        }

        private void LoadComboBox()
        {
            UsuarioDao usuarios = new UsuarioDao();
            var filteredUsers = usuarios.GetUsuarios()
                .Where(u => u.Roles.ITPerms == true || u.Roles.AdminPerms == true)
                .Select(u => new { u.IDUser, u.Username })
                .ToList();
            filteredUsers.Insert(0, new { IDUser = 0, Username = "No Asignado" });

            cmbAsigned.DataSource = filteredUsers;
            cmbAsigned.DisplayMember = "Username";
            cmbAsigned.ValueMember = "IDUser";
        }

        private void CmpTicketFrm_Load(object sender, EventArgs e)
        {
            cmbState.Items.Clear();
            cmbState.SelectedIndex = -1;
            cmbState.DataSource = Enum.GetValues(typeof(State));

            cmbPriority.Items.Clear();
            cmbPriority.SelectedIndex = -1;
            cmbPriority.DataSource = Enum.GetValues(typeof(Priority));

            LoadComboBox();

            // Inicializar el formulario con los datos del ticket seleccionado
            if (ticketSel != null && ticketSel.IDTicket != 0)
            {
                InitializeFormWithTicketData();
                preloadedticket = true;
            }
            else
            {
                InitializeFormWithoutTicketData();
                preloadedticket= false;
            }
        }

        private void txtCreatedBy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtSubject.Focus();
            }
        }

        private void txtSubject_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtDescription.Focus();
            }
        }

        private void txtDescription_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                cmbPriority.Focus();
            }
        }

        private void cmbPriority_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                cmbState.Focus();
            }
        }

        private void cmbState_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                cmbAsigned.Focus();
            }
        }

        private void cmbAsigned_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnSave.Focus();
            }
        }

        private void btnAttachments_Click(object sender, EventArgs e)
        {
            string fileName;
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Select a file";
                openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png, *.bmp)|*.jpg;*.jpeg;*.png;*.bmp|All files (*.*)|*.*";

                string globalpath = AppDomain.CurrentDomain.BaseDirectory;
                string localpath = Path.Combine(globalpath, @"..\..\Data");
                string targetDirectory = @"images";
                targetDirectory = Path.Combine(localpath, targetDirectory);

                targetDirectory = @"data\images";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    sourceFilePath = openFileDialog.FileName;

                    fileName = Path.GetFileName(sourceFilePath).Replace(" ", "");
                    targetFilePath = Path.Combine(targetDirectory, fileName);

                    filelabel.Text = "Path: " + openFileDialog.FileName;
                    Console.WriteLine("Debug #02: " + targetDirectory);
                    filepicturebox.ImageLocation = sourceFilePath;

                    if(preloadedticket)
                    {
                        if (fileName != ticket.imagepath && fileName != string.Empty)
                        {
                            ticket.imagepath = fileName;
                            File.Copy(sourceFilePath, targetFilePath, true);
                        }
                        
                    } else
                    {
                        ticket.imagepath = fileName;
                        File.Copy(sourceFilePath, targetFilePath, true);
                    }

                }
            }

          
        }

        private void fileUpload()
        {
            
        }
    }
}
