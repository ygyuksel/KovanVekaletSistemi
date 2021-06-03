using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovanVekaletSistemi.Core.Domain
{
    public class JobTitle:BaseDomainClass
    {
        public JobTitle()
        {
            //this.AuthorityRoles = new HashSet<AuthorityRole>();
        }
        public virtual ICollection<JobTitleAuthorityRole> JobTitleAuthorityRoles { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
