using Clean_Architecture_Soufiane.BuildingBlocks.EventBus.Events;
using System;
using System.Threading.Tasks;

namespace Ordering.API.Application.IntegrationEvents
{
    public interface IIntegrationEventService
    {
        Task PublishEventsThroughEventBusAsync(Guid transactionId);
        Task AddAndSaveEventAsync(IntegrationEvent evt);
    }
}
