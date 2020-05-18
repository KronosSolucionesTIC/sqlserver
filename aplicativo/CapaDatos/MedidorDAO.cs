using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class MedidorDAO : conexion
    {

        public DataTable SP_zona()//Procedimiento para inicio de sesion
        {
            try
            {
                //Se crea el comando que pasa el procedimiento almacenado
                SqlCommand comando = new SqlCommand("SP_zona", conn);
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

        public DataTable SP_codigos()//Procedimiento para inicio de sesion
        {
            try
            {
                //Se crea el comando que pasa el procedimiento almacenado
                SqlCommand comando = new SqlCommand("SP_codigos", conn);
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

        public DataTable SP_ayuda()//Procedimiento para inicio de sesion
        {
            try
            {
                //Se crea el comando que pasa el procedimiento almacenado
                SqlCommand comando = new SqlCommand("SP_ayuda", conn);
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
    }
}