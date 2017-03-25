using DearDiary.Models;
using System.Collections.Generic;

namespace DearDiary.Services.Contracts
{
    public interface IAimService
    {
        void AddAim(Aim aim);
        Aim GetAimById(int id);
        int GetAimsCount(string searchWord, IEnumerable<int> categoriesIds);
        IEnumerable<Aim> ExploreAims(string searchWord, IEnumerable<int> categoriesIds, string sortBy, int page = 1, int aimsPerPage = 5);
    }
}
