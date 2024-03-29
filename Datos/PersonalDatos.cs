﻿using RapiChicken.Models;
using System.Data.SqlClient;
using System.Data;

namespace RapiChicken.Datos
{
    public class PersonalDatos
    {
        public List<PersonalModel> Listar()
        {
            var oLista = new List<PersonalModel>();
            var cn = new Conexion();
            using (var con = new SqlConnection(cn.getconexion()))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_ListarPersonal", con);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLista.Add(new PersonalModel()
                        {
                            PersonalId = Convert.ToInt32(dr["PID"]),
                            NPersonal = dr["NP"].ToString(),
							APersonal = dr["AP"].ToString(),
							PTel = Convert.ToInt32(dr["PT"]),
							FN = Convert.ToDateTime(dr["FN"]),
							Dni = Convert.ToInt32(dr["DNI"]),
							Dir = dr["DIR"].ToString(),
							sex = Convert.ToChar(dr["SX"]),
							NRoles = dr["RN"].ToString()
                        });
                    }
                }
            }
            return oLista;
        }
        
        public List<PersonalModel> ListarR()
        {
            var oRoles = new List<PersonalModel>();
            var cn = new Conexion();
            using (var con = new SqlConnection(cn.getconexion()))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_ListarRoles", con);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oRoles.Add(new PersonalModel()
                        {
                            RolesId = Convert.ToInt32(dr["Roles_id"]),
                            NRoles = dr["name"].ToString(),
                            Descripcion = dr["description"].ToString()
                        });
                    }
                }
            }
            return oRoles;
        }
        
        public PersonalModel ObtenerPId(int ID)
        {
            var oI_ID = new PersonalModel();
            var cn = new Conexion();
            using (var con = new SqlConnection(cn.getconexion()))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_ObtenerIdPersonal", con);
                cmd.Parameters.AddWithValue("P_ID",ID);
                cmd.CommandType = CommandType.StoredProcedure;

                using(var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oI_ID.PersonalId = Convert.ToInt32(dr["Personas_id"]);
                        oI_ID.NPersonal = dr["nombres"].ToString();
                        oI_ID.APersonal = dr["apellidos"].ToString();
						oI_ID.PTel = Convert.ToInt32(dr["telefono"]);
						oI_ID.FN = Convert.ToDateTime(dr["f_nacimiento"]);
						oI_ID.Dni = Convert.ToInt32(dr["dni"]);
						oI_ID.Dir = dr["direccion"].ToString();
 						oI_ID.sex = Convert.ToChar(dr["sexo"]);
						oI_ID.RolesId = Convert.ToInt32(dr["Roles_id"]);
						oI_ID.NRoles = dr["name"].ToString();
						oI_ID.Descripcion = dr["description"].ToString();
                    }
                }
            }
            return oI_ID;
        }
        
        public RolesModel ObtenerId(int ID)
        {
            var oI_ID = new RolesModel();
            var cn = new Conexion();
            using (var con = new SqlConnection(cn.getconexion()))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_ObtenerIdRoles", con);
                cmd.Parameters.AddWithValue("R_ID",ID);
                cmd.CommandType = CommandType.StoredProcedure;

                using(var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oI_ID.RolId = Convert.ToInt32(dr["Roles_id"]);
                        oI_ID.NRol = dr["name"].ToString();
                        oI_ID.Descripcion = dr["description"].ToString();
                    }
                }
            }
            return oI_ID;
        }

        public bool Guardar(PersonalModel oGuardarP)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();
                using (var con = new SqlConnection(cn.getconexion()))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_GuardarPersonal", con);
                    cmd.Parameters.AddWithValue("NP", oGuardarP.NPersonal);
                    cmd.Parameters.AddWithValue("AP", oGuardarP.APersonal);
					cmd.Parameters.AddWithValue("T", oGuardarP.PTel);
					cmd.Parameters.AddWithValue("F_N", oGuardarP.FN);
					cmd.Parameters.AddWithValue("Dni", oGuardarP.Dni);
					cmd.Parameters.AddWithValue("D", oGuardarP.Dir);
					cmd.Parameters.AddWithValue("S", oGuardarP.sex);
					cmd.Parameters.AddWithValue("R_id", oGuardarP.RolesId);
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

        public bool Editar(PersonalModel oEditarI)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();
                using (var con = new SqlConnection(cn.getconexion()))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_EditarPersonal", con);
                    cmd.Parameters.AddWithValue("P_Id", oEditarI.PersonalId);
                    cmd.Parameters.AddWithValue("NP", oEditarI.NPersonal);
                    cmd.Parameters.AddWithValue("AP", oEditarI.APersonal);
					cmd.Parameters.AddWithValue("T", oEditarI.PTel);
					cmd.Parameters.AddWithValue("F_N", oEditarI.FN);
					cmd.Parameters.AddWithValue("Dni", oEditarI.Dni);
					cmd.Parameters.AddWithValue("D", oEditarI.Dir);
					cmd.Parameters.AddWithValue("S", oEditarI.sex);
					cmd.Parameters.AddWithValue("R_id", oEditarI.RolesId);
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

        public bool Eliminar(int ID)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();
                using (var con = new SqlConnection(cn.getconexion()))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_EliminarPersonal", con);
                    cmd.Parameters.AddWithValue("P_Id", ID);
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
