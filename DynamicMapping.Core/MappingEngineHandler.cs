namespace DynamicMapping.Core
{
    public class MappingEngineHandler : IMappingEngineHandler
    {
        private readonly IEnumerable<IMappingEngine> _mappingEngines;
        private readonly IParserEngine _parserEngine;

        public MappingEngineHandler(IEnumerable<IMappingEngine> mappingEngines, IParserEngine parserEngine)
        {
            _mappingEngines = mappingEngines;
            _parserEngine = parserEngine;
        }

        public Task<string> MapFromLocal(MappingModelBase model)
        {
            // ToDo: Instead of simple method we can think about The strategy pattern - Advanced (Resolver Pattern)
            var mappinEngine = _parserEngine.ResolveMappingEngineByModel(model, _mappingEngines);

            var result = mappinEngine.MapFromLocal(model);

            return result;
        }

        public Task<MappingModelBase> MapToLocal(string customerObject)
        {
            // ToDo: Instead of simple method we can think about The strategy pattern - Advanced (Resolver Pattern)
            var mappinEngine = _parserEngine.ResolveMappingEngineByCustomerObject(customerObject, _mappingEngines);

            var result = mappinEngine.MapToLocal(customerObject);

            return result;
        }
    }
}
