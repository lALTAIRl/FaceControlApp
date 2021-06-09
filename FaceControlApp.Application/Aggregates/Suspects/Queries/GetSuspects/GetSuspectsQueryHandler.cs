namespace FaceControlApp.Application.Aggregates.Suspects.Queries.GetSuspects
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using FaceControlApp.Application.Abstractions;
    using FaceControlApp.Application.Interfaces;
    using FaceControlApp.Domain.Entities;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    public class GetSuspectsQueryHandler
        : AbstractRequestHandler, IRequestHandler<GetSuspectsQuery, List<Suspect>>
    {
        public GetSuspectsQueryHandler(
            IMediator mediator,
            IFaceControlAppDbContext dbContext,
            IMapper mapper)
            : base(mediator, dbContext, mapper)
        {
        }

        public async Task<List<Suspect>> Handle(GetSuspectsQuery request, CancellationToken cancellationToken)
        {
            var suspects = await this.DbContext.Suspects.ToListAsync();

            return suspects;
        }
    }
}
