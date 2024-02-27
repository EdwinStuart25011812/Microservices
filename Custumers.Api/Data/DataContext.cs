using Custumers.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custumers.Infrastructure.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext>options)  : base(options)
        { 
        
        }
        public DbSet<UsersVentral> clientes { get; set; }
    }
}
