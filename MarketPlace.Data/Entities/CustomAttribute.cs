using MarketPlace.Infrastructure.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MarketPlace.Data.Entities
{
    [Table("CustomAttributes")]
    public class CustomAttribute:DomainEntity<int>
    {
        [StringLength(128)]

        public string Name { get; set; }

    }
}
