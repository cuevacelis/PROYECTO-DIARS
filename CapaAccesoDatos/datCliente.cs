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

        public Boolean InsertarCliente(entCliente C)
        {
            SqlCommand cmd = null;
            Boolean insertar = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spInsertarCliente", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmstrNombres", C.idPersona.nombreyApellidoPersona);
                cmd.Parameters.AddWithValue("@prmIdDni", C.idPersona.DNI);
                cmd.Parameters.AddWithValue("@prmIdTelefono", C.idPersona.telefono);
                cmd.Parameters.AddWithValue("@prmdateFechaNacimiento", C.idPersona.fechaNacimiento);
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

        public entCliente BuscarCliente(int idCliente)
        {
            SqlCommand cmd = null;
            entCliente C = null;
            entPersona P = null;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spBuscarCliente", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmintidCliente", idCliente);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    C = new entCliente();
                    P = new entPersona();

                    C.idCliente = Convert.ToInt32(dr["IdCliente"]);
                    P.idPersona = Convert.ToInt32(dr["IdPersona"]);


                    //tc.desTipoCliente = dr["DesTipoCliente"].ToString();
                    C.idPersona = P;

                    C.idPersona.nombreyApellidoPersona = Convert.ToString(dr["NombreYApellidoPersona"]);
                    C.idPersona.DNI = Convert.ToString(dr["Dni"]);
                    C.idPersona.telefono = Convert.ToInt32(dr["Telefono"]);
                    C.idPersona.estPersona = Convert.ToBoolean(dr["EstPersona"]);

                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally { cmd.Connection.Close(); }
            return C;
        }

        public Boolean EditarCliente(entCliente C)
        {
            SqlCommand cmd = null;
            Boolean edita = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spEditarCliente", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmintidCliente", C.idPersona);
                cmd.Parameters.AddWithValue("@prmstrNombres", C.idPersona.nombreyApellidoPersona);
                cmd.Parameters.AddWithValue("@prmIdDni", C.idPersona.DNI);
                cmd.Parameters.AddWithValue("@prmIdTelefono", C.idPersona.telefono);
                cmd.Parameters.AddWithValue("@prmbitEstado", C.idPersona.estPersona);
                cmd.Parameters.AddWithValue("@prmstrRazonSocial", C.idPersona.razonSocial);
                cn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i >= 0)
                { edita = true; }

            }
            catch (Exception e)
            {
                throw e;
            }
            finally { cmd.Connection.Close(); }
            return edita;
        }
        #endregion
    }
}
