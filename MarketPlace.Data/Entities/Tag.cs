using MarketPlace.Infrastructure.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MarketPlace.Data.Entities
{
    [Table("Tags")]
    public class Tag:DomainEntity<string>
    {
        [StringLength(250)]
       
        public string Name { get; set; }
    }
}
