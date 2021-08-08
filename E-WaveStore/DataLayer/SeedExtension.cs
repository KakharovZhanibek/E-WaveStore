
using E_WaveStore.DataLayer.Entity;
using E_WaveStore.DataLayer.Models;
using E_WaveStore.DataLayer.Models.Entity;
using E_WaveStore.DataLayer.Repositories.Interfaces;
using E_WaveStore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_WaveStore.DataLayer
{
    public static class SeedExtention
    {
        public static async Task<IHost> SeedAsync(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {

                await CreateDefaultRolesAsync(scope.ServiceProvider);
                await CreateDefaultAdminAsync(scope.ServiceProvider);
                CreateDefaultCategory(scope.ServiceProvider);
                CreateDefaultProduct(scope.ServiceProvider);

            }

            return host;
        }

        public static async Task CreateDefaultRolesAsync(IServiceProvider serviceProvider)
        {
            RoleManager<IdentityRole> _roleManager = serviceProvider.GetService<RoleManager<IdentityRole>>();
            if (!_roleManager.Roles.Any())
            {
                await _roleManager.CreateAsync(new IdentityRole("admin"));
                await _roleManager.CreateAsync(new IdentityRole("manager"));
                await _roleManager.CreateAsync(new IdentityRole("user"));
            }
        }

        public static async Task CreateDefaultAdminAsync(IServiceProvider serviceProvider)
        {
            UserManager<User> _userManager = serviceProvider.GetService<UserManager<User>>();
            if (!_userManager.Users.Any())
            {
                User user = new User { Email = "admin@gmail.com", UserName = "admin" };

                await _userManager.CreateAsync(user, "admin");
                await _userManager.AddToRoleAsync(user, "admin");
            }
        }

        public static void CreateDefaultProduct(IServiceProvider serviceProvider)
        {

            var productRepository = serviceProvider.GetService<IProductRepository>();
            var categoryRepository = serviceProvider.GetService<ICategoryRepository>();
                       
            Category categoryKeyboards = categoryRepository.GetByCategoryName("Keyboards");
            
            var products = productRepository.GetAll().Any();

            if (!products)
            {

                Product productKeyboard_1 = new Product
                {
                    BrandName = "A4tech",
                    ModelName = "Bloody B500n",
                    Price = 15000,
                    Amount = 32,
                    ImgUrl = "https://shop.kz/upload/iblock/4d6/151222_1.jpg",
                    Category = categoryKeyboards,
                    Specification = " KeysAmount = 112 \n ConnectionType = Wired, \n Layout = qwerty \n Dimension = 44.2 x 4.9 x 13.2 \n KeyType = mechanical \n Color = Black \n BackLight = RGB"
                };

                Product productKeyboard_2 = new Product
                {
                    BrandName = "A4tech",
                    ModelName = "Bloody B810R",
                    Price = 30000,
                    Amount = 15,
                    ImgUrl = "https://shop.kz/upload/iblock/d50/131490_1.jpg",
                    Category = categoryKeyboards,
                    Specification = " KeysAmount = 112 \n ConnectionType = Wireless, \n Layout = qwerty \n Dimension = 44.4 x 3.7 x 13.2 \n KeyType = mechanical \n Color = Black \n BackLight = RGB"
                };

                Product productKeyboard_3 = new Product
                {
                    BrandName = "A4tech",
                    ModelName = "Bloody B800",
                    Price = 30000,
                    Amount = 10,
                    ImgUrl = "https://shop.kz/upload/iblock/741/151224_1.jpg",
                    Category = categoryKeyboards,
                    Specification = " KeysAmount = 112 \n ConnectionType = Wireless, \n Layout = qwerty \n Dimension = 44.4 x 3.7 x 13.2 \n KeyType = optic-mechanical \n Color = Black \n BackLight = Red"
                };

                Product productKeyboard_4 = new Product
                {
                    BrandName = "Logitech",
                    ModelName = "K580",
                    Price = 32990,
                    Amount = 23,
                    ImgUrl = "https://shop.kz/upload/iblock/0bc/154202_1.jpg",
                    Category = categoryKeyboards,
                    Specification = " KeysAmount = 117 \n ConnectionType = Wireless, \n Layout = qwerty \n Dimension = 37.3 x 2.1 x 14.4 \n KeyType = membrane \n Color = Black \n BackLight = Blue"
                };

                Product productKeyboard_5 = new Product
                {
                    BrandName = "SteelSeries",
                    ModelName = "Apex 150",
                    Price = 33900,
                    Amount = 7,
                    ImgUrl = "https://shop.kz/upload/iblock/dd2/14img_6169-kopiya.jpg",
                    Category = categoryKeyboards,
                    Specification = " KeysAmount = 107 \n ConnectionType = Wired, \n Layout = qwerty \n Dimension = 46.3 x 15.6 x 4.2 \n KeyType = membrane \n Color = Black \n BackLight = RGB"
                };

                Product productKeyboard_6 = new Product
                {
                    BrandName = "Razer",
                    ModelName = "BlackWidow",
                    Price = 39900,
                    Amount = 25,
                    ImgUrl = "https://shop.kz/upload/iblock/fc2/1img_0892_640.jpg",
                    Category = categoryKeyboards,
                    Specification = " KeysAmount = 104 \n ConnectionType = Wired, \n Layout = qwerty \n Dimension = 36.4 x 15.4 x 3 \n KeyType = mechanical \n Color = Black \n BackLight = Blue"
                };

                Product productKeyboard_7 = new Product
                {
                    BrandName = "Rapoo",
                    ModelName = "V700 RGB",
                    Price = 34690,
                    Amount = 14,
                    ImgUrl = "https://shop.kz/upload/iblock/8ca/145155_1.jpg",
                    Category = categoryKeyboards,
                    Specification = " KeysAmount = 109 \n ConnectionType = Wired, \n Layout = qwerty \n Dimension = 43.4 x 13.4 x 3.7 \n KeyType = mechanical \n Color = Black \n BackLight = Blue"
                };

                productRepository.Save(productKeyboard_1);
                productRepository.Save(productKeyboard_2);
                productRepository.Save(productKeyboard_3);
                productRepository.Save(productKeyboard_4);
                productRepository.Save(productKeyboard_5);
                productRepository.Save(productKeyboard_6);
                productRepository.Save(productKeyboard_7);

                Category categoryLaptopds = categoryRepository.GetByCategoryName("Laptops");

                Product productLaptop_1 = new Product
                {
                    BrandName = "Prestigio",
                    ModelName = "SmartBook 141",
                    Price = 109900,
                    Amount = 42,
                    ImgUrl = "https://shop.kz/upload/iblock/519/149185_01.jpg",
                    Category = categoryLaptopds,
                    Specification = "Operational System = Windows 10 Pro \n Cpu = Intel celeron \n  Ram = 4 \n Core Amount = 2 " +
                    "\n Ssd = 120 Gb \n Hdd = No \n DisplayDiagonal = 17.4f \n DisplayResolution = 1920x1080 \n Color = Black \n  Weight = 3 kg"
                };

                Product productLaptop_2 = new Product
                {
                    BrandName = "Asus",
                    ModelName = "x515MA",
                    Price = 144990,
                    Amount = 62,
                    ImgUrl = "https://shop.kz/upload/iblock/422/153567_1.jpg",
                    Category = categoryLaptopds,
                    Specification = "Operational System = Windows 10 Home \n Cpu = Intel celeron \n  Ram = 4 \n Core Amount = 2 " +
                   "\n Ssd = No \n Hdd = 1 Tb \n DisplayDiagonal = 17.4f \n DisplayResolution = 1920x1080 \n Color = Black \n  Weight = 3 kg"
                };

                Product productLaptop_3 = new Product
                {
                    BrandName = "Lenovo",
                    ModelName = "IdeaPad s145",
                    Price = 149900,
                    Amount = 12,
                    ImgUrl = "https://shop.kz/upload/iblock/1a7/152324_1.jpg",
                    Category = categoryLaptopds,
                    Specification = "Operational System = Windows 10 Enterprice \n Cpu = AMD E-series \n  Ram = 4 \n Core Amount = 2 " +
                   "\n Ssd = No \n Hdd = 1Tb \n DisplayDiagonal = 17.4f \n DisplayResolution = 1920x1080 \n Color = Black \n  Weight = 3kg"
                };

                Product productLaptop_4 = new Product
                {
                    BrandName = "Acer",
                    ModelName = "Aspire a315",
                    Price = 239990,
                    Amount = 53,
                    ImgUrl = "https://shop.kz/upload/iblock/d41/149452_1.jpg",
                    Category = categoryLaptopds,
                    Specification = "Operational System = Windows 10 Pro \n Cpu = Intel i3 \n  Ram = 4 \n Core Amount = 2 " +
                   "\n Ssd = No \n Hdd = 1 Tb \n DisplayDiagonal = 17.4f \n DisplayResolution = 1920x1080 \n Color = Black \n  Weight = 3 kg"
                };

                Product productLaptop_5 = new Product
                {
                    BrandName = "HP",
                    ModelName = "Pavilion 15-ec1054ur",
                    Price = 449900,
                    Amount = 42,
                    ImgUrl = "https://shop.kz/upload/iblock/2e0/155098_1.jpg",
                    Category = categoryLaptopds,
                    Specification = "Operational System = Windows 10 Pro \n Cpu = AMD Ryzen 7 \n  Ram = 16 \n Core Amount = 8 " +
                   "\n Ssd = 1 Tb \n Hdd = No \n DisplayDiagonal = 17.4f \n DisplayResolution = 1920x1080 \n Color = Black \n  Weight = 3 kg"
                };

                Product productLaptop_6 = new Product
                {
                    BrandName = "Acer",
                    ModelName = "Nitro 5 AN517-52",
                    Price = 451900,
                    Amount = 22,
                    ImgUrl = "https://shop.kz/upload/iblock/616/151798_1.jpg",
                    Category = categoryLaptopds,
                    Specification = "Operational System = Windows 10 Pro \n Cpu = Intel core i5 \n  Ram = 8 \n Core Amount = 4 " +
                  "\n Ssd = 512 Gb \n Hdd = No \n DisplayDiagonal = 17.4f \n DisplayResolution = 1920x1080 \n Color = Black \n  Weight = 3 kg"
                };

                Product productLaptop_7 = new Product
                {
                    BrandName = "Asus ROG",
                    ModelName = "Zephyrus GX703HS",
                    Price = 1879900,
                    Amount = 2,
                    ImgUrl = "https://static.shop.kz/upload/resize_cache/iblock/528/450_450_1/155994_1.jpg",
                    Category = categoryLaptopds,
                    Specification = "Operational System = Windows 10 Pro \n Cpu = Intel Core i9 \n  Ram = 32 \n Core Amount = 8 " +
                  "\n Ssd = 3 Tb \n Hdd = No \n DisplayDiagonal = 17.4f \n DisplayResolution = 1920x1080 \n Color = Black \n  Weight = 3 kg"
                };

                productRepository.Save(productLaptop_1);
                productRepository.Save(productLaptop_2);
                productRepository.Save(productLaptop_3);
                productRepository.Save(productLaptop_4);
                productRepository.Save(productLaptop_5);
                productRepository.Save(productLaptop_6);
                productRepository.Save(productLaptop_7);

             Category categoryMonitors = categoryRepository.GetByCategoryName("Monitors");

                Product productMonitor_1 = new Product
                {
                    BrandName = "2E",
                    ModelName = "e1919b",
                    Price = 26200,
                    Amount = 45,
                    ImgUrl = "https://static.shop.kz/upload/resize_cache/iblock/472/450_450_1/155650_1.jpg",
                    Category = categoryMonitors,
                    Specification = "MonitorcInterface = VGA PowerConsumption = 0.5 Dimension = 43x38x19 Frequency = 60 Hz DisplayDiagonal = 19 DisplayResolution = 1440x900 Color = Black Weight = 3 kg"
                };

                Product productMonitor_2 = new Product
                {
                    BrandName = "philips",
                    ModelName = "243v7qdsb",
                    Price = 59900,
                    Amount = 13,
                    ImgUrl = "https://shop.kz/upload/iblock/ccc/126612_1.jpg",
                    Category = categoryMonitors,
                    Specification = "MonitorcInterface = VGA, dvi-d, hdmi PowerConsumption = 0.5 Dimension = 43x38x19 Frequency = 60 Hz DisplayDiagonal = 23.8 DisplayResolution = 1920x1080 Color = Black Weight = 3 kg"
                };

                Product productMonitor_3 = new Product
                {
                    BrandName = "Samsung",
                    ModelName = "s24f356fhi",
                    Price = 59990,
                    Amount = 35,
                    ImgUrl = "https://shop.kz/upload/iblock/fea/129229.jpg",
                    Category = categoryMonitors,
                    Specification = "MonitorcInterface = VGA, hdmi PowerConsumption = 0.3 Dimension = 54x42x21 Frequency = 60 Hz DisplayDiagonal = 23.5 DisplayResolution = 1920x1080 Color = Black Weight = 3 kg"
                };

                Product productMonitor_4 = new Product
                {
                    BrandName = "HP",
                    ModelName = "x24ih",
                    Price = 90100,
                    Amount = 25,
                    ImgUrl = "https://shop.kz/upload/iblock/706/154562_1.jpg",
                    Category = categoryMonitors,
                    Specification = "MonitorcInterface = hdmi, displayPort PowerConsumption = 0.5 Dimension = 54x49x21 Frequency = 144 Hz DisplayDiagonal = 23.5 DisplayResolution = 1920x1080 Color = Black Weight = 3 kg"
                };

                Product productMonitor_5 = new Product
                {
                    BrandName = "LG",
                    ModelName = "24mk400h",
                    Price = 61900,
                    Amount = 45,
                    ImgUrl = "https://shop.kz/upload/iblock/1d1/132195_01.jpg",
                    Category = categoryMonitors,
                    Specification = "MonitorcInterface = VGA, hdmi PowerConsumption = 0.5 Dimension = 43x38x19 Frequency = 75 Hz DisplayDiagonal = 23.8 DisplayResolution = 1920x1080 Color = Black Weight = 3 kg"
                };

                Product productMonitor_6 = new Product
                {
                    BrandName = "AOC",
                    ModelName = "g2590vxq",
                    Price = 84500,
                    Amount = 55,
                    ImgUrl = "https://shop.kz/upload/iblock/1b6/133526_01.jpg",
                    Category = categoryMonitors,
                    Specification = "MonitorcInterface = VGA, 2xHDMI PowerConsumption = 0.5 Dimension = 43x38x19 Frequency = 75 Hz DisplayDiagonal = 24.5 DisplayResolution = 1920x1080 Color = Black-Red Weight = 3 kg"
                };

                productRepository.Save(productMonitor_1);
                productRepository.Save(productMonitor_2);
                productRepository.Save(productMonitor_3);
                productRepository.Save(productMonitor_4);
                productRepository.Save(productMonitor_5);
                productRepository.Save(productMonitor_6);


                Category categoryMonoblocks = categoryRepository.GetByCategoryName("Monoblocks");

                Product productMonoblock_1 = new Product
                {
                    BrandName = "HP",
                    ModelName = "All in one 21-b0013ur",
                    Price = 139900,
                    Amount = 15,
                    ImgUrl = "https://shop.kz/upload/iblock/d80/152743_1.jpg",
                    Category = categoryMonoblocks,
                    Specification = "DisplayDiagonal = 20.7   DisplayResolution = 1920x1080 Color = white Weight = 3 kg Cpu = intel celeron OperationalSystem = No" +
                    "Dimension = 49x36x18 MonoBlockInterface = 2 usb 2.0, 2xusb 3.0, mic, card reader WebCamera = Yes VideoCard = intel uhd graphics 600 Ram = 4" +
                    "RamType = DDR4 Hdd = 1 Tb VideoMemorySize = 2"
                };

                Product productMonoblock_2 = new Product
                {
                    BrandName = "Lenovo",
                    ModelName = "IDeacentre aio",
                    Price = 206700,
                    Amount = 15,
                    ImgUrl = "https://shop.kz/upload/iblock/d80/152743_1.jpg",
                    Category = categoryMonoblocks,
                    Specification = "DisplayDiagonal = 21.7   DisplayResolution = 1920x1080 Color = black Weight = 3 kg Cpu = amd athlon silver OperationalSystem = windows 10 home" +
                    "Dimension = 49x42x18 MonoBlockInterface = 2xusb 3.0,hdmi WebCamera = Yes VideoCard = Radeon graphics Ram = 4" +
                    "RamType = DDR4 Hdd = 1 Tb VideoMemorySize = 2"
                };

                Product productMonoblock_3 = new Product
                {
                    BrandName = "HP",
                    ModelName = "27-b0013KA",
                    Price = 149500,
                    Amount = 9,
                    ImgUrl = "https://shop.kz/upload/iblock/d80/152743_1.jpg",
                    Category = categoryMonoblocks,
                    Specification = "DisplayDiagonal = 21.5   DisplayResolution = 1920x1080 Color = black Weight = 3 kg Cpu = intel celeron OperationalSystem = Windows 10 Pro" +
                    "Dimension = 49x42x21 MonoBlockInterface = 2 usb 2.0, 2xusb 3.0, mic, card reader WebCamera = Yes VideoCard = intel uhd graphics 600 Ram = 4" +
                    "RamType = DDR4 Hdd = 1 Tb VideoMemorySize = 2"
                };

                Product productMonoblock_4 = new Product
                {
                    BrandName = "Philips",
                    ModelName = "SX-1945H",
                    Price = 130500,
                    Amount = 20,
                    ImgUrl = "https://shop.kz/upload/iblock/d80/152743_1.jpg",
                    Category = categoryMonoblocks,
                    Specification = "DisplayDiagonal = 22.0   DisplayResolution = 1920x1080 Color = black Weight = 3 kg Cpu = intel celeron OperationalSystem = No" +
                    "Dimension = 49x39x21 MonoBlockInterface = 2 usb 2.0, 2xusb 3.0, card reader WebCamera = No VideoCard = intel uhd graphics 600 Ram = 4" +
                    "RamType = DDR4 Hdd = 1 Tb VideoMemorySize = 2"
                };

                productRepository.Save(productMonoblock_1);
                productRepository.Save(productMonoblock_2);
                productRepository.Save(productMonoblock_3);
                productRepository.Save(productMonoblock_4);

                //=================================================================================================================================================

                Category categoryMice = categoryRepository.GetByCategoryName("Mice");

                Product productMouse_1 = new Product
                {
                    BrandName = "Razer",
                    ModelName = "Basilisk",
                    Price = 84900,
                    Amount = 15,
                    ImgUrl = "https://shop.kz/upload/iblock/504/150133_1.jpg",
                    Category = categoryMice,
                    Specification = "BackLight = RGB Connection = wireless ButtonAmount = 13 Type = optical OpticalResolution = 20000 Weight = 400 g Color = Black"
                };

                Product productMouse_2 = new Product
                {
                    BrandName = "Asus Rog",
                    ModelName = "Chakram",
                    Price = 74790,
                    Amount = 9,
                    ImgUrl = "https://shop.kz/upload/iblock/662/148065_1.jpg",
                    Category = categoryMice,
                    Specification = "BackLight = RGB Connection = wireless ButtonAmount = 7 Type = optical OpticalResolution = 16000 Weight = 300 g Color = Black"
                };

                Product productMouse_3 = new Product
                {
                    BrandName = "Razer",
                    ModelName = "Naga",
                    Price = 69990,
                    Amount = 8,
                    ImgUrl = "https://shop.kz/upload/iblock/3f7/154874_1.jpg",
                    Category = categoryMice,
                    Specification = "BackLight = RGB Connection = wireless ButtonAmount = 20 Type = optical OpticalResolution = 20000 Weight = 357 g Color = Black"
                };


                productRepository.Save(productMouse_1);
                productRepository.Save(productMouse_2);
                productRepository.Save(productMouse_3);


                //=================================================================================================================================================

                Category categoryPhones = categoryRepository.GetByCategoryName("Phones");

                Product productPhone_1 = new Product
                {
                    BrandName = "Apple",
                    ModelName = "SE",
                    Price = 229890,
                    Amount = 15,
                    ImgUrl = "https://shop.kz/upload/iblock/59b/147693_01.jpg",
                    Category = categoryPhones,
                    Specification = "DisplayDiagonal = 4.7 DisplayResolution = 1334x750 Color = red Weight = 600 g SimType = nanoSim, eSim SimAmount = 1 " +
                    "Core Amount = 6 OperatingSystem = IOS BuiltMemory = 64 Ram = 3 BatteryCapacity = 2000 Cpu = Apple MainCamera = 12 FrontCamera = 7 " +
                    "NavSystem = GPS Nfc = Yes FaceRecognition = Yes BodyMaterial = steel UsbPort = Apple lightning"
                };

                Product productPhone_2 = new Product
                {
                    BrandName = "Huawei",
                    ModelName = "P smart",
                    Price = 49900,
                    Amount = 13,
                    ImgUrl = "https://shop.kz/upload/iblock/3dc/134862-_-0.jpg",
                    Category = categoryPhones,
                    Specification = "DisplayDiagonal = 6.21 DisplayResolution = 2340x1080 Color = black Weight = 149 g SimType = nanoSim SimAmount = 2 " +
                    "Core Amount = 8 OperatingSystem = Android BuiltMemory = 32 Ram = 3 BatteryCapacity = 3400 Cpu = Kirin 710 MainCamera = 32 FrontCamera = 16 " +
                    "NavSystem = GPS Nfc = Yes FaceRecognition = Yes BodyMaterial = plastic UsbPort = microUSB"
                };

                Product productPhone_3 = new Product
                {
                    BrandName = "Xiaomi",
                    ModelName = "Mi 11",
                    Price = 399990,
                    Amount = 9,
                    ImgUrl = "https://shop.kz/upload/iblock/86a/155372_1.jpg",
                    Category = categoryPhones,
                    Specification = "DisplayDiagonal = 6.81 DisplayResolution = 3200x1440 Color = black Weight = 180 g SimType = nanoSim, eSim SimAmount = 2 " +
                    "Core Amount = 8 OperatingSystem = Android BuiltMemory = 256 Ram = 8 BatteryCapacity = 4600 Cpu = Qualcomm MainCamera = 108+13+15 FrontCamera = 20 " +
                    "NavSystem = GPS Nfc = Yes FaceRecognition = Yes BodyMaterial = plastic UsbPort = Type-C"
                };


                productRepository.Save(productPhone_1);
                productRepository.Save(productPhone_2);
                productRepository.Save(productPhone_3);

                //=================================================================================================================================================

                Category categorySmartWatches = categoryRepository.GetByCategoryName("Smart Watches");

                Product productSmartWatch_1 = new Product
                {
                    BrandName = "Apple",
                    ModelName = "Nike series 6",
                    Price = 214990,
                    Amount = 5,
                    ImgUrl = "https://shop.kz/upload/iblock/5dd/150797_1.jpg",
                    Category = categorySmartWatches,
                    Specification = "BraceletMaterial = leather BodyMaterial = aluminum Wifi = Yes Bluetooth = Yes Sensor = accelerometer Weight = 100 g Color = white"
                };

                Product productSmartWatch_2 = new Product
                {
                    BrandName = "Amazfit",
                    ModelName = "Stratos 2",
                    Price = 103300,
                    Amount = 2,
                    ImgUrl = "https://shop.kz/upload/iblock/f85/131466_3.jpg",
                    Category = categorySmartWatches,
                    Specification = "BraceletMaterial = leather BodyMaterial = steel, policarbonium Wifi = false Bluetooth = Yes Sensor = accelerometer Weight = 100 g Color = Black"
                };


                productRepository.Save(productSmartWatch_1);
                productRepository.Save(productSmartWatch_2);

                //=================================================================================================================================================
                Category categoryTvs = categoryRepository.GetByCategoryName("TV");

                Product productTv_1 = new Product
                {
                    BrandName = "Sony",
                    ModelName = "kd75xg8096br2",
                    Price = 999990,
                    Amount = 5,
                    ImgUrl = "https://shop.kz/upload/iblock/0c7/147618_640.jpg",
                    Category = categoryTvs,
                    Specification = "DisplayDiagonal = 75 DisplayResolution = 3840x2160 Color = Black Weight = 18 kg Smart = Yes Wifi = Yes Frequency = 60 Hz Platform = Android"
                };

                Product productTv_2 = new Product
                {
                    BrandName = "Sony",
                    ModelName = "KD-65XG7096",
                    Price = 399900,
                    Amount = 9,
                    ImgUrl = "https://shop.kz/upload/iblock/b5a/145905_1.jpg",
                    Category = categoryTvs,
                    Specification = "DisplayDiagonal = 65 DisplayResolution = 3840x2160 Color = Black Weight = 17 kg Smart = Yes Wifi = Yes Frequency = 60 Hz Platform = Android"
                };


                productRepository.Save(productTv_1);
                productRepository.Save(productTv_2);

            }
        }
        private static void CreateDefaultCategory(IServiceProvider serviceProvider)
        {
            var categoryRepository = serviceProvider.GetService<ICategoryRepository>();

            var categories = categoryRepository.GetAll().Any();

            if (!categories)
            {
                List<string> categoryNames = new List<string>() { "Keyboards", "Laptops", "Monitors", "Monoblocks", "Mice", "Phones", "Smart Watches", "Tv" };

                for (int i = 0; i < categoryNames.Count; i++)
                {
                    Category category = new Category()
                    {
                        CategoryName = categoryNames[i]
                    };

                    categoryRepository.Save(category);
                }
            }
        }
    }
}
