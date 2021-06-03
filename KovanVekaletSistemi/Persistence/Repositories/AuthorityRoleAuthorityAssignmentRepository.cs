using KovanVekaletSistemi.Core.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovanVekaletSistemi.Persistence.Repositories
{
    public class AuthorityRoleAuthorityAssignmentRepository:Repository<AuthorityRoleAuthorityAssignment>
    {
        public ICollection<AuthorityRole> GetAuthorityRolesByAssigment(AuthorityAssignment authorityAssignment)
        {
            List<AuthorityRole> authorityRoles = new List<AuthorityRole>();
            string[] parameters = { "AuthorityAssignment", "AuthorityRole" };
            var listOfJobTitleAuthorityRole = Find(t => t.AuthorityAssignment_Id==authorityAssignment.Id, parameters).ToList<AuthorityRoleAuthorityAssignment>();

            foreach (AuthorityRoleAuthorityAssignment item in listOfJobTitleAuthorityRole)
            {
                authorityRoles.Add(item.AuthorityRole);
            }

            return authorityRoles;
        }
    }
}
