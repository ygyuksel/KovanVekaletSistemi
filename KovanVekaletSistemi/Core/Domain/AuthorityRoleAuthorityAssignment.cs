using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovanVekaletSistemi.Core.Domain
{
    public class AuthorityRoleAuthorityAssignment:BaseDomainClass
    {
        public int AuthorityRole_Id { get; set; }

        [ForeignKey("AuthorityRole_Id"), Column(Order = 1)]
        public AuthorityRole AuthorityRole { get; set; }

        public int AuthorityAssignment_Id { get; set; }

        [ForeignKey("AuthorityAssignment_Id"), Column(Order = 2)]
        public AuthorityAssignment AuthorityAssignment { get; set; }
    }
}
