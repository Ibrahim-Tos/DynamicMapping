using DynamicMapping.Core;
using Newtonsoft.Json;

namespace DynamicMapping.Services.Fetaures.MappingAltos
{
    public class MappingEngineAltosHandler : IMappingEngine
    {
        public string Name => AppConstants.Altos;

        public async Task<string> MapFromLocal(MappingModelBase model)
        {
            var result = JsonConvert.SerializeObject(model);

            await Task.Delay(1000);

            return result;
        }

        public async Task<MappingModelBase> MapToLocal(string customerObject)
        {
            var result = JsonConvert.DeserializeObject<MappingModelBase>(customerObject);

            await Task.Delay(1000);

            return result;
        }
    }
}
