using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class ConsultaDAO : conexion
    {

        public DataTable SP_consulta(string estado)//Procedimiento para inicio de sesion
        {
            try
            {              
                //Se crea el comando que pasa el procedimiento almacenado
                SqlCommand comando = new SqlCommand("SP_consulta", conn);
                comando.CommandType = CommandType.StoredProcedure;

                //Se declara el DataAdapter
                SqlDataAdapter da = new SqlDataAdapter(comando);
                da.MissingSchemaAction = MissingSchemaAction.AddWithKey;

                //Contenedor de datos
                DataTable dt = new DataTable();
                //Se llena el contenedor
                da.Fill(dt);
                //Retorna el valor de dt
                return dt;
            }
            finally
            {
                conn.Close();
            }

        }

        public string SP_id(string usuario)//Procedimiento que trae el ID del usuario
        {
            try
            {
                string Id = "";

                SqlDataReader rpt;
                SqlCommand comando = new SqlCommand("SP_id", conn);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@USER", SqlDbType.VarChar, 15).Value = usuario;

                conn.Open();
                rpt = comando.ExecuteReader();
                if (rpt.Read() == true)
                {
                    Id = rpt["ID_TBCLIENT"].ToString();
                }
                return Id;
            }
            catch (Exception exc)
            {
                return exc.Message;

            }
            finally
            {
                conn.Close();
            }

        }

        public string SP_cliente(string usuario)//Procedimiento que trae el cliente
        {
            try
            {
                string Cli = "";

                SqlDataReader rpt;
                SqlCommand comando = new SqlCommand("SP_cliente", conn);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@USER", SqlDbType.VarChar, 15).Value = usuario;

                conn.Open();
                rpt = comando.ExecuteReader();
                if (rpt.Read() == true)
                {
                    Cli = rpt["NAME_CLIENT"].ToString();
                }
                return Cli;
            }
            catch (Exception exc)
            {
                return exc.Message;

            }
            finally
            {
                conn.Close();
            }

        }
    }
}