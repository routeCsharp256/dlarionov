using FluentMigrator;

namespace OzonEdu.MerchandiseService.Migrator.Migrations
{
    [Migration(15)]
    public class MerchPackPositionTable : Migration
    {
        public override void Up()
        {
            Create
                .Table("merch_pack_positions")
                .WithColumn("merch_pack_id").AsInt64().PrimaryKey().ForeignKey("merch_packs","id")
                .WithColumn("merch_id").AsInt64().PrimaryKey().ForeignKey("merches","id")
                .WithColumn("quantity").AsInt32().NotNullable();
        }

        public override void Down()
        {
            Delete.Table("merch_pack_positions");
        }
    }
}