using Aplication.Interfaces;
using Aplication.Interfaces.Area;
using Aplication.Response;
using Domain.Entities;
using Infraestructure.Persistence;
using RestSharp;
using RestSharp.Authenticators;
using RestSharp.Authenticators.OAuth2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Querys
{
    public class AreaQuerys : IAreaQuery
    {
        public bool Exists(int id, string jwt)
        {
            var client = new RestClient("https://localhost:7233/api/Area/" + id);
            client.Authenticator = new OAuth2AuthorizationRequestHeaderAuthenticator(jwt, "Bearer");
            var request = new RestRequest();
            var response = client.Execute(request);

            if (response.StatusDescription == "Not Found")
            {
                return false;
            }
            return true;
        }
    }
}
