﻿using F23.PresentationModelLnL.Contracts.Repositories;
using F23.PresentationModelLnL.Domain.Products;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace F23.PresentationModelLnL.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppContext _context;

        public ProductRepository(AppContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<ProductDetails>> GetProductDetailsAsync(int[] productIds, int vendorId)
        {
            return await _context.ProductDetails.Where(x => vendorId == x.VendorId && productIds.Contains(x.Id)).ToListAsync();
        }
    }
}