using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovanVekaletSistemi.Core.Domain
{
    public class AuthorityAssignment:BaseDomainClass
    {
        public int AssignmentFrom_Id { get; set; }

        [ForeignKey("AssignmentFrom_Id"), Column(Order = 1)]
        public Employee AssignmentFrom { get; set; }

        public int AssignmentTo_Id { get; set; }

        [ForeignKey("AssignmentTo_Id"), Column(Order = 2)]
        public Employee AssignmentTo { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public virtual ICollection<AuthorityRoleAuthorityAssignment> AuthorityRoleAuthorityAssignments { get; set; }
    }
}
