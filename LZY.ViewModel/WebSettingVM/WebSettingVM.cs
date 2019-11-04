using LZY.Model.Attachments;
using LZY.Model.WebSettingManagement;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LZY.ViewModel.WebSettingVM
{
    public class WebSettingVM
    {
        [Key]
        public Guid Id { get; set; }
        [StringLength(20)]
        public string Name { get; set; }          //网站标题
        [StringLength(20)]
        public string Suffix { get; set; }        //网站后缀
        [StringLength(20)]
        public string DomainName { get; set; }    //网站域名
        public string KeyWords { get; set; }      //网站关键字
        public string Description { get; set; }   //网站描述
        public string Statistics { get; set; }    //网站统计代码
        public string SortCode { get; set; }
        public string LogoURL { get; set; }       //网站LOGO
        [StringLength(30)]
        public string Copyright { get; set; }     // 网站版权
        [StringLength(30)]
        public string ICP { get; set; }           // 备案号


        public WebSettingVM()
        { }
        public WebSettingVM(WebSiteSettings bo)
        {
            Id                        = bo.Id;
            Name                      = bo.Name;
            Suffix                    = bo.Suffix;
            DomainName                = bo.DomainName;
            KeyWords                  = bo.KeyWords;
            Description               = bo.Description;
            Statistics                = bo.Statistics;
            SortCode                  = bo.SortCode;
            LogoURL                   = "http://onedrive.ibibii.com/?/images/2019/11/04/JgkshvWUYR/untitled.png";
            if (bo.Logo!=null)
            {
                if(bo.Logo.UploadPath!=null)
                {
                    LogoURL           = bo.Logo.UploadPath;
                }
            }
            Copyright                 = bo.Copyright;
            ICP                       = bo.ICP;
        }

        public void MapToBo(WebSiteSettings bo)
        {
            bo.Id                          = Id;
            bo.Name                        = Name;
            bo.Suffix                      = Suffix;
            bo.DomainName                  = DomainName;
            bo.KeyWords                    = bo.KeyWords;
            bo.Description                 = Description;
            //bo.Statistics                  = Statistics;
            //bo.SortCode                    = SortCode;
            if (bo.Logo != null)
            {
                bo.Logo.UploadPath = LogoURL;
                bo.Logo.UploadedTime = DateTime.Now;
            }
            //LogoURL                     = "http://onedrive.ibibii.com/?/images/2019/11/04/JgkshvWUYR/untitled.png";
            //if (bo.Logo !               = null)
            //{
            //    if (bo.Logo.UploadPath != null)
            //    {
            //        LogoURL             = bo.Logo.UploadPath;
            //    }
            //}
            bo.Copyright                   = Copyright;
            bo.ICP                         = ICP;
        }


    }
}
