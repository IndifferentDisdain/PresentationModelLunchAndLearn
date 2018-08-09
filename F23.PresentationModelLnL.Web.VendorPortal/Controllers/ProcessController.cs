using F23.PresentationModelLnL.Contracts.Repositories;
using F23.PresentationModelLnL.Contracts.Services;
using F23.PresentationModelLnL.Domain.ReadModels;
using F23.PresentationModelLnL.Presentation.CaseSheets;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace F23.PresentationModelLnL.Web.VendorPortal.Controllers
{
    /// <summary>
    /// This should generally be located in a different MVC area or even a different web app, 
    /// controlled by user roles, etc. This is the queue that can access case sheets for all
    /// vendors in the system, including processing them. 
    /// </summary>
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
            // Gimmie all case sheets for all vendors.
            // Note it's the same model and call as our case sheets controller, except for all vendors.
            IEnumerable<CaseSheetDetails> model = await _caseSheetRepository.GetCaseSheetsAsync();
            return View(model);
        }

        // GET: Process/Details/5
        public async Task<ActionResult> Details(int id)
        {
            // No need to check vendor context here; I'm allowed :)
            // Yes, the same call as our case sheets controller.
            CaseSheetDetailsPresentationModel vm = 
                await _caseSheetPresentationFactory
                .GetCaseSheetDetailsAsync(id, false, true);

            return View(vm);
        }

        public async Task<ActionResult> Process(int id)
        {
            // Service makes sure we can process. If we wanted to do any auth checks, we'd
            // do them before calling the service method.
            await _caseSheetService.ProcessAsync(id);
            return RedirectToAction("Index");
        }
    }
}