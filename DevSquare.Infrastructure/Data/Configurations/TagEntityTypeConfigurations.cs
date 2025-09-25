using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSquare.Core.Domain.Configurations
{
    public class TagEntityTypeConfigurations : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.ToTable("Tags");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Name)
                .IsRequired()
                .HasColumnType("nvarchar(100)");

            builder.HasIndex(t => t.Name)
                .IsUnique();

            builder.HasMany(t => t.Posts)
                .WithMany(p => p.Tags)
                .UsingEntity("PostTags");
        }
    }
}
