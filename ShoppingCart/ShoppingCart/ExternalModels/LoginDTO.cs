using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.ExternalModels
{
    public class LoginDTO
    {
        public object Email { get; internal set; }
        public object Password { get; internal set; }
    }
}
