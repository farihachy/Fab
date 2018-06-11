using BusinessEntities.Services;
using BusinessEntities.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Business.Controllers
{
    [RoutePrefix("api/product")]
    public class ProductController : ApiController
    {
        public IProductService _productService;

        public IProductService ProductService
        {
            get { return _productService ?? (_productService = new ProductService(new DataModel.UnitOfWork())); }
        }

        [HttpGet]
        [Route("GetAllProductCategory")]
        public List<ProductCategoryViewModel> GetAllProductCategory()
        {
            var listProduct = ProductService.GetAllProductCategory();
            return (listProduct);
        }


        [HttpGet]
        [Route("GetAllProducts")]
        public List<ProductViewModel> GetAllProducts()
        {
            var listProduct = ProductService.GetAllProducts();
            return (listProduct);
        }

        [HttpGet]
        [Route("GetProductsByProductCategory/{productCategoryId:int}")]
        public List<ProductViewModel> GetProductsByProductCategory(int productCategoryId)
        {
            var listProduct = ProductService.GetProductsByProductCategory(productCategoryId);
            return (listProduct);
        }

        [HttpPost]
        [Route("AddNewProduct")]
        public void AddNewProduct(ProductViewModel product)
        {
            ProductService.AddNewProduct(product);
            Ok("Success");
        }

        [Route("UpdateProduct")]
        [HttpPut]
        public void UpdateProduct(ProductViewModel productToUpdate)
        {
            ProductService.UpdateProduct(productToUpdate);
            Ok("Success");
        }

        [HttpDelete]
        [Route("DeleteProduct/{productId:int}")]
        public void DeleteProduct(int productId)
        {
            ProductService.DeleteProduct(productId);
            Ok("Success");
        }

        #region Product Buy


        #endregion


    }
}
