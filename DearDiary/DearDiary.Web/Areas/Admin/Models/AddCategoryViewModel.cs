using DearDiary.Models;
using DearDiary.Web.AutoMapping;
using System.ComponentModel.DataAnnotations;

namespace DearDiary.Web.Areas.Admin.Models
{
    public class AddCategoryViewModel : IMapFrom<AimCategory>
    {
        [Required]
        [MinLength(3)]
        [MaxLength(30)]
        public string Name { get; set; }
    }
}