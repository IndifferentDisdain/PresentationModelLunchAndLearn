using System;
using System.Threading.Tasks;
using F23.PresentationModelLnL.Contracts.Repositories;
using F23.PresentationModelLnL.Contracts.Services;
using Microsoft.AspNetCore.Mvc;
using F23.PresentationModelLnL.Presentation.CaseSheets;
using F23.PresentationModelLnL.Web.VendorPortal.Models;

namespace F23.PresentationModelLnL.Web.VendorPortal.Controllers
{
    /// <summary>
    /// This is the controller for a vendor to use. They won't be able to
    /// access case sheets for any other vendor.
    /// </summary>
    public class CaseSheetsController : Controller
    {
        private readonly ICaseSheetRepository _caseSheetRepository;
        private readonly ICaseSheetPresentationFactory _caseSheetPresentationFactory;
        private readonly ICaseSheetService _caseSheetService;

        // This would generally be handled by user auth, but skipping that for now.
        private const int _vendorId = 1;

        public CaseSheetsController(ICaseSheetRepository caseSheetRepository
            , ICaseSheetPresentationFactory caseSheetPresentationFactory
            , ICaseSheetService caseSheetService)
        {
            _caseSheetRepository = caseSheetRepository;
            _caseSheetPresentationFactory = caseSheetPresentationFactory;
            _caseSheetService = caseSheetService;
        }

        public async Task<ActionResult> Index()
        {
            // Be sure we only get case sheets for our vendor.
            var model = await _caseSheetRepository.GetCaseSheetsAsync(_vendorId);
            return View(model);
        }

        // GET: CaseSheets/Details/5
        public async Task<ActionResult> Details(int id)
        {
            // double-check to make sure someone didn't get cute w/ the case sheet id
            // I don't want the vendors to see our selling price, but I can control that in the razor view.
            // Also, in a more complex app, we could use claims instead of interrogating user roles.
            // Controllers are great at this point, so let them do it.
            var vm = await _caseSheetPresentationFactory.GetCaseSheetDetailsAsync(id, User?.IsInRole("Administrator") ?? false, false, _vendorId);
            return View(vm);
        }

        // GET: CaseSheets/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CaseSheets/Create
        [HttpPost]
        // Yeah, I cheated here.
        // Also, a problem to be solved later, but reactjs validation.
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([FromBody]CaseSheetPostModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View();

                var request = model.ToCaseSheetCreateRequest(_vendorId);
                var caseSheetId = await _caseSheetService.CreateCaseSheetAsync(request);

                return Ok(caseSheetId);
            }
            catch
            {
                return View();
            }
        }
    }
}