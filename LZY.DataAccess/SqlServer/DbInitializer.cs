using LZY.DataAccess.EntityFramework;
using LZY.Model.WebSettingManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LZY.DataAccess.SqlServer
{
    public class DbInitializer
    {
        static EntityDbContext _Context;
        public static void Initialize(EntityDbContext context)
        {
            _Context = context;
            context.Database.EnsureCreated(); //如果创建了，则不会重新创建
            AddWebSiteSetting();
        }
        public static void AddWebSiteSetting()
        {
            #region 网站的基本信息
            if (_Context.WebSiteSittings.Any())
                return;
            var siteSettings = new WebSiteSettings { Name = "瞧一瞧不花一分钱", Suffix = "真的", DomainName = "域名", KeyWords = "搜索关键字", Logo = null, Description = "这里填写描述", Copyright = "版权归LZY所有", ICP = "这里填写ICP网站备案号", Statistics = "这里填写网站统计代码" };
            _Context.WebSiteSittings.Add(siteSettings);
            _Context.SaveChanges();
            #endregion
        }
    }
}
