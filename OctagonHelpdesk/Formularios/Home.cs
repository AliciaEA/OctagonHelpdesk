using OctagonHelpdesk.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OctagonHelpdesk.Formularios
{
    public partial class Home : Form
    {
        public UserModel currentUser;
        public Home(UserModel currentUser)
        {
            InitializeComponent();
            this.currentUser = currentUser;
            timer1.Interval = 1000; // 1 segundo
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Start();
            UpdateGreeting();
            UpdateDate();

        }
        private void UpdateGreeting()
        {
            string greeting;
            int hour = DateTime.Now.Hour;

            if (hour < 12)
            {
                greeting = "Buenos días, " + currentUser.Name;
            }
            else if (hour < 18)
            {
                greeting = "Buenas tardes, " + currentUser.Name;
            }
            else
            {
                greeting = "Buenas noches, " + currentUser.Name;
            }

            lblGreeting.Text = greeting; 
        }
        public void UpdateDate()
        {
            lblDate.Text = DateTime.Now.ToLongDateString();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            UpdateGreeting();

        }

        private void updatesUserInfo3_Load(object sender, EventArgs e)
        {

        }

        private void updatesUserInfo2_Load(object sender, EventArgs e)
        {

        }

        private void updatesUserInfo1_Load(object sender, EventArgs e)
        {

        }
    }
}
