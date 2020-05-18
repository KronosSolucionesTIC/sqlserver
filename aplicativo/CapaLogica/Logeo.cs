using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;

namespace CapaLogica
{
    public class Logeo : LogeoDAO
    { 
        //atributos o campos 
        private string usuario;
        private string contraseña;

        //metodos get y set 
        public string Usuario
        {
            get
            { return usuario; }
            set
            { usuario = value; }
        }

        public string Contraseña
        {
            get
            { return contraseña; }
            set
            { contraseña = value; }
        }

        //Metidi para inicio de sesion
        public string inicio_sesion()
        {
            string ok = SP_inicio_Sesion(this.usuario, this.contraseña);
            return ok;
        }

        //Metodo para retornar el ID
        public string getId()
        {
            string Id = SP_id(this.usuario);
            return Id;
        }

        //Metodo para retornar el campo de bloqueado
        public string getBloqueo()
        {
            string bloqueo = SP_bloqueo(this.usuario);
            return bloqueo;
        }

        //Metodo para retornar el campo de activo
        public string getActivo()
        {
            string activo = SP_activo(this.usuario);
            return activo;
        }

        //Metodo para bloquear usuario
        public string getBloquear()
        {
            string bloqueado = SP_bloquear(this.usuario);
            return bloqueado;
        }

        //Metodo para guardar en el log de inicio de sesion
        public string getAccede()
        {
            DateTime fecha = DateTime.Now;
            string id = getId();
            string accede = SP_acceder(id,fecha);
            return accede;
        }

        //Metodo para guardar en el log de inicio de sesion
        public string getSalida()
        {
            DateTime fecha = DateTime.Now;
            string id = getId();
            string salida = SP_salida(id, fecha);
            return salida;
        }
    }

}
