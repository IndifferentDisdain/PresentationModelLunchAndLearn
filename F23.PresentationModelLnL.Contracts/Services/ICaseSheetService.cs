using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using F23.PresentationModelLnL.Contracts.DataContracts;

namespace F23.PresentationModelLnL.Contracts.Services
{
    public interface ICaseSheetService
    {
        Task<int> CreateCaseSheetAsync(CaseSheetCreateRequest request);
    }
}
