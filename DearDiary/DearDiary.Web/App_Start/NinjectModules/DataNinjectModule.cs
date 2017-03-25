using DearDiary.Data;
using DearDiary.Data.Repositories;
using DearDiary.Services;
using DearDiary.Services.Contracts;
using DearDiary.Web.AutoMapping;
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
            this.Bind<IAimService>().To<AimService>().InRequestScope();
            this.Bind<ICountryService>().To<CountryService>().InRequestScope();
            this.Bind<ICityService>().To<CityService>().InRequestScope();
            this.Bind<IAimCategoryService>().To<AimCategoryService>().InRequestScope();
            this.Bind<IMapperAdapter>().To<MapperAdapter>().InRequestScope();
        }
    }
}