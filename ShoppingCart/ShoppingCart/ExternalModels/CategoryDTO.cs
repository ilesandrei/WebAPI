using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.ExternalModels
{
    public class CategoryDTO
    {
        public Guid Id { get; set; }
        public string CatName { get; set; }
        public bool? Deleted { get; set; }
    }
}
