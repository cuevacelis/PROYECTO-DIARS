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
    public class datCliente
    {
        
        #region singleton
        private static readonly datCliente UnicaInstancia = new datCliente();
        public static datCliente Instancia
        {
            get
            {
                return datCliente.UnicaInstancia;
            }

        }
        #endregion singleton

        #region metodos
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

                    entCliente Cliente = new entCliente();
                    entTipoCliente TipoCliente = new entTipoCliente();

                    Cliente.idCliente = Convert.ToInt32(dr["IdCliente"]);

                    //tp.desTipoCliente = Convert.ToInt16(dr["idTipoCliente"]);
                    TipoCliente.desTipoCliente = dr["DesTipoCliente"].ToString();
                    Cliente.idTipoCliente = TipoCliente;

                    Cliente.nombreCliente = dr["NombreCliente"].ToString();
                    Cliente.apellidoCliente = dr["ApellidoCliente"].ToString();
                    Cliente.DNI = dr["Dni"].ToString();
                    Cliente.telefono = Convert.ToInt32(dr["Telefono"]);
                    Cliente.estCliente = Convert.ToBoolean(dr["EstCliente"]);

                    lista.Add(Cliente);
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
                cmd.Parameters.AddWithValue("@prmstrNombre",C.nombreCliente);
                cmd.Parameters.AddWithValue("@prmstrApellido",C.apellidoCliente);
                cmd.Parameters.AddWithValue("@prmIdDni", C.DNI);
                cmd.Parameters.AddWithValue("@prmIdTelefono", C.telefono);
                cmd.Parameters.AddWithValue("@prmbitEstado", C.estCliente);
                cmd.Parameters.AddWithValue("@prmIdTipoCliente", C.idTipoCliente.idTipoCliente);
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
        #endregion metodos
    }

}

