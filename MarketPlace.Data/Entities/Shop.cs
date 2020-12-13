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
    [Table("Shops")]
    public class Shop : DomainEntity<int>, IDateTracking, ISwitchable, IHasOwner
    {
        [StringLength(250)]
        
        public string Name { get; set; }

        
        public string Description { get; set; }

        [StringLength(250)]
       
        public string Image { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public int Rate { get; set; }
        public int Warning { get; set; }
        public bool Deposit { get; set; }
        public Status Status { get; set; }
        public int OwnerId { get; set; }

        [ForeignKey("OwnerId")]
        public virtual CusUser User { get; set; }

    }
}
