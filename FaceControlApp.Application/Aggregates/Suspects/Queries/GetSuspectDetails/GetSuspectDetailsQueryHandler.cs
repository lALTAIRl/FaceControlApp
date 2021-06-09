namespace FaceControlApp.Application.Aggregates.Suspects.Queries.GetSuspectDetails
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using FaceControlApp.Application.Abstractions;
    using FaceControlApp.Application.Exceptions;
    using FaceControlApp.Application.Interfaces;
    using FaceControlApp.Domain.Entities;
    using MediatR;

    public class GetSuspectDetailsQueryHandler
        : AbstractRequestHandler, IRequestHandler<GetSuspectDetailsQuery, Suspect>
    {
        public GetSuspectDetailsQueryHandler(
            IMediator mediator,
            IFaceControlAppDbContext dbContext,
            IMapper mapper)
            : base(mediator, dbContext, mapper)
        {
        }

        public async Task<Suspect> Handle(GetSuspectDetailsQuery request, CancellationToken cancellationToken)
        {
            var suspect = this.DbContext.Suspects.FirstOrDefault(x => x.Id == request.Id);

            if (suspect == null)
            {
                throw new NotFoundException();
            }

            return suspect;
        }
    }
}
