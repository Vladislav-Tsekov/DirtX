using Microsoft.AspNetCore.Mvc.Rendering;

namespace DirtX.Core.Models
{
    public class MotoSelectionViewModel
    {
        public int SelectedMake { get; set; }
        public int SelectedModel { get; set; }
        public int SelectedYear { get; set; }
        public int SelectedDisplacement { get; set; }

        public IEnumerable<SelectListItem> Makes { get; set; } = new List<SelectListItem>();
    }
}
