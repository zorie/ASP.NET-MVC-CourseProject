using DearDiary.Models;
using DearDiary.Web.AutoMapping;
using System.Collections.Generic;

namespace DearDiary.Web.Models
{
    public class AimsViewModel
    {
        public IEnumerable<AimViewModel> Aims { get; set; }
    }
}