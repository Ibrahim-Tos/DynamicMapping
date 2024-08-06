using DynamicMapping.Core;

namespace DynamicMapping.Services.Fetaures.MappingBnb
{
    public class MappingEngineBnbHandler : IMappingEngine
    {
        public string Name => AppConstants.Bnb;

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
