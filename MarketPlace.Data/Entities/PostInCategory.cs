using MarketPlace.Infrastructure.SharedKernel;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarketPlace.Data.Entities
{
    [Table("PostInCategories")]
    public class PostInCategory : DomainEntity<int>
    {
        public int PostId { get; set; }
        public int CategoryId { get; set; }

        [ForeignKey("PostId")]
        public virtual Post Post { get; set; }

        [ForeignKey("CategoryId")]
        public virtual PostCategory PostCategory { get; set; }
    }
}