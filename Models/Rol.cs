using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelHenry.Models
{
    public class Rol
    {
        [Key]
        public int IdRol { get; set; }
        public string TipoRol { get; set; }
    }
}
