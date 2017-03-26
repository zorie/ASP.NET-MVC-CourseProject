using DearDiary.Models;
using DearDiary.Web.AutoMapping;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace DearDiary.Web.Areas.Admin.Models
{
    public class AddCityViewModel : IMapFrom<City>
    {
        [Required]
        [MinLength(3)]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Country")]
        public int CountryId { get; set; }
        public IEnumerable<SelectListItem> Countries { get; set; }
    }
}