using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;

namespace CapaLogica
{
    public class Medidor : MedidorDAO
    {
        //atributos o campos 
        private string zona;
        private string codigos;

        //metodos get y set 
        public string Zona
        {
            get
            { return zona; }
            set
            { zona = value; }
        }

        public string Codigos
        {
            get
            { return codigos; }
            set
            { codigos = value; }
        }

        //Metodo para marca
        public DataTable getZona()
        {
            DataTable ok = SP_zona();
            return ok;
        }

        //Metodo para codigos
        public DataTable getCodigos()
        {
            DataTable ok = SP_codigos();
            return ok;
        }

        //Metido para ayuda
        public DataTable getAyuda()
        {
            DataTable ok = SP_ayuda();
            return ok;
        }
    }

}