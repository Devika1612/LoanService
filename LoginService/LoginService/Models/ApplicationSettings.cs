using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginService.Models
{
    public class ApplicationSettings
    {
        public string JWT_Secret { get; set; }
        // public string Client_URL { get; set; }    "Client_URL": "http://localhost:4200"
    }
}
