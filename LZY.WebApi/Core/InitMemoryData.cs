using IdentityServer4.Models;
using IdentityServer4.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LZY.WebApi.Core
{
    public class InitMemoryData
    {
        #region 定义要保护的资源（webapi）
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("api", "API接口安全测试")
            };
        }
        #endregion

        #region 定义可访问客户端
        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client
                {
                    //客户端id自定义
                    ClientId = "lzy",

                    AllowedGrantTypes = GrantTypes.ClientCredentials, ////设置模式，客户端模式

                    // 加密验证
                    ClientSecrets = new List<Secret>
                    {
                        new Secret("secret".Sha256())
                    },

                    // client可以访问的范围，在GetScopes方法定义的名字。
                    AllowedScopes = new List<string>
                    {
                        "api"
                    }
                }
            };
        }


        
        #endregion
    }
}
