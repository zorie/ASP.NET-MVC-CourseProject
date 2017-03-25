using DearDiary.Models;
using DearDiary.Web.AutoMapping;

namespace DearDiary.Web.Models
{
    public class AimDetailsViewModel : IMapFrom<Aim>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CityName { get; set; }
        public string CountryName { get; set; }
        public string OwnerName { get; set; }
        public string Photo { get; set; }

    }
}