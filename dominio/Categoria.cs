using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Categoria
    {

        public int _idCategoria { get; set; }
        public string _nombreCategoria { get; set; }
        public override string ToString()
        {
            return _nombreCategoria;
        }

        
    }
}

