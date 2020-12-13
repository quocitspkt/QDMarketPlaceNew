using MarketPlace.Data.Enums;
using MarketPlace.Data.Interfaces;
using MarketPlace.Infrastructure.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MarketPlace.Data.Entities
{
    [Table("ChatSessions")]
    public class ChatSession : DomainEntity<int>, IDateTracking, ISwitchable
    {
        public int BuyerId { get; set; }

        public int SellerId { get; set; }

        public int AdminId { get; set; }


        public string Content { get; set; }

        public int ProductId { get; set; }

        public bool Report { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }

        public Status Status { get; set; }

        public int OrderId { get; set; }
        [ForeignKey("OrderId")]
        public virtual Order Order { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }

        

    }
}
