using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LZY.DataAccess;
using LZY.Model.WebSettingManagement;
using LZY.ViewModel.WebSettingVM;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace LZY.WebApi.Controllers.AdminBGController
{
    /// <summary>
    /// 这是配置网站用的
    /// </summary>
    public class WebSettingController : BaseController
    {
        private readonly IEntityRepository<WebSiteSettings> _bo;
       

        public WebSettingController(IEntityRepository<WebSiteSettings> bo)
        {
            _bo = bo;//bo指的是business obje(业务对象)
        }

        /// <summary>
        /// 获取网站的基本信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<WebSettingVM> GetWebSite()
        {
            var ws = await _bo.GetAllIncludingAsyn(x => x.Logo);
            var boVM = new WebSettingVM(ws.FirstOrDefault());
            return boVM;
        }

        [HttpPost]
        public async Task<bool> EditWebSiteAsync([FromBody]WebSettingVM webSettingVM)
        {
            var ws =await _bo.GetAllIncludingAsyn(x => x.Logo);
                ws= ws.Where(x => x.Id == webSettingVM.Id);
            webSettingVM.MapToBo(ws.FirstOrDefault());
            var status =await _bo.AddOrEditAndSaveAsyn(ws.FirstOrDefault());
            
            return status;
           
        }

    }
}