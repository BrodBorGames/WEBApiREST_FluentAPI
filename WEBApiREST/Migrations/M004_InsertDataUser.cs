using FluentMigrator;
using static WEBApiREST.Migrations.M002_AddUserTable;

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
            Insert.IntoTable(UserTableName)
                .Row(new { id = Guid.NewGuid(), first_name = "Данил", last_name = "Юсупов", age = 19, telephone = "+79326044223", college_id = 1 })
                .Row(new { id = Guid.NewGuid(), first_name = "Иван", last_name = "Черняков", age = 20, telephone = "+79026044223", college_id = 2 });
        }
    }
}
