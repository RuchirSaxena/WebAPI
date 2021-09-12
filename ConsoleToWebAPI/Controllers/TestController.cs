using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleToWebAPI.Controllers
{
    [ApiController]
    [Route("test/[action]")]
    public class TestController: ControllerBase
    {
        public string Get()
        {
            return "Hello From GET";
        }

        public string Get1()
        {
            return "Hello From GET";
        }
    }
}
