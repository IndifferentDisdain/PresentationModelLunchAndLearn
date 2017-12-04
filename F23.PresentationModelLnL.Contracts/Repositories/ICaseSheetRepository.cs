using F23.PresentationModelLnL.Domain.CaseSheets;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace F23.PresentationModelLnL.Contracts.Repositories
{
    public interface ICaseSheetRepository
    {
        Task<IEnumerable<CaseSheetDetails>> GetCaseSheetsAsync();
        Task<CaseSheetDetails> GetCaseSheetDetailsAsync(int caseSheetId);
        Task<IList<CaseSheetProduct>> GetCaseSheetProductsAsync(int caseSheetId);
        void AddCaseSheet(CaseSheet caseSheet);
        void AddCaseSheetProducts(IEnumerable<CaseSheetProduct> products);
        Task SaveAsync();
        void UpdateCaseSheet(CaseSheet caseSheet);
    }
}
