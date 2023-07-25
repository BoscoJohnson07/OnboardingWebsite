using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace OnboardingWebsite.Migrations
{
    /// <inheritdoc />
    public partial class usertable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Approvals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Empid = table.Column<string>(type: "text", nullable: false),
                    Empname = table.Column<string>(type: "text", nullable: false),
                    Approved = table.Column<bool>(type: "boolean", nullable: true),
                    Cancelled = table.Column<bool>(type: "boolean", nullable: true),
                    Date_Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Date_Modified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Created_by = table.Column<string>(type: "text", nullable: false),
                    Modified_by = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Approvals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeAdditionalInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Empid = table.Column<string>(type: "text", nullable: false),
                    Disability = table.Column<bool>(type: "boolean", nullable: true),
                    Disablility_type = table.Column<string>(type: "text", nullable: true),
                    Covid_VaccSts = table.Column<string>(type: "text", nullable: false),
                    Vacc_Certificate = table.Column<string>(type: "text", nullable: true),
                    Date_Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Date_Modified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Created_by = table.Column<string>(type: "text", nullable: false),
                    Modified_by = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeAdditionalInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeAddressDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Empid = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    Country = table.Column<string>(type: "text", nullable: false),
                    State = table.Column<string>(type: "text", nullable: false),
                    City = table.Column<string>(type: "text", nullable: false),
                    Pincode = table.Column<string>(type: "text", nullable: false),
                    Date_Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Date_Modified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Created_by = table.Column<string>(type: "text", nullable: false),
                    Modified_by = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeAddressDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeContactDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Empid = table.Column<string>(type: "text", nullable: false),
                    Personal_Emailid = table.Column<string>(type: "text", nullable: false),
                    Contact_no = table.Column<double>(type: "double precision", nullable: false),
                    Emgy_Contactperson = table.Column<string>(type: "text", nullable: true),
                    Emgy_Contactrelation = table.Column<string>(type: "text", nullable: true),
                    Emgy_Contactno = table.Column<double>(type: "double precision", nullable: true),
                    Date_Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Date_Modified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Created_by = table.Column<string>(type: "text", nullable: false),
                    Modified_by = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeContactDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeEducationDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Empid = table.Column<string>(type: "text", nullable: false),
                    programme = table.Column<string>(type: "text", nullable: false),
                    CollegeName = table.Column<string>(type: "text", nullable: false),
                    Degree = table.Column<string>(type: "text", nullable: false),
                    specialization = table.Column<string>(type: "text", nullable: false),
                    Passoutyear = table.Column<int>(type: "integer", nullable: false),
                    Certificate = table.Column<string>(type: "text", nullable: false),
                    Date_Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Date_Modified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Created_by = table.Column<string>(type: "text", nullable: false),
                    Modified_by = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeEducationDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeExperienceDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Empid = table.Column<string>(type: "text", nullable: false),
                    Company_name = table.Column<string>(type: "text", nullable: false),
                    Designation = table.Column<string>(type: "text", nullable: false),
                    Totalmonths = table.Column<int>(type: "integer", nullable: false),
                    Reason = table.Column<string>(type: "text", nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Exp_Certificate = table.Column<string>(type: "text", nullable: true),
                    Date_Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Date_Modified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Created_by = table.Column<string>(type: "text", nullable: false),
                    Modified_by = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeExperienceDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeGeneralDetails",
                columns: table => new
                {
                    EmpID = table.Column<string>(type: "text", nullable: false),
                    EmployeeName = table.Column<string>(type: "text", nullable: false),
                    DOB = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    FatherName = table.Column<string>(type: "text", nullable: false),
                    Gender = table.Column<string>(type: "text", nullable: false),
                    MaritalName = table.Column<string>(type: "text", nullable: false),
                    DateOfMarriage = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    BloodGrp = table.Column<string>(type: "text", nullable: false),
                    Date_Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Date_Modified = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Created_by = table.Column<string>(type: "text", nullable: false),
                    Modified_by = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeGeneralDetails", x => x.EmpID);
                });

            migrationBuilder.CreateTable(
                name: "Logins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Emailid = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    Designation = table.Column<string>(type: "text", nullable: false),
                    Date_Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Date_Modified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Created_by = table.Column<string>(type: "text", nullable: false),
                    Modified_by = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logins", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Approvals");

            migrationBuilder.DropTable(
                name: "EmployeeAdditionalInfo");

            migrationBuilder.DropTable(
                name: "EmployeeAddressDetails");

            migrationBuilder.DropTable(
                name: "EmployeeContactDetails");

            migrationBuilder.DropTable(
                name: "EmployeeEducationDetails");

            migrationBuilder.DropTable(
                name: "EmployeeExperienceDetails");

            migrationBuilder.DropTable(
                name: "EmployeeGeneralDetails");

            migrationBuilder.DropTable(
                name: "Logins");
        }
    }
}
