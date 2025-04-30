using FluentMigrator;

namespace WEBApiREST.Migrations
{
    [Migration(1, "Добавление таблицы College")]
    public class M001_AddCollegeTable : Migration
    {
        public const string CollegeTableName = "college";
        public const string IdColumnName = "id";
        public const string NameColumnName = "name";
        public const string DirectorColumnName = "director";

        public override void Down()
        {
            Delete.Table("College");
        }

        public override void Up()
        {
            Create.Table(CollegeTableName)
                .WithColumn(IdColumnName).AsInt32().PrimaryKey().NotNullable().Identity()
                .WithColumn(NameColumnName).AsString().NotNullable()
                .WithColumn(DirectorColumnName).AsString().NotNullable();

        }
    }
}
