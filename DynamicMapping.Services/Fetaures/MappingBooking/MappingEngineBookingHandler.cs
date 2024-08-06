using DynamicMapping.Core;

namespace DynamicMapping.Services.Fetaures.MappingBooking
{
    public class MappingEngineBookingHandler : IMappingEngine
    {
        public string Name => AppConstants.Booking;

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
