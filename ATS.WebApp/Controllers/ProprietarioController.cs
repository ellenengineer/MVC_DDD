using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ATS.WebApp.Controllers
{
    public class ProprietarioController : Controller
    {
        // GET: ProprietarioController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ProprietarioController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProprietarioController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProprietarioController/Create
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

        // GET: ProprietarioController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProprietarioController/Edit/5
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

        // GET: ProprietarioController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProprietarioController/Delete/5
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
