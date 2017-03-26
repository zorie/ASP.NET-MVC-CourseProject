using DearDiary.Models;
using System.Collections.Generic;

namespace DearDiary.Services.Contracts
{
    public interface ICityService
    {
        void AddCity(City city);
        IEnumerable<City> GetAllCities();

        IEnumerable<City> GetAllCitiesByCountry(string countryId);
    }
}
