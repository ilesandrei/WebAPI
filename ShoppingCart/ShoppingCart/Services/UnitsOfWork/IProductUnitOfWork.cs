using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShoppingCart.Services.Repositories;

namespace ShoppingCart.Services.UnitsOfWork
{
    public interface IProductUnitOfWork : IDisposable
    {
            public IProductRepository Products { get; }

            public ICategoryRepository Categories { get; }

            public IManufacturerRepository Manufacturers { get; }

            int Complete();
  
    }
}
