using F23.PresentationModelLnL.Contracts.Repositories;
using F23.PresentationModelLnL.Domain.CaseSheets;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public async Task<IList<CaseSheetProduct>> GetCaseSheetProductsAsync(int caseSheetId)
        {
            return await _context.CaseSheetProducts.Where(x => x.CaseSheetId == caseSheetId).ToListAsync();
        }

        public void AddCaseSheet(CaseSheet caseSheet)
        {
            _context.CaseSheets.Add(caseSheet);
        }

        public void AddCaseSheetProducts(IEnumerable<CaseSheetProduct> products)
        {
            _context.CaseSheetProducts.AddRange(products);
        }

        public Task SaveAsync()
        {
            return _context.SaveChangesAsync();
        }

        public void UpdateCaseSheet(CaseSheet caseSheet)
        {
            _context.Entry(caseSheet).State = EntityState.Modified;
        }
    }
}
