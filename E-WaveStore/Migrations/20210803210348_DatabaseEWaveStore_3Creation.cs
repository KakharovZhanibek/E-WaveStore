using Microsoft.EntityFrameworkCore.Migrations;

namespace E_WaveStore.Migrations
{
    public partial class DatabaseEWaveStore_3Creation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Characteristics",
                table: "Specifications");

            migrationBuilder.AddColumn<string>(
                name: "BackLight",
                table: "Specifications",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BatteryCapacity",
                table: "Specifications",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Bluetooth",
                table: "Specifications",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "BodyMaterial",
                table: "Specifications",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BraceletMaterial",
                table: "Specifications",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BuiltMemory",
                table: "Specifications",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ButtonAmount",
                table: "Specifications",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "Specifications",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Connection",
                table: "Specifications",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ConnectionType",
                table: "Specifications",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CoreAmount",
                table: "Specifications",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Cpu",
                table: "Specifications",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeviceInterface",
                table: "Specifications",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Dimension",
                table: "Specifications",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "DisplayDiagonal",
                table: "Specifications",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "DisplayResolution",
                table: "Specifications",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "FaceRecognition",
                table: "Specifications",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Frequency",
                table: "Specifications",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "FrontCamera",
                table: "Specifications",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Hdd",
                table: "Specifications",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KeyType",
                table: "Specifications",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "KeysAmount",
                table: "Specifications",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Layout",
                table: "Specifications",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MainCamera",
                table: "Specifications",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NavSystem",
                table: "Specifications",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Nfc",
                table: "Specifications",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "OperationalSystem",
                table: "Specifications",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OpticalResolution",
                table: "Specifications",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Platform",
                table: "Specifications",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "PowerConsumption",
                table: "Specifications",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "Ram",
                table: "Specifications",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "RamType",
                table: "Specifications",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Sensor",
                table: "Specifications",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SimAmount",
                table: "Specifications",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "SimType",
                table: "Specifications",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Smart",
                table: "Specifications",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Ssd",
                table: "Specifications",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Specifications",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UsbPort",
                table: "Specifications",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VideoCard",
                table: "Specifications",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VideoMemorySize",
                table: "Specifications",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "WebCamera",
                table: "Specifications",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Weight",
                table: "Specifications",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Wifi",
                table: "Specifications",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BackLight",
                table: "Specifications");

            migrationBuilder.DropColumn(
                name: "BatteryCapacity",
                table: "Specifications");

            migrationBuilder.DropColumn(
                name: "Bluetooth",
                table: "Specifications");

            migrationBuilder.DropColumn(
                name: "BodyMaterial",
                table: "Specifications");

            migrationBuilder.DropColumn(
                name: "BraceletMaterial",
                table: "Specifications");

            migrationBuilder.DropColumn(
                name: "BuiltMemory",
                table: "Specifications");

            migrationBuilder.DropColumn(
                name: "ButtonAmount",
                table: "Specifications");

            migrationBuilder.DropColumn(
                name: "Color",
                table: "Specifications");

            migrationBuilder.DropColumn(
                name: "Connection",
                table: "Specifications");

            migrationBuilder.DropColumn(
                name: "ConnectionType",
                table: "Specifications");

            migrationBuilder.DropColumn(
                name: "CoreAmount",
                table: "Specifications");

            migrationBuilder.DropColumn(
                name: "Cpu",
                table: "Specifications");

            migrationBuilder.DropColumn(
                name: "DeviceInterface",
                table: "Specifications");

            migrationBuilder.DropColumn(
                name: "Dimension",
                table: "Specifications");

            migrationBuilder.DropColumn(
                name: "DisplayDiagonal",
                table: "Specifications");

            migrationBuilder.DropColumn(
                name: "DisplayResolution",
                table: "Specifications");

            migrationBuilder.DropColumn(
                name: "FaceRecognition",
                table: "Specifications");

            migrationBuilder.DropColumn(
                name: "Frequency",
                table: "Specifications");

            migrationBuilder.DropColumn(
                name: "FrontCamera",
                table: "Specifications");

            migrationBuilder.DropColumn(
                name: "Hdd",
                table: "Specifications");

            migrationBuilder.DropColumn(
                name: "KeyType",
                table: "Specifications");

            migrationBuilder.DropColumn(
                name: "KeysAmount",
                table: "Specifications");

            migrationBuilder.DropColumn(
                name: "Layout",
                table: "Specifications");

            migrationBuilder.DropColumn(
                name: "MainCamera",
                table: "Specifications");

            migrationBuilder.DropColumn(
                name: "NavSystem",
                table: "Specifications");

            migrationBuilder.DropColumn(
                name: "Nfc",
                table: "Specifications");

            migrationBuilder.DropColumn(
                name: "OperationalSystem",
                table: "Specifications");

            migrationBuilder.DropColumn(
                name: "OpticalResolution",
                table: "Specifications");

            migrationBuilder.DropColumn(
                name: "Platform",
                table: "Specifications");

            migrationBuilder.DropColumn(
                name: "PowerConsumption",
                table: "Specifications");

            migrationBuilder.DropColumn(
                name: "Ram",
                table: "Specifications");

            migrationBuilder.DropColumn(
                name: "RamType",
                table: "Specifications");

            migrationBuilder.DropColumn(
                name: "Sensor",
                table: "Specifications");

            migrationBuilder.DropColumn(
                name: "SimAmount",
                table: "Specifications");

            migrationBuilder.DropColumn(
                name: "SimType",
                table: "Specifications");

            migrationBuilder.DropColumn(
                name: "Smart",
                table: "Specifications");

            migrationBuilder.DropColumn(
                name: "Ssd",
                table: "Specifications");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Specifications");

            migrationBuilder.DropColumn(
                name: "UsbPort",
                table: "Specifications");

            migrationBuilder.DropColumn(
                name: "VideoCard",
                table: "Specifications");

            migrationBuilder.DropColumn(
                name: "VideoMemorySize",
                table: "Specifications");

            migrationBuilder.DropColumn(
                name: "WebCamera",
                table: "Specifications");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "Specifications");

            migrationBuilder.DropColumn(
                name: "Wifi",
                table: "Specifications");

            migrationBuilder.AddColumn<string>(
                name: "Characteristics",
                table: "Specifications",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
