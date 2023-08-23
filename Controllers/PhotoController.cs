using Microsoft.AspNetCore.Mvc;
using Sosyopix_CaseStudy.Models.Entity;
using Sosyopix_CaseStudy.Models.Repository.Abstract;
using Sosyopix_CaseStudy.Models.Repository.Concrete;

namespace Sosyopix_CaseStudy.Controllers
{
    public class PhotoController : Controller
    {
        private readonly IPhotoRepository _photoRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public PhotoController(IPhotoRepository photoRepository, IWebHostEnvironment webHostEnvironment)
        {
            _photoRepository = photoRepository;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            List<Photo> photoList = _photoRepository.GetList().ToList();
            return View(photoList);
        }

        [HttpGet]
        public IActionResult Add() 
        { 
            return View();
        }
        [HttpPost]
        public IActionResult Add(Photo p, IFormFile? file) 
        {
            string wwwRootPath = _webHostEnvironment.WebRootPath;
            string photoPath = Path.Combine(wwwRootPath, @"img");

            if (file != null)
            {
                using (var fileStream = new FileStream(Path.Combine(photoPath, file.FileName), FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }

                p.URL = @"\img\" + file.FileName;

                _photoRepository.Add(p);
                TempData["Successful"] = "New photo has beed added";
                _photoRepository.Save();
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int? id) 
        {
            if (id == null || id == 0) 
            {
                return NotFound(); 
            }
            Photo? photoVT = _photoRepository.Get(x => x.ID == id); // Linq expression

            if (photoVT == null)
            {
                return NotFound();
            }

            return View(photoVT);
        }
        [HttpGet]
        public IActionResult DeletePhoto(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Photo? photoVT = _photoRepository.Get(x => x.ID == id);

            if (photoVT == null)
            {
                return NotFound();
            }

            return View(photoVT);
        }


        [HttpPost,ActionName("DeletePhoto")]
        public IActionResult Delete(int? id)       
        {
            Photo? photoVT = _photoRepository.Get(x => x.ID == id);
            if (photoVT == null) 
            {
                return NotFound();  
            }
            _photoRepository.Remove(photoVT);
            _photoRepository.Save();

            return RedirectToAction("Index");
        }
    }
}
