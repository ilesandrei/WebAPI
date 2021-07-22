using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShoppingCart.Entities;

namespace ShoppingCart.Services.Repositories
{
    public class CategoryRepository
    {
        private readonly ProductsContext _context;

        public CategoryRepository(ProductsContext context) : base()
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
    }
}
