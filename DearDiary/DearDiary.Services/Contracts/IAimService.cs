using DearDiary.Models;
using System.Collections.Generic;

namespace DearDiary.Services.Contracts
{
    public interface IAimService
    {
        void AddAim(Aim aim);
        IEnumerable<Aim> GetAims(int count);
    }
}
