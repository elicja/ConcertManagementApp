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

        public IActionResult Create()
        {
            ConcertInfoVm concertInfoVm = new ConcertInfoVm();
            concertInfoVm.ConcertInfo = new ConcertInfo();

            concertInfoVm.Cities = _cityProvider.GetAll().Select(c => new SelectListItem()
            {
                Text = c.Value,
                Value = c.Id.ToString()
            });

            concertInfoVm.Genres = _musicGenresProvider.GetAll().Select(x => new SelectListItem()
            {
                Text = x.Value,
                Value = x.Id.ToString()
            }); 

            return View(concertInfoVm);
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

            ConcertInfoVm concertInfoVm = new ConcertInfoVm();
            concertInfoVm.ConcertInfo = _concertProvider.Get(concertId);

            concertInfoVm.Cities = _cityProvider.GetAll().Select(c => new SelectListItem()
            {
                Text = c.Value,
                Value = c.Id.ToString()
            });

            concertInfoVm.Genres = _musicGenresProvider.GetAll().Select(x => new SelectListItem()
            {
                Text = x.Value,
                Value = x.Id.ToString()
            });


            if (concertInfoVm == null)
            {
                return NotFound();
            }

            return View(concertInfoVm);
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
