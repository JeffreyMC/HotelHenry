using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;
using System.Linq;
using System.Threading.Tasks;

namespace HotelHenry.Models
{
	public class Habitacion
	{
		[Key]
		public int IdHabitacion { get; set; }
		public string Tipo { get; set; }

		[Column(TypeName = "decimal(18,2)")]
		public decimal CostoAdultos { get; set; }

		[Column(TypeName = "decimal(18,2)")]
		public decimal CostoNinos { get; set; }

		public string Disponible { get; set; }

	}
}
