namespace DynamicMapping.Core
{
    public interface IMappingEngineHandler
    {
        Task<MappingModelBase> MapToLocal(string customerObject);
        Task<string> MapFromLocal(MappingModelBase model);
    }
}
