﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShoppingCart.Entities;

namespace ShoppingCart.Services.Repositories
{
    public interface IManufacturerRepository : IRepository<Manufacturer>
    {
        object Get(object manufacturerId);
    }
}
