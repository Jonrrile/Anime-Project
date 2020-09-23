using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Anime.Models;
using Anime.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Anime.Controllers
{
    public class TitlesController : Controller
    {
        private readonly ITitleRepository _titleRepo;
        public TitlesController(ITitleRepository titleRepository)
        {
            _titleRepo = titleRepository;
        }
        // GET: TitlesController
        public ActionResult Index()
        {
            List<Title> titles = _titleRepo.GetTitles();
            return View(titles);
        }

        // GET: TitlesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TitlesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TitlesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TitlesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TitlesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TitlesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TitlesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
