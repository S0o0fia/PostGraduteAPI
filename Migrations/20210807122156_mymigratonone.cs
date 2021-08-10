using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UniWebAPI.Migrations
{
    public partial class mymigratonone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Colleges",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colleges", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "News",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NewDetails = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PostGradutesInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Namear = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nameen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SSD = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IssuerSSD = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nationality = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Religion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Job = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    birthPlace = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    birthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    SalltPassword = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    MilirityStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    University = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Collage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SSDFile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MilirtyFile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Photo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthCertificate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApproveAffairFile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AcknowledmentFile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AcknowledmentJobFile = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostGradutesInfos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "universityInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UniName_ar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UniName_en = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UniVisionar_ar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UniVisionar_en = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UniMassage_ar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UniMassage_en = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UniPresidentSpeech_ar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UniPresidentSpeech_en = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_universityInfos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NewsImgs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    img = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NewId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsImgs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NewsImgs_News_NewId",
                        column: x => x.NewId,
                        principalTable: "News",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PostGraduteMasters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MasterType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    registerDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CollageGrade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CollageCertificateFile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatementGradesFile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GraduteYear = table.Column<int>(type: "int", nullable: false),
                    GradutePrencetage = table.Column<float>(type: "real", nullable: false),
                    RequestAccepted = table.Column<int>(type: "int", nullable: false),
                    matchingPaperDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    matchingPaper = table.Column<int>(type: "int", nullable: false),
                    InterviewDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InterviewPassed = table.Column<int>(type: "int", nullable: false),
                    expancesDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    expancesAmount = table.Column<float>(type: "real", nullable: false),
                    expancesDone = table.Column<int>(type: "int", nullable: false),
                    expancesReciepts = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    accepted = table.Column<int>(type: "int", nullable: false),
                    PostGraduteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostGraduteMasters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostGraduteMasters_PostGradutesInfos_PostGraduteId",
                        column: x => x.PostGraduteId,
                        principalTable: "PostGradutesInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PostGradutePhds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhdType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    registerDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MasterGrade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MasterCertificateFile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MasterYear = table.Column<int>(type: "int", nullable: false),
                    RequestAccepted = table.Column<int>(type: "int", nullable: false),
                    matchingPaperDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    matchingPaper = table.Column<int>(type: "int", nullable: false),
                    InterviewDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InterviewPassed = table.Column<int>(type: "int", nullable: false),
                    expancesDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    expancesAmount = table.Column<float>(type: "real", nullable: false),
                    expancesDone = table.Column<int>(type: "int", nullable: false),
                    expancesReciepts = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    accepted = table.Column<int>(type: "int", nullable: false),
                    PostGraduteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostGradutePhds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostGradutePhds_PostGradutesInfos_PostGraduteId",
                        column: x => x.PostGraduteId,
                        principalTable: "PostGradutesInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PostGradutesDiplomas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiplomaType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    registerDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CollageGrade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CollageCertificateFile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatementGradesFile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GraduteYear = table.Column<int>(type: "int", nullable: false),
                    GradutePrencetage = table.Column<float>(type: "real", nullable: false),
                    RequestAccepted = table.Column<int>(type: "int", nullable: false),
                    matchingPaperDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    matchingPaper = table.Column<int>(type: "int", nullable: false),
                    InterviewDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InterviewPassed = table.Column<int>(type: "int", nullable: false),
                    expancesDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    expancesAmount = table.Column<float>(type: "real", nullable: false),
                    expancesDone = table.Column<int>(type: "int", nullable: false),
                    expancesReciepts = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    accepted = table.Column<int>(type: "int", nullable: false),
                    PostGraduteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostGradutesDiplomas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostGradutesDiplomas_PostGradutesInfos_PostGraduteId",
                        column: x => x.PostGraduteId,
                        principalTable: "PostGradutesInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NewsImgs_NewId",
                table: "NewsImgs",
                column: "NewId");

            migrationBuilder.CreateIndex(
                name: "IX_PostGraduteMasters_PostGraduteId",
                table: "PostGraduteMasters",
                column: "PostGraduteId");

            migrationBuilder.CreateIndex(
                name: "IX_PostGradutePhds_PostGraduteId",
                table: "PostGradutePhds",
                column: "PostGraduteId");

            migrationBuilder.CreateIndex(
                name: "IX_PostGradutesDiplomas_PostGraduteId",
                table: "PostGradutesDiplomas",
                column: "PostGraduteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Colleges");

            migrationBuilder.DropTable(
                name: "NewsImgs");

            migrationBuilder.DropTable(
                name: "PostGraduteMasters");

            migrationBuilder.DropTable(
                name: "PostGradutePhds");

            migrationBuilder.DropTable(
                name: "PostGradutesDiplomas");

            migrationBuilder.DropTable(
                name: "universityInfos");

            migrationBuilder.DropTable(
                name: "News");

            migrationBuilder.DropTable(
                name: "PostGradutesInfos");
        }
    }
}
