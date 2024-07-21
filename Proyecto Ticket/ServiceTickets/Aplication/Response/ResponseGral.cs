using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Response
{
    public class ResponseGral
    {
        public int Codigo { get; set; }
        public object Json { get; set; }

        public ResponseGral(int codigo, object json)
        {
            Codigo = codigo;
            Json = json;
        }
    }
}
