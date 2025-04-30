using FluentMigrator;
using static WEBApiREST.Migrations.M001_AddCollegeTable;

namespace WEBApiREST.Migrations
{
    [Migration(3, "Добавление данных в таблицу College")]
    public class M003_InsertDataCollege : Migration
    {
        public override void Down()
        {
            throw new NotImplementedException();
        }

        public override void Up()
        {
            Insert.IntoTable(CollegeTableName)
                .Row(new {name = "Первоуральский Металлургический Колледж", director = "Антипина Ольга Феликсовна"})
                .Row(new { name = "Первоуральский Политехникум", director = "Иванов Иван Григорьевич" });

        }
    }
}
