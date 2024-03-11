using Microsoft.AspNetCore.Mvc.Rendering;

namespace DirtX.Models
{
    public class MotoSelectionViewModel
    {
        public int SelectedMake { get; set; }
        public int SelectedModel { get; set; }
        public int SelectedYear { get; set; }
        public int SelectedDisplacement { get; set; }

        public IEnumerable<SelectListItem> Makes { get; set; }
        public IEnumerable<SelectListItem> Models { get; set; }
        public IEnumerable<SelectListItem> Displacements { get; set; }
        public IEnumerable<SelectListItem> Years { get; set; }
    }

}
