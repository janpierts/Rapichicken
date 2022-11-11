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
    public class G_PromocionesController : Controller
    {
        InventarioDatos _InventarioDatos = new InventarioDatos();
		PromocionesDatos _PromocionesDatos = new PromocionesDatos();
        public IActionResult Listar_GPromociones()
        {
            var oLista = _PromocionesDatos.Listar();
            return View(oLista);
        }
        public IActionResult FGuardar_Promociones()
        {
            return View();
        }
        [HttpPost]
        public IActionResult FGuardar_Promociones(PromocionesModel oInventario)
        {
            var save = _PromocionesDatos.Guardar(oInventario);
            if (save)
                return RedirectToAction("Listar_GPromociones");
            else
                return View();
        }
        public IActionResult FEditar_Promociones(int I_ID)
        {
            var oID_Inventario = _PromocionesDatos.ObtenerId(I_ID);
            return View(oID_Inventario);
        }

        [HttpPost]
        public IActionResult FEditar_Promociones(PromocionesModel oI_ID)
        {
            if (!ModelState.IsValid)
                return View();

            var up = _PromocionesDatos.Editar(oI_ID);

            if (up)
                return RedirectToAction("Listar_GPromociones");
            else
                return View();
        }
        
        public IActionResult Editar_SPromociones(int I_ID)
        {
            var oID_Inventario = _PromocionesDatos.ObtenerId(I_ID);
            return View(oID_Inventario);
        }

        [HttpPost]
        public IActionResult Editar_SPromociones(PromocionesModel oI_ID)
        {
            if (!ModelState.IsValid)
                return View();

            var up = _PromocionesDatos.EditarS(oI_ID);

            if (up)
                return RedirectToAction("Listar_GPromociones");
            else
                return View();
        }

        public IActionResult Eliminar_Promociones(int I_ID)
        {
            //METODO SOLO DEVUELVE LA VISTA
            var oDI = _PromocionesDatos.ObtenerId(I_ID);
            return View(oDI);
        }

        [HttpPost]
        public IActionResult Eliminar_Promociones(PromocionesModel odi)
        {

            var down = _PromocionesDatos.Eliminar(odi.PromocionesId);

            if (down)
                return RedirectToAction("Listar_GPromociones");
            else
                return View();
        }
    }
}
