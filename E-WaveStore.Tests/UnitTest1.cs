using AutoMapper;
using E_WaveStore.Controllers;
using E_WaveStore.DataLayer;
using E_WaveStore.DataLayer.Entity;
using E_WaveStore.DataLayer.Models;
using E_WaveStore.DataLayer.Models.Entity;
using E_WaveStore.DataLayer.Repositories.Implementations;
using E_WaveStore.DataLayer.Repositories.Interfaces;
using E_WaveStore.Models;
using E_WaveStore.PresentationLayer.Implementations;
using E_WaveStore.PresentationLayer.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Moq;
using NUnit.Framework;
using ReflectionIT.Mvc.Paging;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;

namespace E_WaveStore.Tests
{
    public class Tests
    {
        private Mock<IProductRepository> productRepositoryMock;       
        private Mock<IOrderRepository> orderRepositoryMock;       
        private Mock<ICategoryRepository> categoryRepositoryMock;       
        private Mock<ICartRepository> cartRepositoryMock; 
        
        private Mock<IPaymentTypeRepository> paymentTypeRepositoryMock;    
        
        private Mock<IMapper> mapperMock;
        
        private IWebHostEnvironment webHostEnvironment;
        private ProductPresentation productPresentation;
        private OrderPresentation orderPresentation;
        private CategoryPresentation categoryPresentation;
        private CartPresentation cartPresentation;                  

        [SetUp]
        public void Setup()
        {
            productRepositoryMock = new Mock<IProductRepository>();
            orderRepositoryMock = new Mock<IOrderRepository>();
            categoryRepositoryMock = new Mock<ICategoryRepository>();
            cartRepositoryMock = new Mock<ICartRepository>();
            paymentTypeRepositoryMock = new Mock<IPaymentTypeRepository>();

            mapperMock = new Mock<IMapper>();

            productPresentation = new ProductPresentation(
                productRepositoryMock.Object,              
                mapperMock.Object);

            orderPresentation = new OrderPresentation(
               orderRepositoryMock.Object,
               paymentTypeRepositoryMock.Object,
               mapperMock.Object);

            categoryPresentation = new CategoryPresentation(
              categoryRepositoryMock.Object,
              mapperMock.Object);

            cartPresentation = new CartPresentation(
              cartRepositoryMock.Object,
              mapperMock.Object);
        }

        List<Product> getSomeProducts()
        {
            return new List<Product>()
            {
                new Product(){BrandName="Acer",ModelName="Vnn321",Price=15640,Amount=5,ImgUrl="Empty",Specification="Resolution = 1920x1080",Category=new Category(){ CategoryName="Laptops"} },
                new Product(){BrandName="Razer",ModelName="Naga",Price=34950,Amount=10,ImgUrl="Empty",Specification="Button amount = 20",Category=new Category(){ CategoryName="Mice"} },
                new Product(){BrandName="SteelSeries",ModelName="someShit",Price=21540,Amount=6,ImgUrl="SomeImg",Specification="Type = mechanical",Category=new Category(){ CategoryName="Keyboards"} }
            };
        }
        [Test]
        public void Test_ProductList()
        {

            /* var prod = new Product();
             productRepositoryMock.Setup(x => x.GetByModelName("SmartBook 141")).Returns(prod);*/
            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[] {
                                        new Claim(ClaimTypes.NameIdentifier, "SomeValueHere"),
                                        new Claim(ClaimTypes.Name, "some@somecompany.com")                                        
                                   }, "TestAuthentication"));

            ProductController controller = new ProductController(productPresentation, webHostEnvironment, categoryPresentation, cartPresentation, orderPresentation);

            controller.ControllerContext.HttpContext = new DefaultHttpContext { User = user };
            var products = new List<Product>();
            
            productRepositoryMock.Setup(x => x.GetAll()).Returns(getSomeProducts);

            var test2 = controller.ProductList("Laptops");           

            var result = true ? test2 != null : false;

            Assert.IsTrue(result);

        }

        [Test]
        public void Test_FilterProductbyPriceAndBrandName()
        {
            ProductController controller = new ProductController(productPresentation, webHostEnvironment, categoryPresentation, cartPresentation, orderPresentation);

            productRepositoryMock.Setup(x => x.GetAll()).Returns(getSomeProducts);
        }
    }
}