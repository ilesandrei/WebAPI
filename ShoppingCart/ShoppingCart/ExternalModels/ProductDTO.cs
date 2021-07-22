using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.ExternalModels
{
    public class ProductDTO
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public Guid ManufacturerId { get; set; }

        public ManufacturerDTO Manufacturer { get; set; }

        public Guid CategoryId { get; set; }

        public CategoryDTO Category { get; set; }

    }
}
