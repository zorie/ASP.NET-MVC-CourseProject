namespace DearDiary.Web.AutoMapping
{
    public interface IMapperAdapter
    {
        TDestination Map<TDestination>(object source);
    }
}
