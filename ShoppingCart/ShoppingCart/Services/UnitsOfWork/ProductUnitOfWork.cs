using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShoppingCart.Entities;
using ShoppingCart.Services.Repositories;


namespace ShoppingCart.Services.UnitsOfWork
{
    public class ProductUnitOfWork : IProductUnitOfWork
    {
        private readonly ProductsContext _context;

        public ProductUnitOfWork(ProductsContext context, IProductRepository product,
            ICategoryRepository category)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            Products = products ?? throw new ArgumentNullException(nameof(context));
            Manufacturers = manufacturers ?? throw new ArgumentNullException(nameof(context));
            Categories = categories ?? throw new ArgumentNullException(nameof(context));
        }

        public IProductRepository Books { get; }

        public IManufacturerRepository Authors { get; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
