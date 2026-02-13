using Core.Entities;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Config;

public class PostConfiguration : IEntityTypeConfiguration<Post>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Post> builder)
    {
        builder.Property(p => p.Title)
            .IsRequired()
            .HasMaxLength(100);
    }
}
