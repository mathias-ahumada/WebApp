using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace negocio
{
    public static class Seguridad
    {
       public static bool sessionActiva(object user)
        {
            ///no tocar esta funcion, anda bien
            usuario Usuario = user != null ? (usuario)user : null;
            if (Usuario != null && Usuario.id != 0)
                return true;
            else
                return false;
           

        }

        public static bool esAdmin(object user)
        {
            usuario Usuario = user != null ? (usuario)user : null;
            return Usuario != null ? Usuario.esAdmin : false;
        }
    }
}
