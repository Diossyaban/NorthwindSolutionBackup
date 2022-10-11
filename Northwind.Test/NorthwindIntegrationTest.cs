using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Northwind.Contracts.Dto.Category;
using Northwind.Contracts.Dto.Product;
using Northwind.Domain.Base;
using Northwind.Domain.Models;
using Northwind.Persistence;
using Northwind.Persistence.Base;
using Northwind.Services;
using Northwind.Services.Abstraction;
using Northwind.Web.Mapping;
using Shouldly;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Northwind.Test
{
    public class NorthwindIntegrationTest
    {
        private static IConfigurationRoot Configuration;
        private static DbContextOptionsBuilder<NorthwindContext> optionBuilder;
        private static MapperConfiguration mapperConfig;
        private static IMapper mapper;
        private static IServiceProvider serviceProvider;
        private static IRepositoryManager _repositoryManager;

        public NorthwindIntegrationTest()
        {
            BuildConfiguration();
            SetupOptions();
        }
        [Fact]
        public void TestCreateCategoryService()
        {
            using (var context = new NorthwindContext(optionBuilder.Options))
            {
                // act
                _repositoryManager = new RepositoryManager(context);
                IServiceManager serviceManager = new ServiceManager(_repositoryManager, mapper);
                var categoryForCreate = new CategoryForCreateDto
                {
                    CategoryName = "Toys",
                    Description = "Mainan Anak"
                };
                serviceManager.CategoryService.Insert(categoryForCreate);

                //assert
                var category = serviceManager.CategoryService.GetAllCategory(false);
                category.ShouldNotBeNull();
                category.Result.Count().ShouldBe(13);
            }
        }

        [Fact]
        public void TestGetCategoryService()
        {
            using(var context = new NorthwindContext(optionBuilder.Options))
            {
                _repositoryManager = new RepositoryManager(context);
                IServiceManager serviceManager = new ServiceManager(_repositoryManager, mapper);
                var categoryService = serviceManager.CategoryService.GetAllCategory(false);
                categoryService.ShouldNotBeNull();
                categoryService.Result.Count().ShouldBe(12);
            }
        }
        [Fact]
        public void TestCreateCategoryRepo()
        {
            using (var context = new NorthwindContext(optionBuilder.Options))
            {
                // act
                _repositoryManager = new RepositoryManager(context);

                //define model category
                var categoryModel = new Category
                {
                    CategoryName = "Jajan",
                    Description = "Jajan"
                };
                _repositoryManager.CategoryRepository.Insert(categoryModel);
                _repositoryManager.Save();
                categoryModel.CategoryId.ShouldBeEquivalentTo(24);

                //assert
                var category = _repositoryManager.CategoryRepository.GetAllCategory(false);
                category.ShouldNotBeNull();
                category.Result.Count().ShouldBe(13);
                

            }
        }

        [Fact]
        public void TestCreateProductRepo()
        {
            using (var context = new NorthwindContext(optionBuilder.Options))
            {
                // act
                _repositoryManager = new RepositoryManager(context);

                //define model category
                var categoryModel = new Product
                {
                    ProductName = "Hot Wheels",
                    SupplierId = 1,
                    CategoryId = 1,
                    QuantityPerUnit = "1",
                    Discontinued = false
                };
                _repositoryManager.ProductRepository.Insert(categoryModel);
                _repositoryManager.Save();

                //assert
                var category = _repositoryManager.CategoryRepository.GetAllCategory(false);
                category.ShouldNotBeNull();
                category.Result.Count().ShouldBe(79);
            }
        }

        [Fact]
        public void TestCreateProductService()
        {
            using (var context = new NorthwindContext(optionBuilder.Options))
            {
                // act
                _repositoryManager = new RepositoryManager(context);
                IServiceManager serviceManager = new ServiceManager(_repositoryManager, mapper);
                var categoryForCreate = new ProductForCreateDto
                {
                    ProductName = "Testing55",
                    QuantityPerUnit = "2",
                    Discontinued = false,
                };
                serviceManager.ProductService.Insert(categoryForCreate);

                //assert
                var category = serviceManager.ProductService.GetAllProduct(false);
                category.ShouldNotBeNull();
                category.Result.Count().ShouldBe(82);
            }
        }

        [Fact]
        public void TestEditProductService()
        {
            using (var context = new NorthwindContext(optionBuilder.Options))
            {
                // act
                _repositoryManager = new RepositoryManager(context);
                IServiceManager serviceManager = new ServiceManager(_repositoryManager, mapper);
                var categoryForCreate = new ProductDto
                {
                    ProductId = 83,
                    ProductName = "Koran",
                    SupplierId = 2,
                    CategoryId = 2,
                    QuantityPerUnit = "12",
                    Discontinued = true,
                };
                serviceManager.ProductService.Edit(categoryForCreate);

                //assert
                var category = serviceManager.ProductService.GetAllProduct(false);
                category.ShouldNotBeNull();
                category.Result.Count().ShouldBe(80);
            }
        }

        [Fact]
        public void TestDeleteProductService()
        {
            using (var context = new NorthwindContext(optionBuilder.Options))
            {
                // act
                _repositoryManager = new RepositoryManager(context);
                IServiceManager serviceManager = new ServiceManager(_repositoryManager, mapper);
                var categoryForCreate = new ProductDto
                {
                    ProductId = 83
                };
                serviceManager.ProductService.Remove(categoryForCreate);

                //assert
                var category = serviceManager.ProductService.GetAllProduct(false);
                category.ShouldNotBeNull();
                category.Result.Count().ShouldBe(79);
            }
        }

        [Fact]
        public void TestGetCategoryRepo()
        {
            using (var context = new NorthwindContext(optionBuilder.Options))
            {
                // act
                _repositoryManager = new RepositoryManager(context);
                var category = _repositoryManager.CategoryRepository.GetAllCategory(false);

                //assert
                category.ShouldNotBeNull();
                category.Result.Count().ShouldBe(10);
            }
        }

        private void BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            Configuration = builder.Build();
        }

        private void SetupOptions()
        {
            optionBuilder = new DbContextOptionsBuilder<NorthwindContext>();
            optionBuilder.UseSqlServer(Configuration.GetConnectionString("NorthwindDb"));

            var service = new ServiceCollection();
            service.AddAutoMapper(typeof(MappingProfile));
            serviceProvider = service.BuildServiceProvider();

            mapperConfig = new MapperConfiguration(cfg => 
            { 
                cfg.AddProfile<MappingProfile>();
            });

            mapperConfig.AssertConfigurationIsValid();
            mapper = mapperConfig.CreateMapper();
        }
    }
}
