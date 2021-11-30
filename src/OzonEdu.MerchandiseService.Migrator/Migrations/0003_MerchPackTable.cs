using FluentMigrator;

namespace OzonEdu.MerchandiseService.Migrator.Migrations
{
    [Migration(13)]
    public class MerchPackTable : Migration
    {
        public override void Up()
        {
            Create
                .Table("merch_packs")
                .WithColumn("id").AsInt64().PrimaryKey()
                .WithColumn("name").AsString(200).NotNullable();
        }

        public override void Down()
        {
            Delete.Table("merch_packs");
        }
    }
}