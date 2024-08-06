using DynamicMapping.Core;

namespace DynamicMapping.Services.Fetaures.MappingAltos
{
    public class MappingEngineAltosHandler : IMappingEngine
    {
        public string Name => AppConstants.Altos;

        public Task<string> MapFromLocal(MappingModelBase model)
        {
            throw new NotImplementedException();
        }

        public Task<MappingModelBase> MapToLocal(string customerObject)
        {
            throw new NotImplementedException();
        }
    }
}
