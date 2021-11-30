using FluentMigrator;

namespace OzonEdu.MerchandiseService.Migrator.Migrations
{
    [Migration(16)]
    public class MerchReceiptApplicationTable: Migration
    {
        public override void Up()
        {
            Create
                .Table("merch_receipt_applications")
                .WithColumn("id").AsInt64().Identity().PrimaryKey()
                .WithColumn("employee_id").AsInt64().NotNullable().ForeignKey("employees", "id")
                .WithColumn("merch_pack_id").AsInt64().NotNullable().ForeignKey("merch_packs", "id")
                .WithColumn("application_status_id").AsInt32().NotNullable()
                .WithColumn("created_at").AsDate().NotNullable()
                .WithColumn("give_out_at").AsDate().NotNullable();
        }

        public override void Down()
        {
            Delete.Table("merch_receipt_applications");
        }
    }
}