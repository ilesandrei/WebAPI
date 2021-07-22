using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShoppingCart.Entities;
using ShoppingCart.Services.Repositories;

namespace ShoppingCart.Services.UnitsOfWork
{
        public interface IUserUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }

        int Complete();
    }
}
