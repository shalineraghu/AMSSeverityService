using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuditSeverityModule.Models
{
    public class ApplicationContext : DbContext

    {
        public ApplicationContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<SaveAuditDetails> SaveDetail { get; set; }
    }
    
}
