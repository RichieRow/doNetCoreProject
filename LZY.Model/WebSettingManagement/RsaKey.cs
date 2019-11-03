using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LZY.Model.WebSettingManagement
{
    /// <summary>
    /// Rsa加密的实体
    /// </summary>
    public class RsaKey : IEntity
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string SortCode { get; set; }
        public string PublicKey { get; set; }//公钥
        public string PrivateKey { get; set; }//私钥
            
       
    }
}
