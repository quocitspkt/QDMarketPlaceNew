using MarketPlace.Infrastructure.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MarketPlace.Data.Entities
{
    [Table("CusRoles")]
    public class CusRole:DomainEntity<int>
    {

        [StringLength(50)]
        public string Name { get; set; }
    }
}
