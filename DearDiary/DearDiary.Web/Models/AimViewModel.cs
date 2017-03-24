using DearDiary.Models;
using DearDiary.Web.AutoMapping;

namespace DearDiary.Web.Models
{
    public class AimViewModel : IMapFrom<Aim>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string OwnerUsername { get; set; }

        public string Photo { get; set; }
    }
}