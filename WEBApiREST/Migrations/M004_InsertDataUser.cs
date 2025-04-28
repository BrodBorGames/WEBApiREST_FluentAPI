using FluentMigrator;

namespace WEBApiREST.Migrations
{
    [Migration(4, "Добавление данных в табилцу User")]
    public class M004_InsertDataUser : Migration
    {
        public override void Down()
        {
            throw new NotImplementedException();
        }

        public override void Up()
        {
            Insert.IntoTable("User")
                .Row(new { Id = Guid.NewGuid(), FirstName = "Данил", LastName = "Юсупов", Age = 19, Telephone = "+79326044223", CollegeID = 1 })
                .Row(new { Id = Guid.NewGuid(), FirstName = "Иван", LastName = "Черняков", Age = 20, Telephone = "+79026044223", CollegeID = 2 });
        }
    }
}
