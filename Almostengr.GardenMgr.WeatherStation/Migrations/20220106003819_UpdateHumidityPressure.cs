using Microsoft.EntityFrameworkCore.Migrations;

namespace Almostengr.WeatherStation.Api.Migrations
{
    public partial class UpdateHumidityPressure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Pressure",
                table: "Observations",
                newName: "PressureMb");

            migrationBuilder.RenameColumn(
                name: "Humidity",
                table: "Observations",
                newName: "HumidityPct");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PressureMb",
                table: "Observations",
                newName: "Pressure");

            migrationBuilder.RenameColumn(
                name: "HumidityPct",
                table: "Observations",
                newName: "Humidity");
        }
    }
}
