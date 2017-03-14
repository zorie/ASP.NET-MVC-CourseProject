using DearDiary.Data;
using System.Data.Entity;
using DearDiary.Data.Migrations;

namespace DearDiary.Web.App_Start
{
    public class DbConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DearDiaryDbContext, Configuration>());
            DearDiaryDbContext.Create().Database.Initialize(true);
        }
    }
}