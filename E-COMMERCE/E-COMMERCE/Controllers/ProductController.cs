﻿using E_COMMERCE.Models;
using E_COMMERCE.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_COMMERCE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private IProductCollection db = new ProductCollection();

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            return Ok(await db.GetAllProducts());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductsDetails(string id)
        {
            return Ok(await db.GetProductById(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] Product product)
        {
            if (product == null)
                return BadRequest();

            if(product.Name == string.Empty)
            {
                ModelState.AddModelError("Name", "No puede estar vacio");
            }

            await db.InsertProduct(product);

            return Created("Created", true);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct([FromBody] Product product, string id)
        {
            if (product == null)
                return BadRequest();

            if (product.Name == string.Empty)
            {
                ModelState.AddModelError("Name", "No puede estar vacio");
            }

            product.Id = new MongoDB.Bson.ObjectId(id);
            await db.UpdateProduct(product);

            return Created("Created", true);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct( string id)
        {
        
            await db.DeleteProduct(id);

            return NoContent();

        }


    }
}
