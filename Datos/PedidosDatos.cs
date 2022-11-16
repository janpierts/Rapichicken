using RapiChicken.Models;
using System.Data.SqlClient;
using System.Data;

namespace RapiChicken.Datos
{
    public class PedidosDatos
    {
        public List<PedidosModel> Listar()
        {
            var oLista = new List<PedidosModel>();
            var cn = new Conexion();
            using (var con = new SqlConnection(cn.getconexion()))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_ListarPedidos", con);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLista.Add(new PedidosModel()
                        {
                            Pedidos_id = Convert.ToInt32(dr["Pedidos_id"]),
                            N_Pedido = dr["N_Pedido"].ToString(),
                            D_Pedido = dr["D_Pedido"].ToString(),
                            Cantidad = Convert.ToInt32(dr["Cantidad"]),
                            NP_C = dr["NP_C"].ToString()
                        });
                    }
                }
            }
            return oLista;
        }
        public PedidosModel ObtenerId(int I_ID)
        {
            var oI_ID = new PedidosModel();
            var cn = new Conexion();
            using (var con = new SqlConnection(cn.getconexion()))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_ObtenerIdPedido", con);
                cmd.Parameters.AddWithValue("I_ID",I_ID);
                cmd.CommandType = CommandType.StoredProcedure;

                using(var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oI_ID.Pedidos_id = Convert.ToInt32(dr["Pedidos_id"]);
                        oI_ID.N_Pedido = dr["N_Pedido"].ToString();
                        oI_ID.D_Pedido = dr["D_Pedido"].ToString();
                        oI_ID.Cantidad = Convert.ToInt32(dr["Cantidad"]);
                        oI_ID.NP_C = dr["NP_C"].ToString();
                    }
                }
            }
            return oI_ID;
        }
        public List<InventarioModel> ListarN(string NP)
        {
            var oListaN = new List<InventarioModel>();
            var cn = new Conexion();
            using (var con = new SqlConnection(cn.getconexion()))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_ListarNInventario", con);
                cmd.Parameters.AddWithValue("NombreP", NP);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oListaN.Add(new InventarioModel()
                        {
                            InventarioId = Convert.ToInt32(dr["Inventario_id"]),
                            NProducto = dr["n_producto"].ToString(),
                            Descripcion = dr["descripcion"].ToString(),
                            TipoProducto = dr["tipo_producto"].ToString(),
                            EstadoProducto = dr["estado_producto"].ToString(),
                            Stock = Convert.ToInt32(dr["stock"]),
                            DetalleUnidad = dr["detalle_unidad"].ToString()
                        });
                    }
                }
            }
            return oListaN;
        }

        public bool Guardar(InventarioModel oGuardarI)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();
                using (var con = new SqlConnection(cn.getconexion()))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_GuardarInventario", con);
                    cmd.Parameters.AddWithValue("NombreP", oGuardarI.NProducto);
                    cmd.Parameters.AddWithValue("I_D", oGuardarI.Descripcion);
                    cmd.Parameters.AddWithValue("T_P", oGuardarI.TipoProducto);
                    cmd.Parameters.AddWithValue("E_P", oGuardarI.EstadoProducto);
                    cmd.Parameters.AddWithValue("I_Stock", oGuardarI.Stock);
                    cmd.Parameters.AddWithValue("I_D_Unidad", oGuardarI.DetalleUnidad);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;
            }
            catch(Exception e)
            {
                string error = e.Message;
                rpta = false;
            }
            return rpta;
        }

        public bool EditarP(CatalogoModel oEditarI)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();
                using (var con = new SqlConnection(cn.getconexion()))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_GuardarPedido", con);
					cmd.Parameters.AddWithValue("CID", oEditarI.CatalogoId);
                    cmd.Parameters.AddWithValue("NP", oEditarI.NProducto);
                    cmd.Parameters.AddWithValue("DP", oEditarI.Descripcion);
                    cmd.Parameters.AddWithValue("C", oEditarI.C);
                    cmd.Parameters.AddWithValue("NPC", oEditarI.NPC);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;
            }
            return rpta;
        }

        public bool Eliminar(int I_ID)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();
                using (var con = new SqlConnection(cn.getconexion()))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_EliminarPedido", con);
                    cmd.Parameters.AddWithValue("I_Id", I_ID);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;
            }
            return rpta;
        }
    }
}
