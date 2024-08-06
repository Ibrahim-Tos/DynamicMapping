namespace DynamicMapping.Core
{
    public interface IParserEngine
    {
        IMappingEngine ResolveMappingEngineByModel(MappingModelBase model, IEnumerable<IMappingEngine> mappingEngines);
        IMappingEngine ResolveMappingEngineByCustomerObject(string customerObject, IEnumerable<IMappingEngine> mappingEngines);
    }
}
