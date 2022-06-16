using BootcampFinalProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootcampFinalProject.Domain.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(300).IsRequired();

            //builder.HasMany(e => e.Products)
            //    .WithOne(e => e.Category)
            //    .HasForeignKey(e => e.CategoryId)
            //    .OnDelete(DeleteBehavior.NoAction);

           
        }
    }
}

