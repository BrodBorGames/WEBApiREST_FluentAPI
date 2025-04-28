using FluentMigrator;

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
            Insert.IntoTable("College")
                .Row(new {Name = "Первоуральский Металлургический Колледж", Director = "Антипина Ольга Феликсовна"})
                .Row(new { Name = "Первоуральский Политехникум", Director = "Иванов Иван Григорьевич" });

        }
    }
}
