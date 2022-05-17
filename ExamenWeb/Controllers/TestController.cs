using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenWeb.Controllers
{
    public class TestController : Controller
    {
        private IServiceTest se;
        public TestController(IServiceTest se)
        {
            this.se = se;
        }
        // GET: TestController
        public ActionResult Index()
        {
            return View(se.GetMany());
        }
        //IN CASE U NEED A FILTER
        [HttpPost]
        public ActionResult Index(string filter)
        {
            /* Filter
             * var list = se.GetMany();
             if (!String.IsNullOrEmpty(filter))
             {
                 //list = list.Where(p => p.NomEquipe.ToString().Equals(filtre)).ToList();
                 list = list.Where(p => p.NomEquipe.ToString().Contains(filter)).ToList();
             }
             return View(list);*/
            return View(se.GetMany());
        }
        // GET: TestController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TestController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TestController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Class2 collection, IFormFile file)
        {
            try
            {
                /*Add image
                 * collection.Logo = file.FileName;
                if (file != null)
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads",
                   file.FileName);
                    using (System.IO.Stream stream = new FileStream(path, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                }
                */
                se.Add(collection);
                se.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TestController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(se.Get(e => e.Class2Id == id));
        }

        // POST: TestController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Class2 collection, IFormFile file)
        {
            try
            {
                /*
                collection.Logo = file.FileName;
                if (file != null)
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads",
                    file.FileName);
                    using (System.IO.Stream stream = new FileStream(path, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                }*/
                se.Update(collection);
                se.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TestController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(se.Get(e => e.Class2Id == id));
        }

        // POST: TestController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Class2 collection)
        {
            try
            {
                se.Delete(collection);
                se.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
