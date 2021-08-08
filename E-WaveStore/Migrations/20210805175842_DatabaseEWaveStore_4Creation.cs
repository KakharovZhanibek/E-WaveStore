using Microsoft.EntityFrameworkCore.Migrations;

namespace E_WaveStore.Migrations
{
    public partial class DatabaseEWaveStore_4Creation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Specifications_SpecificationId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "Specifications");

            migrationBuilder.DropIndex(
                name: "IX_Products_SpecificationId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "SpecificationId",
                table: "Products");

            migrationBuilder.AddColumn<string>(
                name: "Specification",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Specification",
                table: "Products");

            migrationBuilder.AddColumn<long>(
                name: "SpecificationId",
                table: "Products",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "Specifications",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BackLight = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BatteryCapacity = table.Column<int>(type: "int", nullable: false),
                    Bluetooth = table.Column<bool>(type: "bit", nullable: false),
                    BodyMaterial = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BraceletMaterial = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BuiltMemory = table.Column<int>(type: "int", nullable: false),
                    ButtonAmount = table.Column<int>(type: "int", nullable: true),
                    Color = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Connection = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ConnectionType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CoreAmount = table.Column<int>(type: "int", nullable: false),
                    Cpu = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DeviceInterface = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Dimension = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DisplayDiagonal = table.Column<float>(type: "real", nullable: false),
                    DisplayResolution = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    FaceRecognition = table.Column<bool>(type: "bit", nullable: false),
                    Frequency = table.Column<int>(type: "int", nullable: false),
                    FrontCamera = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Hdd = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    KeyType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    KeysAmount = table.Column<int>(type: "int", nullable: false),
                    Layout = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    MainCamera = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NavSystem = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Nfc = table.Column<bool>(type: "bit", nullable: false),
                    OperationalSystem = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    OpticalResolution = table.Column<int>(type: "int", nullable: false),
                    Platform = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PowerConsumption = table.Column<double>(type: "float", nullable: false),
                    Ram = table.Column<int>(type: "int", nullable: false),
                    RamType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Sensor = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SimAmount = table.Column<int>(type: "int", nullable: false),
                    SimType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Smart = table.Column<bool>(type: "bit", nullable: false),
                    Ssd = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UsbPort = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    VideoCard = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    VideoMemorySize = table.Column<int>(type: "int", nullable: false),
                    WebCamera = table.Column<bool>(type: "bit", nullable: true),
                    Weight = table.Column<int>(type: "int", nullable: false),
                    Wifi = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specifications", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_SpecificationId",
                table: "Products",
                column: "SpecificationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Specifications_SpecificationId",
                table: "Products",
                column: "SpecificationId",
                principalTable: "Specifications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
