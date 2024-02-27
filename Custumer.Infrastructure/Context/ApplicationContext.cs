using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Custumers.Domain.Entities;
namespace Custumer.Infrastructure.Context
{
    public class ApplicationContext:DbContext
    {
        public DbSet<UsersVentral> Users { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
       : base(options)
        {
        }
    }


}
