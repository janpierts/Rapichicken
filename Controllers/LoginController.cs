using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Linq;
using System.Configuration;
using RapiChicken.Datos;
using RapiChicken.Models;
using RapiChicken.Util;
using System.Data.SqlClient;  
using System.Data;  

namespace RapiChicken.Controllers
{
	public class LoginController : Controller
	{
		LoginDatos _LoginDatos = new LoginDatos();
		public IActionResult IniciarSesion()
		{
			return View();
		}
		[HttpPost]
		public ActionResult IniciarSesion(LoginModel oI_ID)
		{
			var cn = new Conexion();
            using (var con = new SqlConnection(cn.getconexion()))
            {
				con.Open();
                SqlCommand cmd = new SqlCommand("sp_Login", con);
				cmd.Parameters.AddWithValue("NP",oI_ID.NU);
				cmd.Parameters.AddWithValue("AP",oI_ID.PU);
                cmd.CommandType = CommandType.StoredProcedure;
				var dr = cmd.ExecuteReader();
				if(dr.Read())
				{
					oI_ID.RolesId = Convert.ToInt32(dr["Roles_id"]);
						if(oI_ID.RolesId==1)
						{
							return View("Test");
						}
					return View();
				}
				else
				{
					return View();
				}
			}
			return View();
		}
	}
}
