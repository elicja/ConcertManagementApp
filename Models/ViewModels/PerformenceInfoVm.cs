using Microsoft.AspNetCore.Mvc.Rendering;

namespace Models.ViewModels
{
    public class PerformenceInfoVm
    {
        public PerformenceInfo PerformenceInfo { get; set; }
        public IEnumerable<SelectListItem> Artists { get; set; }
    }
}
