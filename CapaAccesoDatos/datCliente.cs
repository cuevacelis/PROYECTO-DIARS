using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using CapaEntidad;

namespace CapaAccesoDatos
{
    public class datCliente
    {
        #region singleton
        private static readonly datCliente _instancia = new datCliente();
        public static datCliente Instancia
        {
            get { return datCliente._instancia; }
        }
        #endregion

        #region Metodos
        public List<entCliente> ListarCliente()
        {
            SqlCommand cmd = null;
            List<entCliente> lista = new List<entCliente>();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spListarCliente", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    entPersona P = new entPersona();
                    P.idPersona = Convert.ToInt32(dr["idPersona"]);
                    P.nombreyApellidoPersona = dr["Nombres"].ToString();
                    P.DNI = dr["DNI"].ToString();
                    P.telefono = Convert.ToInt32(dr["Telefono"]);
                    P.estPersona = Convert.ToBoolean(dr["EstPersona"]);

                    entCliente C = new entCliente();
                    //C.idCliente = Convert.ToInt32(dr["IdCliente"]);

                    entTipoPersona TP = new entTipoPersona();
                    //TP.idTipoPersona = Convert.ToInt32(dr["IdTipoPersona"]);

                    C.idPersona = P;
                    lista.Add(C);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally { cmd.Connection.Close(); }
            return lista;
        }

        public Boolean InsertarCliente(entCliente C, entPersona P, entUsuario U)
        {
            SqlCommand cmd = null;
            Boolean insertar = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spInsertarCliente", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmstrNombres", P.nombreyApellidoPersona);
                cmd.Parameters.AddWithValue("@prmIdDni", P.DNI);
                cmd.Parameters.AddWithValue("@prmIdTelefono", P.telefono);
                cmd.Parameters.AddWithValue("@prmdateFechaNacimiento", P.fechaNacimiento);
                cmd.Parameters.AddWithValue("@prmstrCorreo", U.Correo);
                cmd.Parameters.AddWithValue("@prmstrContraseña", U.Password);
                cn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                { insertar = true; }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally { cmd.Connection.Close(); }
            return insertar;
        }
        #endregion
    }
}
