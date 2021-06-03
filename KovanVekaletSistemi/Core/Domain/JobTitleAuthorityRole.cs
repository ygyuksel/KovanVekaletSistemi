using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovanVekaletSistemi.Core.Domain
{
    public class JobTitleAuthorityRole:BaseDomainClass
    {
        
        public int JobTitle_Id { get; set; }
   
       
        public int AuthorityRole_Id { get; set; }

        [ForeignKey("AuthorityRole_Id ")]
        public virtual AuthorityRole AuthorityRole { get; set; }

        [ForeignKey("JobTitle_Id")]
        public virtual JobTitle JobTitle { get; set; }
    }
}
