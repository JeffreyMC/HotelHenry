using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelHenry.Models
{
	public class Usuario
	{
		[Key]
		[RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Por favor ingrese una dirección de correo válida")]
		[Required(ErrorMessage = "Este campo es obligatorio")]
		[DataType(DataType.EmailAddress)]
		public string Correo { get; set; }
		public string Nombre { get; set; }
		public string Apellidos { get; set; }

		[DataType(DataType.PhoneNumber)]
		public int Telefono { get; set; }
		public Pais Pais { get; set; }
		public string Password { get; set; }
		public virtual Rol Rol { get; set; }

		public List<Reservacion> Reservacion { get; set; }

	}
}
