using System;
using System.Collections.Generic;
using System.Text;

namespace LZY.Model.BusinessManegement.Audit
{
    /// <summary>
    /// 审核类型操作的状态
    /// </summary>
    public enum AuditStatusEnum
    {
        Received,   // 已接收
        Pending,    // 挂起中
        Finished,   // 已完成
    }
}
