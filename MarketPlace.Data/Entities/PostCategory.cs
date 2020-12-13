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
    [Table("PostCategories")]
    public class PostCategory : DomainEntity<int>, ISortable, ISwitchable, IHasSeoMetaData
    {
        [StringLength(250)]
        
        public string Name { get; set; }

        public int SortOrder { get; set; }

        public Status Status { get; set; }

        [StringLength(158)]
        
        public string SeoPageTitle { get; set; }

        [StringLength(128)]
       
        public string SeoAlias { get; set; }
        [StringLength(158)]
        
        public string SeoKeyWord { get; set; }
        [StringLength(158)]
       
        public string SeoDescription { get; set; }
    }
}
