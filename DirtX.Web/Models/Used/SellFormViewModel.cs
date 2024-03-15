namespace DirtX.Web.Models.Home;

using DirtX.Infrastructure.Data.Models.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;

public class SellFormViewModel
{
    public int SelectedMake { get; set; }
    public int SelectedModel { get; set; }
    public int SelectedYear { get; set; }
    public int SelectedDisplacement { get; set; }
    public int Price { get; set; }
    public byte[] Image { get; set; }

    //public List<Province> Provinces { get; set; }
    public Province? Province { get; set; }
    public string Description { get; set; }
    public string Contact { get; set; }

    public IEnumerable<SelectListItem> Makes { get; set; }
    public IEnumerable<SelectListItem> Models { get; set; }
    public IEnumerable<SelectListItem> Displacements { get; set; }
    public IEnumerable<SelectListItem> Years { get; set; }
}
