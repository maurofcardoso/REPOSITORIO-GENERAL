using Aplication.Response.ServiceUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Response
{
    public class AreaResponse
    {
        public int idArea { get; set; }
        public bool activeArea { get; set; }
        public string nameArea { get; set; }
        public string description { get; set; }
        public DateTime dateCreate { get; set; }
        public int createUser { get; set; }
        public DateTime dateUpdate { get; set; }
        public int updateUser { get; set; }

        public List<TicketCategoryResponse> ticketCategories { get; set; }
    }
}
