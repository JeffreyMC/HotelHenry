using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using HotelHenry.Data;
using HotelHenry.Models;
using Microsoft.AspNetCore.Mvc;

namespace HotelHenry.Controllers
{
	public class AdminController : Controller
	{
		//para manejar el contexto de la base de datos
		private readonly Data.HotelContext bd;
		public AdminController(HotelContext cx)
		{
			bd = cx;
		}

		public IActionResult Index()
		{
			return View();
		}

		[HttpGet]
		public IActionResult ReservasMes()
		{
			ViewBag.ListaRes = bd.Reservacions.ToList();
			ViewBag.Clientes = bd.Usuarios.ToList();
			ViewBag.Tipo = bd.Habitacions.ToList();

			return View();
		}

		public IActionResult Mantenimiento()
		{
			List<Habitacion> h = bd.Habitacions.ToList();
			return View(h);
		}

		[HttpGet]
		public IActionResult EditarPrecios(int id)
		{
			Habitacion h = bd.Habitacions.FirstOrDefault(hab => hab.IdHabitacion == id);

			return View(h);
		}

		[HttpPost]
		public IActionResult EditarPrecios(Habitacion h)
		{
			Habitacion hab = bd.Habitacions.FirstOrDefault(r => r.IdHabitacion == h.IdHabitacion);

			//se actualiza la tabla
			hab.CostoAdultos = h.CostoAdultos;
			hab.CostoNinos = h.CostoNinos;
			hab.Disponible = h.Disponible;

			bd.SaveChanges();

			return RedirectToAction("Mantenimiento", "Admin");
		}


	}
}
