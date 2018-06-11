using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DataModel.RepoFile
{

    public interface IProduct: IGenericRepository<Product>
    {
        List<Product> GetAllProducts();
        List<Product> GetProductsByProductCategory(int productCategoryId);
    }

    public class RepoProduct : GenericRepository<Product>, IProduct
    {
        public RepoProduct(BusinessDBEntities context) : base(context)
        {
        }

        public List<Product> GetAllProducts()
        {
            return GetAll().ToList();
        }

        public List<Product> GetProductsByProductCategory(int productCategoryId)
        {
            return GetAll().Where(e => e.CategoryId == productCategoryId).ToList();
        }
    }
}
