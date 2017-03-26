using DearDiary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DearDiary.Services.Contracts
{
    public interface IAimCategoryService
    {
        IEnumerable<AimCategory> GetAimCategories();

        void AddAimCategory(AimCategory category);
    }
}
