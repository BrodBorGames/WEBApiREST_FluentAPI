using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using WEBApiREST.Models;

namespace WEBApiREST.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            //builder.HasKey(u => u.Id);
            //builder.HasOne<CollegeEntity>();
            builder.HasKey(x => x.Id);
            builder.
                HasOne(e => e.College)
                .WithMany(x => x.Users)
                .HasForeignKey(e => e.CollegeID)
                .IsRequired();
        }

    }
}
