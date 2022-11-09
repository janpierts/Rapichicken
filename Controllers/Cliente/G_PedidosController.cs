using Microsoft.AspNetCore.Mvc;
using RapiChicken.Datos;
using RapiChicken.Models;

namespace RapiChicken.Controllers.Cliente
{
    public class G_PedidosController : Controller
    {
        CatalogoDatos _CatalogoDatos = new CatalogoDatos();
        PromocionesDatos _PromocionesDatos = new PromocionesDatos();
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

            var up = _CatalogoDatos.Editar(oI_ID);

            if (up)
                return RedirectToAction("Listar_Catalogo");
            else
                return View();
        }
        /*
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
                return RedirectToAction("Listar_Catalogo");
            else
                return View();
        }*/
    }
}
