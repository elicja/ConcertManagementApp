using Microsoft.AspNetCore.Mvc.Rendering;

namespace Models.ViewModels
{
    public class ConcertInfoVm
    {
        public ConcertInfo ConcertInfo { get; set; }
        public IEnumerable<SelectListItem> Genres { get; set; }
        public IEnumerable<SelectListItem> Cities { get; set; }
    }
}
