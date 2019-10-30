﻿using LZY.Model.Attachments;
using LZY.Model.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LZY.Model.WebSettingManagement
{
   public class WebSiteSettings : IEntity
    {
        [Key]
        public Guid Id { get; set; }
        [StringLength(20)]
        public string Name { get; set; }//网站标题
        [StringLength(20)]
        public string Suffix { get; set; }//网站后缀
        [StringLength(20)]
        public string DomainName { get; set; }//网站域名
        public string KeyWords { get; set; }      //网站关键字
        public string Description { get; set; }//网站描述
        public string Statistics { get; set; }//网站统计代码
        public string SortCode { get; set; }
        public BusinessImage Logo { get; set; } //网站LOGO
        [StringLength(30)]
        public string Copyright { get; set; }// 网站版权
        [StringLength(30)]
        public string ICP { get; set; }// 备案号
        public WebSiteSettings()
        {
            this.SortCode = BusinessEntityComponentsFactory.SortCodeByDefaultDateTime<WebSiteSettings>();
            this.Id = Guid.NewGuid();
        }
    }
}
