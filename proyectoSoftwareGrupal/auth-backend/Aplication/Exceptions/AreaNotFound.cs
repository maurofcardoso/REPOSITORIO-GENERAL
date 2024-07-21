using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Exceptions
{
    public class AreaNotFound : Exception
    {
            public string mensaje;
        public AreaNotFound(string mensaje)
        {
            this.mensaje = mensaje;
        }
    }
}
