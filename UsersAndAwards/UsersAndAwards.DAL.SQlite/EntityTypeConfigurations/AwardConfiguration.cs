using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UsersAndAwards.Entities;

namespace UsersAndAwards.DAL.SQLiteDAO.EntityTypeConfigurations
{
    public class AwardConfiguration : IEntityTypeConfiguration<AwardEntity>
    {
        public void Configure(EntityTypeBuilder<AwardEntity> builder)
        {
            builder.ToTable("awards");
            builder.HasKey(award => award.Id);
            builder.HasIndex(award => award.Id).IsUnique();
            builder.Property(award => award.Title).HasMaxLength(250);
        }
    }
}
