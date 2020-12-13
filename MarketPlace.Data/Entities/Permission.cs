using MarketPlace.Infrastructure.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MarketPlace.Data.Entities
{
    [Table("Permissions")]
    public class Permission:DomainEntity<int>
    {
        public int UserId { get; set; }
        public int ActionId { get; set; }
        public int FunctionId { get; set; }

        [ForeignKey("UserId")]
        public virtual CusUser CusUser { get; set; }

        [ForeignKey("ActionId")]
        public virtual DoAction DoAction { get; set; }

        [ForeignKey("FunctionId")]
        public virtual Function Function { get; set; }

    }
}
