﻿using F23.PresentationModelLnL.Contracts.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using F23.PresentationModelLnL.Domain;
using F23.PresentationModelLnL.Domain.ReadModels;

namespace F23.PresentationModelLnL.Repositories
{
    public class CaseSheetRepository : ICaseSheetRepository
    {
        private readonly AppContext _context;

        public CaseSheetRepository(AppContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CaseSheetDetails>> GetCaseSheetsAsync(int? vendorId = null)
        {
            var query = _context.CaseSheetDetails.AsQueryable();
            if (vendorId.HasValue)
                query = query.Where(x => x.VendorId == vendorId.Value);
            return await query.ToListAsync();
        }

        public Task<CaseSheetDetails> GetCaseSheetDetailsAsync(int caseSheetId)
        {
            return _context.CaseSheetDetails.FindAsync(caseSheetId);
        }

        public async Task<IList<CaseSheetProduct>> GetCaseSheetProductsAsync(int caseSheetId)
        {
            return await _context.CaseSheetProducts.Where(x => x.CaseSheetId == caseSheetId).ToListAsync();
        }

        public Task AddCaseSheetAsync(CaseSheet caseSheet)
        {
            _context.CaseSheets.Add(caseSheet);
            return _context.SaveChangesAsync();
        }

        public Task AddCaseSheetProductsAsync(IEnumerable<CaseSheetProduct> products)
        {
            _context.CaseSheetProducts.AddRange(products);
            return _context.SaveChangesAsync();
        }

        public Task UpdateCaseSheetAsync(CaseSheet caseSheet)
        {
            _context.Entry(caseSheet).State = EntityState.Modified;
            return _context.SaveChangesAsync();
        }

        public Task<CaseSheet> GetCaseSheetAsync(int caseSheetId)
        {
            return _context.CaseSheets.FindAsync(caseSheetId);
        }
    }
}
