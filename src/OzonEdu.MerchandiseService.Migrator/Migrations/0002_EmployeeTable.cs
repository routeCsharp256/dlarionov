using FluentMigrator;

namespace OzonEdu.MerchandiseService.Migrator.Migrations
{
    [Migration(12)]
    public class EmployeeTable : Migration
    {
        public override void Up()
        {
            Create
                .Table("employees")
                .WithColumn("id").AsInt64().Identity().PrimaryKey()
                .WithColumn("name").AsString(200).NotNullable()
                .WithColumn("email").AsString(120).NotNullable()
                .WithColumn("clothing_size_id").AsInt32().NotNullable().ForeignKey("clothing_sizes", "id");
        }

        public override void Down()
        {
            Delete.Table("employees");
        }
    }
}