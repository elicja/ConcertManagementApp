using DataAccess.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Base;
using Models.Enum;
using Models.ViewModels;

namespace ConcertManagement.Controllers
{
    public class DetailsController : Controller
    {
        private readonly ICityProvider _cityProvider;
        private readonly IMusicGenreProvider _musicGenreProvider;
        private readonly IArtistProvider _artistProvider;

        public DetailsController(ICityProvider cityProvider, IMusicGenreProvider musicGenreProvider, IArtistProvider artistProvider)
        {
            _cityProvider = cityProvider;
            _musicGenreProvider = musicGenreProvider;
            _artistProvider = artistProvider;
        }

        public IActionResult Index()
        {
            DetailsVm detailsVm = new DetailsVm();

            detailsVm.Artists = _artistProvider.GetAll();
            detailsVm.MusicGenres = _musicGenreProvider.GetAll();
            detailsVm.Cities = _cityProvider.GetAll();

            return View(detailsVm);
        }

        public IActionResult Create(DetailType type)
        {
            DetailsManagementVM detailsManagementVM = new DetailsManagementVM { Type = type, Data = new DictionaryTableBase()};

            return View(detailsManagementVM);
        }

        [HttpPost, ActionName("Create")]
        public IActionResult CreatePOST(DetailsManagementVM detailsManagementVM)
        {
            if(detailsManagementVM.Type == DetailType.Artist)
            {
                Artist artist = new Artist(detailsManagementVM.Data);
                _artistProvider.Add(artist);
            }

            if (detailsManagementVM.Type == DetailType.City)
            {
                City city = new City(detailsManagementVM.Data);
                _cityProvider.Add(city);
            }

            if (detailsManagementVM.Type == DetailType.MusicGenre)
            {
                MusicGenre genre = new MusicGenre(detailsManagementVM.Data);
                _musicGenreProvider.Add(genre);
            }

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id,DetailType type)
        {
            DictionaryTableBase data = new DictionaryTableBase();

            if (type == DetailType.Artist)
            {
                data = _artistProvider.Get(id);
            }

            if (type == DetailType.City)
            {
                data = _cityProvider.Get(id);
            }

            if (type == DetailType.MusicGenre)
            {
                data = _musicGenreProvider.Get(id);
            }

            DetailsManagementVM detailsManagementVM = new DetailsManagementVM();
            detailsManagementVM.Data = data;
            detailsManagementVM.Type = type;            

            return View("Delete", detailsManagementVM);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int id, DetailType type)
        {
            if (type == DetailType.Artist)
            {
                Artist artist = _artistProvider.Get(id);
                _artistProvider.Remove(artist);
            }

            if (type == DetailType.City)
            {
                City city = _cityProvider.Get(id);
                _cityProvider.Remove(city);
            }

            if (type == DetailType.MusicGenre)
            {
                MusicGenre genre = _musicGenreProvider.Get(id);
                _musicGenreProvider.Remove(genre);
            }

            return RedirectToAction("Index");
        }
    }
}
