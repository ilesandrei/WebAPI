using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Entities;
using ShoppingCart.ExternalModels;
using ShoppingCart.Services.UnitsOfWork;

namespace ShoppingCart.Controllers
{
    [Route("product")]
    [ApiController]
    [EnableCors]
    public class ProductController : ControllerBase
    {
        private readonly IProductUnitOfWork _productUnit;
        private readonly IMapper _mapper;
        private object product;

        public ProductController(IProductUnitOfWork productUnit,
            IMapper mapper)
        {
            _productUnit = productUnit ?? throw new ArgumentNullException(nameof(productUnit));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        #region Products
        [HttpGet, Authorize]
        [Route("{id}", Name = "GetProduct")]
        public IActionResult GetProduct(Guid id)
        {
            var productEntity = _productUnit.Products.Get(id);
            if (productEntity == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<ProductDTO>(productEntity));
        }

        [HttpGet, Authorize]
        [Route("", Name = "GetAllProducts")]
        public IActionResult GetAllProducts()
        {
            var productEntities = _productUnit.Products.Find(a => a.Deleted == false || a.Deleted == null);
            if (productEntities == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<List<ProductDTO>>(productEntities));
        }

        [HttpGet, Authorize]
        [Route("details/{id}", Name = "GetProductDetails")]
        public IActionResult GetProductDetails(Guid id)
        {
            var productEntity = _productUnit.Products.GetProductDetails(id);
            if (productEntity == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<ProductDTO>(productEntity));
        }

        [Route("add", Name = "Add a new product")]
        [HttpPost, Authorize]
        public IActionResult AddProduct([FromBody] ProductDTO book)
        {
            var productEntity = _mapper.Map<Product>(product);
            _productUnit.Products.Add(productEntity);

            _productUnit.Complete();

            _productUnit.Products.Get(productEntity.Id);

            return CreatedAtRoute("GetProduct",
                new { id = productEntity.Id },
                _mapper.Map<ProductDTO>(productEntity));
        }
        #endregion Products

        #region Manufacturers
        [HttpGet, Authorize]
        [Route("manufacturer/{manufacturerId}", Name = "GetManufacturer")]
        public IActionResult GetAuthor(Guid manufacturerId)
        {
            var manufacturerEntity = _productUnit.Manufacturers.Get(manufacturerId);
            if (manufacturerEntity == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<ManufacturerDTO>(manufacturerEntity));
        }

        [HttpGet, Authorize]
        [Route("manufacturer", Name = "GetAllManufacturers")]
        public IActionResult GetAllManufacturers()
        {
            var manufacturerEntities = _productUnit.Manufacturers.Find(a => a.Deleted == false || a.Deleted == null);
            if (manufacturerEntities == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<List<ManufacturerDTO>>(manufacturerEntities));
        }

        [Route("manufacturer/add", Name = "Add a new manufacturer")]
        [HttpPost, Authorize]
        public IActionResult AddManufacturer([FromBody] ManufacturerDTO manufacturer)
        {
            var manufacturerEntity = _mapper.Map<Manufacturer>(manufacturer);
            _productUnit.Manufacturers.Add(manufacturerEntity);

            _productUnit.Complete();

            _productUnit.Manufacturers.Get(manufacturerEntity.Id);

            return CreatedAtRoute("GetManufacturer",
                new { manufacturerId = manufacturerEntity.Id },
                _mapper.Map<ManufacturerDTO>(manufacturerEntity));
        }

        [Route("manufactorer/{manufacturerId}", Name = "Mark author as deleted")]
        [HttpPut, Authorize]
        public IActionResult MarkManufacturerAsDeleted(Guid manufacturerId)
        {
            var manufacturer = _productUnit.Manufacturers.FindDefault(a => a.Id.Equals(manufacturerId) && (a.Deleted == false || a.Deleted == null));
            if (manufacturer != null)
            {
                manufacturer.Deleted = true;
                if (_productUnit.Complete() > 0)
                {
                    return Ok("Manufacturer " + manufacturerId + " was deleted.");
                }
            }
            return NotFound();
        }
        #endregion Manufacturers
    }
}

