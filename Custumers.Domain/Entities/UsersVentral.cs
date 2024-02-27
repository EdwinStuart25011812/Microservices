using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custumers.Domain.Entities
{
    public class UsersVentral
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Direction  { get; set; } = string.Empty;
        public string NumberPhone { get; set; } = string.Empty;
        public DateTimeOffset DateRegister { get; set; } 
        public DateTimeOffset LastDateRegister { get; set; }


        // Constructor para inicializar automáticamente las fechas
        public UsersVentral()
        {
            DateRegister = DateTimeOffset.Now;
            LastDateRegister = DateTimeOffset.Now;
        }
    }
}
