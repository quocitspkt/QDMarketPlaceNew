using MarketPlace.Data.Enums;
using MarketPlace.Data.Interfaces;
using MarketPlace.Infrastructure.SharedKernel;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MarketPlace.Data.Entities
{
    [Table("CusUsers")]
    public class CusUser : IdentityUser<int>, ISwitchable
    {
        

        [StringLength(50)]

        public string Password { get; set; }

        [StringLength(50)]

        public string FullName { get; set; }

        public DateTime BirthDay { get; set; }

        [StringLength(250)]

        public string Address { get; set; }
        public DateTime RegisteredDate { get; set; }
        public DateTime LastLoginDate { get; set; }
        public Status Status { get; set; }

    }
}
