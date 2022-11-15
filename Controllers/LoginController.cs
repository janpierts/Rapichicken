using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Linq;
using System.Configuration;
using RapiChicken.Datos;
using RapiChicken.Models;
using RapiChicken.Util;

namespace RapiChicken.Controllers
{
	public class LoginController : Controller
	{
		public IActionResult IniciarSesion()
		{
			return View();
		}
	}
}
