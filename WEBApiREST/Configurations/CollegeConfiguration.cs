using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WEBApiREST.Models;

namespace WEBApiREST.Configurations
{
    public class CollegeConfiguration : IEntityTypeConfiguration<CollegeEntity>
    {
        public void Configure(EntityTypeBuilder<CollegeEntity> builder)
        {
            builder
                .HasMany(e => e.Users)
                .WithOne(e => e.College)
                .HasForeignKey(e => e.CollegeID)
                .IsRequired();
            //builder.Ignore(x => x.Users);
        }
    }
}
