using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.ViewModel
{
    public class ProductViewModel
    {
        public long Id { get; set; }

        public long CategoryId { get; set; }

        public string CategoryName { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }
    }

    public class ProductCategoryViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }
}
