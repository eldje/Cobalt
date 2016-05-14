using System.Data.Entity.Migrations;
using System.Diagnostics.CodeAnalysis;

namespace Cobalt.DataAccess.Migrations
{
    [SuppressMessage("ReSharper", "ArgumentsStyleLiteral")]
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                {
                    AddressId = c.Int(nullable: false, identity: true),
                    Street = c.String(maxLength: 125),
                    Number = c.String(maxLength: 125),
                    ConstructionAddress = c.String(maxLength: 125)
                })
                .PrimaryKey(t => t.AddressId);

            CreateTable(
                "dbo.Complaints",
                c => new
                {
                    ComplaintId = c.Int(nullable: false, identity: true),
                    ProjectId = c.Int(nullable: false),
                    OccupantContactId = c.Int(),
                    SubContractorContactId = c.Int(),
                    ComplaintStatus = c.Int(nullable: false, defaultValue: 0),
                    EmailStatus = c.Int(nullable: false, defaultValue: 0),
                    ActionByNotEc = c.Int(nullable: false, defaultValue: 0),
                    ActionByNotEcComment = c.String(maxLength: 125),
                    ComplaintName = c.String(maxLength: 125),
                    Vo = c.Boolean(nullable: false, defaultValue: false),
                    SolvedSub = c.Boolean(nullable: false, defaultValue: false),
                    SolvedPm = c.Boolean(nullable: false, defaultValue: false),
                    SolvedAll = c.Boolean(nullable: false, defaultValue: false),
                    Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    AffirmationInhabitant = c.String(maxLength: 125),
                    RemarkArchitect = c.String(maxLength: 255),
                    RemarkClient = c.String(maxLength: 255),
                    RemarkEc = c.String(maxLength: 255),
                    RemarkEngineer = c.String(maxLength: 255),
                    RemarkExpert = c.String(maxLength: 255),
                    InternalRemarkEc = c.String(maxLength: 255),
                    StorageDirectory = c.String(maxLength: 255),
                    ActionDate = c.DateTime(),
                    DueDate = c.DateTime(),
                    LastUpdated = c.DateTime(),
                    DateCreated = c.DateTime(defaultValueSql: "GETDATE()"),
                    RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion")
                })
                .PrimaryKey(t => t.ComplaintId)
                .ForeignKey("dbo.Contacts", t => t.OccupantContactId)
                .ForeignKey("dbo.Projects", t => t.ProjectId, cascadeDelete: true)
                .ForeignKey("dbo.Contacts", t => t.SubContractorContactId)
                .Index(t => t.ProjectId)
                .Index(t => t.OccupantContactId)
                .Index(t => t.SubContractorContactId);

            CreateTable(
                "dbo.Contacts",
                c => new
                {
                    ContactId = c.Int(nullable: false, identity: true),
                    AddressId = c.Int(nullable: false),
                    FirstName = c.String(maxLength: 125),
                    LastName = c.String(maxLength: 125),
                    Email = c.String(maxLength: 125),
                    Phone = c.String(maxLength: 125),
                    ContactType = c.Int(nullable: false, defaultValue: 0)
                })
                .PrimaryKey(t => t.ContactId)
                .ForeignKey("dbo.Addresses", t => t.AddressId, cascadeDelete: true)
                .Index(t => t.AddressId);

            CreateTable(
                "dbo.Projects",
                c => new
                {
                    ProjectId = c.Int(nullable: false, identity: true),
                    ClientContactId = c.Int(nullable: false, defaultValue: 0),
                    ArchitectContactId = c.Int(nullable: false, defaultValue: 0),
                    ProjectManagerId = c.Int(nullable: false, defaultValue: 0),
                    ProjectAddressId = c.Int(nullable: false, defaultValue: 0),
                    ProjectName = c.String(maxLength: 255)
                })
                .PrimaryKey(t => t.ProjectId)
                .ForeignKey("dbo.Contacts", t => t.ArchitectContactId)
                .ForeignKey("dbo.Contacts", t => t.ClientContactId)
                .ForeignKey("dbo.Addresses", t => t.ProjectAddressId)
                .ForeignKey("dbo.Contacts", t => t.ProjectManagerId)
                .Index(t => t.ClientContactId)
                .Index(t => t.ArchitectContactId)
                .Index(t => t.ProjectManagerId)
                .Index(t => t.ProjectAddressId);
        }

        public override void Down()
        {
            DropForeignKey("dbo.Complaints", "SubContractorContactId", "dbo.Contacts");
            DropForeignKey("dbo.Complaints", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.Projects", "ProjectManagerId", "dbo.Contacts");
            DropForeignKey("dbo.Projects", "ProjectAddressId", "dbo.Addresses");
            DropForeignKey("dbo.Projects", "ClientContactId", "dbo.Contacts");
            DropForeignKey("dbo.Projects", "ArchitectContactId", "dbo.Contacts");
            DropForeignKey("dbo.Complaints", "OccupantContactId", "dbo.Contacts");
            DropForeignKey("dbo.Contacts", "AddressId", "dbo.Addresses");
            DropIndex("dbo.Projects", new[] {"ProjectAddressId"});
            DropIndex("dbo.Projects", new[] {"ProjectManagerId"});
            DropIndex("dbo.Projects", new[] {"ArchitectContactId"});
            DropIndex("dbo.Projects", new[] {"ClientContactId"});
            DropIndex("dbo.Contacts", new[] {"AddressId"});
            DropIndex("dbo.Complaints", new[] {"SubContractorContactId"});
            DropIndex("dbo.Complaints", new[] {"OccupantContactId"});
            DropIndex("dbo.Complaints", new[] {"ProjectId"});
            DropTable("dbo.Projects");
            DropTable("dbo.Contacts");
            DropTable("dbo.Complaints");
            DropTable("dbo.Addresses");
        }
    }
}