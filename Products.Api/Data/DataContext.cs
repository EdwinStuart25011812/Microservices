using Microsoft.EntityFrameworkCore;
using Products.Domain.Entities;

namespace Products.Api.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<ProductsVentral> products { get; set; }
    }
}
