using System.Collections.Generic;

namespace DearDiary.Web.Models
{
    public class ExploreResultsViewModel
    {
        public IEnumerable<AimViewModel> Aims { get; set; }

        public int Pages { get; set; }

        public ExploreSubmitViewModel SubmitModel { get; set; }
    }
}