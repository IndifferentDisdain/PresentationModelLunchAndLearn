﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using F23.PresentationModelLnL.Contracts.Repositories;
using F23.PresentationModelLnL.Contracts.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using F23.PresentationModelLnL.Domain.CaseSheets;
using F23.PresentationModelLnL.Presentation.CaseSheets;
using F23.PresentationModelLnL.Web.VendorPortal.Models;

namespace F23.PresentationModelLnL.Web.VendorPortal.Controllers
{
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
            var model = await _caseSheetRepository.GetCaseSheetsAsync();
            return View(model);
        }

        // GET: CaseSheets/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var vm = await _caseSheetPresentationFactory.GetCaseSheetDetailsAsync(id, User?.IsInRole("Administrator") ?? false);
            return View(vm);
        }

        // GET: CaseSheets/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CaseSheets/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CaseSheetPostModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View();

                var request = model.ToCaseSheetCreateRequest(_vendorId);
                await _caseSheetService.CreateCaseSheetAsync(request);

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