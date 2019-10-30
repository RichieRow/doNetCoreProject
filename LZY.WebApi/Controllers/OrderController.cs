using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LZY.WebApi.Controllers
{
    [Authorize]
    public class OrderController : BaseController
    {
        // GET api/order
        [HttpGet]
        public string Get()
        {
            

            return "123";
        }
    }
}