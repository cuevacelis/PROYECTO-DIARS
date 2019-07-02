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
    public class datPersona
    {
        
        #region singleton
        private static readonly datPersona UnicaInstancia = new datPersona();
        public static datPersona Instancia
        {
            get
            {
                return datPersona.UnicaInstancia;
            }

        }
        #endregion singleton

        #region metodos
        public List<entPersona> ListarPersona()
        {
            SqlCommand cmd = null;
            List<entPersona> lista = new List<entPersona>();

            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spListarPersona", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {

                    entPersona Persona = new entPersona();
                    entTipoPersona TipoPersona = new entTipoPersona();

                    Persona.idPersona = Convert.ToInt32(dr["IdPersona"]);

                    //tp.desTipoCliente = Convert.ToInt16(dr["idTipoCliente"]);
                    TipoPersona.desTipoPersona = dr["DesTipoPersona"].ToString();
                    Persona.idTipoPersona = TipoPersona;

                    Persona.nombreyApellidoPersona = dr["Nombres"].ToString();
                    Persona.DNI = dr["Dni"].ToString();
                    Persona.telefono = Convert.ToInt32(dr["Telefono"]);
                    Persona.estPersona = Convert.ToBoolean(dr["EstPersona"]);

                    lista.Add(Persona);
                }

            }
            catch (Exception e)
            {
                throw e;
            }
            finally { cmd.Connection.Close(); }
            return lista;
        }

        public Boolean InsertarPersona(entPersona P)
        {
            SqlCommand cmd = null;
            Boolean insertar = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spInsertarPersona", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmstrNombres",P.nombreyApellidoPersona);
                cmd.Parameters.AddWithValue("@prmIdDni", P.DNI);
                cmd.Parameters.AddWithValue("@prmIdTelefono", P.telefono);
                cmd.Parameters.AddWithValue("@prmbitEstado", P.estPersona);
                cmd.Parameters.AddWithValue("@prmIdTipoPersona", P.idTipoPersona.idTipoPersona);
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

        public Boolean EditarPersona(entPersona P)
        {
            SqlCommand cmd = null;
            Boolean edita = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spEditarPersona", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmintidPersona", P.idPersona);
                cmd.Parameters.AddWithValue("@prmstrNombre", P.nombreyApellidoPersona);
                cmd.Parameters.AddWithValue("@prmIdDni", P.DNI);
                cmd.Parameters.AddWithValue("@prmIdTelefono", P.telefono);
                cmd.Parameters.AddWithValue("@prmbitEstado", P.estPersona);
                cmd.Parameters.AddWithValue("@prmIdTipoPersona", P.idTipoPersona.idTipoPersona);
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

        public entPersona BuscarPersona(int idPersona)
        {
            SqlCommand cmd = null;
            entPersona c = null;
            entTipoPersona tp = null;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spBuscarPersona", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmintidPersona", idPersona);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    c = new entPersona();
                    tp = new entTipoPersona();

                    c.idPersona = Convert.ToInt32(dr["IdPersona"]);

                    tp.idTipoPersona = Convert.ToInt32(dr["idTipoPersona"]);
                    //tc.desTipoCliente = dr["DesTipoCliente"].ToString();
                    c.idTipoPersona = tp;

                    c.nombreyApellidoPersona = Convert.ToString(dr["NombreYApellidoPersona"]);
                    c.DNI = Convert.ToString(dr["Dni"]);
                    c.telefono = Convert.ToInt32(dr["Telefono"]);
                    c.estPersona = Convert.ToBoolean(dr["EstPersona"]);

                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally { cmd.Connection.Close(); }
            return c;
        }

        public Boolean EliminarPersona(int idPersona)
        {
            SqlCommand cmd = null;
            Boolean elimina = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spEliminarPersona", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmintidPersona", idPersona);
                cn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i >= 0)
                { elimina = true; }

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



