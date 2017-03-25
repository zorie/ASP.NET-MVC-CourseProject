using DearDiary.Models;
using System.Collections.Generic;

namespace DearDiary.Services.Contracts
{
    public interface ICountryService
    {
        IEnumerable<Country> GetAllCountries();
    }
}
