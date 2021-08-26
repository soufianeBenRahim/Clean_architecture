using Clean_Architecture_Soufiane.BuildingBlocks.EventBus.Events;
using System.Threading.Tasks;

namespace Clean_Architecture_Soufiane.BuildingBlocks.EventBus.Abstractions
{
    public interface IIntegrationEventHandler<in TIntegrationEvent> : IIntegrationEventHandler
        where TIntegrationEvent : IntegrationEvent
    {
        Task Handle(TIntegrationEvent @event);
    }

    public interface IIntegrationEventHandler
    {
    }
}
