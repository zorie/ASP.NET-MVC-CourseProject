using DearDiary.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DearDiary.Models;
using DearDiary.Data;

namespace DearDiary.Services
{
    public class AimCategoryService : IAimCategoryService
    {
        private readonly IDearDiaryData data;
        public AimCategoryService(IDearDiaryData data)
        {
            if (data == null)
            {
                throw new ArgumentNullException("Data cannot be null");
            }

            this.data = data;
        }
        public void AddAimCategory(AimCategory category)
        {
            this.data.AimCategories.Add(category);
            this.data.SaveChanges();
        }

        public IEnumerable<AimCategory> GetAimCategories()
        {
            var categories = this.data.AimCategories.All.ToList();

            return categories;
        }
    }
}
