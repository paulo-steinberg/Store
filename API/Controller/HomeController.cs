using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace API.Controller
{
    public class HomeController : ControllerBase
    {
        [Route("error")]
        public string Error()
        {
            throw new Exception("Error test");
            return "Error";
        }
    }
}