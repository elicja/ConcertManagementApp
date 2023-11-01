using DataAccess.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Models;
using Models.ViewModels;

namespace ConcertManagement.Controllers
{
    public class ConcertInfoController : Controller
    {
        private readonly IConcertProvider _concertProvider;
        private readonly ICityProvider _cityProvider;
        private readonly IMusicGenreProvider _musicGenresProvider;

        public ConcertInfoController(IConcertProvider concertProvider,ICityProvider citiesProvider,IMusicGenreProvider musicGenresProvider)
        {
            _concertProvider = concertProvider;
            _cityProvider = citiesProvider;
            _musicGenresProvider = musicGenresProvider;
        }

        public IActionResult Index()
        {
            List<ConcertInfo> concertsInfo = _concertProvider.GetAll().ToList();
            return View(concertsInfo);
        }

        public IActionResult Management()
        {
            List<ConcertInfo> concertsInfo = _concertProvider.GetAll().ToList();
            return View(concertsInfo);
        }

        public IActionResult Details(int concertId)
        {
            ConcertInfo concertInfo = _concertProvider.Get(concertId);
            return View(concertInfo);
        }

        public IActionResult Create()
        {
            ConcertInfoVM concertInfoVM = new ConcertInfoVM();
            concertInfoVM.ConcertInfo = new ConcertInfo();

            concertInfoVM.Cities = _cityProvider.GetAll().Select(c => new SelectListItem()
            {
                Text = c.Value,
                Value = c.Id.ToString()
            });

            concertInfoVM.Genres = _musicGenresProvider.GetAll().Select(x => new SelectListItem()
            {
                Text = x.Value,
                Value = x.Id.ToString()
            }); 

            return View(concertInfoVM);
        }

        [HttpPost]
        public IActionResult Create(ConcertInfo concertInfo)
        {
            if (ModelState.IsValid)
            {
                _concertProvider.AddNewConcert(concertInfo);

                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(int concertId)
        {
            if (concertId == null || concertId == default)
            {
                return NotFound();
            }

            ConcertInfoVM concertInfoVM = new ConcertInfoVM();
            concertInfoVM.ConcertInfo = _concertProvider.Get(concertId);

            concertInfoVM.Cities = _cityProvider.GetAll().Select(c => new SelectListItem()
            {
                Text = c.Value,
                Value = c.Id.ToString()
            });

            concertInfoVM.Genres = _musicGenresProvider.GetAll().Select(x => new SelectListItem()
            {
                Text = x.Value,
                Value = x.Id.ToString()
            });


            if (concertInfoVM == null)
            {
                return NotFound();
            }

            return View(concertInfoVM);
        }

        [HttpPost]
        public IActionResult Edit(ConcertInfo concertInfo)
        {
            if (ModelState.IsValid)
            {
                _concertProvider.UpdateConcert(concertInfo);

                return RedirectToAction("Index");
            }

            return View();
        }

        public IActionResult Delete(int concertId)
        {
            if (concertId == null || concertId == default)
            {
                return NotFound();
            }

            ConcertInfo concertFromDb = _concertProvider.Get(concertId);    

            if (concertFromDb == null)
            {
                return NotFound();
            }

            return View(concertFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int concertId)
        {
            ConcertInfo concertFromDb = _concertProvider.Get(concertId);

            if (concertFromDb == null)
            {
                return NotFound();
            }
            _concertProvider.DeleteConcert(concertId);

            return RedirectToAction("Index");
        }
    }
}
