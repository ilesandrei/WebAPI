using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.ExternalModels
{
    public class ManufacturerDTO
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public bool? Deleted { get; set; }
    }
}
