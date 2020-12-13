using MarketPlace.Data.Enums;
using MarketPlace.Data.Interfaces;
using MarketPlace.Infrastructure.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MarketPlace.Data.Entities
{
    [Table("Functions")]
    public class Function : DomainEntity<int>, ISwitchable, ISortable
    {
        [StringLength(50)]

        public string Code { get; set; }
        [StringLength(50)]
    
        public string Name { get; set; }
        public int ParentId { get; set; }
        
        public Status Status { get; set; }
        public int SortOrder { get; set; }

    }
}
