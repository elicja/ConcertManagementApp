using Models.Base;
using Models.Enum;

namespace Models.ViewModels
{
    public class DetailsManagementVM
    {
        public DictionaryTableBase Data { get; set; }
        public DetailType Type { get; set; }
    }
}
