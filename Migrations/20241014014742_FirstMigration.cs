using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CrudIntern.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "E_Banks",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Value = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "E_CostCenter",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Code = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    CostCenter = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CostCenter", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "E_Countries",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Value = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    ISO_CODE = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "E_Departments",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Value = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Code = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "E_Educations",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Value = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Educations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "E_EmployeeStatus",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Value = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__E_Employ__3214EC0765619410", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "E_Grade",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Value = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_E_Grade", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "E_GradeCategory",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Value = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__E_GradeC__3214EC073566F89A", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "E_HardshipLocation",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    Province = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    ProvinceId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__E_HardshipLocation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "E_Insurances",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Value = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Insurances", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "E_MaritalStatus",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Value = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaritalStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "E_Nationalities",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Value = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nationalities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "E_Occupations",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Value = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Occupations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "E_Position",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Value = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Authorization = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__E_Positi__3214EC072CB345E1", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "E_Relationship",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Value = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__E_Relati__3214EC0737BDD449", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "E_Religions",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Value = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Religions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "E_StatusOwner",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Value = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusOwner", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "E_StayStatus",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Value = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StayStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "E_Universities",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Value = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Universities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "E_WorkLocation",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Value = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__E_WorkLo__3214EC07710D254F", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "M_AssigmentStatus",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Value = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__M_Assigm__3214EC073284038D", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "E_Provinces",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Value = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    CountryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provinces", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Provinces_Countries",
                        column: x => x.CountryId,
                        principalSchema: "dbo",
                        principalTable: "E_Countries",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "E_Sections",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Value = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    DepartmentId = table.Column<int>(type: "int", nullable: true),
                    Code = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__E_Sectio__3214EC077A9E0451", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Section_Department",
                        column: x => x.DepartmentId,
                        principalSchema: "dbo",
                        principalTable: "E_Departments",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "E_Cities",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Value = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    ProvinceId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_Provinces",
                        column: x => x.ProvinceId,
                        principalSchema: "dbo",
                        principalTable: "E_Provinces",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_E_Cities_ProvinceId",
                schema: "dbo",
                table: "E_Cities",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "idx_ValueGrade",
                schema: "dbo",
                table: "E_Grade",
                column: "Value");

            migrationBuilder.CreateIndex(
                name: "UQ__E_Grade__07D9BBC2C3CC6944",
                schema: "dbo",
                table: "E_Grade",
                column: "Value",
                unique: true,
                filter: "[Value] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_E_Provinces_CountryId",
                schema: "dbo",
                table: "E_Provinces",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_E_Sections_DepartmentId",
                schema: "dbo",
                table: "E_Sections",
                column: "DepartmentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "E_Banks",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "E_Cities",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "E_CostCenter",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "E_Educations",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "E_EmployeeStatus",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "E_Grade",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "E_GradeCategory",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "E_HardshipLocation",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "E_Insurances",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "E_MaritalStatus",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "E_Nationalities",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "E_Occupations",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "E_Position",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "E_Relationship",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "E_Religions",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "E_Sections",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "E_StatusOwner",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "E_StayStatus",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "E_Universities",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "E_WorkLocation",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "M_AssigmentStatus",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "E_Provinces",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "E_Departments",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "E_Countries",
                schema: "dbo");
        }
    }
}
