using IdentityModel.Client;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace LZY.ConsoleTest
{
    public class Program
    {
        static void Main(string[] args)
        {
            //请求授权服务器
            var diso = DiscoveryClient.GetAsync("http://localhost:56182").Result;
            if (diso.IsError)
            {
                Console.WriteLine(diso.Error);
            }

            //授权服务器根据客户端发来的请求返回令牌
            var tokenClient = new TokenClient(diso.TokenEndpoint, "lzy", "secret");
            var tokenResponse = tokenClient.RequestClientCredentialsAsync("api").Result;
            if (tokenResponse.IsError)
            {
                Console.WriteLine(tokenResponse.Error);
            }
            //如果成功，则打印输出返回的令牌信息
            else
            {
                Console.WriteLine(tokenResponse.Json);
            }

            //创建HttpClient对象
            var httpClient = new HttpClient();

            //设置Authorization的Value值
            httpClient.SetBearerToken(tokenResponse.AccessToken);

            //根据授权服务器返回的令牌信息请求Api资源
            var response = httpClient.GetAsync("http://localhost:56182/api/values").Result;

            //如果返回结果为成功，输出Api资源的结果
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine(response.Content.ReadAsStringAsync().Result);
            }
        }

    }
}
