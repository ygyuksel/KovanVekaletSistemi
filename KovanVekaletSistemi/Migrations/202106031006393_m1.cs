namespace KovanVekaletSistemi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AuthorityAssignments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AssignmentFrom_Id = c.Int(nullable: false),
                        AssignmentTo_Id = c.Int(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Baslik = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.AssignmentFrom_Id)
                .ForeignKey("dbo.Employees", t => t.AssignmentTo_Id)
                .Index(t => t.AssignmentFrom_Id)
                .Index(t => t.AssignmentTo_Id);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RegistirationNumber = c.Int(nullable: false),
                        UserName = c.String(),
                        FullName = c.String(),
                        JobTitle_Id = c.Int(nullable: false),
                        Baslik = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.JobTitles", t => t.JobTitle_Id)
                .Index(t => t.JobTitle_Id);
            
            CreateTable(
                "dbo.JobTitles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Baslik = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.JobTitleAuthorityRoles",
                c => new
                    {
                        JobTitle_Id = c.Int(nullable: false),
                        AuthorityRole_Id = c.Int(nullable: false),
                        Id = c.Int(nullable: false, identity: true),
                        Baslik = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => new { t.JobTitle_Id, t.AuthorityRole_Id })
                .ForeignKey("dbo.AuthorityRoles", t => t.AuthorityRole_Id)
                .ForeignKey("dbo.JobTitles", t => t.JobTitle_Id)
                .Index(t => t.JobTitle_Id)
                .Index(t => t.AuthorityRole_Id);
            
            CreateTable(
                "dbo.AuthorityRoles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Baslik = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AuthorityRoleAuthorityAssignments",
                c => new
                    {
                        AuthorityRole_Id = c.Int(nullable: false),
                        AuthorityAssignment_Id = c.Int(nullable: false),
                        Id = c.Int(nullable: false, identity: true),
                        Baslik = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => new { t.AuthorityRole_Id, t.AuthorityAssignment_Id })
                .ForeignKey("dbo.AuthorityAssignments", t => t.AuthorityAssignment_Id)
                .ForeignKey("dbo.AuthorityRoles", t => t.AuthorityRole_Id)
                .Index(t => t.AuthorityRole_Id)
                .Index(t => t.AuthorityAssignment_Id);
            
            CreateTable(
                "dbo.TimeOffRequests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TimeOffType = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        RequestFrom_Id = c.Int(),
                        RequestTo_Id = c.Int(),
                        AuthorityRole_Id = c.Int(nullable: false),
                        ApproveStatus = c.String(),
                        ApprovedBy_Id = c.Int(),
                        ApprovedTime = c.DateTime(nullable: false),
                        Baslik = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.ApprovedBy_Id)
                .ForeignKey("dbo.AuthorityRoles", t => t.AuthorityRole_Id)
                .ForeignKey("dbo.Employees", t => t.RequestFrom_Id)
                .ForeignKey("dbo.Employees", t => t.RequestTo_Id)
                .Index(t => t.RequestFrom_Id)
                .Index(t => t.RequestTo_Id)
                .Index(t => t.AuthorityRole_Id)
                .Index(t => t.ApprovedBy_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TimeOffRequests", "RequestTo_Id", "dbo.Employees");
            DropForeignKey("dbo.TimeOffRequests", "RequestFrom_Id", "dbo.Employees");
            DropForeignKey("dbo.TimeOffRequests", "AuthorityRole_Id", "dbo.AuthorityRoles");
            DropForeignKey("dbo.TimeOffRequests", "ApprovedBy_Id", "dbo.Employees");
            DropForeignKey("dbo.AuthorityAssignments", "AssignmentTo_Id", "dbo.Employees");
            DropForeignKey("dbo.AuthorityAssignments", "AssignmentFrom_Id", "dbo.Employees");
            DropForeignKey("dbo.JobTitleAuthorityRoles", "JobTitle_Id", "dbo.JobTitles");
            DropForeignKey("dbo.JobTitleAuthorityRoles", "AuthorityRole_Id", "dbo.AuthorityRoles");
            DropForeignKey("dbo.AuthorityRoleAuthorityAssignments", "AuthorityRole_Id", "dbo.AuthorityRoles");
            DropForeignKey("dbo.AuthorityRoleAuthorityAssignments", "AuthorityAssignment_Id", "dbo.AuthorityAssignments");
            DropForeignKey("dbo.Employees", "JobTitle_Id", "dbo.JobTitles");
            DropIndex("dbo.TimeOffRequests", new[] { "ApprovedBy_Id" });
            DropIndex("dbo.TimeOffRequests", new[] { "AuthorityRole_Id" });
            DropIndex("dbo.TimeOffRequests", new[] { "RequestTo_Id" });
            DropIndex("dbo.TimeOffRequests", new[] { "RequestFrom_Id" });
            DropIndex("dbo.AuthorityRoleAuthorityAssignments", new[] { "AuthorityAssignment_Id" });
            DropIndex("dbo.AuthorityRoleAuthorityAssignments", new[] { "AuthorityRole_Id" });
            DropIndex("dbo.JobTitleAuthorityRoles", new[] { "AuthorityRole_Id" });
            DropIndex("dbo.JobTitleAuthorityRoles", new[] { "JobTitle_Id" });
            DropIndex("dbo.Employees", new[] { "JobTitle_Id" });
            DropIndex("dbo.AuthorityAssignments", new[] { "AssignmentTo_Id" });
            DropIndex("dbo.AuthorityAssignments", new[] { "AssignmentFrom_Id" });
            DropTable("dbo.TimeOffRequests");
            DropTable("dbo.AuthorityRoleAuthorityAssignments");
            DropTable("dbo.AuthorityRoles");
            DropTable("dbo.JobTitleAuthorityRoles");
            DropTable("dbo.JobTitles");
            DropTable("dbo.Employees");
            DropTable("dbo.AuthorityAssignments");
        }
    }
}
