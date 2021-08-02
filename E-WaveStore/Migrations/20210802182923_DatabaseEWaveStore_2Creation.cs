using Microsoft.EntityFrameworkCore.Migrations;

namespace E_WaveStore.Migrations
{
    public partial class DatabaseEWaveStore_2Creation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Keyboards");

            migrationBuilder.DropTable(
                name: "Laptops");

            migrationBuilder.DropTable(
                name: "Mice");

            migrationBuilder.DropTable(
                name: "Monitors");

            migrationBuilder.DropTable(
                name: "MonoBlocks");

            migrationBuilder.DropTable(
                name: "Phones");

            migrationBuilder.DropTable(
                name: "SmartWatches");

            migrationBuilder.DropTable(
                name: "Tvs");

            migrationBuilder.CreateTable(
                name: "Specifications",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Characteristics = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specifications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ModelName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    ImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpecificationId = table.Column<long>(type: "bigint", nullable: false),
                    CategoryId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_Specifications_SpecificationId",
                        column: x => x.SpecificationId,
                        principalTable: "Specifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_SpecificationId",
                table: "Products",
                column: "SpecificationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Specifications");

            migrationBuilder.CreateTable(
                name: "Keyboards",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    BackLight = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BrandName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CategoryId = table.Column<long>(type: "bigint", nullable: true),
                    Color = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ConnectionType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Dimension = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KeyType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    KeysAmount = table.Column<int>(type: "int", nullable: false),
                    Layout = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ModelName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Keyboards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Keyboards_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Laptops",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    BrandName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CategoryId = table.Column<long>(type: "bigint", nullable: true),
                    Color = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CoreAmount = table.Column<int>(type: "int", nullable: false),
                    Cpu = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DisplayDiagonal = table.Column<float>(type: "real", nullable: false),
                    DisplayResolution = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Hdd = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModelName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    OperationalSystem = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Ram = table.Column<int>(type: "int", nullable: false),
                    Ssd = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Weight = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Laptops", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Laptops_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Mice",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    BackLight = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BrandName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ButtonAmount = table.Column<int>(type: "int", nullable: true),
                    CategoryId = table.Column<long>(type: "bigint", nullable: true),
                    Color = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Connection = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModelName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    OpticalResolution = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Weight = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mice_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Monitors",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    BrandName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CategoryId = table.Column<long>(type: "bigint", nullable: true),
                    Color = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Dimension = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DisplayDiagonal = table.Column<float>(type: "real", nullable: false),
                    DisplayResolution = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Frequency = table.Column<int>(type: "int", nullable: false),
                    ImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModelName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    MonitorcInterface = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PowerConsumption = table.Column<double>(type: "float", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Weight = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Monitors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Monitors_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MonoBlocks",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    BrandName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CategoryId = table.Column<long>(type: "bigint", nullable: true),
                    Color = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Cpu = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Dimension = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DisplayDiagonal = table.Column<float>(type: "real", nullable: false),
                    DisplayResolution = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Hdd = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    ImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModelName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    MonoBlockInterface = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    OperationalSystem = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Ram = table.Column<int>(type: "int", nullable: false),
                    RamType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    VideoCard = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    VideoMemorySize = table.Column<int>(type: "int", nullable: false),
                    WebCamera = table.Column<bool>(type: "bit", nullable: true),
                    Weight = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonoBlocks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MonoBlocks_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Phones",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    BatteryCapacity = table.Column<int>(type: "int", nullable: false),
                    BodyMaterial = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BrandName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    BuiltMemory = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<long>(type: "bigint", nullable: true),
                    Color = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CoreAmount = table.Column<int>(type: "int", nullable: false),
                    Cpu = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DisplayDiagonal = table.Column<float>(type: "real", nullable: false),
                    DisplayResolution = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    FaceRecognition = table.Column<bool>(type: "bit", nullable: false),
                    FrontCamera = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MainCamera = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModelName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    NavSystem = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Nfc = table.Column<bool>(type: "bit", nullable: false),
                    OperatingSystem = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Ram = table.Column<int>(type: "int", nullable: false),
                    SimAmount = table.Column<int>(type: "int", nullable: false),
                    SimType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    UsbPort = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Weight = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Phones_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SmartWatches",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    Bluetooth = table.Column<bool>(type: "bit", nullable: false),
                    BodyMaterial = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BraceletMaterial = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BrandName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CategoryId = table.Column<long>(type: "bigint", nullable: true),
                    Color = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModelName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Sensor = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Weight = table.Column<int>(type: "int", nullable: false),
                    Wifi = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SmartWatches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SmartWatches_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tvs",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    BrandName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CategoryId = table.Column<long>(type: "bigint", nullable: true),
                    Color = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DisplayDiagonal = table.Column<float>(type: "real", nullable: false),
                    DisplayResolution = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Frequency = table.Column<int>(type: "int", nullable: false),
                    ImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModelName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Platform = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Smart = table.Column<bool>(type: "bit", nullable: false),
                    Weight = table.Column<int>(type: "int", nullable: false),
                    Wifi = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tvs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tvs_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Keyboards_CategoryId",
                table: "Keyboards",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Laptops_CategoryId",
                table: "Laptops",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Mice_CategoryId",
                table: "Mice",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Monitors_CategoryId",
                table: "Monitors",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_MonoBlocks_CategoryId",
                table: "MonoBlocks",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Phones_CategoryId",
                table: "Phones",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SmartWatches_CategoryId",
                table: "SmartWatches",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Tvs_CategoryId",
                table: "Tvs",
                column: "CategoryId");
        }
    }
}
