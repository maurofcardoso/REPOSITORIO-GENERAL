using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.ResponseCompleto
{
    public class BalanceComplete
    {
        public BalanceComplete()
        {
            this.ListOrdenResponseCompleto = new List<OrdenResponseCompleto>();
        }

        public int CantidadVentas { get; set; }

        public decimal RecaudationDay { get; set; }

        public List<OrdenResponseCompleto> ListOrdenResponseCompleto { get; set; }
    }
}
