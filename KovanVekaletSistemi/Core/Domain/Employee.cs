using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovanVekaletSistemi.Core.Domain
{
    public class Employee:BaseDomainClass
    {
        public int RegistirationNumber { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }

        public int JobTitle_Id { get; set; }

        [ForeignKey("JobTitle_Id")]
        public JobTitle JobTitle { get; set; }

       
    }
}
