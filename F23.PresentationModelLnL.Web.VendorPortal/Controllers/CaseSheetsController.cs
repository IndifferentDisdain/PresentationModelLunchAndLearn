using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using F23.PresentationModelLnL.Domain.CaseSheets;

namespace F23.PresentationModelLnL.Web.VendorPortal.Controllers
{
    public class CaseSheetsController : Controller
    {
        // GET: CaseSheets
        public ActionResult Index()
        {
            var model = new List<CaseSheetDetails>()
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