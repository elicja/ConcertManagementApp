using Microsoft.AspNetCore.Mvc.Rendering;

namespace Models.ViewModels
{
    public class PerformanceInfoVM
    {
        public PerformanceInfo PerformanceInfo { get; set; }
        public IEnumerable<SelectListItem> Artists { get; set; }
    }
}
