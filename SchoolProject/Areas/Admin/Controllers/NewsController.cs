using Microsoft.AspNetCore.Mvc;
using SchoolProject.DAL;
using SchoolProject.Entities;
using System.Xml;

namespace SchoolProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class NewsController : Controller
    {
        private readonly SchoolDBContext _context;

        public NewsController(SchoolDBContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Xeberler> News = _context.Xeberler.ToList();
            //return Json(News);
            return View(News);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Xeberler xeber)
        {
            if (xeber == null) return BadRequest();
            if (string.IsNullOrEmpty(xeber.Name) || string.IsNullOrEmpty(xeber.Description))
            {
                ModelState.AddModelError("Null", "Please Fill Form");
                return View();

            }
            _context.Xeberler.Add(xeber);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            Xeberler xeber = _context.Xeberler.FirstOrDefault(x => x.Id == id)!;
            if (xeber == null) return BadRequest();
            return View(xeber);
        }

        [HttpPost]
        public IActionResult Update(int id, Xeberler edited)
        {
            if (edited == null) return BadRequest();
            if (string.IsNullOrEmpty(edited.Name) || string.IsNullOrEmpty(edited.Description))
            {
                ModelState.AddModelError("Null", "Please Fill Form");
                return View();
            }

            Xeberler xeber = _context.Xeberler.FirstOrDefault(x => x.Id == id)!;
            if (xeber == null) return BadRequest();
            xeber.Name = edited.Name;
            xeber.Description = edited.Description;
            _context.SaveChanges();
            //Xeberler xeber = _context.Xeberler.FirstOrDefault(x => x.Id == id)!;
            //if (xeber == null) return BadRequest();
            return RedirectToAction("Index");
        }



        [HttpGet]
        public IActionResult Delete(int id)
        {
            Xeberler xeber = _context.Xeberler.FirstOrDefault(_x => _x.Id == id)!;
            if(xeber == null) return BadRequest();
            _context.Xeberler.Remove(xeber);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
