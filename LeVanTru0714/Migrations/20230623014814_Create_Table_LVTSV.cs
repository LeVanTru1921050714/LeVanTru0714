using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeVanTru0714.Migrations
{
    /// <inheritdoc />
    public partial class Create_Table_LVTSV : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LVTSinhVien",
                columns: table => new
                {
                    LVTMaSinhVien = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LVTTenSinhVien = table.Column<string>(type: "TEXT", nullable: false),
                    LVTTuoi = table.Column<float>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LVTSinhVien", x => x.LVTMaSinhVien);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LVTSinhVien");
        }
    }
}
