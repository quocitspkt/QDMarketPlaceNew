using MarketPlace.Infrastructure.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MarketPlace.Data.Entities
{
    [Table("AttributeValues")]
    public class AttributeValue:DomainEntity<int>
    {
        public int AttributeId { get; set; }

        [StringLength(128)]
        
        public string Name { get; set; }

        public virtual CustomAttribute CustomAttribute { get; set; }
    }
}
