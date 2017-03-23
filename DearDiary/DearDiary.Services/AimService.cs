using DearDiary.Data;
using DearDiary.Models;
using DearDiary.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
