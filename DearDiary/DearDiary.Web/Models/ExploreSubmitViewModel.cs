using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DearDiary.Web.Models
{
    public class ExploreSubmitViewModel
    {
        public string SearchWord { get; set; }

        public IEnumerable<int> ChosenCategoriesIds { get; set; }

        public string SortBy { get; set; }
    }
}