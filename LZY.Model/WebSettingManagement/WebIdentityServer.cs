using LZY.Model.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LZY.Model.WebSettingManagement
{
    public class WebIdentityServer : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string SortCode { get; set; }
        public string Url { get; set; }//提供认证服务的URL
        public WebIdentityServer()
        {
            this.SortCode = BusinessEntityComponentsFactory.SortCodeByDefaultDateTime<WebSiteSettings>();
            this.Id = Guid.NewGuid();
        }

    }
}
