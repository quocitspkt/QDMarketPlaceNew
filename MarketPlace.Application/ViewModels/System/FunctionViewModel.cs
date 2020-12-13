using MarketPlace.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MarketPlace.Application.ViewModels.System
{
    public class FunctionViewModel
    {
        public string Id { get; set; }
        [Required]
        [StringLength(128)]
        public string Name { set; get; }

        [Required]
        [StringLength(50)]
        public string Code { set; get; }


        [StringLength(128)]
        public string ParentId { set; get; }

        //public string IconCss { get; set; }
        public int SortOrder { set; get; }
        public Status Status { set; get; }
    }
}
