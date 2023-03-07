using Microsoft.AspNetCore.Mvc.Rendering;

namespace formProject.Models.ViewModel.CarDetailsView
{
    public class CarDetailsViewModel
    {
        public int CarDetailsId { get; set; }
        public string CarName { get; set; }
        public string CarMake { get; set; }
        public int CarEngineTypeId { get; set; }
        public int CarTypeId { get; set; }
        public int CarTyreBrandId { get; set; }
        public List<SelectListItem> SelectCarEngineType { get; set; }

        public List<SelectListItem> SelectCarType { get; set; }

        public List<SelectListItem> SelectCarTyreBrand { get; set; }

    }
}
