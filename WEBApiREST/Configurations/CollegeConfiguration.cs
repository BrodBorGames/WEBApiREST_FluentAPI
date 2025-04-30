using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WEBApiREST.Models;
using static WEBApiREST.Migrations.M001_AddCollegeTable;

namespace WEBApiREST.Configurations
{
    public class CollegeConfiguration : IEntityTypeConfiguration<CollegeEntity>
    {
        public void Configure(EntityTypeBuilder<CollegeEntity> builder)
        {
            builder.ToTable(CollegeTableName);
            builder.Property(x => x.Id).HasColumnName(IdColumnName);
            builder
                .HasMany(e => e.Users)
                .WithOne(e => e.College)
                .HasForeignKey(e => e.CollegeID)
                .IsRequired();
            
            builder.Property(x => x.Name).HasColumnName(NameColumnName);
            builder.Property(x => x.Director).HasColumnName(DirectorColumnName);
            
            //builder.Ignore(x => x.Users);
        }
    }
}
