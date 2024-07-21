using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Models
{
    public class TicketRequest
    {
        public int PriorityId { get; set; }
        public int CategoryId { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string fileAdjunt { get; set; }
    }
}
