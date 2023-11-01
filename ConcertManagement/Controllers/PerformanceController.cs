using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Models.ViewModels;
using Models;
using DataAccess.Interfaces;
using DataAccess.Implementation;

namespace ConcertManagement.Controllers
{
    public class PerformanceController : Controller
    {
        private readonly IArtistProvider _artistProvider;
        private readonly IPerformanceProvider _performanceProvider;

        public PerformanceController(IArtistProvider artistProvider, IPerformanceProvider performanceProvider)
        {
            _artistProvider = artistProvider;
            _performanceProvider = performanceProvider;
        }

        public IActionResult Index(int concertId)
        {
            List<PerformanceInfo> performanceInfo = _performanceProvider.GetAll(concertId).ToList();

            ConcertPerformancesVM concertPerformancesVM = new ConcertPerformancesVM();
            concertPerformancesVM.ConcertId = concertId;
            concertPerformancesVM.Performances = performanceInfo;
            
            return View(concertPerformancesVM);
        }

        public IActionResult Create(int concertId)
        {
            PerformanceInfoVM performenceInfoVM = new PerformanceInfoVM();
            performenceInfoVM.PerformanceInfo = new PerformanceInfo();
            performenceInfoVM.PerformanceInfo.ConcertId = concertId;

            performenceInfoVM.Artists = _artistProvider.GetAll().Select(c => new SelectListItem()
            {
                Text = c.Value,
                Value = c.Id.ToString()
            });

            return View(performenceInfoVM);
        }

        [HttpPost]
        public IActionResult Create(PerformanceInfo performanceInfo)
        {            
            _performanceProvider.Create(performanceInfo);

            return RedirectToAction("Index", "Performance", new { concertId = performanceInfo.ConcertId });            
        }

        public IActionResult Edit(int performanceId)
        {
            PerformanceInfoVM performanceInfoVM = new PerformanceInfoVM();
            performanceInfoVM.PerformanceInfo = _performanceProvider.Get(performanceId);

            performanceInfoVM.Artists = _artistProvider.GetAll().Select(c => new SelectListItem()
            {
                Text = c.Value,
                Value = c.Id.ToString()
            });

            return View(performanceInfoVM);
        }

        [HttpPost]
        public IActionResult Edit(PerformanceInfo performanceInfo)
        {            
            _performanceProvider.Update(performanceInfo);

            return RedirectToAction("Index",new { concertId = performanceInfo.ConcertId });           
        }

        public IActionResult Delete(int performanceId)
        {
            if (performanceId == null || performanceId == default)
            {
                return NotFound();
            }

            PerformanceInfo performanceFromDb = _performanceProvider.Get(performanceId);

            if (performanceFromDb == null)
            {
                return NotFound();
            }

            return View(performanceFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int performanceId)
        {
            PerformanceInfo performanceFromDb = _performanceProvider.Get(performanceId);

            if (performanceFromDb == null)
            {
                return NotFound();
            }
            _performanceProvider.Delete(performanceId);

            return RedirectToAction("Index", new { concertId = performanceFromDb.ConcertId });
        }
    }
}
