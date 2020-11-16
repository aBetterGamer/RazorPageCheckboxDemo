using Microsoft.EntityFrameworkCore.Migrations;

namespace CheckboxDemo.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Children",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    IsSelected = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Children", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Parents",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ParentChild",
                columns: table => new
                {
                    ParentId = table.Column<int>(nullable: false),
                    ChildId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParentChild", x => new { x.ParentId, x.ChildId });
                    table.ForeignKey(
                        name: "FK_ParentChild_Children_ChildId",
                        column: x => x.ChildId,
                        principalTable: "Children",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ParentChild_Parents_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Parents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Children",
                columns: new[] { "Id", "IsSelected", "Name" },
                values: new object[,]
                {
                    { 1, true, "First Child" },
                    { 2, false, "Second Child" },
                    { 3, true, "Third Child" },
                    { 4, false, "Fourth Child" },
                    { 5, true, "Fifth Child" },
                    { 6, false, "Sixth Child" }
                });

            migrationBuilder.InsertData(
                table: "Parents",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "First Parent" },
                    { 2, "Second Parent" }
                });

            migrationBuilder.InsertData(
                table: "ParentChild",
                columns: new[] { "ParentId", "ChildId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 1, 3 },
                    { 2, 4 },
                    { 2, 5 },
                    { 2, 6 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ParentChild_ChildId",
                table: "ParentChild",
                column: "ChildId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ParentChild");

            migrationBuilder.DropTable(
                name: "Children");

            migrationBuilder.DropTable(
                name: "Parents");
        }
    }
}
