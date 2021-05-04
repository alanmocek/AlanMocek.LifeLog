using Microsoft.EntityFrameworkCore.Migrations;

namespace AlanMocek.LifeLog.Data.Migrations
{
    public partial class Dev1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ActivityRecords_DayRecordId",
                table: "ActivityRecords",
                column: "DayRecordId");

            migrationBuilder.AddForeignKey(
                name: "FK_ActivityRecords_DayRecords_DayRecordId",
                table: "ActivityRecords",
                column: "DayRecordId",
                principalTable: "DayRecords",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActivityRecords_DayRecords_DayRecordId",
                table: "ActivityRecords");

            migrationBuilder.DropIndex(
                name: "IX_ActivityRecords_DayRecordId",
                table: "ActivityRecords");
        }
    }
}
