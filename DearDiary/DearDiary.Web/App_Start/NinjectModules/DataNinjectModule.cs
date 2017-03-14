using DearDiary.Data;
using DearDiary.Data.Repositories;
using Ninject.Modules;
using Ninject.Web.Common;

namespace DearDiary.Web.App_Start.NinjectModules
{
    public class DataNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IDearDiaryDbContext>().To<DearDiaryDbContext>().InRequestScope();
            this.Bind(typeof(IEFGenericRepository<>)).To(typeof(EFGenericRepository<>)).InRequestScope();
            this.Bind<IDearDiaryData>().To<DearDiaryData>().InRequestScope();
        }
    }
}