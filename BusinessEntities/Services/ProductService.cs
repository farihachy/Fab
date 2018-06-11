using Business.DataModel;
using BusinessEntities.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Services
{
    public interface IProductService
    {
        List<ProductCategoryViewModel> GetAllProductCategory();
        List<ProductViewModel> GetAllProducts();
        void AddNewProduct(ProductViewModel product);
        void UpdateProduct(ProductViewModel productToUpdate);
        void DeleteProduct(int productId);

        List<ProductViewModel> GetProductsByProductCategory(int productCategoryId);
    }

    public class ProductService:IProductService
    {
        private IUnitOfWork _unitOfWork;

        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void AddNewProduct(ProductViewModel product)
        {
            try
            {
                var entity = product.ToEntity();
                _unitOfWork.Product.Insert(entity);
                _unitOfWork.SaveChanges();
            }
            catch
            {
               
            }
           
        }

        public void DeleteProduct(int productId)
        {
            _unitOfWork.Product.Delete(productId);
            _unitOfWork.SaveChanges();
        }

        public List<ProductCategoryViewModel> GetAllProductCategory()
        {
            var entity= _unitOfWork.ProductCategory.GetAll().ToList();

            var listProductCategory = new List<ProductCategoryViewModel>();

            foreach (var item in entity)
            {
                var productCategory = new ProductCategoryViewModel();
                productCategory.Id = item.Id;
                productCategory.Name = item.Name;

                listProductCategory.Add(productCategory);
            }
            return listProductCategory;
        } 

        public List<ProductViewModel> GetAllProducts()
        {
            var entity= _unitOfWork.Product.GetAll().ToList();

            var listProduct = new List<ProductViewModel>();

            foreach (var item in entity)
            {
                var product = new ProductViewModel();
                product.Id = item.Id;
                product.CategoryId = item.CategoryId;
                product.CategoryName = item.ProductCategory.Name;
                product.Name = item.Name;
                product.Code = item.Code;

                listProduct.Add(product);
            }

            return listProduct;
        }

        public List<ProductViewModel> GetProductsByProductCategory(int productCategoryId)
        {
            var entity = _unitOfWork.Product.GetProductsByProductCategory(productCategoryId).ToList();

            var listProduct = new List<ProductViewModel>();

            foreach (var item in entity)
            {
                var product = new ProductViewModel();
                product.Id = item.Id;
                product.CategoryId = item.CategoryId;
                product.CategoryName = item.ProductCategory.Name;
                product.Name = item.Name;
                product.Code = item.Code;

                listProduct.Add(product);
            }

            return listProduct;
        }

        public void UpdateProduct(ProductViewModel productToUpdate)
        {
            var entity = productToUpdate.ToEntity();
            _unitOfWork.Product.Update(entity);
            _unitOfWork.SaveChanges();
        }
    }
}
