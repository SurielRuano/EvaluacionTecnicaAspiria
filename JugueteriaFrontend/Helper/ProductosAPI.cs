using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace JugueteriaFrontend.Helper
{
    public class ProductosAPI
    {
        public HttpClient Initial() {

            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:44328/");
            return client;
        }        
    }
}
