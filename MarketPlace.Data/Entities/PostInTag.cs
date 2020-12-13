using MarketPlace.Infrastructure.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MarketPlace.Data.Entities
{
    [Table("PostInTags")]
    public class PostInTag:DomainEntity<int>
    {
        public int PostId { get; set; }
        public string TagId { get; set; }

        [ForeignKey("PostId")]
        public virtual Post Post { get; set; }
        [ForeignKey("TagId")]
        public virtual Tag Tag { get; set; }
    }
}
