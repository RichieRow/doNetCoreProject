using LZY.Model.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LZY.Model.ApplicationOrganization
{
    public class Department : IEntity
    {
        [Key]
        public Guid Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(1000)]
        public string Description { get; set; }
        [StringLength(150)]
        public string SortCode { get; set; }
        public bool IsActiveDepartment { get; set; }

        [ForeignKey("ParentDepartmentId")]
        public virtual Department ParentDepartment { get; set; }  // 上级部门

        public Department()
        {
            this.Id = Guid.NewGuid();
            this.IsActiveDepartment = true;
            this.SortCode = BusinessEntityComponentsFactory.SortCodeByDefaultDateTime<Department>();
        }
    }
}
