using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using CapaEntidad;

namespace CapaAccesoDatos
{
    public class datTrabajador
    {
        #region singleton
        private static readonly datTrabajador UnicaInstancia = new datTrabajador();
        public static datTrabajador Instancia
        {
            get
            {
                return datTrabajador.UnicaInstancia;
            }

        }
        #endregion singleton

        #region metodos
        public List<entTrabajador> ListarTrabajador()
        {
            SqlCommand cmd = null;
            List<entTrabajador> lista = new List<entTrabajador>();

            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spListarTrabajador", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    entTrabajador Trabajador = new entTrabajador();
                    entPersona Persona = new entPersona();

                    Trabajador.idTrabajador = Convert.ToInt32(dr["IdTrabajador"]);

                    //tp.desTipoCliente = Convert.ToInt16(dr["idTipoCliente"]);
                    Trabajador.profesion = dr["Profesion"].ToString();
                    Trabajador.ingresos = Convert.ToInt64(dr["Ingresos"]);

                    Persona.nombreyApellidoPersona = dr["Nombres"].ToString();
                    Persona.DNI = dr["Dni"].ToString();
                    Persona.telefono = Convert.ToInt32(dr["Telefono"]);
                    Persona.estPersona = Convert.ToBoolean(dr["EstPersona"]);

                    lista.Add(Trabajador);
                }

            }
            catch (Exception e)
            {
                throw e;
            }
            finally { cmd.Connection.Close(); }
            return lista;
        }

        public Boolean InsertarTrabajador(entTrabajador T)
        {
            SqlCommand cmd = null;
            Boolean insertar = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spInsertarTrabajador", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@prmstrNombre", T.nombreyApellidoPersona);
                //cmd.Parameters.AddWithValue("@prmIdDni", T.DNI);
                //cmd.Parameters.AddWithValue("@prmIdTelefono", T.telefono);
                //cmd.Parameters.AddWithValue("@prmbitEstado", T.estPersona);
                cmd.Parameters.AddWithValue("@prmIdPersona", T.idPersona.idPersona);
                cmd.Parameters.AddWithValue("@prmintIngresos",T.ingresos);
                cmd.Parameters.AddWithValue("@prmstrProfesion", T.profesion);
                cmd.Parameters.AddWithValue("@prmstrRol", T.rol);
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

        public Boolean EditarTrabajador(entTrabajador T)
        {
            SqlCommand cmd = null;
            Boolean edita = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spEditarTrabajador", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmintidPersona", T.idPersona.idPersona);
                cmd.Parameters.AddWithValue("@prmintIngresos", T.ingresos);
                cmd.Parameters.AddWithValue("@prmstrProfesion", T.profesion);
                cmd.Parameters.AddWithValue("@prmstrRol", T.rol);
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

        public entTrabajador BuscarTrabajador(int idTrabajador)
        {
            SqlCommand cmd = null;
            entTrabajador T = null;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spBuscarTrabajador", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmintidTrabajador", idTrabajador);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    T = new entTrabajador();

                    T.idTrabajador = Convert.ToInt32(dr["IdTrabajador"]);

                    //tc.desTipoCliente = dr["DesTipoCliente"].ToString();

                    T.ingresos = Convert.ToInt64(dr["Ingresos"]);
                    T.profesion = Convert.ToString(dr["Profesion"]);
                    T.rol = dr["Telefono"].ToString();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally { cmd.Connection.Close(); }
            return T;
        }

        public Boolean EliminarTrabajador(int idTrabajador)
        {
            SqlCommand cmd = null;
            Boolean elimina = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spEliminarTrabajador", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmintidTrabajador", idTrabajador);
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
