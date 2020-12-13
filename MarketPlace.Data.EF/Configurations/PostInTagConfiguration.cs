using MarketPlace.Data.EF.Extentions;
using MarketPlace.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarketPlace.Data.EF.Configurations
{
    public class PostInTagConfiguration : DbEntityConfiguration<PostInTag>
    {
        public override void Configure(EntityTypeBuilder<PostInTag> entity)
        {
            entity.Property(c => c.TagId).HasMaxLength(50).IsRequired().HasColumnType("varchar(50)");
            // etc.
        }
    }
}
