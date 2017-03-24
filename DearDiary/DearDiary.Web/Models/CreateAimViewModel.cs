using DearDiary.Models;
using DearDiary.Web.AutoMapping;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;
using System.Web.Mvc;

namespace DearDiary.Web.Models
{
    public class CreateAimViewModel : IMapFrom<Aim>
    {
        [Required]        
        [Display(Name = "Name")]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Description")]
        [StringLength(150, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 5)]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Status")]
        public string Status { get; set; }

        [Display(Name = "City")]
        public int CityId { get; set; }
        public IEnumerable<SelectListItem> Cities { get; set; }

        [Display(Name = "Country")]
        public int CountryId { get; set; }
        public IEnumerable<SelectListItem> Countries { get; set; }

        //[Required]
        [Display(Name = "Photo")]
        [NotMapped]
        public HttpPostedFileBase Photo { get; set; }
        
        [Display(Name = "Owner username")]
        public string OwnerUsername { get; set; }

        //[Required]
        //[Display(Name = "Category")]
        //public string AimCategory { get; set; }
    }
}