using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Response
{
    public class TicketCategoryResponse
    {
        public int idTicketCategory { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public bool reqApproval { get; set; }
        public int minApprovers { get; set; }
        public int idAreadestino { get; set; }
        public bool active { get; set; }
    }
}
