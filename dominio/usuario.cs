using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{

    
    public class usuario
    {


        public int id { get; set; }
        public string user { get; set; }
        public string pass { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public DateTime fechaNacimiento { get; set; }

        public bool esAdmin { get; set; }

        public string imagen { get; set; }

        
    }
}
