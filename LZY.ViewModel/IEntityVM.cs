using System;
using System.Collections.Generic;
using System.Text;

namespace LZY.ViewModel
{
    public interface IEntityVM
    {
        Guid Id { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        string SortCode { get; set; }
        bool IsNew { get; set; }         // 是否是新创建的对象，要特别注意在实际使用时候的赋值
    }
}
