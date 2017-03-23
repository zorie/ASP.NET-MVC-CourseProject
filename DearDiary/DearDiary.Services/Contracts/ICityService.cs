using DearDiary.Models;
using System.Collections.Generic;

namespace DearDiary.Services.Contracts
{
    public interface ICityService
    {
        List<City> GetAllCities();

        List<City> GetAllCitiesByCountry(string countryId);
    }
}
