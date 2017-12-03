﻿using F23.PresentationModelLnL.Domain.Products;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace F23.PresentationModelLnL.Contracts.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductDetails>> GetProductDetailsAsync(int[] productIds, int vendorId);

        Task<IEnumerable<ProductDetails>> GetProductsAsync(int vendorId, string searchTerm);
    }
}
