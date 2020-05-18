using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;

namespace CapaLogica
{
    public class Consulta : ConsultaDAO
    {
        //atributos o campos 
        private string usuario;
        private string cliente;
        private string estado;

        //metodos get y set 
        public string Usuario
        {
            get
            { return usuario; }
            set
            { usuario = value; }
        }

        public string Cliente
        {
            get
            { return cliente; }
            set
            { cliente = value; }
        }

        public string Estado
        {
            get
            { return estado; }
            set
            { estado = value; }
        }

        //Metodo para consulta actualizar
        public DataTable getConsultaActualizar()
        {
            DataTable ok = SP_consulta(this.estado);
            return ok;
        } 

        //Metodo para retornar el ID
        public string getId()
        {
            string Id = SP_id(this.usuario);
            return Id;
        }

        //Metodo para retornar el Cliente
        public string getCliente()
        {
            string Cli = SP_cliente(this.usuario);
            return Cli;
        }
    }

}
