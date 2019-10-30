using System;
using System.Collections.Generic;
using System.Text;

namespace LZY.Model.BusinessManegement.Audit
{
    /// <summary>
    /// 审核类型操作的业务对象的审核结果
    /// </summary>
    public enum AuditResultEnum
    {
        Passed,   // 已通过
        Fail,     // 不通过
        Defeated  // 作废
    }
}
