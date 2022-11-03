using RapiChicken.Models;
using System.Data.SqlClient;
using System.Data;

namespace RapiChicken.Datos
{
    public class InventarioDatos
    {
        public List<InventarioModel> Listar()
        {
            var oLista = new List<InventarioModel>();
            var cn = new Conexion();
            using (var con = new SqlConnection(cn.getconexion()))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_ListarInventario", con);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLista.Add(new InventarioModel()
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
            return oLista;
        }
        public InventarioModel ObtenerId(int I_ID)
        {
            var oI_ID = new InventarioModel();
            var cn = new Conexion();
            using (var con = new SqlConnection(cn.getconexion()))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_ObtenerIdInventario", con);
                cmd.Parameters.AddWithValue("I_ID",I_ID);
                cmd.CommandType = CommandType.StoredProcedure;

                using(var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oI_ID.InventarioId = Convert.ToInt32(dr["Inventario_id"]);
                        oI_ID.NProducto = dr["n_producto"].ToString();
                        oI_ID.Descripcion = dr["descripcion"].ToString();
                        oI_ID.TipoProducto = dr["tipo_producto"].ToString();
                        oI_ID.EstadoProducto = dr["estado_producto"].ToString();
                        oI_ID.Stock = Convert.ToInt32(dr["stock"]);
                        oI_ID.DetalleUnidad = dr["detalle_unidad"].ToString();
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

        public bool Editar(InventarioModel oEditarI)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();
                using (var con = new SqlConnection(cn.getconexion()))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_EditarInventario", con);
                    cmd.Parameters.AddWithValue("I_Id", oEditarI.InventarioId);
                    cmd.Parameters.AddWithValue("NombreP", oEditarI.NProducto);
                    cmd.Parameters.AddWithValue("I_D", oEditarI.Descripcion);
                    cmd.Parameters.AddWithValue("T_P", oEditarI.TipoProducto);
                    cmd.Parameters.AddWithValue("E_P", oEditarI.EstadoProducto);
                    cmd.Parameters.AddWithValue("I_Stock", oEditarI.Stock);
                    cmd.Parameters.AddWithValue("I_D_Unidad", oEditarI.DetalleUnidad);
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
                    SqlCommand cmd = new SqlCommand("sp_EliminarInventario", con);
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
