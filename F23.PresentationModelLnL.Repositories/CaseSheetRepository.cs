using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using F23.PresentationModelLnL.Contracts.Repositories;
using F23.PresentationModelLnL.Domain.CaseSheets;
using Microsoft.EntityFrameworkCore;

namespace F23.PresentationModelLnL.Repositories
{
    public class CaseSheetRepository : ICaseSheetRepository
    {
        private readonly AppContext _context;

        public CaseSheetRepository(AppContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CaseSheetDetails>> GetCaseSheetsAsync()
        {
            return await _context.CaseSheetDetails.ToListAsync();
        }

        public Task<CaseSheetDetails> GetCaseSheetDetailsAsync(int caseSheetId)
        {
            return _context.CaseSheetDetails.FindAsync(caseSheetId);
        }
    }
}
