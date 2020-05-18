using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;

namespace CapaLogica
{
    public class Cargue : cargueDAO
    {
        //atributos o campos 
        private string zona;

        //metodos get y set 
        public string Zona
        {
            get
            { return zona; }
            set
            { zona = value; }
        }

        //Metodo para retornar el ID zona
        public string getZona()
        {
            string Id_zona = SP_get_zona(this.zona);
            return Id_zona;
        }
    }

}
