using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OctagonHelpdesk.Models;

namespace OctagonHelpdesk.Services
{
    internal class UserRolesService 
    {
        public void AssignPerms(UserModel currentUser, UserModel targetUser,Role assignedRoles)
        {
            // Mario: To do, Retrieve Target User from whatever we use to mass store stuff
            if (currentUser.Roles.AdminPerms)
            {
                targetUser.Roles.ITPerms = assignedRoles.ITPerms;
                targetUser.Roles.BasicPerms = assignedRoles.BasicPerms;
            }
        }


        public void RetrieveRoles(UserModel currentUser)
        {

            // Mario: To do, Retrieve Target User from whatever we use to mass store stuff
            Role assignedRoles = new Role();

            currentUser.Roles.BasicPerms = assignedRoles.BasicPerms;
            currentUser.Roles.ITPerms = assignedRoles.ITPerms;
           
        }

        //Mario: To Do, Enable Admins to create other admins
        private void AdminSetter(UserModel CurrentUser, Role AssignedRole, string AdminPasskey)
        {
            string secretkey = "admin"; 
            if (CurrentUser.Roles.AdminPerms && AdminPasskey == secretkey)
            {
                //To do Implement Admin creation logic -Mario
            }
        }
    }
}
