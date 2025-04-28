using FluentMigrator;

namespace WEBApiREST.Migrations
{
    [Migration(2, "Добавление таблицы User")]
    public class M002_AddUserTable : Migration
    {
        public override void Down()
        {
            throw new NotImplementedException();
        }

        public override void Up()
        {
            Create.Table("User")
                .WithColumn("Id").AsGuid().NotNullable().PrimaryKey()
                .WithColumn("FirstName").AsString().NotNullable()
                .WithColumn("LastName").AsString().NotNullable()
                .WithColumn("Age").AsInt32().Nullable()
                .WithColumn("Telephone").AsString().Nullable()
                .WithColumn("CollegeID").AsInt32().ForeignKey("College", "Id");
        }
    }
}
