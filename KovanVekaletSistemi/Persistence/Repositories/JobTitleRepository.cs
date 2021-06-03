using KovanVekaletSistemi.Core.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovanVekaletSistemi.Persistence.Repositories
{
    public class JobTitleRepository:Repository<JobTitle>
    {
        public JobTitleRepository()
        {

        }
        public JobTitleRepository(DbContext context) : base(context)
        {

        }
    }
}
