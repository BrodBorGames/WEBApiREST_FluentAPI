using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using WEBApiREST.Models;
using static WEBApiREST.Migrations.M002_AddUserTable;

namespace WEBApiREST.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.ToTable(UserTableName);
            builder.Property(x => x.Id).HasColumnName(IdColumnName);
            builder.Property(x => x.FirstName).HasColumnName(FirstNameColumnName);
            builder.Property(x => x.LastName).HasColumnName(LastNameColumnName);
            builder.Property(x => x.Age).HasColumnName(AgeColumnName);
            builder.Property(x => x.Telephone).HasColumnName(TelephoneColumnName);
            builder.Property(x => x.CollegeID).HasColumnName(CollegeIdColumnName);
            builder.HasKey(x => x.Id);
           
            builder.
                HasOne(e => e.College)
                .WithMany(x => x.Users)
                .HasForeignKey(e => e.CollegeID)
                .IsRequired();
        }

    }
}
