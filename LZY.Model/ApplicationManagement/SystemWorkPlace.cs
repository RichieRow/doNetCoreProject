using LZY.Model.Attachments;
using LZY.Model.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LZY.Model.ApplicationManagement
{
    /// <summary>
    /// 导航栏/菜单栏
    /// </summary>
    public class SystemWorkPlace : IEntity
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string SortCode { get; set; }
        public string Url { get; set; }//指向页面URL
        public WorkPlaceCategory workPlaceCategory { get; set; }
        public virtual BusinessImage IconPath { get; set; }
        public bool IsUsed { get; set; }
        public virtual SystemWorkPlace personWorkPlace { get; set; }//上级导航栏

        public SystemWorkPlace()
        {
            Id = Guid.NewGuid();
            SortCode = BusinessEntityComponentsFactory.SortCodeByDefaultDateTime<SystemWorkPlace>();
            IsUsed = true;
        }

    }
}
