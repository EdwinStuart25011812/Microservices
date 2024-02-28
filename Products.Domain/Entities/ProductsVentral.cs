using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Domain.Entities
{
    public class ProductsVentral
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int UnitPrice { get; set; }
        public int Stock { get; set; }
        public string Category { get; set; }=string.Empty;
    }
}
