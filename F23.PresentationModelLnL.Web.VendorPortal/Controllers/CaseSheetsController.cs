using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using F23.PresentationModelLnL.Contracts.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using F23.PresentationModelLnL.Domain.CaseSheets;

namespace F23.PresentationModelLnL.Web.VendorPortal.Controllers
{
    public class CaseSheetsController : Controller
    {
        private readonly ICaseSheetRepository _caseSheetRepository;

        public CaseSheetsController(ICaseSheetRepository caseSheetRepository)
        {
            _caseSheetRepository = caseSheetRepository;
        }
        // GET: CaseSheets
        //public ActionResult Index()
        //{
        //    var model = _caseSheetRepository.GetCaseSheetsAsync();
        //    return View(model);
        //}

        public async Task<ActionResult> Index()
        {
            var model = await _caseSheetRepository.GetCaseSheetsAsync();
            return View(model);
        }

        // GET: CaseSheets/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CaseSheets/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CaseSheets/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CaseSheets/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CaseSheets/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CaseSheets/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CaseSheets/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}