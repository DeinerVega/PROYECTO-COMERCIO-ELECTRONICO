﻿using E_COMMERCE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_COMMERCE.Repositories
{
    public interface IProductCollection
    {
        Task InsertProduct(Product product);

        Task UpdateProduct(Product product);

        Task DeleteProduct(string id);

        Task<List<Product>> GetAllProducts();
        Task<Product> GetProductById(string id);
    }
}
