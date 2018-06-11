using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DataModel.RepoFile
{
    public interface IProductCategory : IGenericRepository<ProductCategory>
    {

    }
    public class RepoProductCategory : GenericRepository<ProductCategory>, IProductCategory
    {
        public RepoProductCategory(BusinessDBEntities context) : base(context)
        {

        }
    }
}
