using System.Threading.Tasks;
using F23.PresentationModelLnL.Contracts.DataContracts;

namespace F23.PresentationModelLnL.Contracts.Services
{
    public interface ICaseSheetService
    {
        Task<int> CreateCaseSheetAsync(CaseSheetCreateRequest request);
        Task ProcessAsync(int caseSheetId);
    }
}
