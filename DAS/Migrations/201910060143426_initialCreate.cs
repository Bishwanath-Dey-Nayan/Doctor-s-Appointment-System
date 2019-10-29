namespace DAS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Appointments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        P_Name = c.String(),
                        Age = c.String(),
                        Mobile = c.String(),
                        Prev_visit = c.Boolean(nullable: false),
                        DoctorID = c.Int(nullable: false),
                        ChamberID = c.Int(nullable: false),
                        SechduleId = c.Int(nullable: false),
                        Schedule_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Chambers", t => t.ChamberID)
                .ForeignKey("dbo.Doctors", t => t.DoctorID)
                .ForeignKey("dbo.Schedules", t => t.Schedule_ID)
                .Index(t => t.DoctorID)
                .Index(t => t.ChamberID)
                .Index(t => t.Schedule_ID);
            
            CreateTable(
                "dbo.Chambers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        HospitalName = c.String(),
                        Area = c.String(),
                        Address = c.String(),
                        DoctorID = c.Int(nullable: false),
                        DoctorName = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Doctors", t => t.DoctorID)
                .Index(t => t.DoctorID);
            
            CreateTable(
                "dbo.Doctors",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Designation = c.String(),
                        Gender = c.String(),
                        Image = c.String(),
                        MobileNo = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                        BMDCNo = c.String(),
                        Description = c.String(),
                        Degree_Spec = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.PaitentHistories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        DoctorID = c.Int(nullable: false),
                        ChamberID = c.Int(nullable: false),
                        Name = c.String(),
                        Age = c.String(),
                        Address = c.String(),
                        ProblemSpec = c.String(),
                        Description = c.String(),
                        MettingDate = c.DateTime(nullable: false),
                        NextMeet = c.DateTime(nullable: false),
                        PrescribedMed = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Chambers", t => t.ChamberID)
                .ForeignKey("dbo.Doctors", t => t.DoctorID)
                .Index(t => t.DoctorID)
                .Index(t => t.ChamberID);
            
            CreateTable(
                "dbo.Schedules",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        DoctorID = c.Int(nullable: false),
                        ChamberID = c.Int(nullable: false),
                        StartTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(nullable: false),
                        Fee = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Chambers", t => t.ChamberID)
                .ForeignKey("dbo.Doctors", t => t.DoctorID)
                .Index(t => t.DoctorID)
                .Index(t => t.ChamberID);
            
            CreateTable(
                "dbo.ConfirmedAppointments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        AppointmentID = c.Int(nullable: false),
                        Confirmed = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Appointments", t => t.AppointmentID)
                .Index(t => t.AppointmentID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ConfirmedAppointments", "AppointmentID", "dbo.Appointments");
            DropForeignKey("dbo.Schedules", "DoctorID", "dbo.Doctors");
            DropForeignKey("dbo.Schedules", "ChamberID", "dbo.Chambers");
            DropForeignKey("dbo.Appointments", "Schedule_ID", "dbo.Schedules");
            DropForeignKey("dbo.PaitentHistories", "DoctorID", "dbo.Doctors");
            DropForeignKey("dbo.PaitentHistories", "ChamberID", "dbo.Chambers");
            DropForeignKey("dbo.Chambers", "DoctorID", "dbo.Doctors");
            DropForeignKey("dbo.Appointments", "DoctorID", "dbo.Doctors");
            DropForeignKey("dbo.Appointments", "ChamberID", "dbo.Chambers");
            DropIndex("dbo.ConfirmedAppointments", new[] { "AppointmentID" });
            DropIndex("dbo.Schedules", new[] { "ChamberID" });
            DropIndex("dbo.Schedules", new[] { "DoctorID" });
            DropIndex("dbo.PaitentHistories", new[] { "ChamberID" });
            DropIndex("dbo.PaitentHistories", new[] { "DoctorID" });
            DropIndex("dbo.Chambers", new[] { "DoctorID" });
            DropIndex("dbo.Appointments", new[] { "Schedule_ID" });
            DropIndex("dbo.Appointments", new[] { "ChamberID" });
            DropIndex("dbo.Appointments", new[] { "DoctorID" });
            DropTable("dbo.ConfirmedAppointments");
            DropTable("dbo.Schedules");
            DropTable("dbo.PaitentHistories");
            DropTable("dbo.Doctors");
            DropTable("dbo.Chambers");
            DropTable("dbo.Appointments");
        }
    }
}
