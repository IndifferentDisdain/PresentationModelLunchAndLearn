using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using F23.PresentationModelLnL.Contracts.Repositories;
using F23.PresentationModelLnL.Contracts.Services;
using F23.PresentationModelLnL.Presentation.CaseSheets;
using Microsoft.AspNetCore.Mvc;

namespace F23.PresentationModelLnL.Web.VendorPortal.Controllers
{
    public class ProcessController : Controller
    {
        private readonly ICaseSheetRepository _caseSheetRepository;
        private readonly ICaseSheetPresentationFactory _caseSheetPresentationFactory;
        private readonly ICaseSheetService _caseSheetService;

        public ProcessController(ICaseSheetRepository caseSheetRepository, ICaseSheetPresentationFactory caseSheetPresentationFactory, ICaseSheetService caseSheetService)
        {
            _caseSheetRepository = caseSheetRepository;
            _caseSheetPresentationFactory = caseSheetPresentationFactory;
            _caseSheetService = caseSheetService;
        }

        public async Task<ActionResult> Index()
        {
            var model = await _caseSheetRepository.GetCaseSheetsAsync();
            return View(model);
        }

        // GET: CaseSheets/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var vm = await _caseSheetPresentationFactory.GetCaseSheetDetailsAsync(id, false, true);
            return View(vm);
        }

        public async Task<ActionResult> Process(int id)
        {
            await _caseSheetService.ProcessAsync(id);
            return RedirectToAction("Index");
        }
    }
}