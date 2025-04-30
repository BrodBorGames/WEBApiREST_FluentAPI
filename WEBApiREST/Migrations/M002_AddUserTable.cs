using FluentMigrator;
using static WEBApiREST.Migrations.M001_AddCollegeTable;

namespace WEBApiREST.Migrations
{
    [Migration(2, "Добавление таблицы User")]
    public class M002_AddUserTable : Migration
    {
        public const string UserTableName = "user";
        public const string IdColumnName = "id";
        public const string FirstNameColumnName = "first_name";
        public const string LastNameColumnName = "last_name";
        public const string AgeColumnName = "age";
        public const string TelephoneColumnName = "telephone";
        public const string CollegeIdColumnName = "college_id";
        public override void Down()
        {
            throw new NotImplementedException();
        }

        public override void Up()
        {
            Create.Table(UserTableName)
                .WithColumn(IdColumnName).AsGuid().NotNullable().PrimaryKey()
                .WithColumn(FirstNameColumnName).AsString().NotNullable()
                .WithColumn(LastNameColumnName).AsString().NotNullable()
                .WithColumn(AgeColumnName).AsInt32().Nullable()
                .WithColumn(TelephoneColumnName).AsString().Nullable()
                .WithColumn(CollegeIdColumnName).AsInt32().ForeignKey(CollegeTableName, M001_AddCollegeTable.IdColumnName);
        }
    }
}
