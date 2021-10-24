using Domain.Entities;
using Domain.Exceptions.ProductExceptions;
using Domain.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FinalPractice_Test.RepositoryTests
{
    public class ProductRepository_Test
    {
        [Fact]
        public void GetAll_Return_ProductList()
        {
            var mock = new Mock<IProductRepository>();
            var productList = GetAllProducts();
            mock.Setup(repository => repository.GetAll()).ReturnsAsync(productList);
            IProductRepository productRepository = mock.Object;
            var product = productList[0];

            var result = productRepository.GetAll();

            Assert.NotNull(result);
            Assert.True(!string.IsNullOrWhiteSpace(product.Id.ToString()));
            Assert.True(!string.IsNullOrWhiteSpace(product.ProductName));
        }

        [Fact]
        public void GetAll_ThrowException()
        {
            var mock = new Mock<IProductRepository>();
            List<Product> productsList = new List<Product>();
            mock.Setup(repository => repository.GetAll()).ReturnsAsync(() =>
            {
                if (productsList.Count == 0)
                {
                    throw new ProductNotFoundException(ProductExceptionMessages.ProductNotFound);
                }
                else
                {
                    return productsList;
                }
            });
            IProductRepository productRepository = mock.Object;

            Assert.ThrowsAsync<ProductNotFoundException>(() => productRepository.GetAll());
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void GetById_Return_Product(int id)
        {
            var mock = new Mock<IProductRepository>();
            var productList = GetAllProducts();
            mock.Setup(repository => repository.GetById(It.IsAny<int>())).ReturnsAsync(() =>
            {
                var product = productList.FirstOrDefault(p => p.Id == id);
                return product;
            });

            IProductRepository productRepository = mock.Object;

            var result = productRepository.GetById(id);

            Assert.NotNull(result);
            Assert.True(!string.IsNullOrWhiteSpace(result.Id.ToString()));
        }

        [Fact]
        public void GetById_Throw_Exception()
        {
            var mock = new Mock<IProductRepository>();
            var productList = GetAllProducts();
            mock.Setup(repository => repository.GetById(It.IsAny<int>())).ReturnsAsync((int id) =>
            {
                var product = productList.FirstOrDefault(p => p.Id == id);

                if (product == null)
                {
                    throw new ProductNotFoundException(ProductExceptionMessages.ProductNotFound);
                }
                else
                {
                    return product;
                }
            });
            IProductRepository productRepository = mock.Object;

            Assert.ThrowsAsync<ProductNotFoundException>(() => productRepository.GetById(productList.Count + 1));
        }

        [Fact]
        public void Add()
        {
            var mock = new Mock<IProductRepository>();
            var productList = GetAllProducts();
            int productListCount = productList.Count;
            mock.Setup(repository => repository.Add(It.IsAny<Product>()));
            Product product = new Product
            {
                Id = productListCount,
                ProductName = $"{productListCount} ProductName",
                UnitPrice = productListCount,
                CategoryId = productListCount + 1
            };
            productList.Add(product);
            IProductRepository productRepository = mock.Object;

            productRepository.Add(product);

            Assert.True(productListCount < productList.Count);
            Assert.NotNull(product);
            Assert.True(!string.IsNullOrWhiteSpace(product.Id.ToString()));
            Assert.True(!string.IsNullOrWhiteSpace(product.ProductName));
        }

        [Fact]
        public void Add_ThrowException()
        {
            var mock = new Mock<IProductRepository>();
            Product product = new Product();
            mock.Setup(repository => repository.Add(It.IsAny<Product>())).Callback(() =>
            {
                if (product == null)
                {
                    throw new ProductDontAddException(ProductExceptionMessages.ProductDontAdd);
                }
                else
                {
                    return;
                }
            });
            IProductRepository productRepository = mock.Object;

            Assert.ThrowsAsync<ProductDontAddException>(() => productRepository.Add(product));
        }

        [Theory]
        [InlineData(2)]
        [InlineData(3)]
        public void Update(int id)
        {
            var mock = new Mock<IProductRepository>();
            var productList = GetAllProducts();
            mock.Setup(repository => repository.Update(It.IsAny<Product>()));
            Product product = new Product
            {
                Id = id,
                ProductName = $"{id} ProductName",
                CategoryId = id,
                UnitPrice = id * 10
            };
            var updatedProduct = productList.FirstOrDefault(p => p.Id == product.Id);
            updatedProduct = product;
            IProductRepository productRepository = mock.Object;

            productRepository.Update(product);

            Assert.Same(product, updatedProduct);
        }

        [Fact]
        public void Update_ThrowException()
        {
            //Arrange
            var mock = new Mock<IProductRepository>();
            Product product = new Product();
            mock.Setup(repository => repository.Update(It.IsAny<Product>())).Callback(() =>
            {
                if (product.ProductName == null)
                {
                    throw new ProductDontUpdateException(ProductExceptionMessages.ProductDontUpdate);
                }
                else
                {
                    return;
                }
            });
            IProductRepository productRepository = mock.Object;

            //Assert
            Assert.Throws<ProductDontUpdateException>(() => productRepository.Update(product));
        }

        [Theory]
        [InlineData(2)]
        [InlineData(3)]
        public void Delete(int id)
        {
            var mock = new Mock<IProductRepository>();
            var list = GetAllProducts();
            int productCount = list.Count;
            mock.Setup(repository => repository.Delete(It.IsAny<int>())).Callback(() =>
            {

                var product = list.FirstOrDefault(p => p.Id == id);
                list.Remove(product);


            });

            IProductRepository productRepository = mock.Object;

            productRepository.Delete(id);

            Assert.True(productCount > list.Count);
        }

        private List<Product> GetAllProducts()
        {
            List<Product> products = new List<Product>();
            for (int i = 0; i < 5; i++)
            {
                Product product = new Product();
                product.Id = i;
                product.ProductName = $"{i} ProductName";
                product.CategoryId = i + 1;
                product.UnitPrice = i * 10;

                products.Add(product);
            }
            return products;
        }
    }
}
