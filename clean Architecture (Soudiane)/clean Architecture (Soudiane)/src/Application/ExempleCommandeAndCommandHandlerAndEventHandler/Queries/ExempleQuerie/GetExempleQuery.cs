using AutoMapper;
using AutoMapper.QueryableExtensions;
using Clean_Architecture_Soufiane.Application.Common.Models;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ClienArchitectureJaisonTailer.Application.GetExempleQuery
{
    public class GetExempleQuery : IRequest<PaginatedList<ExampleDTO>>
    {
        public int ListId { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }

    public class GetTodoItemsWithPaginationQueryHandler : IRequestHandler<GetExempleQuery, PaginatedList<ExampleDTO>>
    {
 
        private readonly IMapper _mapper;

        public GetTodoItemsWithPaginationQueryHandler(IMapper mapper)
        {

            _mapper = mapper;
        }

        public async Task<PaginatedList<ExampleDTO>> Handle(GetExempleQuery request, CancellationToken cancellationToken)
        {
            return new PaginatedList<ExampleDTO>(new System.Collections.Generic.List<ExampleDTO>(),2,0,5);
        }
    }
}
