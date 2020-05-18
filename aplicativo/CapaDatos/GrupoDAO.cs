using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class GrupoDAO : conexion
    {

        public DataTable SP_marca()//Procedimiento para inicio de sesion
        {
            try
            {
                //Se crea el comando que pasa el procedimiento almacenado
                SqlCommand comando = new SqlCommand("SP_marca", conn);
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

        public DataTable SP_modelo(string marca)//Procedimiento para inicio de sesion
        {
            if (marca == "Seleccione...")
            {
                marca = "";
            }

            try
            {
                //Se crea el comando que pasa el procedimiento almacenado
                SqlCommand comando = new SqlCommand("SP_modelo", conn);
                comando.CommandType = CommandType.StoredProcedure;

                //Se agregan parametros
                comando.Parameters.Add("@MARCA", SqlDbType.VarChar).Value = marca;

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
    }
}