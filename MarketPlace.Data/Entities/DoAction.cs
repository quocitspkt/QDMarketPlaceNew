using MarketPlace.Infrastructure.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MarketPlace.Data.Entities
{
    [Table("DoActions")]
    public class DoAction:DomainEntity<int>
    {
        [StringLength(50)]

        public string Code { get; set; }
        [StringLength(50)]

        public string Name { get; set; }
    }
}
