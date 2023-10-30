using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Models.ViewModels;
using Models;
using DataAccess.Interfaces;
using DataAccess.Implementation;

namespace ConcertManagement.Controllers
{
    public class PerformenceController : Controller
    {
        private readonly IArtistProvider _artistProvider;
        private readonly IPerformenceProvider _performenceProvider;

        public PerformenceController(IArtistProvider artistProvider, IPerformenceProvider performenceProvider)
        {
            _artistProvider = artistProvider;
            _performenceProvider = performenceProvider;
        }

        public IActionResult Index(int concertId)
        {
            List<PerformenceInfo> performenceInfo = _performenceProvider.GetAll(concertId).ToList();
            return View(performenceInfo);
        }

        public IActionResult Create(int concertId)
        {
            PerformenceInfoVm performenceInfoVm = new PerformenceInfoVm();
            performenceInfoVm.PerformenceInfo = new PerformenceInfo();
            performenceInfoVm.PerformenceInfo.ConcertId = concertId;

            performenceInfoVm.Artists = _artistProvider.GetAll().Select(c => new SelectListItem()
            {
                Text = c.Value,
                Value = c.Id.ToString()
            });

            return View(performenceInfoVm);
        }

        [HttpPost]
        public IActionResult Create(PerformenceInfo performenceInfo)
        {            
            _performenceProvider.Create(performenceInfo);

            return RedirectToAction("Index","ConcertInfo");            
        }

        public IActionResult Edit(int performenceId)
        {
            PerformenceInfoVm performenceInfoVm = new PerformenceInfoVm();
            performenceInfoVm.PerformenceInfo = _performenceProvider.Get(performenceId);

            performenceInfoVm.Artists = _artistProvider.GetAll().Select(c => new SelectListItem()
            {
                Text = c.Value,
                Value = c.Id.ToString()
            });

            return View(performenceInfoVm);
        }

        [HttpPost]
        public IActionResult Edit(PerformenceInfo performenceInfo)
        {            
            _performenceProvider.Update(performenceInfo);

            return RedirectToAction("Index",new { concertId = performenceInfo.ConcertId });           
        }

        public IActionResult Delete(int performenceId)
        {
            if (performenceId == null || performenceId == default)
            {
                return NotFound();
            }

            PerformenceInfo performenceFromDb = _performenceProvider.Get(performenceId);

            if (performenceFromDb == null)
            {
                return NotFound();
            }

            return View(performenceFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int performenceId)
        {
            PerformenceInfo performenceFromDb = _performenceProvider.Get(performenceId);

            if (performenceFromDb == null)
            {
                return NotFound();
            }
            _performenceProvider.Delete(performenceId);

            return RedirectToAction("Index", new { concertId = performenceFromDb.ConcertId });
        }
    }
}
