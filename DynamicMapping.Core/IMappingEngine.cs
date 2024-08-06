namespace DynamicMapping.Core
{
    public interface IMappingEngine
    {
        string Name { get; }
        Task<MappingModelBase> MapToLocal(string customerObject);
        Task<string> MapFromLocal(MappingModelBase model);
    }
}
