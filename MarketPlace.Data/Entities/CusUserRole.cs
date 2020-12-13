using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MarketPlace.Data.Entities
{
    [Table("CusUserRoles")]
    public class CusUserRole : IdentityRole<int>
    {
        public CusUserRole(): base()
        {

        }
        public CusUserRole(string name,string description):base(name)
        {
            this.Description = description;
        }
        [StringLength(250)]
        public string Description { get; set; }
    }
}
