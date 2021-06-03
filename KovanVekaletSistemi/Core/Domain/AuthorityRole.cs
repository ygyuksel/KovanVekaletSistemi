using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovanVekaletSistemi.Core.Domain
{
    public class AuthorityRole:BaseDomainClass
    {
        public AuthorityRole()
        {
            //this.JobTitles = new HashSet<JobTitle>();
            //this.AuthorityAssignments = new HashSet<AuthorityAssignment>();
        }
        public virtual ICollection<JobTitleAuthorityRole> JobTitleAuthorityRoles { get; set; }
        public virtual ICollection<AuthorityRoleAuthorityAssignment> AuthorityRoleAuthorityAssignments { get; set; }
    }
}
