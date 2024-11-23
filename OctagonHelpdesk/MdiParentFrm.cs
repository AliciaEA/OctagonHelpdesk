using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OctagonHelpdesk.Formularios;
using OctagonHelpdesk.Models;


namespace OctagonHelpdesk
{
    public partial class MdiParentFrm : Form
    {
        //SIDE BAR ANIMATION
        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);
        private const int WM_SETREDRAW = 0x000B;
        private bool isExpanded = true; // Indica si el sidebar está expandido
        private int sidebarWidthExpanded = 150; // Ancho expandido
        private int sidebarWidthCollapsed = 50;  // Ancho colapsado
        private int animationStep = 5; // Velocidad de la animación



        UserModel currentUser { get; set; }

        public MdiParentFrm()
        {
            InitializeComponent();
            animationTimer.Interval = 15; // Velocidad de refresco (15 ms)
            timer1.Interval = 1000; // 1 segundo
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Start();
            UpdateTime();
        }

        //Archivo, Salir
        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //Formulario Login
        private void On_Load(object sender, EventArgs e)
        {
            using (LoginFrm loginForm = new LoginFrm())
            {
                if (loginForm.ShowDialog(this) == DialogResult.OK)
                {
                    currentUser = loginForm.CurrentUser;
                    // Aquí puedes agregar lógica adicional para manejar el usuario logueado
                    Home home = Application.OpenForms.OfType<Home>().FirstOrDefault();
                    /*busca si ya existe una instancia de RegTicketFrm abierta. Si encuentra una, la asigna a regTicketFrm.*/

                    if (home != null)
                    {
                        // Si el formulario ya está abierto, lo trae al frente y lo maximiza
                        home.WindowState = FormWindowState.Maximized;
                        home.BringToFront();
                    }
                    else
                    {
                        // Si el formulario no está abierto, crea una nueva instancia
                        home = new Home(currentUser);
                        home.MdiParent = this;
                        home.WindowState = FormWindowState.Minimized; // Minimiza el formulario inmediatamente
                        home.Show();
                        home.WindowState = FormWindowState.Maximized; // Luego lo maximiza
                    }
                }
                else
                {
                    this.Close();
                }
            }
        }

        //****Formulario Home****
        private void btnHome_Click(object sender, EventArgs e)
        {
            Home home = Application.OpenForms.OfType<Home>().FirstOrDefault();
            /*busca si ya existe una instancia de RegTicketFrm abierta. Si encuentra una, la asigna a regTicketFrm.*/

            if (home != null)
            {
                // Si el formulario ya está abierto, lo trae al frente y lo maximiza
                home.WindowState = FormWindowState.Maximized;
                home.BringToFront();
            }
            else
            {
                // Si el formulario no está abierto, crea una nueva instancia
                home = new Home(currentUser);
                home.MdiParent = this;
                home.WindowState = FormWindowState.Minimized; // Minimiza el formulario inmediatamente
                home.Show();
                home.WindowState = FormWindowState.Maximized; // Luego lo maximiza
            }
        }


        //****Formulario Registro de Tickets****
        private void btnRegTickets_Click(object sender, EventArgs e)
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
                regTicketFrm = new RegTicketFrm(currentUser);
                regTicketFrm.MdiParent = this;
                regTicketFrm.WindowState = FormWindowState.Minimized; // Minimiza el formulario inmediatamente
                regTicketFrm.Show();
                regTicketFrm.WindowState = FormWindowState.Maximized; // Luego lo maximiza
            }
        }


        //****Formulario Registro de Usuarios****
        private void btnRegUsuarios_Click(object sender, EventArgs e)
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
                regEmpleadosFrm = new RegEmpleadosFrm(currentUser);
                regEmpleadosFrm.MdiParent = this;
                regEmpleadosFrm.WindowState = FormWindowState.Minimized; // Minimiza el formulario inmediatamente
                regEmpleadosFrm.Show();
                regEmpleadosFrm.WindowState = FormWindowState.Maximized; // Luego lo maximiza
            }

        }

       

        //Test
        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frame frame = new Frame();
            frame.Show();
        }

        //****DISPLAY HOUR****


        private void UpdateTime()
        {
            lblHora.Text = DateTime.Now.ToString("HH:mm");
        }

        //****SIDE BAR ANIMATION****
        private void ToggleSidebar(object sender, EventArgs e)
        {
            // Evita activar la animación si ya está en curso
            if (animationTimer.Enabled) return;

            // Ajusta el estado inicial para evitar el clic extra
            if (sidebar.Width == sidebarWidthExpanded)
            {
                isExpanded = true; // Si el ancho es igual al expandido, la barra está expandida
            }
            else if (sidebar.Width == sidebarWidthCollapsed)
            {
                isExpanded = false; // Si el ancho es igual al colapsado, la barra está colapsada
            }

            // Deshabilitar el redibujado mientras la animación ocurre
            SendMessage(this.Handle, WM_SETREDRAW, 0, 0);  // Desactivar redibujado

            animationTimer.Start(); // Iniciar animación
        }

        private void AnimateSidebar(object sender, EventArgs e)
        {
            if (isExpanded)
            {
                sidebar.Width -= animationStep;
                if (sidebar.Width <= sidebarWidthCollapsed)
                {
                    sidebar.Width = sidebarWidthCollapsed;
                    isExpanded = false;
                    btnRegTickets.Text = "";
                    btnMenu.Text = "";
                    btnRegUsuarios.Text = "";

                    // Ajustar el ancho de los botones
                    btnRegTickets.Width = sidebarWidthCollapsed;
                    btnMenu.Width = sidebarWidthCollapsed;
                    btnRegUsuarios.Width = sidebarWidthCollapsed;

                    animationTimer.Stop();

                    // Reactiva el redibujado al finalizar la animación
                    SendMessage(this.Handle, WM_SETREDRAW, 1, 0);
                    this.Refresh(); // Forzar redibujado
                }
            }
            else
            {
                sidebar.Width += animationStep;
                if (sidebar.Width >= sidebarWidthExpanded)
                {
                    sidebar.Width = sidebarWidthExpanded;
                    isExpanded = true;
                    btnRegTickets.Text = "Tickets";
                    btnMenu.Text = "Menu";
                    btnRegUsuarios.Text = "Usuarios";

                    // Ajustar el ancho de los botones
                    btnRegTickets.Width = sidebarWidthExpanded;
                    btnRegUsuarios.Width = sidebarWidthExpanded;


                    btnMenu.Width = sidebarWidthExpanded;

                    animationTimer.Stop();

                    // Reactiva el redibujado al finalizar la animación
                    SendMessage(this.Handle, WM_SETREDRAW, 1, 0);
                    this.Refresh(); // Forzar redibujado
                }
            }
        }


        private void btnMenu_Click(object sender, EventArgs e)
        {
            ToggleSidebar(sender, e);
        }

        private void animationTimer_Tick(object sender, EventArgs e)
        {
            AnimateSidebar(sender, e);
        }

        //****HOVER EFFECTS****
        private void btnRegTickets_MouseHover(object sender, EventArgs e)
        {
            btnRegTickets.BackColor = Color.FromArgb(0, 122, 204);

        }

        private void btnMenu_MouseHover(object sender, EventArgs e)
        {
            btnMenu.BackColor = Color.FromArgb(0, 122, 204);
        }

        private void btnRegUsuarios_MouseHover(object sender, EventArgs e)
        {
            btnRegUsuarios.BackColor = Color.FromArgb(0, 122, 204);
        }


        private void timer1_Tick(object sender, EventArgs e)
        {

            UpdateTime();
        }

       
    }
}

