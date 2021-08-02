
using E_WaveStore.DataLayer.Entity;
using E_WaveStore.DataLayer.Models.Entity;
using E_WaveStore.DataLayer.Repositories.Interfaces;
using E_WaveStore.Models;
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
        public static IHost Seed(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                 CreateDefaultCategory(scope.ServiceProvider);
                /*
                  CreateDefaultKeyboard(scope.ServiceProvider);
                  CreateDefaultLaptop(scope.ServiceProvider);
                  CreateDefaultMonitor(scope.ServiceProvider);
                  CreateDefaultMonoblock(scope.ServiceProvider);
                  CreateDefaultMouse(scope.ServiceProvider);
                  CreateDefaultPhone(scope.ServiceProvider);
                  CreateDefaultSmartWatch(scope.ServiceProvider);
                  CreateDefaultTv(scope.ServiceProvider);*/

                //CreateDefaultSpecification(scope.ServiceProvider);


            }

            return host;
        }

        /* public static void CreateDefaultSpecification(IServiceProvider serviceProvider)
         {
             var specificationRepository = serviceProvider.GetService<ISpecificationRepository>();
             KeyboardVM keyboard_1 = new KeyboardVM
             {
                 KeysAmount = 112,
                 ConnectionType = "Wired",
                 Layout = "qwerty",
                 Dimension = "44.2 x 4.9 x 13.2",
                 KeyType = "Mechanical",
                 Color = "Black",
                 BackLight = "RGB"
             };

             KeyboardVM keyboard_2 = new KeyboardVM
             {
                 KeysAmount = 112,
                 ConnectionType = "Wireless",
                 Layout = "qwerty",
                 Dimension = "44.4 x 3.7 x 13.2",
                 KeyType = "Mechanical",
                 Color = "Black",
                 BackLight = "RGB"
             };

             KeyboardVM keyboard_3 = new KeyboardVM
             {
                 KeysAmount = 112,
                 ConnectionType = "Wireless",
                 Layout = "qwerty",
                 Dimension = "44.4 x 3.7 x 13.2",
                 KeyType = "optic-mechanical",
                 Color = "Black",
                 BackLight = "Red"
             };

             KeyboardVM keyboard_4 = new KeyboardVM
             {
                 KeysAmount = 117,
                 ConnectionType = "Wireless",
                 Layout = "qwerty",
                 Dimension = "37.3 x 2.1 x 14.4",
                 KeyType = "membrane",
                 Color = "Black",
                 BackLight = "Blue"
             };
             string JSONString_1 = string.Empty;
             string JSONString_2 = string.Empty;
             string JSONString_3 = string.Empty;
             string JSONString_4 = string.Empty;
             JSONString_1 = JsonConvert.SerializeObject(keyboard_1);
             JSONString_2 = JsonConvert.SerializeObject(keyboard_2);
             JSONString_3 = JsonConvert.SerializeObject(keyboard_3);
             JSONString_4 = JsonConvert.SerializeObject(keyboard_4);

             specificationRepository.Save(
                 new Specification
                 {
                     Characteristics = JSONString_1
                 });
             specificationRepository.Save(
                 new Specification
                 {
                     Characteristics = JSONString_2
                 });
             specificationRepository.Save(
                 new Specification
                 {
                     Characteristics = JSONString_3
                 });
             specificationRepository.Save(
                 new Specification
                 {
                     Characteristics = JSONString_4
                 });
         }
 */

        private static void CreateDefaultCategory(IServiceProvider serviceProvider)
        {
            var categoryRepository = serviceProvider.GetService<ICategoryRepository>();

            var categories = categoryRepository.GetAll().Any();

            if (!categories)
            {
                List<long> categoryIds = new List<long>() { 1, 2, 3, 4, 5, 6, 7, 8 };
                List<string> categoryNames = new List<string>() { "Keyboards", "Laptops", "Monitors", "Monoblocks", "Mice", "Phones", "Smart Watches", "Tv" };

                for (int i = 0; i < categoryIds.Count; i++)
                {
                    Category category = new Category()
                    {
                        Id = categoryIds[i],
                        CategoryName = categoryNames[i]
                    };

                    categoryRepository.Save(category);
                }
            }
        }
        /*
                private static void CreateDefaultKeyboard(IServiceProvider serviceProvider)
                {
                    var keyboardRepository = serviceProvider.GetService<IKeyboardRepository>();
                    var keyboards = keyboardRepository.GetAll().Any();

                    Category category = new Category();
                    category.CategoryName = "Keyboards";
                    if (!keyboards)
                    {
                        Keyboard keyboard_1 = new Keyboard()
                        {
                            Id = 100,
                            BrandName = "A4tech",
                            ModelName = "Bloody B500n",
                            Price = 15000,
                            Amount = 32,
                            ImgUrl = "https://shop.kz/upload/iblock/4d6/151222_1.jpg",
                            Category = category,
                            KeysAmount = 112,
                            ConnectionType = "Wired",
                            Layout = "qwerty",
                            Dimension = "44.2 x 4.9 x 13.2",
                            KeyType = "mechanical",
                            Color = "Black",
                            BackLight = "RGB"
                        };

                        Keyboard keyboard_2 = new Keyboard()
                        {
                            Id = 100,
                            BrandName = "A4tech",
                            ModelName = "Bloody B810R",
                            Price = 30000,
                            Amount = 15,
                            ImgUrl = "https://shop.kz/upload/iblock/d50/131490_1.jpg",
                            Category = category,
                            KeysAmount = 112,
                            ConnectionType = "Wireless",
                            Layout = "qwerty",
                            Dimension = "44.4 x 3.7 x 13.2",
                            KeyType = "mechanical",
                            Color = "Black",
                            BackLight = "RGB"
                        };

                        Keyboard keyboard_3 = new Keyboard()
                        {
                            Id = 100,
                            BrandName = "A4tech",
                            ModelName = "Bloody B800",
                            Price = 30000,
                            Amount = 10,
                            ImgUrl = "https://shop.kz/upload/iblock/741/151224_1.jpg",
                            Category = category,
                            KeysAmount = 112,
                            ConnectionType = "Wired",
                            Layout = "qwerty",
                            Dimension = "44.4 x 3.7 x 13.2",
                            KeyType = "optic-mechanical",
                            Color = "Black",
                            BackLight = "Red"
                        };

                        Keyboard keyboard_4 = new Keyboard()
                        {
                            Id = 100,
                            BrandName = "Logitech",
                            ModelName = "K580",
                            Price = 32990,
                            Amount = 23,
                            ImgUrl = "https://shop.kz/upload/iblock/0bc/154202_1.jpg",
                            Category = category,
                            KeysAmount = 117,
                            ConnectionType = "Wireless",
                            Layout = "qwerty",
                            Dimension = "37.3 x 2.1 x 14.4",
                            KeyType = "membrane",
                            Color = "Black",
                            BackLight = "blue"
                        };

                        Keyboard keyboard_5 = new Keyboard()
                        {
                            Id = 100,
                            BrandName = "SteelSeries",
                            ModelName = "Apex 150",
                            Price = 33900,
                            Amount = 7,
                            ImgUrl = "https://shop.kz/upload/iblock/dd2/14img_6169-kopiya.jpg",
                            Category = category,
                            KeysAmount = 107,
                            ConnectionType = "Wired",
                            Layout = "qwerty",
                            Dimension = "46.3 x 15.6 x 4.2",
                            KeyType = "membrane",
                            Color = "Black",
                            BackLight = "RGB"
                        };

                        Keyboard keyboard_6 = new Keyboard()
                        {
                            Id = 100,
                            BrandName = "Razer",
                            ModelName = "BlackWidow",
                            Price = 39900,
                            Amount = 25,
                            ImgUrl = "https://shop.kz/upload/iblock/fc2/1img_0892_640.jpg",
                            Category = category,
                            KeysAmount = 104,
                            ConnectionType = "Wired",
                            Layout = "qwerty",
                            Dimension = "36.4 x 15.4 x 3",
                            KeyType = "mechanical",
                            Color = "Black",
                            BackLight = "RGB"
                        };

                        Keyboard keyboard_7 = new Keyboard()
                        {
                            Id = 100,
                            BrandName = "Rapoo",
                            ModelName = "V700 RGB",
                            Price = 34690,
                            Amount = 14,
                            ImgUrl = "https://shop.kz/upload/iblock/8ca/145155_1.jpg",
                            Category = category,
                            KeysAmount = 109,
                            ConnectionType = "Wired",
                            Layout = "qwerty",
                            Dimension = "43.4 x 13.4 x 3.7",
                            KeyType = "mechanical",
                            Color = "Black",
                            BackLight = "RGB"
                        };

                        keyboardRepository.Save(keyboard_1);
                        keyboardRepository.Save(keyboard_2);
                        keyboardRepository.Save(keyboard_3);
                        keyboardRepository.Save(keyboard_4);
                        keyboardRepository.Save(keyboard_5);
                        keyboardRepository.Save(keyboard_6);
                        keyboardRepository.Save(keyboard_7);
                    }
                }

                private static void CreateDefaultLaptop(IServiceProvider serviceProvider)
                {
                    var laptopRepository = serviceProvider.GetService<ILaptopRepository>();
                    var laptops = laptopRepository.GetAll().Any();

                    Category category = new Category();
                    category.CategoryName = "Laptops";
                    if (!laptops)
                    {
                        Laptop laptops_1 = new Laptop()
                        {
                            Id = 100,
                            BrandName = "Prestigio",
                            ModelName = "SmartBook 141",
                            Price = 109900,
                            Amount = 42,
                            ImgUrl = "https://shop.kz/upload/iblock/519/149185_01.jpg",
                            Category = category,
                            OperationalSystem = "Windows 10 Pro",
                            Cpu = "Intel celeron",
                            Ram = 4,
                            CoreAmount = 2,
                            Ssd = "120 Гб",
                            Hdd = "Нет",
                            DisplayDiagonal = 17.4f,
                            DisplayResolution = "1920x1080",
                            Color = "Black",
                            Weight = 3
                        };
                        Laptop laptops_2 = new Laptop()
                        {
                            Id = 100,
                            BrandName = "Asus",
                            ModelName = "x515MA",
                            Price = 144990,
                            Amount = 62,
                            ImgUrl = "https://shop.kz/upload/iblock/422/153567_1.jpg",
                            Category = category,
                            OperationalSystem = "Windows 10 Home",
                            Cpu = "Intel celeron",
                            Ram = 4,
                            CoreAmount = 2,
                            Ssd = "Нет",
                            Hdd = "1 Тб",
                            DisplayDiagonal = 17.4f,
                            DisplayResolution = "1920x1080",
                            Color = "Black",
                            Weight = 3
                        };
                        Laptop laptops_3 = new Laptop()
                        {
                            Id = 100,
                            BrandName = "Lenovo",
                            ModelName = "IdeaPad s145",
                            Price = 149900,
                            Amount = 12,
                            ImgUrl = "https://shop.kz/upload/iblock/1a7/152324_1.jpg",
                            Category = category,
                            OperationalSystem = "Windows 10 Enterprice",
                            Cpu = "AMD E-series",
                            Ram = 4,
                            CoreAmount = 2,
                            Ssd = "Нет",
                            Hdd = "1 Тб",
                            DisplayDiagonal = 17.4f,
                            DisplayResolution = "1920x1080",
                            Color = "Black",
                            Weight = 3
                        };
                        Laptop laptops_4 = new Laptop()
                        {
                            Id = 100,
                            BrandName = "Acer",
                            ModelName = "Aspire a315",
                            Price = 239990,
                            Amount = 53,
                            ImgUrl = "https://shop.kz/upload/iblock/d41/149452_1.jpg",
                            Category = category,
                            OperationalSystem = "Windows 10 Pro",
                            Cpu = "Intel i3",
                            Ram = 4,
                            CoreAmount = 2,
                            Ssd = "Нет",
                            Hdd = "1 Тб",
                            DisplayDiagonal = 17.4f,
                            DisplayResolution = "1920x1080",
                            Color = "Black",
                            Weight = 3
                        };
                        Laptop laptops_5 = new Laptop()
                        {
                            Id = 100,
                            BrandName = "HP",
                            ModelName = "Pavilion 15-ec1054ur",
                            Price = 449900,
                            Amount = 42,
                            ImgUrl = "https://shop.kz/upload/iblock/2e0/155098_1.jpg",
                            Category = category,
                            OperationalSystem = "Windows 10 Pro",
                            Cpu = "AMD Ryzen 7",
                            Ram = 16,
                            CoreAmount = 8,
                            Ssd = "1 Тб",
                            Hdd = "Нет",
                            DisplayDiagonal = 17.4f,
                            DisplayResolution = "1920x1080",
                            Color = "Black",
                            Weight = 3
                        };
                        Laptop laptops_6 = new Laptop()
                        {
                            Id = 100,
                            BrandName = "Acer",
                            ModelName = "Nitro 5 AN517-52",
                            Price = 451900,
                            Amount = 22,
                            ImgUrl = "https://shop.kz/upload/iblock/616/151798_1.jpg",
                            Category = category,
                            OperationalSystem = "Windows 10 Pro",
                            Cpu = "Intel core i5",
                            Ram = 8,
                            CoreAmount = 4,
                            Ssd = "512 Гб",
                            Hdd = "Нет",
                            DisplayDiagonal = 17.4f,
                            DisplayResolution = "1920x1080",
                            Color = "Black",
                            Weight = 3
                        };
                        Laptop laptops_7 = new Laptop()
                        {
                            Id = 100,
                            BrandName = "Asus ROG",
                            ModelName = "Zephyrus GX703HS",
                            Price = 1879900,
                            Amount = 2,
                            ImgUrl = "https://static.shop.kz/upload/resize_cache/iblock/528/450_450_1/155994_1.jpg",
                            Category = category,
                            OperationalSystem = "Windows 10 Pro",
                            Cpu = "Intel Core i9",
                            Ram = 32,
                            CoreAmount = 8,
                            Ssd = "3 Тб",
                            Hdd = "Нет",
                            DisplayDiagonal = 17.4f,
                            DisplayResolution = "1920x1080",
                            Color = "Black",
                            Weight = 3
                        };


                        laptopRepository.Save(laptops_1);
                        laptopRepository.Save(laptops_2);
                        laptopRepository.Save(laptops_3);
                        laptopRepository.Save(laptops_4);
                        laptopRepository.Save(laptops_5);
                        laptopRepository.Save(laptops_6);
                        laptopRepository.Save(laptops_7);
                    }
                }

                private static void CreateDefaultMonitor(IServiceProvider serviceProvider)
                {
                    var monitorRepository = serviceProvider.GetService<IMonitorRepository>();
                    var monitors = monitorRepository.GetAll().Any();

                    Category category = new Category();
                    category.CategoryName = "Monitors";

                    if (!monitors)
                    {
                        Monitor monitor_1 = new Monitor()
                        {
                            Id = 100,
                            BrandName = "2E",
                            ModelName = "e1919b",
                            Price = 26200,
                            Amount = 45,
                            ImgUrl = "https://static.shop.kz/upload/resize_cache/iblock/472/450_450_1/155650_1.jpg",
                            Category = category,
                            MonitorcInterface = "VGA",
                            PowerConsumption = 0.5,
                            Dimension = "43x38x19",
                            Frequency = 60,
                            DisplayDiagonal = 19,
                            DisplayResolution = "1440x900",
                            Color = "Black",
                            Weight = 3,
                        };
                        Monitor monitor_2 = new Monitor()
                        {
                            Id = 100,
                            BrandName = "philips",
                            ModelName = "243v7qdsb",
                            Price = 59900,
                            Amount = 13,
                            ImgUrl = "https://shop.kz/upload/iblock/ccc/126612_1.jpg",
                            Category = category,
                            MonitorcInterface = "VGA, dvi-d, hdmi",
                            PowerConsumption = 0.5,
                            Dimension = "43x38x19",
                            Frequency = 60,
                            DisplayDiagonal = 23.8f,
                            DisplayResolution = "1920x1080",
                            Color = "Black",
                            Weight = 3,
                        };
                        Monitor monitor_3 = new Monitor()
                        {
                            Id = 100,
                            BrandName = "Samsung",
                            ModelName = "s24f356fhi",
                            Price = 59990,
                            Amount = 35,
                            ImgUrl = "https://shop.kz/upload/iblock/fea/129229.jpg",
                            Category = category,
                            MonitorcInterface = "VGA, hdmi",
                            PowerConsumption = 0.3,
                            Dimension = "54x42x21",
                            Frequency = 60,
                            DisplayDiagonal = 23.5f,
                            DisplayResolution = "1920x1080",
                            Color = "Black",
                            Weight = 3,
                        };
                        Monitor monitor_4 = new Monitor()
                        {
                            Id = 100,
                            BrandName = "HP",
                            ModelName = "x24ih",
                            Price = 90100,
                            Amount = 25,
                            ImgUrl = "https://shop.kz/upload/iblock/706/154562_1.jpg",
                            Category = category,
                            MonitorcInterface = "hdmi, displayPort",
                            PowerConsumption = 0.5,
                            Dimension = "54x49x21",
                            Frequency = 144,
                            DisplayDiagonal = 23.8f,
                            DisplayResolution = "1920x1080",
                            Color = "Black",
                            Weight = 3,
                        };
                        Monitor monitor_5 = new Monitor()
                        {
                            Id = 100,
                            BrandName = "LG",
                            ModelName = "24mk400h",
                            Price = 61900,
                            Amount = 45,
                            ImgUrl = "https://shop.kz/upload/iblock/1d1/132195_01.jpg",
                            Category = category,
                            MonitorcInterface = "VGA, hdmi",
                            PowerConsumption = 0.5,
                            Dimension = "43x38x19",
                            Frequency = 75,
                            DisplayDiagonal = 23.8f,
                            DisplayResolution = "1920x1080",
                            Color = "Black",
                            Weight = 3,
                        };
                        Monitor monitor_6 = new Monitor()
                        {
                            Id = 100,
                            BrandName = "AOC",
                            ModelName = "g2590vxq",
                            Price = 84500,
                            Amount = 55,
                            ImgUrl = "https://shop.kz/upload/iblock/1b6/133526_01.jpg",
                            Category = category,
                            MonitorcInterface = "VGA 2xHDMI",
                            PowerConsumption = 0.5,
                            Dimension = "43x38x19",
                            Frequency = 75,
                            DisplayDiagonal = 24.5f,
                            DisplayResolution = "1920x1080",
                            Color = "Black-Red",
                            Weight = 3,
                        };
                        monitorRepository.Save(monitor_1);
                        monitorRepository.Save(monitor_2);
                        monitorRepository.Save(monitor_3);
                        monitorRepository.Save(monitor_4);
                        monitorRepository.Save(monitor_5);
                        monitorRepository.Save(monitor_6);

                    }
                }

                private static void CreateDefaultMonoblock(IServiceProvider serviceProvider)
                {
                    var monoblockRepository = serviceProvider.GetService<IMonoblockRepository>();
                    var monoblocks = monoblockRepository.GetAll().Any();

                    Category category = new Category();
                    category.CategoryName = "Monoblocks";
                    if (!monoblocks)
                    {
                        MonoBlock monoBlock_1 = new MonoBlock()
                        {
                            Id = 100,
                            BrandName = "HP",
                            ModelName = "All in one 21-b0013ur",
                            Price = 139900,
                            Amount = 15,
                            ImgUrl = "https://shop.kz/upload/iblock/d80/152743_1.jpg",
                            Category = category,
                            DisplayDiagonal = 20.7f,
                            DisplayResolution = "1920x1080",
                            Color = "white",
                            Weight = 3,
                            Cpu = "intel celeron",
                            OperationalSystem = "нет",
                            Dimension = "49x36x18",
                            MonoBlockInterface = "2 usb 2.0, 2xusb 3.0, mic, card reader",
                            WebCamera = true,
                            VideoCard = "intel uhd graphics 600",
                            Ram = 4,
                            RamType = "DDR4",
                            Hdd = "1 Тб",
                            VideoMemorySize = 2,
                        };
                        MonoBlock monoBlock_2 = new MonoBlock()
                        {
                            Id = 100,
                            BrandName = "Lenovo",
                            ModelName = "IDeacentre aio",
                            Price = 206700,
                            Amount = 15,
                            ImgUrl = "https://shop.kz/upload/iblock/d80/152743_1.jpg",
                            Category = category,
                            DisplayDiagonal = 21.7f,
                            DisplayResolution = "1920x1080",
                            Color = "black",
                            Weight = 3,
                            Cpu = "amd athlon silver     ",
                            OperationalSystem = "windows 10 home",
                            Dimension = "49x42x18",
                            MonoBlockInterface = "2xusb 3.0,hdmi",
                            WebCamera = true,
                            VideoCard = "Radeon graphics",
                            Ram = 4,
                            RamType = "DDR4",
                            Hdd = "1 Тб",
                            VideoMemorySize = 2,
                        };
                        monoblockRepository.Save(monoBlock_1);
                        monoblockRepository.Save(monoBlock_2);
                    }
                }

                private static void CreateDefaultMouse(IServiceProvider serviceProvider)
                {
                    var mouseRepository = serviceProvider.GetService<IMouseRepository>();
                    var mice = mouseRepository.GetAll().Any();

                    Category category = new Category();
                    category.CategoryName = "Mice";
                    if (!mice)
                    {
                        Mouse mouse_1 = new Mouse()
                        {
                            Id = 1,
                            BrandName = "Razer",
                            ModelName = "Basilisk",
                            Price = 84900,
                            Amount = 15,
                            ImgUrl = "https://shop.kz/upload/iblock/504/150133_1.jpg",
                            Category = category,
                            BackLight = "RGB",
                            Connection = "wireless",
                            ButtonAmount = 13,
                            Type = "optical",
                            OpticalResolution = 20000,
                            Weight = 1,
                            Color = "Black"
                        };
                        Mouse mouse_2 = new Mouse()
                        {
                            Id = 2,
                            BrandName = "Asus Rog",
                            ModelName = "Chakram",
                            Price = 74790,
                            Amount = 9,
                            ImgUrl = "https://shop.kz/upload/iblock/662/148065_1.jpg",
                            Category = category,
                            BackLight = "RGB",
                            Connection = "wireless",
                            ButtonAmount = 7,
                            Type = "optical",
                            OpticalResolution = 16000,
                            Weight = 1,
                            Color = "Black"
                        };
                        Mouse mouse_3 = new Mouse()
                        {
                            Id = 3,
                            BrandName = "Razer",
                            ModelName = "Naga",
                            Price = 69990,
                            Amount = 8,
                            ImgUrl = "https://shop.kz/upload/iblock/3f7/154874_1.jpg",
                            Category = category,
                            BackLight = "RGB",
                            Connection = "wireless",
                            ButtonAmount = 20,
                            Type = "optical",
                            OpticalResolution = 20000,
                            Weight = 1,
                            Color = "Black"
                        };
                        mouseRepository.Save(mouse_1);
                        mouseRepository.Save(mouse_2);
                        mouseRepository.Save(mouse_3);
                    }
                }

                private static void CreateDefaultPhone(IServiceProvider serviceProvider)
                {
                    var phoneRepository = serviceProvider.GetService<IPhoneRepository>();
                    var phones = phoneRepository.GetAll().Any();

                    Category category = new Category();
                    category.CategoryName = "Phones";
                    if (!phones)
                    {
                        Phone phone_1 = new Phone()
                        {
                            Id = 1,
                            BrandName = "Apple",
                            ModelName = "SE",
                            Price = 229890,
                            Amount = 15,
                            ImgUrl = "https://shop.kz/upload/iblock/59b/147693_01.jpg",
                            Category = category,
                            DisplayDiagonal = 4.7f,
                            DisplayResolution = "1334X750",
                            Color = "red",
                            Weight = 1,
                            SimType = "nanoSim, eSim",
                            SimAmount = 1,
                            CoreAmount = 6,
                            OperatingSystem = "iOS",
                            BuiltMemory = 64,
                            Ram = 3,
                            BatteryCapacity = 2000,
                            Cpu = "Apple",
                            MainCamera = "12",
                            FrontCamera = "7",
                            NavSystem = "gps",
                            Nfc = true,
                            FaceRecognition = true,
                            BodyMaterial = "steel",
                            UsbPort = "APple lightning"
                        };
                        Phone phone_2 = new Phone()
                        {
                            Id = 2,
                            BrandName = "Huawei",
                            ModelName = "P smart",
                            Price = 49900,
                            Amount = 13,
                            ImgUrl = "https://shop.kz/upload/iblock/3dc/134862-_-0.jpg",
                            Category = category,
                            DisplayDiagonal = 6.21f,
                            DisplayResolution = "2340x1080",
                            Color = "black",
                            Weight = 1,
                            SimType = "Nano",
                            SimAmount = 2,
                            CoreAmount = 8,
                            OperatingSystem = "Android",
                            BuiltMemory = 32,
                            Ram = 3,
                            BatteryCapacity = 3400,
                            Cpu = "Kirin 710",
                            MainCamera = "32",
                            FrontCamera = "16",
                            NavSystem = "gps",
                            Nfc = true,
                            FaceRecognition = true,
                            BodyMaterial = "plastic",
                            UsbPort = "microUsb"
                        };
                        Phone phone_3 = new Phone()
                        {
                            Id = 3,
                            BrandName = "Xiaomi",
                            ModelName = "Mi 11",
                            Price = 399990,
                            Amount = 9,
                            ImgUrl = "https://shop.kz/upload/iblock/86a/155372_1.jpg",
                            Category = category,
                            DisplayDiagonal = 6.81f,
                            DisplayResolution = "3200x1440",
                            Color = "black",
                            Weight = 1,
                            SimType = "Nano",
                            SimAmount = 2,
                            CoreAmount = 8,
                            OperatingSystem = "Android",
                            BuiltMemory = 256,
                            Ram = 8,
                            BatteryCapacity = 4600,
                            Cpu = "Qualcomm",
                            MainCamera = "108+13+5",
                            FrontCamera = "20",
                            NavSystem = "gps",
                            Nfc = true,
                            FaceRecognition = true,
                            BodyMaterial = "plastic",
                            UsbPort = "Type-c"
                        };

                        phoneRepository.Save(phone_1);
                        phoneRepository.Save(phone_2);
                        phoneRepository.Save(phone_3);
                    }
                }

                private static void CreateDefaultSmartWatch(IServiceProvider serviceProvider)
                {
                    var smartWatchRepository = serviceProvider.GetService<ISmartWatchRepository>();
                    var smartWatches = smartWatchRepository.GetAll().Any();

                    Category category = new Category();
                    category.CategoryName = "Smart Watches";
                    if (!smartWatches)
                    {
                        SmartWatch smartWatch_1 = new SmartWatch()
                        {
                            Id = 1,
                            BrandName = "Apple",
                            ModelName = "Nike series 6",
                            Price = 214990,
                            Amount = 5,
                            ImgUrl = "https://shop.kz/upload/iblock/5dd/150797_1.jpg",
                            Category = category,
                            BraceletMaterial = "leather",
                            BodyMaterial = "aluminum",
                            Wifi = true,
                            Bluetooth = true,
                            Sensor = "accelerometer",
                            Weight = 0,
                            Color = "white",
                        };
                        SmartWatch smartWatch_2 = new SmartWatch()
                        {
                            Id = 2,
                            BrandName = "Amazfit",
                            ModelName = "Stratos 2",
                            Price = 103300,
                            Amount = 2,
                            ImgUrl = "https://shop.kz/upload/iblock/f85/131466_3.jpg",
                            Category = category,
                            BraceletMaterial = "leather",
                            BodyMaterial = "steel, policarbonium",
                            Wifi = false,
                            Bluetooth = true,
                            Sensor = "accelerometer",
                            Weight = 0,
                            Color = "Black",
                        };

                        smartWatchRepository.Save(smartWatch_1);
                        smartWatchRepository.Save(smartWatch_2);
                    }
                }

                private static void CreateDefaultTv(IServiceProvider serviceProvider)
                {
                    var tvRepository = serviceProvider.GetService<ITvRepository>();
                    var tvs = tvRepository.GetAll().Any();

                    Category category = new Category();
                    category.CategoryName = "Tv";
                    if (!tvs)
                    {
                        Tv tv_1 = new Tv()
                        {
                            Id = 1,
                            BrandName = "Sony",
                            ModelName = "kd75xg8096br2",
                            Price = 999990,
                            Amount = 5,
                            ImgUrl = "https://shop.kz/upload/iblock/0c7/147618_640.jpg",
                            Category = category,
                            DisplayDiagonal = 75,
                            DisplayResolution = "3840x2160",
                            Color = "Black",
                            Weight = 32,
                            Smart = true,
                            Wifi = true,
                            Frequency = 60,
                            Platform = "Android"
                        };
                        Tv tv_2 = new Tv()
                        {
                            Id = 2,
                            BrandName = "Sony",
                            ModelName = "KD-65XG7096",
                            Price = 399900,
                            Amount = 9,
                            ImgUrl = "https://shop.kz/upload/iblock/b5a/145905_1.jpg",
                            Category = category,
                            DisplayDiagonal = 65,
                            DisplayResolution = "3840x2160",
                            Color = "Black",
                            Weight = 31,
                            Smart = true,
                            Wifi = true,
                            Frequency = 60,
                            Platform = "Android"
                        };

                        tvRepository.Save(tv_1);
                        tvRepository.Save(tv_2);

                    }
                }*/

    }
}
