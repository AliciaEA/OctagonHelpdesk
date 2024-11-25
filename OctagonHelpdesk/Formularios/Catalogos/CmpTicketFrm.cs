using OctagonHelpdesk.Models;
using OctagonHelpdesk.Models.Enum;
using OctagonHelpdesk.Services;
using System;
using System.Linq;
using System.IO;
using System.Windows.Forms;

namespace OctagonHelpdesk.Formularios
{
    public partial class CmpTicketFrm : Form
    {
        public event Action<Ticket> TicketCreated;
        private readonly TicketDao ticketDaoLocal;
        UserModel currentUser { get; set; }
        public Ticket ticket = new Ticket();
        public Ticket ticketSel = new Ticket();



        // Constructor para crear un nuevo ticket
        public CmpTicketFrm(TicketDao ticketDao, UserModel currentUser)
        {
            InitializeComponent();
            ticketDaoLocal = ticketDao;
            InitializeFormWithoutTicketData();
            this.currentUser = currentUser;
            txtCreatedBy.Text = currentUser.Name;
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

                    File.Copy(sourceFilePath, targetFilePath, true);
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
                MessageBox.Show($"Error al guardar el ticket: {ex.ToString()}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (ticketSel != null)
            {
                InitializeFormWithTicketData();
            }
        }


        string sourceFilePath;
        string targetFilePath;
        private void btnAttachments_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Select a file";
                openFileDialog.Filter = "All files (*.*)|*.*";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    sourceFilePath = openFileDialog.FileName;
                    string targetDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "data", "images");

                    // Ensure the target directory exists
                    if (!Directory.Exists(targetDirectory))
                    {
                        Directory.CreateDirectory(targetDirectory);
                    }

                    // Get the file name and trim spaces
                    string fileName = Path.GetFileName(sourceFilePath).Replace(" ", "");

                    // Combine the target directory and the trimmed file name
                    targetFilePath = Path.Combine(targetDirectory, fileName);
                    
                   

                    // Store the trimmed path
                    filelabel.Text = targetFilePath;
                    Console.WriteLine("New Filepath: ");
                    filepicturebox.ImageLocation = targetFilePath;
                }
            }
        }
    }
}
