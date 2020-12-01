using HotelHenry.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelHenry.Data
{
	public class HotelContext : DbContext
	{
		public HotelContext(DbContextOptions<HotelContext> options)
			: base(options)
		{

		}

		public DbSet<Reservacion> Reservacions { get; set; }
		public DbSet<Habitacion> Habitacions { get; set; }
		public DbSet<Pais> Paises { get; set; }
		public DbSet<Rol> Rols { get; set; }
		public DbSet<Usuario> Usuarios { get; set; }

	}
}
