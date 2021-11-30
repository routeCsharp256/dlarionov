using FluentMigrator;

namespace OzonEdu.MerchandiseService.Migrator.Migrations
{
    [Migration(11)]
    public class MerchTable : Migration
    {
        public override void Up()
        {
            Create
                .Table("merches")
                .WithColumn("id").AsInt64().Identity().PrimaryKey()
                .WithColumn("sku").AsInt64().NotNullable().Unique()
                .WithColumn("name").AsString(200).NotNullable()
                .WithColumn("merch_type_id").AsInt32().NotNullable()
                .WithColumn("clothing_size_id").AsInt32().Nullable().ForeignKey("clothing_sizes", "id");
        }

        public override void Down()
        {
            Delete.Table("merches");
        }
    }
}