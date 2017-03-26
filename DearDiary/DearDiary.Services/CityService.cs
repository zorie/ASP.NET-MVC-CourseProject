using DearDiary.Data;
using DearDiary.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using DearDiary.Models;

namespace DearDiary.Services
{
    public class CityService : ICityService
    {
        private readonly IDearDiaryData data;

        public CityService(IDearDiaryData data)
        {
            if (data == null)
            {
                throw new ArgumentNullException("Data cannot be null");
            }

            this.data = data;
        }

        public void AddCity(City city)
        {
            this.data.Cities.Add(city);
            this.data.SaveChanges();
        }

        public IEnumerable<City> GetAllCities()
        {
            return this.data.Cities.All.ToList();
        }

        public IEnumerable<City> GetAllCitiesByCountry(string countryId)
        {
            int countryID = int.Parse(countryId);
            return this.data.Cities.All.Where(x => x.CountryId == countryID).ToList();
        }
    }
}
