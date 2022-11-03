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
    public class G_RolesController : Controller
    {
        InventarioDatos _InventarioDatos = new InventarioDatos();
        public IActionResult Listar_Roles()
        {
            var oLista = _InventarioDatos.Listar();
            return View(oLista);
        }
        public IActionResult FGuardar_Inventario()
        {
            return View();
        }
        [HttpPost]
        public IActionResult FGuardar_Inventario(InventarioModel oInventario)
        {
            var save = _InventarioDatos.Guardar(oInventario);
            if (save)
                return RedirectToAction("Listar_Inventario");
            else
                return View();
        }
        public IActionResult FEditar_Inventario(int I_ID)
        {
            var oID_Inventario = _InventarioDatos.ObtenerId(I_ID);
            return View(oID_Inventario);
        }

        [HttpPost]
        public IActionResult FEditar_Inventario(InventarioModel oI_ID)
        {
            if (!ModelState.IsValid)
                return View();

            var up = _InventarioDatos.Editar(oI_ID);

            if (up)
                return RedirectToAction("Listar_Inventario");
            else
                return View();
        }
        
        public IActionResult Editar_SInventario(int I_ID)
        {
            var oID_Inventario = _InventarioDatos.ObtenerId(I_ID);
            return View(oID_Inventario);
        }

        [HttpPost]
        public IActionResult Editar_SInventario(InventarioModel oI_ID)
        {
            if (!ModelState.IsValid)
                return View();

            var up = _InventarioDatos.EditarS(oI_ID);

            if (up)
                return RedirectToAction("Listar_Inventario");
            else
                return View();
        }

        public IActionResult Eliminar_PInventario(int I_ID)
        {
            //METODO SOLO DEVUELVE LA VISTA
            var oDI = _InventarioDatos.ObtenerId(I_ID);
            return View(oDI);
        }

        [HttpPost]
        public IActionResult Eliminar_PInventario(InventarioModel odi)
        {

            var down = _InventarioDatos.Eliminar(odi.InventarioId);

            if (down)
                return RedirectToAction("Listar_Inventario");
            else
                return View();
        }
    }
}
 
