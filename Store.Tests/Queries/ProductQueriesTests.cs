using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Store.Domain.Entities;
using Store.Domain.Queries;

namespace Store.Tests.Queries
{
    [TestClass]
    public class ProductQueriesTests
    
    
    {
        
        private IList<Product> _products;
        
        public ProductQueriesTests()
        {
            _products = new List<Product>
            {
                new Product("Produto 01", 10, true),
                new Product("Produto 02", 20, true),
                new Product("Produto 03", 30, true),
                new Product("Produto 04", 40, false),
                new Product("Produto 05", 50, false)
            };
        }
        [TestMethod]
        [TestCategory("Queries")]
        public void Dado_a_consulta_de_produtos_ativos_deve_retornar_3()
        {
            var results = _products.AsQueryable().Where(ProductQueries.GetActiveProducts());
            Assert.AreEqual(results.Count(),3);

        }

        [TestMethod]
        [TestCategory("Queries")]
        public void Dado_a_consulta_de_produtos_inativos_deve_retornar_2()
        {
            var results = _products.AsQueryable().Where(ProductQueries.GetInactiveProducts());
            Assert.AreEqual(results.Count(), 2);
        }
    }
}