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

        public IEnumerable<CaseSheetDetails> GetCaseSheets()
        {
            return new List<CaseSheetDetails>()
            {
                new CaseSheetDetails
                {
                    Id = 1,
                    CaseSheetNumber = "CS-1",
                    CaseDate = new DateTime(2017, 09, 01),
                    LocationId = 1,
                    LocationName = "Joe's Garage",
                    TotalCost = 10000m
                },
                new CaseSheetDetails
                {
                    Id = 2,
                    CaseSheetNumber = "CS-2",
                    CaseDate = new DateTime(2017, 10, 01),
                    LocationId = 2,
                    LocationName = "Joe's Apartment",
                    TotalCost = 15000m
                }
            };
        }

        public async Task<IEnumerable<CaseSheetDetails>> GetCaseSheetsAsync()
        {
            return await _context.CaseSheetDetails.ToListAsync();
        }
    }
}
