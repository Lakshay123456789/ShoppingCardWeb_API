using BusinessLayer.Resportiory;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ModelDataLogic.Data;
using ModelDataLogic.Model;
using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace ShoppingCardWebApI2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles ="Admin")]
    public class ProductController : ControllerBase
    {

        private readonly IGenericRepository<Product> _productRepository;
        private readonly ShoppingDbContext2 _shoppingDbContext;

        public ProductController(IGenericRepository<Product> productRepository, ShoppingDbContext2 shoppingDbContext2)
        {
            _productRepository = productRepository;
            _shoppingDbContext = shoppingDbContext2;
        }

        [HttpGet(Name = "GetAllProcducts")]
        public async Task<IActionResult> GetAllProduct()
        {
            var result = await _productRepository.GetAll();

            if (result != null) {
                return Ok(result);
            }
            return NotFound();
        }
        [HttpGet]
        [Route("{ProductId:guid}")]
        public async Task<IActionResult> GetProductbyId([FromRoute] Guid ProductId)
        {
            var result = await _productRepository.GetById(ProductId);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest("This Product not Exist");
        }

        [HttpPost(Name = "AddNewProduct")]
        public IActionResult AddProduct(UpDateProduct model)
        {
            if (ModelState.IsValid)
            {
                var product = new Product
                {
                    ProductName = model.ProductName,
                    ProductPrice = model.ProductPrice,
                    ProductQuality = model.ProductQuality,
                    ProductCategory = model.ProductCategory,
                    ProductImage = model.ProductImage,
                    ProductDescription = model.ProductDescription,
                };
                _productRepository.Insert(product);
                _productRepository.Save();
                return Ok(product);
            }
            return BadRequest("Product is not Insert");


        }
        [HttpPut]
        [Route("{ProductId:guid}")]
        public async Task<IActionResult> EditProduct(UpDateProduct model, [FromRoute] Guid ProductId)
        {
            var ProductExit = await _productRepository.GetById(ProductId);

            if (ModelState.IsValid && ProductExit != null)
            {
                ProductExit.ProductName = model.ProductName;
                ProductExit.ProductPrice = model.ProductPrice;
                ProductExit.ProductQuality = model.ProductQuality;
                ProductExit.ProductCategory = model.ProductCategory;
                ProductExit.ProductImage = model.ProductImage;
                ProductExit.ProductDescription = model.ProductDescription;

                var result = await _productRepository.Update(ProductExit);

                return Ok(result);
            }

            return BadRequest("product not found");
        }

        [HttpDelete]
        [Route("{ProductId:guid}")]
        public async Task<IActionResult> DeleteProduct([FromRoute] Guid ProductId)
        {

            var result = await _productRepository.Delete(ProductId);
            if (result)
            {
                _productRepository.Save();
                return Ok("Product Delete Succesfully");
            }
            return BadRequest("This ProductId is not Exist");
        }
       


    

    }
}
