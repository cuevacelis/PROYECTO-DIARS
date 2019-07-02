using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using CapaEntidad;
using CapaAccesoDatos;

namespace CapaAccesoDatos
{
    public class datUsuario
    {
        #region singleton
        private static readonly datUsuario _instancia = new datUsuario();
        public static datUsuario Instancia
        {
            get { return datUsuario._instancia; }
        }
        #endregion

        #region Metodos
        public List<entUsuario> ListarUsuario()
        {
            SqlCommand cmd = null;
            List<entUsuario> lista = new List<entUsuario>();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spListarUsuario", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    entUsuario U = new entUsuario();
                    U.idUsuario = Convert.ToInt16(dr["idUsuario"]);
                    U.Username = dr["nomUsuario"].ToString();
                    U.Correo = dr["correo"].ToString();
                    U.estUsuario = Convert.ToBoolean(dr["estUsuario"]);
                    U.fechCreacion = Convert.ToDateTime(dr["fecCreacion"]);

                    entPersona P = new entPersona();
                    P.idPersona = Convert.ToInt16(dr["idPersona"]);
                    P.nombreyApellidoPersona = dr["Nombres"].ToString();
                    P.DNI = dr["DNI"].ToString();
                    P.telefono = Convert.ToInt16(dr["Telefono"]);
                    P.estPersona = Convert.ToBoolean(dr["EstCliente"]);

                    U.idPersona = P;
                    lista.Add(U);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally { cmd.Connection.Close(); }
            return lista;
        }

        public entUsuario VerificarAcceso(String Usuario, String Password)
        {
            SqlCommand cmd = null;
            entUsuario u = null;

            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spVerificarAcceso", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmstrCorreo", Usuario);
                cmd.Parameters.AddWithValue("@prmstrPassword", Password);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    u = new entUsuario();
                    u.idUsuario = Convert.ToInt32(dr["idUsuario"]);
                    u.fechCreacion = Convert.ToDateTime(dr["fechaCreacion"]);
                    u.Username = dr["Username"].ToString();
                    u.Correo = dr["Correo"].ToString();
                    u.estUsuario = Convert.ToBoolean(dr["estUsuario"]);

                    entPersona P = new entPersona();
                    P.nombreyApellidoPersona = dr["Nombres"].ToString();
                    P.DNI = dr["Dni"].ToString();
                    P.telefono = Convert.ToInt32(dr["Telefono"]);
                    //C.estPersona = Convert.ToBoolean(dr["EstCliente"]);

                    entTipoPersona tp = new entTipoPersona();
                    tp.Privilegio = Convert.ToInt32(dr["Privilegio"]);
                    tp.desTipoPersona= dr["DesTipoPersona"].ToString();
                    P.idTipoPersona = tp;

                    u.idPersona = P;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally { cmd.Connection.Close(); }
            return u;
        }
        #endregion
    }
}
