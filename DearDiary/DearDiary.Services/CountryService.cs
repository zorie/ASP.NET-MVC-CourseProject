using DearDiary.Data;
using DearDiary.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using DearDiary.Models;

namespace DearDiary.Services
{
    public class CountryService : ICountryService
    {
        private readonly IDearDiaryData data;

        public CountryService(IDearDiaryData data)
        {
            if (data == null)
            {
                throw new ArgumentNullException("Data cannot be null");
            }

            this.data = data;
        }

        public List<Country> GetAllCountries()
        {
            return this.data.Countries.All.ToList();
        }
    }
}
