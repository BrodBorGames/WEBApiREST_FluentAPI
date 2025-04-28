using FluentMigrator;

namespace WEBApiREST.Migrations
{
    [Migration(1, "Добавление таблицы College")]
    public class M001_AddCollegeTable : Migration
    {
        public override void Down()
        {
            Delete.Table("College");
        }

        public override void Up()
        {
            Create.Table("College")
                .WithColumn("Id").AsInt32().PrimaryKey().NotNullable().Identity()
                .WithColumn("Name").AsString().NotNullable()
                .WithColumn("Director").AsString().NotNullable();

        }
    }
}
