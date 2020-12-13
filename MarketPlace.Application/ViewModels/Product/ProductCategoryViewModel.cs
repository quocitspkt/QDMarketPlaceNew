using MarketPlace.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MarketPlace.Application.ViewModels.Product
{
    public class ProductCategoryViewModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(128)]
        public string Name { get; set; }
        public string Description;

        public int? ParentId { get; set; }
        public int? HomeOrder { get; set; }
        public bool? HomeFlag { get; set; }

        [Required]
        [StringLength(128)]
        public string SeoPageTitle { set; get; }

        [Required]
        [StringLength(128)]
        public string SeoAlias { set; get; }

        [StringLength(158)]
        public string SeoKeyWord { set; get; }

        [StringLength(158)]
        public string SeoDescription { set; get; }

        public Status Status { set; get; }

        public DateTime DateCreated { set; get; }

        public DateTime DateModified { set; get; }

        public int SortOrder { set; get; }

        public ICollection<ProductViewModel> Products { set; get; }
    }
}
