using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelHenry.Data;
using HotelHenry.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Bson;
using MailKit.Net.Smtp;
using MimeKit;

namespace HotelHenry.Controllers
{

	public class HuespedController : Controller
	{
		private readonly HotelContext bd;
		public HuespedController(HotelContext cx)
		{
			bd = cx;
		}

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult StandardRoom()
		{
			Habitacion h = bd.Habitacions.FirstOrDefault(id => id.IdHabitacion == 1);

			return View(h);
		}

		public IActionResult JuniorRoom()
		{
			Habitacion h = bd.Habitacions.FirstOrDefault(id => id.IdHabitacion == 2);
			return View(h);
		}

		public IActionResult DeluxeRoom()
		{
			Habitacion h = bd.Habitacions.FirstOrDefault(id => id.IdHabitacion == 3);
			return View(h);
		}


		[HttpGet]
		public IActionResult Reservacion()
		{

			if (HttpContext.Session.GetString("Usuario") != null)
			{
				//retorna el modelo con los datos: nombre Apellido y correo
				var email = HttpContext.Session.GetString("Correo");
				Usuario p = bd.Usuarios.FirstOrDefault(c => c.Correo == email);

				//se llenan los ViewBag
				ViewBag.Nombre = p.Nombre;
				ViewBag.Apellidos = p.Apellidos;
				ViewBag.Correo = p.Correo;

				//Viewbag con los tipos de habitación
				ViewBag.Habitaciones = bd.Habitacions.Where(h => h.Disponible == "SI").ToList();
				return View();
			}

			return RedirectToAction("Login", "Huesped");
		}

		[HttpPost]
		public IActionResult Reservacion(Reservacion datos)
		{
			//obtiene los datos del usuario
			var correo = HttpContext.Session.GetString("Correo");
			Usuario user = bd.Usuarios.FirstOrDefault(c => c.Correo == correo);
			//se obtienen los datos del tipo de habitación
			var tipo = bd.Habitacions.FirstOrDefault(h => h.IdHabitacion == datos.TipoHabitacion.IdHabitacion);

			//se pasan las variables de las llaves foráneas

			Reservacion res = new Reservacion
			{
				Correo = user,
				TipoHabitacion = tipo,
				FechaIngreso = datos.FechaIngreso,
				FechaSalida = datos.FechaSalida,
				CantHabitaciones = datos.CantHabitaciones,
				CantDias = datos.CantDias,
				CantAdultos = datos.CantAdultos,
				CantMayores = datos.CantMayores,
				CantNinos = datos.CantNinos,
				CostoTotal = datos.CostoTotal
			};

			//se guardan los datos en la base de datos
			bd.Reservacions.Add(res);
			bd.SaveChanges();

			//enviar email de confirmación
			EnviarCorreo ec = new EnviarCorreo();
			ec.EnviarEmail(user, res, "Confirmación de reservación", tipo.Tipo);

			//mensaje de la reservación realizada
			TempData["Reserva"] = "Reserva realizada con éxito";

			return RedirectToAction("Perfil", "Huesped");
		}

		public IActionResult Galeria()
		{
			return View();
		}

		public IActionResult Perfil()
		{
			//mensaje en caso de haber realizado una reservacion
			ViewBag.Reserva = TempData["Reserva"];

			var correo = HttpContext.Session.GetString("Correo");
			ViewBag.User = HttpContext.Session.GetString("Usuario");
			var user = bd.Usuarios.FirstOrDefault(u => u.Correo == correo);

			//obtiene las reservaciones previas
			ViewBag.ReservacionesPrevias = bd.Reservacions.Where(c => c.Correo == user && c.FechaIngreso < DateTime.Now).OrderByDescending(o => o.FechaSalida);
			//retorna el número de elementos
			ViewBag.NoPrevias = bd.Reservacions.Where(c => c.Correo == user && c.FechaIngreso < DateTime.Now).OrderByDescending(o => o.FechaSalida).Count();
			//obtiene las reservaciones actuales
			ViewBag.ReservacionesActuales = bd.Reservacions.Where(c => c.Correo == user && c.FechaIngreso > DateTime.Now).OrderBy(o => o.FechaIngreso);
			//retorna la el número de elementos
			ViewBag.NoActuales = bd.Reservacions.Where(c => c.Correo == user && c.FechaIngreso > DateTime.Now).OrderBy(o => o.FechaIngreso).Count();

			//retorna los tipo de habitación
			ViewBag.Rooms = bd.Habitacions.ToList();
			return View();
		}

		[HttpGet]
		public IActionResult Login()
		{
			//mensaje en caso de venir de registrarse
			ViewBag.Success = TempData["Success"];

			return View();
		}

