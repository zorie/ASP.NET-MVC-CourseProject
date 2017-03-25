using System.Collections.Generic;

namespace DearDiary.Web.Models
{
    public class ExploreViewModel
    {
        // we will not need this in the future, its here now because of the testing exapmles
        public IEnumerable<AimViewModel> Aims { get; set; }

        public IEnumerable<AimCategoryViewModel> AimCategories { get; set; }
    }
}