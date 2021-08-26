using System.Threading.Tasks;

namespace Clean_Architecture_Soufiane.BuildingBlocks.EventBus.Abstractions
{
    public interface IDynamicIntegrationEventHandler
    {
        Task Handle(dynamic eventData);
    }
}
