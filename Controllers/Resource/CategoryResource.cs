using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace ALSaray.Controllers.Resource
{
    public class CategoryResource
    {
         public int catId { get; set; }

        public string catName { get; set; }
        public ICollection<ProductResource> Products { get; set; }

        public CategoryResource()
        {
            Products = new Collection<ProductResource>();


        }
    }
}
