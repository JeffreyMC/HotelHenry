using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HotelHenry.Models
{
	public class Reservacion
	{
		[Key]
		public int IdReserva { get; set; }
		public Usuario Correo { get; set; }
		public DateTime FechaIngreso { get; set; }
		public DateTime FechaSalida { get; set; }
		public Habitacion TipoHabitacion { get; set; }
		public int CantHabitaciones { get; set; }
		public int CantAdultos { get; set; }
		public int CantMayores { get; set; }
		public int CantNinos { get; set; }
		public int CantDias { get; set; }

		[Column(TypeName = "decimal(18,2)")]
		public decimal CostoTotal { get; set; }
	}
}
