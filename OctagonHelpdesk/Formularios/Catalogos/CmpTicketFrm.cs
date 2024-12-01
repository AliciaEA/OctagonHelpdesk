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

        public Ticket ticket = new Ticket();

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
            ShareLoad(currentUser);
            InitializeFormWithoutTicketData(ticketDao);
        }

        // Constructor para editar un ticket existente
        public CmpTicketFrm(Ticket ticketSelected, UserModel currentUser)
        {
            InitializeComponent();
            ShareLoad(currentUser);
            InitializeFormWithTicketData(ticketSelected);
        }

        public void ShareLoad(UserModel usuario)
        {
            currentUser = usuario;
            txtCreatedBy.Text = currentUser.Name;

            cmbState.Items.Clear();
            cmbState.SelectedIndex = -1;
            cmbState.DataSource = Enum.GetValues(typeof(State));

            cmbPriority.Items.Clear();
            cmbPriority.SelectedIndex = -1;
            cmbPriority.DataSource = Enum.GetValues(typeof(Priority));

            LoadComboBox();
        }


        // Inicializar el formulario para crear un nuevo ticket
        private void InitializeFormWithoutTicketData(TicketDao ticketDaoLocal)
        {
            ticket.IDTicket = ticketDaoLocal.AutogeneradorID();
            lblTicketID.Text = $"Ticket # {ticket.IDTicket}";
            ticket.CreationDate = DateTime.Now;
            ticket.ActiveState = true;
            cmbAsigned.SelectedValue = 0;
        }

        // Inicializar el formulario para editar un ticket existente
        private void InitializeFormWithTicketData(Ticket ticketSel)
        {
            ticket = ticketSel;

            lblTicketID.Text = $"Ticket # {ticketSel.IDTicket}";
            txtSubject.Text = ticketSel.Subject;
            txtDescription.Text = ticketSel.Descripcion;
            cmbState.SelectedItem = ticketSel.StateProcess;
            cmbPriority.SelectedItem = ticketSel.Prioridad;

            // Ruta relativa a la carpeta "Data/images" fuera del directorio bin
            string globalpath = AppDomain.CurrentDomain.BaseDirectory;
            string localpath = Path.Combine(globalpath, @"..\..\Data");
            string targetDirectory = Path.Combine(localpath, "images");

            if (!string.IsNullOrEmpty(ticket.imagepath) && File.Exists(Path.Combine(targetDirectory, ticket.imagepath)))
            {
                filepicturebox.ImageLocation = Path.Combine(targetDirectory, ticket.imagepath);
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
            cmbAsigned.SelectedValue = ticketSel.AsignadoA is null ? 0:ticket.AsignadoA ;

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

                    var selectedValue = cmbAsigned.SelectedValue;
                    if (selectedValue is null || (int)selectedValue == 0)
                    {
                        ticket.AsignadoA = null;
                    }
                    else
                    {
                        ticket.AsignadoA = (int)selectedValue;
                    }




                    if (ticket.StateProcess == State.Cerrado)
                    {
                        ticket.CloseDate = DateTime.Now;
                    }

                    // Verificar si se ha seleccionado una imagen
                    if (string.IsNullOrEmpty(ticket.imagepath))
                    {
                        ticket.imagepath = null;
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
                MessageBox.Show("Error al guardar el ticket" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
           

            cmbAsigned.DataSource = filteredUsers;
            cmbAsigned.DisplayMember = "Username";
            cmbAsigned.ValueMember = "IDUser";
        }

        private void CmpTicketFrm_Load(object sender, EventArgs e)
        {
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
                openFileDialog.Filter = "Image files (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp|All files (*.*)|*.*";

                // Ruta relativa a la carpeta "Data/images" fuera del directorio bin
                string globalpath = AppDomain.CurrentDomain.BaseDirectory;
                string localpath = Path.Combine(globalpath, @"..\..\Data");
                string targetDirectory = Path.Combine(localpath, "images");

                if (!Directory.Exists(targetDirectory))
                {
                    Directory.CreateDirectory(targetDirectory);
                }

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        sourceFilePath = openFileDialog.FileName;
                        fileName = Path.GetFileName(sourceFilePath).Replace(" ", "");
                        targetFilePath = Path.Combine(targetDirectory, fileName);

                        // Verificar la extensión del archivo
                        string fileExtension = Path.GetExtension(sourceFilePath).ToLower();
                        if (fileExtension != ".jpg" && fileExtension != ".jpeg" && fileExtension != ".png" && fileExtension != ".bmp")
                        {
                            MessageBox.Show("Tipo de archivo no permitido. Por favor, seleccione una imagen con extensión .jpg, .jpeg, .png o .bmp.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        filelabel.Text = "Path: " + openFileDialog.FileName;
                        filepicturebox.ImageLocation = sourceFilePath;

                        if (preloadedticket)
                        {
                            if (fileName != ticket.imagepath && !string.IsNullOrEmpty(fileName))
                            {
                                ticket.imagepath = fileName;
                                File.Copy(sourceFilePath, targetFilePath, true);
                            }
                        }
                        else
                        {
                            ticket.imagepath = fileName;
                            File.Copy(sourceFilePath, targetFilePath, true);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al copiar el archivo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void fileUpload()
        {

        }
    }
}
