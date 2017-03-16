using AutoMapper;

namespace DearDiary.Web.AutoMapping
{
    public interface IHaveCustomMappings
    {
        void CreateMappings(IMapperConfigurationExpression configuration);
    }
}