		[HttpPost]
		public IActionResult Login(Usuario datos)
		{

			var correo = datos.Correo;
			var pass = datos.Password;

			//valida que los datos sean correctos
			Usuario user = bd.Usuarios.FirstOrDefault(u => u.Correo == correo && u.Password == pass);

			if (user != null)
			{
				//se llena la variable de sesión
				HttpContext.Session.SetString("Usuario", user.Nombre + " " + user.Apellidos);
				//se llena variable de sesión con el correo
				HttpContext.Session.SetString("Correo", user.Correo);

				//consulta con la llave foránea
				Usuario us = bd.Usuarios.Where(c => c.Correo == correo).Include(r => r.Rol).FirstOrDefault();

				//verifica si es administrador (1) o huésped (2)
				if (us.Rol.IdRol == 1)
				{
					return RedirectToAction("Index", "Admin");
				}
				else
				{
					return RedirectToAction("Index", "Huesped");
				}

			}

			ViewBag.Error = "El correo o la contraseña es incorrecta";

			return View();
		}

		[HttpGet]
		public IActionResult SignUp()
		{
			ViewBag.Paises = bd.Paises.ToList();

			return View();
		}

		[HttpPost]
		public IActionResult SignUp(Usuario datos)
		{
			//verifica que el correo no exista
			var existe = bd.Usuarios.FirstOrDefault(c => c.Correo == datos.Correo);

			if (existe != null)
			{
				ViewBag.Message = "El correo ingresado ya está registrado";

				return View(datos);
			}


			//rol por defecto: Huesped
			Rol rol = bd.Rols.FirstOrDefault(r => r.IdRol == 2);

			//devuelve el país elegido
			var IdPais = datos.Pais.IdPais;
			Pais pais = bd.Paises.FirstOrDefault(p => p.IdPais == IdPais);

			//guarda los datos en objeto Usuario
			Usuario us = new Usuario
			{
				Nombre = datos.Nombre,
				Correo = datos.Correo,
				Apellidos = datos.Apellidos,
				Password = datos.Password,
				Rol = rol,
				Pais = pais,
				Telefono = datos.Telefono
			};

			//se guardan los datos
			bd.Usuarios.Add(us);
			bd.SaveChanges();

			//mensaje de éxito
			TempData["Success"] = "Registrado éxitosamente. ¡Ya puedes iniciar sesión!";

			return RedirectToAction("Login", "Huesped");
		}

		public IActionResult SignOut()
		{
			//Limpia la variable de sesión
			HttpContext.Session.Clear();

			return RedirectToAction("Index", "Huesped");
		}

		[HttpGet]
		public IActionResult EditarReserva(int id)
		{
			Reservacion reserva = bd.Reservacions.Where(r => r.IdReserva == id).Include(c => c.Correo).FirstOrDefault();
			Usuario user = reserva.Correo;
			Usuario p = bd.Usuarios.FirstOrDefault(c => c.Correo == user.Correo);

			//se llenan los ViewBag
			ViewBag.Nombre = p.Nombre;
			ViewBag.Apellidos = p.Apellidos;
			ViewBag.Correo = p.Correo;

			//Viewbag con los tipos de habitación
			ViewBag.Habitaciones = bd.Habitacions.Where(h => h.Disponible == "SI").ToList();
			return View(reserva);
		}

		[HttpPost]
		public IActionResult EditarReserva(Reservacion datos)
		{
			Reservacion reserva = bd.Reservacions.FirstOrDefault(r => r.IdReserva == datos.IdReserva);

			//obtiene los datos del usuario
			var correo = HttpContext.Session.GetString("Correo");
			Usuario user = bd.Usuarios.FirstOrDefault(c => c.Correo == correo);
			//se obtienen los datos del tipo de habitación
			var tipo = bd.Habitacions.FirstOrDefault(h => h.IdHabitacion == datos.TipoHabitacion.IdHabitacion);

			//se actualiza la tabla

			reserva.Correo = user;
			reserva.TipoHabitacion = tipo;
			reserva.FechaIngreso = datos.FechaIngreso;
			reserva.FechaSalida = datos.FechaSalida;
			reserva.CantHabitaciones = datos.CantHabitaciones;
			reserva.CantDias = datos.CantDias;
			reserva.CantAdultos = datos.CantAdultos;
			reserva.CantMayores = datos.CantMayores;
			reserva.CantNinos = datos.CantNinos;
			reserva.CostoTotal = datos.CostoTotal;


			//se guardan los datos en la base de datos
			bd.SaveChanges();

			//enviar email de confirmación
			EnviarCorreo ec = new EnviarCorreo();
			ec.EnviarEmail(user, reserva, "Confirmación de modificación de reserva", tipo.Tipo);

			return RedirectToAction("Perfil", "Huesped");

		}


	}

}
