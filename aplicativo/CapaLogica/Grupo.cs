using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;

namespace CapaLogica
{
    public class Grupo : GrupoDAO
    {
        //atributos o campos 
        private string marca;

        //metodos get y set 
        public string Marca
        {
            get
            { return marca; }
            set
            { marca = value; }
        }

        //Metodo para marca
        public DataTable getMarca()
        {
            DataTable ok = SP_marca();
            return ok;
        }

        //Metodo para modelo
        public DataTable getModelo()
        {
            DataTable ok = SP_modelo(this.marca);
            return ok;
        }
    }

}
