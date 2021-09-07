using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Clean_Architecture_Soufiane.Application.Commands
{
    public class ExempleCommand : IRequest<bool>
    {
        
    }
    public class ExempleCommandHandler : IRequestHandler<ExempleCommand, bool>
    {


        public ExempleCommandHandler()
        {

        }

        public async Task<bool> Handle(ExempleCommand request, CancellationToken cancellationToken)
        {
           
            return true;
        }
    }
}
