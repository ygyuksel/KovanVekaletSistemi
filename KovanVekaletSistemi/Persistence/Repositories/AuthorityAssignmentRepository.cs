using KovanVekaletSistemi.Core.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace KovanVekaletSistemi.Persistence.Repositories
{
    public class AuthorityAssignmentRepository : Repository<AuthorityAssignment>
    {
        /// <summary>
        /// Kullanıcıya ait mevcut bir yetki ataması yapılmış ise getiriyor
        /// </summary>
        /// <param name="userName">Kullanıcı adı</param>
        /// <returns>Kullanıcıya ait güncel yetki atamaları</returns>
        public List<AuthorityAssignment> GetAuthorityAssignmentsByUserName(string userName)
        {
            string[] parameters = { "AssignmentTo", "AssignmentFrom", "AuthorityRoleAuthorityAssignments" };

            return Find(t => t.AssignmentTo.UserName == userName & t.StartDate<=DateTime.Now & t.EndDate>=DateTime.Now, parameters).ToList<AuthorityAssignment>();
        }
    }
}
