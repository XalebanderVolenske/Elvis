namespace Elvis.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Communities",
                c => new
                    {
                        CommunityIndex = c.String(name: "Community Index", nullable: false, maxLength: 255),
                        Name = c.String(nullable: false, maxLength: 255),
                        PostCode = c.Double(name: "Post Code", nullable: false),
                        DistrictCode = c.Double(name: "District Code", nullable: false),
                        ValidFrom = c.DateTime(name: "Valid From", nullable: false, storeType: "date"),
                        ValidTo = c.DateTime(name: "Valid To", storeType: "date"),
                    })
                .PrimaryKey(t => t.CommunityIndex)
                .ForeignKey("dbo.Districts", t => t.DistrictCode)
                .Index(t => t.DistrictCode);
            
            CreateTable(
                "dbo.Districts",
                c => new
                    {
                        Code = c.Double(nullable: false),
                        Name = c.String(nullable: false, maxLength: 255),
                        regional_constituency = c.String(nullable: false, maxLength: 255),
                        ValidFrom = c.DateTime(name: "Valid From", nullable: false, storeType: "date"),
                        ValidTo = c.DateTime(name: "Valid To", storeType: "date"),
                    })
                .PrimaryKey(t => t.Code)
                .ForeignKey("dbo.Constituencies", t => t.regional_constituency)
                .Index(t => t.regional_constituency);
            
            CreateTable(
                "dbo.Constituencies",
                c => new
                    {
                        Code = c.String(nullable: false, maxLength: 255),
                        name = c.String(nullable: false, maxLength: 255),
                        ProvinceCode = c.Double(nullable: false),
                        ValidFrom = c.DateTime(name: "Valid From", nullable: false, storeType: "date"),
                        ValidTo = c.DateTime(name: "Valid To", storeType: "date"),
                    })
                .PrimaryKey(t => t.Code)
                .ForeignKey("dbo.Provinces", t => t.ProvinceCode)
                .Index(t => t.ProvinceCode);
            
            CreateTable(
                "dbo.Provinces",
                c => new
                    {
                        Code = c.Double(nullable: false),
                        Name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Code);
            
            CreateTable(
                "dbo.Electorial_Register",
                c => new
                    {
                        ElectionCode = c.String(nullable: false, maxLength: 255),
                        CommunityIndex = c.String(name: "Community Index", nullable: false, maxLength: 255),
                        EligibleVoters = c.Long(name: "Eligible Voters"),
                    })
                .PrimaryKey(t => new { t.ElectionCode, t.CommunityIndex })
                .ForeignKey("dbo.Elections", t => t.ElectionCode)
                .ForeignKey("dbo.Communities", t => t.CommunityIndex)
                .Index(t => t.ElectionCode)
                .Index(t => t.CommunityIndex);
            
            CreateTable(
                "dbo.Elections",
                c => new
                    {
                        Code = c.String(nullable: false, maxLength: 255),
                        Name = c.String(nullable: false, maxLength: 255),
                        DueDate = c.DateTime(name: "Due Date", nullable: false, storeType: "date"),
                    })
                .PrimaryKey(t => t.Code);
            
            CreateTable(
                "dbo.Election_Parties",
                c => new
                    {
                        PartyCode = c.String(name: "Party Code", nullable: false, maxLength: 255),
                        ElectionCode = c.String(name: "Election Code", nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.PartyCode)
                .ForeignKey("dbo.Parties", t => t.PartyCode)
                .ForeignKey("dbo.Elections", t => t.ElectionCode)
                .Index(t => t.PartyCode)
                .Index(t => t.ElectionCode);
            
            CreateTable(
                "dbo.Parties",
                c => new
                    {
                        Code = c.String(nullable: false, maxLength: 255),
                        FullName = c.String(name: "Full Name", nullable: false, maxLength: 255),
                        Color = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.Code);
            
            CreateTable(
                "dbo.Vote_Data",
                c => new
                    {
                        CommunityIndex = c.String(name: "Community Index", nullable: false, maxLength: 255),
                        ElectionCode = c.String(name: "Election Code", nullable: false, maxLength: 255),
                        PartyCode = c.String(name: "Party Code", nullable: false, maxLength: 255),
                        Votes = c.Double(),
                    })
                .PrimaryKey(t => t.CommunityIndex)
                .ForeignKey("dbo.Election_Parties", t => t.PartyCode)
                .ForeignKey("dbo.Communities", t => t.CommunityIndex)
                .Index(t => t.CommunityIndex)
                .Index(t => t.PartyCode);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vote_Data", "Community Index", "dbo.Communities");
            DropForeignKey("dbo.Electorial_Register", "Community Index", "dbo.Communities");
            DropForeignKey("dbo.Electorial_Register", "ElectionCode", "dbo.Elections");
            DropForeignKey("dbo.Election_Parties", "Election Code", "dbo.Elections");
            DropForeignKey("dbo.Vote_Data", "Party Code", "dbo.Election_Parties");
            DropForeignKey("dbo.Election_Parties", "Party Code", "dbo.Parties");
            DropForeignKey("dbo.Constituencies", "ProvinceCode", "dbo.Provinces");
            DropForeignKey("dbo.Districts", "regional_constituency", "dbo.Constituencies");
            DropForeignKey("dbo.Communities", "District Code", "dbo.Districts");
            DropIndex("dbo.Vote_Data", new[] { "Party Code" });
            DropIndex("dbo.Vote_Data", new[] { "Community Index" });
            DropIndex("dbo.Election_Parties", new[] { "Election Code" });
            DropIndex("dbo.Election_Parties", new[] { "Party Code" });
            DropIndex("dbo.Electorial_Register", new[] { "Community Index" });
            DropIndex("dbo.Electorial_Register", new[] { "ElectionCode" });
            DropIndex("dbo.Constituencies", new[] { "ProvinceCode" });
            DropIndex("dbo.Districts", new[] { "regional_constituency" });
            DropIndex("dbo.Communities", new[] { "District Code" });
            DropTable("dbo.Vote_Data");
            DropTable("dbo.Parties");
            DropTable("dbo.Election_Parties");
            DropTable("dbo.Elections");
            DropTable("dbo.Electorial_Register");
            DropTable("dbo.Provinces");
            DropTable("dbo.Constituencies");
            DropTable("dbo.Districts");
            DropTable("dbo.Communities");
        }
    }
}
