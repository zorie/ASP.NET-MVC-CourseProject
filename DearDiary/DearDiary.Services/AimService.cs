using DearDiary.Data;
using DearDiary.Models;
using DearDiary.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DearDiary.Services
{
    public class AimService : IAimService
    {
        private readonly IDearDiaryData data;

        public AimService(IDearDiaryData data)
        {
            if(data == null)
            {
                throw new ArgumentNullException("Data cannot be null");
            }

            this.data = data;
        }

        public void AddAim(Aim aim)
        {
            this.data.Aims.Add(aim);
            this.data.SaveChanges();
        }

        public Aim GetAimById(int id)
        {
            Aim aim = this.data.Aims
                .All
                .Where(x => x.Id == id)
                .Include(x => x.City)
                .Include(x => x.Country)
                .FirstOrDefault();
            return aim;            
        }

        public IEnumerable<Aim> ExploreAims(string searchWord, IEnumerable<int> categoriesIds, string sortBy, int page = 1, int aimsPerPage = 5)
        {
            var getAimsFrom = (page - 1) * aimsPerPage;

            var aims = this.FilterQuery(searchWord, categoriesIds);

            sortBy = sortBy == null ? string.Empty : sortBy.ToLower();
            switch (sortBy)
            {
                case "name": aims = aims.OrderBy(x => x.Name); break;
                case "ownerusername": aims = aims.OrderBy(x => x.OwnerUsername); break;
                default: aims = aims.OrderBy(x => x.Name); break;
            }

            var result = aims.Skip(getAimsFrom).Take(aimsPerPage).ToList();

            return result;
        }

        public int GetAimsCount(string searchWord, IEnumerable<int> categoriesIds)
        {
            var aims = this.FilterQuery(searchWord, categoriesIds);
            return aims.Count();
        }

        private IQueryable<Aim> FilterQuery(string searchWord, IEnumerable<int> categoriesIds)
        {
            var aims = this.data.Aims.All;
            searchWord = searchWord.ToLower();

            if (searchWord != null)
            {
                aims= aims.Where(x => x.Name.ToLower().Contains(searchWord) || x.OwnerUsername.ToLower().Contains(searchWord));
            }

            if (categoriesIds != null && categoriesIds.Any())
            {
                aims = aims.Where(x => categoriesIds.Contains(x.AimCategoryId));
            }

            return aims;
        }
    }
}
