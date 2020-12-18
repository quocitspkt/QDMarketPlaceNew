using MarketPlace.Data.Enums;
using MarketPlace.Data.Interfaces;
using MarketPlace.Infrastructure.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MarketPlace.Data.Entities
{
    [Table("Orders")]
    public class Order : DomainEntity<int>, ISwitchable
    {
        
        public DateTime OrderDate { get; set; }
        public Guid CustomerId { get; set; }

        public Status Status { get; set; }

        [ForeignKey("CustomerId")]
        public virtual AppUser AppUser { get; set; }
    }
}
