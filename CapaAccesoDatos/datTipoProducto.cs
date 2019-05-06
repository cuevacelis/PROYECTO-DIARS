using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using System.Data;
using System.Data.SqlClient;

namespace CapaAccesoDatos
{

        public class datTipoProducto
        {
            #region singleton
            private static readonly datTipoProducto UnicaInstancia = new datTipoProducto();
            public static datTipoProducto Instancia
            {
                get
                {
                    return datTipoProducto.UnicaInstancia;
                }

            }
            #endregion singleton

            #region metodos
            public List<entTipoProducto>ListarTipoProducto()
            {
                SqlCommand cmd = null;
                List<entTipoProducto> lista = new List<entTipoProducto>();

                try
                {
                    SqlConnection cn = Conexion.Instancia.Conectar();
                    cmd = new SqlCommand("spListaTipoProducto", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while(dr.Read())
                    {

                       entTipoProducto tipo = new entTipoProducto();
                       tipo.idTipoProducto = Convert.ToInt16(dr["idTipoProducto"]); 
                       tipo.desTipoProducto = dr["desTipoProducto"].ToString();
                       tipo.esTipoProducto = Convert.ToBoolean(dr["esTipoProducto"]);
                       lista.Add(tipo);
                    }
                    
                }
                catch (Exception e)
                {
                    throw e;
                }
                finally{ cmd.Connection.Close();}
                return lista;
            }
            

            public Boolean InsertarTipoProducto(entTipoProducto a)
            {
                SqlCommand cmd = null;
                Boolean Inserta = false;
                try
                {   SqlConnection cn = Conexion.Instancia.Conectar();
                    cmd = new SqlCommand("spInsertaTipoProducto", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@prmstrdesTipoProducto", a.desTipoProducto);
                    cmd.Parameters.AddWithValue("@prmbolesTipoProducto", a.esTipoProducto);
                    cn.Open();
                    int i = cmd.ExecuteNonQuery();
                    if (i > 0)
                    {  Inserta = true;
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
                finally { cmd.Connection.Close(); }
                return Inserta;
            }



            public entTipoProducto BuscarTipoProducto(int idTipoProducto)
            {
                SqlCommand cmd = null;
                entTipoProducto tp = null;
                try
                {
                    SqlConnection cn = Conexion.Instancia.Conectar();
                    cmd = new SqlCommand("spBuscarTipoProductoid", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@prmintidTipoProducto", idTipoProducto);
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        tp = new entTipoProducto();
                        tp.idTipoProducto = Convert.ToInt16(dr["idTipoProducto"]);
                        tp.desTipoProducto = dr["desTipoProducto"].ToString();
                        tp.esTipoProducto = Convert.ToBoolean(dr["esTipoProducto"]);
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
                finally 
                {
                    cmd.Connection.Close();
                }
                return tp;
                
            }

            public Boolean EditarTipoProducto(entTipoProducto tp)
            {
                SqlCommand cmd = null;
                Boolean edita = false;
                try
                {
                    SqlConnection cn = Conexion.Instancia.Conectar();
                    cmd = new SqlCommand("spEditarTipoProducto", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@prmintidTipoProducto",  tp.idTipoProducto);
                    cmd.Parameters.AddWithValue("@prmstrdesTipoProducto", tp.desTipoProducto);
                    cmd.Parameters.AddWithValue("@prmbolesTipoProducto",  tp.esTipoProducto);
                    cn.Open();
                    int i = cmd.ExecuteNonQuery();
                    if (i >= 0)
                    {
                        edita = true;
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
                finally { cmd.Connection.Close(); }
                return edita;
            }
            public Boolean EliminarTipoProducto(entTipoProducto tp)
            {
                SqlCommand cmd = null;
                Boolean elimina = false;
                try
                {
                    SqlConnection cn = Conexion.Instancia.Conectar();
                    cmd = new SqlCommand("spEliminarTipoProducto", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@prmintidTipoProducto", tp.idTipoProducto);
                    cmd.Parameters.AddWithValue("@prmbolesTipoProducto", tp.esTipoProducto);
                    cn.Open();
                    int i = cmd.ExecuteNonQuery();
                    if (i >= 0)
                    {
                        elimina = true;
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
                finally { cmd.Connection.Close(); }
                return elimina;
            }
            #endregion metodos
        }
    
}
