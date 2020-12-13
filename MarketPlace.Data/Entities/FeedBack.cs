using MarketPlace.Data.Enums;
using MarketPlace.Data.Interfaces;
using MarketPlace.Infrastructure.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MarketPlace.Data.Entities
{
    [Table("FeedBacks")]
    public class FeedBack : DomainEntity<int>, IDateTracking,IHasOwner,ISwitchable
    {
        public int ProductId { get; set; }


        public string Content { get; set; }

        public bool Positive { get; set; }
        
        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }

        public int OwnerId { get; set; }

        public Status Status { get; set; }

        [ForeignKey("OwnerId")]
        public virtual CusUser User { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }
    }
}
