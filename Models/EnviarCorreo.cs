using System;
using System.Collections.Generic;
using System.Linq;
//using System.Net.Mail;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MimeKit;
using System.Net;


namespace HotelHenry.Models
{
	public class EnviarCorreo
	{
		public void EnviarEmail(Usuario user, Reservacion reserva, string asunto, string tipo)
		{
			MimeMessage message = new MimeMessage();

			MailboxAddress from = new MailboxAddress("Hotel Henry VIII",
			"hotelhenryviii2020@gmail.com");
			message.From.Add(from);

			MailboxAddress to = new MailboxAddress(user.Nombre + user.Apellidos,
			user.Correo);
			message.To.Add(to);

			message.Subject = asunto;

			//cuerpo del mensaje
			BodyBuilder bodyBuilder = new BodyBuilder();
			bodyBuilder.HtmlBody = "<h1>Confirmación de reserva</h1></br>" +
									"<p>El Hotel Henry VIII confirma la reserva a nombre del " +
									"cliente " + user.Nombre + " " + user.Apellidos + " con " +
									"fecha de llegada al hotel " + reserva.FechaIngreso.ToString("dd/MM/yyyy") +
									" y con fecha de salida del hotel al " + reserva.FechaSalida.ToString("dd/MM/yyyy") + ".</br>" +
									"<table>" +
									"<thead>" +
									"<tr style=\"text-align:center\">" +
									"<th>Tipo de habitación</th><th>Cant. habitaciones</th>" +
									"<th>Cant. Adultos</th><th>Cant. Adultos mayores</th>" +
									"<th>Cant. Niños</th><th>Costo de reservación</th>" +
									"</thead>" +
									"</tr>" +
									"<tr style=\"text-align:center\">" +
									"<td>" + tipo + "</td><td>" + reserva.CantHabitaciones + "</td>" +
									"<td>" + reserva.CantAdultos + "</td><td>" + reserva.CantMayores + "</td>" +
									"<td>" + reserva.CantNinos + "</td><td>$" + reserva.CostoTotal + "</td>" +
									"</tr>" +
									"</table></p>" +
									"<img style=\"text-align:center\" src =\"https://drive.google.com/thumbnail?id=1wDeI527i_3eSqYNnPEWkA8KrtxLgB0WM \"> ";



			//se adjunta el cuerpo del correo
			message.Body = bodyBuilder.ToMessageBody();

			//conecta y autentica el servidor SMTP
			SmtpClient client = new SmtpClient();
			client.Connect("smtp.gmail.com", 587);
			client.Authenticate("hotelhenryoctavo@gmail.com", "HotelHenry2020");

			//se envía el mensaje
			client.Send(message);
			client.Disconnect(true);
			client.Dispose();

		}
	}
}
