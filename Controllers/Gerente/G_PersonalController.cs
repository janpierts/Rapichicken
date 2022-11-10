using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Linq;
using System.Configuration;
using RapiChicken.Datos;
using RapiChicken.Models;
using RapiChicken.Util;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
using Twilio.TwiML;
using Twilio.AspNet.Mvc;

namespace RapiChicken.Controllers
{
    public class G_PersonalController : Controller
    {
        PersonalDatos _PersonalDatos = new PersonalDatos();
        public IActionResult Listar_Personal()
        {
            var oLista = _PersonalDatos.Listar();
            return View(oLista);
        }
        public IActionResult FGuardar_Personal()
        {
			var oRoles = _PersonalDatos.ListarR();
            return View();
        }
        [HttpPost]
        public IActionResult FGuardar_Personal(PersonalModel oGuardarP)
        {
            var save = _PersonalDatos.Guardar(oGuardarP);
            if (save)
                return RedirectToAction("Listar_Personal");
            else
                return View();
        }
        public IActionResult FEditar_Personal(int I_ID)
        {
            var oID_Roles = _PersonalDatos.ObtenerPId(I_ID);
            return View(oID_Roles);
        }

        [HttpPost]
        public IActionResult FEditar_Personal(PersonalModel oI_ID)
        {
            if (!ModelState.IsValid)
                return View();

            var up = _PersonalDatos.Editar(oI_ID);

            if (up)
                return RedirectToAction("Listar_Personal");
            else
                return View();
        }
        
        public IActionResult Eliminar_Personal(int I_ID)
        {
            //METODO SOLO DEVUELVE LA VISTA
            var oDI = _PersonalDatos.ObtenerPId(I_ID);
            return View(oDI);
        }

        [HttpPost]
        public IActionResult Eliminar_Personal(PersonalModel odi)
        {

            var down = _PersonalDatos.Eliminar(odi.PersonalId);

            if (down)
                return RedirectToAction("Listar_Personal");
            else
                return View();
        }
    }
}
 
