using Clean_Architecture_Soufiane.Application.Common.Exceptions;
using Clean_Architecture_Soufiane.Application.Common.Models;
using Clean_Architecture_Soufiane.Domain.Events;
using Clean_Architecture_Soufiane.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Clean_Architecture_Soufiane.Application.DomainEventHandlers
{
    class ExempleDomainEventHandler : INotificationHandler<DomainEventNotification<ExempleDomainEvent>>
    {

        public ExempleDomainEventHandler ()
        {

        }
        public async Task Handle(DomainEventNotification<ExempleDomainEvent> notification, CancellationToken cancellationToken)
        {
            
            await Task.CompletedTask;
        }
    }
}
