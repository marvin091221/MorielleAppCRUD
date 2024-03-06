using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace EstellaAppCRUD
{
    // Inhirit class RoleProvider
    public class MyRole : RoleProvider
    {
        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            using (var db = new IMDBsys32Entities())
            {
                //since array return
                // equivalent
                // Select roleName from vw_UserRole
                return db.vw_UserRole.Select(m => m.roleName).ToArray();
            }
        }

        public override string[] GetRolesForUser(string username)
        {
            using (var db = new IMDBsys32Entities())
            {
                // same as
                // Select roleName WHERE userName = userName
                //
                return db.vw_UserRole.Where(m => m.userName == username).Select(m => m.roleName).ToArray();
            }
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}