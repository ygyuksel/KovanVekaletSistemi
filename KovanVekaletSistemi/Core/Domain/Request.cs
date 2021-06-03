using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovanVekaletSistemi.Core.Domain
{
    public class Request:BaseDomainClass
    {
        public int? RequestFrom_Id { get; set; }

        [ForeignKey("RequestFrom_Id")]
        public Employee RequestFrom { get; set; }

        public int? RequestTo_Id { get; set; }

        [ForeignKey("RequestTo_Id")]
        public Employee RequestTo { get; set; }

        public int AuthorityRole_Id { get; set; }
        [ForeignKey("AuthorityRole_Id")]
        public AuthorityRole AuthorityRole { get; set; }

        public string ApproveStatus { get; set; }
        public int? ApprovedBy_Id { get; set; }

        [ForeignKey("ApprovedBy_Id")]
        public Employee ApprovedBy { get; set; }

        public DateTime ApprovedTime { get; set; }
    }
}
