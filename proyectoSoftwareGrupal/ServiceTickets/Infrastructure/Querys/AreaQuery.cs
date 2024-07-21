using Aplication.Interfaces.IArea;
using Aplication.Response;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using RestSharp.Authenticators.OAuth2;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aplication.Response.ServiceUser;

namespace Infrastructure.Querys
{
    public class AreaQuery : IAreaQuery
    {
        private readonly AppDbContext _context;

        public AreaQuery(AppDbContext context)
        {
            _context = context;
        }

        public Area GetAreaById(int id)
        {
            var area = _context.Area.Include(a => a.ticketCategories).FirstOrDefault(a => a.idArea == id);
            return area;
        }

        public List<Area> GetListArea()
        {
            var areas = _context.Area.Include(a => a.ticketCategories).ToList();
            return areas;
        }

        public UserResponse GetUser(int id)
        {
            var client = new RestClient("https://localhost:7051/api/Users/" + id);
            client.Authenticator = new OAuth2AuthorizationRequestHeaderAuthenticator("eyJhbGciOiJIUzUxMiIsInR5cCI6IkpXVCJ9.eyJuYW1laWQiOiIxIiwidW5pcXVlX25hbWUiOiJhZG1pbiIsImVtYWlsIjoicHNncnVwb2ludGVyQGdtYWlsLmNvbSIsInJvbGUiOiJBZG1pbmlzdHJhZG9yIiwibmJmIjoxNjY2NTU4MjU0LCJleHAiOjE2NjcxNjMwNTQsImlhdCI6MTY2NjU1ODI1NH0.t1ATSm6hi4FtilNR3-nxYlYaDuN625i-nKoLisnq__1eTenoPSLUEAfFuIw2SnzydXM3Ts99IATm1VxSh3BXNg", "Bearer");
            var request = new RestRequest();
            var response = client.Execute(request);

            if (response.StatusDescription == "Not Found")
            {
                return null;
            }

            UserResponse user = JsonConvert.DeserializeObject<UserResponse>(response.Content);
            return user;
        }

    }
}
