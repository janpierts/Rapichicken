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
        /*public IActionResult FGuardar_Roles()
        {
            return View();
        }
        [HttpPost]
        public IActionResult FGuardar_Roles(RolesModel oGuardarR)
        {
            var save = _RolesDatos.Guardar(oGuardarR);
            if (save)
                return RedirectToAction("Listar_Roles");
            else
                return View();
        }
        public IActionResult FEditar_Roles(int I_ID)
        {
            var oID_Roles = _RolesDatos.ObtenerId(I_ID);
            return View(oID_Roles);
        }

        [HttpPost]
        public IActionResult FEditar_Roles(RolesModel oI_ID)
        {
            if (!ModelState.IsValid)
                return View();

            var up = _RolesDatos.Editar(oI_ID);

            if (up)
                return RedirectToAction("Listar_Roles");
            else
                return View();
        }
        
        public IActionResult Eliminar_Roles(int I_ID)
        {
            //METODO SOLO DEVUELVE LA VISTA
            var oDI = _RolesDatos.ObtenerId(I_ID);
            return View(oDI);
        }

        [HttpPost]
        public IActionResult Eliminar_Roles(RolesModel odi)
        {

            var down = _RolesDatos.Eliminar(odi.RolId);

            if (down)
                return RedirectToAction("Listar_Roles");
            else
                return View();
        }*/
    }
}
 
