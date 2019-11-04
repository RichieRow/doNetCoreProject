using LZY.Model.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LZY.Model.ApplicationManagement
{
    /// <summary>
    /// 导航栏的类别
    /// </summary>
    public class WorkPlaceCategory : IEntity
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string WorkArea { get; set; }//工作范围 比如说是用在微信小程序的，还是用在普通web端的
        public string Description { get; set; }
        public string SortCode { get; set; }
        public WorkPlaceCategory()
        {
            Id = Guid.NewGuid();
            SortCode = BusinessEntityComponentsFactory.SortCodeByDefaultDateTime<WorkPlaceCategory>();
        }

    }
}
