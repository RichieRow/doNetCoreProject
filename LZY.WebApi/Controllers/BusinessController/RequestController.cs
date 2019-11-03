using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityModel.Client;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LZY.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        [HttpGet]
        public string Post(string id,string pwd)
        {
         
            var diso = DiscoveryClient.GetAsync("http://localhost:5000/").Result;
            if (diso.IsError)
            {
                return diso.Error;
            }

            //授权服务器根据客户端发来的请求返回令牌
            var tokenClient = new TokenClient(diso.TokenEndpoint, id, pwd);
            var tokenResponse = tokenClient.RequestClientCredentialsAsync("api").Result;
            if (tokenResponse.IsError)
            {
                return tokenResponse.Error;
            }
            //如果成功，则返回令牌信息
            else
            {
                return tokenResponse.AccessToken;
            }
        }
    }
}