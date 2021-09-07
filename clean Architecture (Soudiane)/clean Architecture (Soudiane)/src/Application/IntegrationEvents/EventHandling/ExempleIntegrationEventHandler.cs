using Clean_Architecture_Soufiane.Application.IntegrationEvents.Events;
using Clean_Architecture_Soufiane.BuildingBlocks.EventBus.Abstractions;
using MediatR;
using Microsoft.Extensions.Logging;
using Serilog.Context;
using System.Threading.Tasks;

namespace Clean_Architecture_Soufiane.Application.IntegrationEvents.EventHandling
{
    public class ExempleIntegrationEventHandler : IIntegrationEventHandler<ExempleIntegrationEvent>
    {

        public ExempleIntegrationEventHandler()
        {

        }

        /// <summary>
        /// Exemple integratiobn event
        /// </summary>
        /// <param name="event">       
        /// </param>
        /// <returns></returns>
        public async Task Handle(ExempleIntegrationEvent @event)
        {
           
        }
    }
}
