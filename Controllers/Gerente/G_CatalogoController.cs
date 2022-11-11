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
    public class G_CatalogoController : Controller
    {
        InventarioDatos _InventarioDatos = new InventarioDatos();
		CatalogoDatos _CatalogoDatos = new CatalogoDatos();
        public IActionResult Listar_GCatalogo()
        {
            var oLista = _CatalogoDatos.Listar();
            return View(oLista);
        }
        public IActionResult FGuardar_Catalogo()
        {
            return View();
        }
        [HttpPost]
        public IActionResult FGuardar_Catalogo(CatalogoModel oInventario)
        {
            var save = _CatalogoDatos.Guardar(oInventario);
            if (save)
                return RedirectToAction("Listar_GCatalogo");
            else
                return View();
        }
        public IActionResult FEditar_Catalogo(int I_ID)
        {
            var oID_Inventario = _CatalogoDatos.ObtenerId(I_ID);
            return View(oID_Inventario);
        }

        [HttpPost]
        public IActionResult FEditar_Catalogo(CatalogoModel oI_ID)
        {
            if (!ModelState.IsValid)
                return View();

            var up = _CatalogoDatos.Editar(oI_ID);

            if (up)
                return RedirectToAction("Listar_GCatalogo");
            else
                return View();
        }
        
        public IActionResult Editar_SCatalogo(int I_ID)
        {
            var oID_Inventario = _CatalogoDatos.ObtenerId(I_ID);
            return View(oID_Inventario);
        }

        [HttpPost]
        public IActionResult Editar_SCatalogo(CatalogoModel oI_ID)
        {
            if (!ModelState.IsValid)
                return View();

            var up = _CatalogoDatos.EditarS(oI_ID);

            if (up)
                return RedirectToAction("Listar_GCatalogo");
            else
                return View();
        }

        public IActionResult Eliminar_Catalogo(int I_ID)
        {
            //METODO SOLO DEVUELVE LA VISTA
            var oDI = _CatalogoDatos.ObtenerId(I_ID);
            return View(oDI);
        }

        [HttpPost]
        public IActionResult Eliminar_Catalogo(CatalogoModel odi)
        {

            var down = _CatalogoDatos.Eliminar(odi.CatalogoId);

            if (down)
                return RedirectToAction("Listar_GCatalogo");
            else
                return View();
        }
    }
}
