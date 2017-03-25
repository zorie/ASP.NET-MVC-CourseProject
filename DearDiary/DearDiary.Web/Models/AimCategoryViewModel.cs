using DearDiary.Models;
using DearDiary.Web.AutoMapping;

namespace DearDiary.Web.Models
{
    public class AimCategoryViewModel : IMapFrom<AimCategory>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}