namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMVCMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Address",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        AddressLine1 = c.String(),
                        AddressLine2 = c.String(),
                        PostCode = c.Int(nullable: false),
                        AddressTypeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AddressType", t => t.AddressTypeID, cascadeDelete: true)
                .Index(t => t.AddressTypeID);
            
            CreateTable(
                "dbo.AddressType",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Course",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.CourseTraining",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.DelegateAddress",
                c => new
                    {
                        AddressID = c.Int(nullable: false),
                        DelegateID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.AddressID, t.DelegateID })
                .ForeignKey("dbo.Address", t => t.AddressID, cascadeDelete: true)
                .ForeignKey("dbo.Delegate", t => t.DelegateID, cascadeDelete: true)
                .Index(t => t.AddressID)
                .Index(t => t.DelegateID);
            
            CreateTable(
                "dbo.Delegate",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        PhoneNumber = c.Int(nullable: false),
                        Email = c.String(),
                        CompanyName = c.String(),
                        DieataryRequirementID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.DietaryRequirement", t => t.DieataryRequirementID, cascadeDelete: true)
                .Index(t => t.DieataryRequirementID);
            
            CreateTable(
                "dbo.DietaryRequirement",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Requirement = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.DelegateTraining",
                c => new
                    {
                        DelegateID = c.Int(nullable: false),
                        TrainingsID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.DelegateID, t.TrainingsID })
                .ForeignKey("dbo.Delegate", t => t.DelegateID, cascadeDelete: true)
                .ForeignKey("dbo.Training", t => t.TrainingsID, cascadeDelete: true)
                .Index(t => t.DelegateID)
                .Index(t => t.TrainingsID);
            
            CreateTable(
                "dbo.Training",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Cost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        RegistrationClosingDate = c.DateTime(nullable: false),
                        VenueID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Venue", t => t.VenueID, cascadeDelete: true)
                .Index(t => t.VenueID);
            
            CreateTable(
                "dbo.Venue",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Seats = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DelegateTraining", "TrainingsID", "dbo.Training");
            DropForeignKey("dbo.Training", "VenueID", "dbo.Venue");
            DropForeignKey("dbo.DelegateTraining", "DelegateID", "dbo.Delegate");
            DropForeignKey("dbo.DelegateAddress", "DelegateID", "dbo.Delegate");
            DropForeignKey("dbo.Delegate", "DieataryRequirementID", "dbo.DietaryRequirement");
            DropForeignKey("dbo.DelegateAddress", "AddressID", "dbo.Address");
            DropForeignKey("dbo.Address", "AddressTypeID", "dbo.AddressType");
            DropIndex("dbo.Training", new[] { "VenueID" });
            DropIndex("dbo.DelegateTraining", new[] { "TrainingsID" });
            DropIndex("dbo.DelegateTraining", new[] { "DelegateID" });
            DropIndex("dbo.Delegate", new[] { "DieataryRequirementID" });
            DropIndex("dbo.DelegateAddress", new[] { "DelegateID" });
            DropIndex("dbo.DelegateAddress", new[] { "AddressID" });
            DropIndex("dbo.Address", new[] { "AddressTypeID" });
            DropTable("dbo.Venue");
            DropTable("dbo.Training");
            DropTable("dbo.DelegateTraining");
            DropTable("dbo.DietaryRequirement");
            DropTable("dbo.Delegate");
            DropTable("dbo.DelegateAddress");
            DropTable("dbo.CourseTraining");
            DropTable("dbo.Course");
            DropTable("dbo.AddressType");
            DropTable("dbo.Address");
        }
    }
}
