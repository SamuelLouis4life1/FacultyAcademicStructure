using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AcademicStructure.Infrastructure.Migrations
{
    public partial class InitialCreateDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CEP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddicionalAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HouseAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Neighborhood = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Number = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DbClassRooms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClassName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FinishAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbClassRooms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DbStudents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CPF = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StudentOrTeacher = table.Column<bool>(type: "bit", nullable: false),
                    PhoneNumber = table.Column<long>(type: "bigint", nullable: false),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddressId = table.Column<int>(type: "int", nullable: true),
                    Matricula = table.Column<int>(type: "int", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbStudents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DbStudents_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DbTeachers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CPF = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StudentOrTeacher = table.Column<bool>(type: "bit", nullable: false),
                    PhoneNumber = table.Column<long>(type: "bigint", nullable: false),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddressId = table.Column<int>(type: "int", nullable: true),
                    Matricula = table.Column<int>(type: "int", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbTeachers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DbTeachers_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClassRoomStudent",
                columns: table => new
                {
                    ClassRoomsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudentsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassRoomStudent", x => new { x.ClassRoomsId, x.StudentsId });
                    table.ForeignKey(
                        name: "FK_ClassRoomStudent_DbClassRooms_ClassRoomsId",
                        column: x => x.ClassRoomsId,
                        principalTable: "DbClassRooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClassRoomStudent_DbStudents_StudentsId",
                        column: x => x.StudentsId,
                        principalTable: "DbStudents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClassRoomTeacher",
                columns: table => new
                {
                    ClassRoomsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TeachersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassRoomTeacher", x => new { x.ClassRoomsId, x.TeachersId });
                    table.ForeignKey(
                        name: "FK_ClassRoomTeacher_DbClassRooms_ClassRoomsId",
                        column: x => x.ClassRoomsId,
                        principalTable: "DbClassRooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClassRoomTeacher_DbTeachers_TeachersId",
                        column: x => x.TeachersId,
                        principalTable: "DbTeachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentTeacher",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    TeachersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentTeacher", x => new { x.StudentId, x.TeachersId });
                    table.ForeignKey(
                        name: "FK_StudentTeacher_DbStudents_StudentId",
                        column: x => x.StudentId,
                        principalTable: "DbStudents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentTeacher_DbTeachers_TeachersId",
                        column: x => x.TeachersId,
                        principalTable: "DbTeachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClassRoomStudent_StudentsId",
                table: "ClassRoomStudent",
                column: "StudentsId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassRoomTeacher_TeachersId",
                table: "ClassRoomTeacher",
                column: "TeachersId");

            migrationBuilder.CreateIndex(
                name: "IX_DbStudents_AddressId",
                table: "DbStudents",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_DbTeachers_AddressId",
                table: "DbTeachers",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentTeacher_TeachersId",
                table: "StudentTeacher",
                column: "TeachersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClassRoomStudent");

            migrationBuilder.DropTable(
                name: "ClassRoomTeacher");

            migrationBuilder.DropTable(
                name: "StudentTeacher");

            migrationBuilder.DropTable(
                name: "DbClassRooms");

            migrationBuilder.DropTable(
                name: "DbStudents");

            migrationBuilder.DropTable(
                name: "DbTeachers");

            migrationBuilder.DropTable(
                name: "Address");
        }
    }
}
