using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShoppingCart.Entities;

namespace ShoppingCart.Services.Repositories
{
    public class ProductRepository
    {
        private readonly ProductsContext _context;

        public ProductRepository(ProductsContext context) : base()
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Product GetBookDetails(Guid bookId)
        {
            return _context.Products
                .Where(b => b.Id == bookId && (b.Deleted == false || b.Deleted == null))
                .Include(b => b.Manufacturer)
                .FirstOrDefault();
        }
    }
}
