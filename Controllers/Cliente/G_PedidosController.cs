﻿using Microsoft.AspNetCore.Mvc;
using RapiChicken.Datos;
using RapiChicken.Models;

namespace RapiChicken.Controllers.Cliente
{
    public class G_PedidosController : Controller
    {
        CatalogoDatos _CatalogoDatos = new CatalogoDatos();
        PromocionesDatos _PromocionesDatos = new PromocionesDatos();
		PedidosDatos _PedidosDatos = new PedidosDatos();
        public IActionResult Listar_Catalogo()
        {
            var oLista = _CatalogoDatos.Listar();
            return View(oLista);
        }
        
        public IActionResult Listar_Promociones()
        {
            var oLista = _PromocionesDatos.Listar();
            return View(oLista);
        }
        
        public IActionResult ListarPedidos()
        {
            var oLista = _PedidosDatos.Listar();
            return View(oLista);
        }
        
        public IActionResult CarritoC()
        {
            var oLista = _PedidosDatos.Listar();
            return View(oLista);
        }
        /*
        public IActionResult FGuardar_Inventario()
        {
            return View();
        }
        [HttpPost]
        public IActionResult FGuardar_Inventario(InventarioModel oInventario)
        {
            var save = _InventarioDatos.Guardar(oInventario);
            if (save)
                return RedirectToAction("Listar_Catalogo");
            else
                return View();
        }*/
        public IActionResult FEditar_Pedido(int I_ID)
        {
            var oID_Inventario = _CatalogoDatos.ObtenerId(I_ID);
            return View(oID_Inventario);
        }

        [HttpPost]
        public IActionResult FEditar_Pedido(CatalogoModel oI_ID)
        {
            if (!ModelState.IsValid)
                return View();

            var up = _PedidosDatos.EditarP(oI_ID);

            if (up)
                return RedirectToAction("Listar_Catalogo");
            else
                return View();
        }
        
        public IActionResult Eliminar_Pedido(int I_ID)
        {
            //METODO SOLO DEVUELVE LA VISTA
            var oDI = _PedidosDatos.ObtenerId(I_ID);
            return View(oDI);
        }

        [HttpPost]
        public IActionResult Eliminar_Pedido(PedidosModel odi)
        {

            var down = _PedidosDatos.Eliminar(odi.Pedidos_id);

            if (down)
                return RedirectToAction("Listar_Catalogo");
            else
                return View();
        }
    }
}
