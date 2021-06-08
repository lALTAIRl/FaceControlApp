namespace FaceControlApp.Application.Aggregates.BiometricalIdentifiers.Queries.GetBiometricalIdentifier
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using FaceControlApp.Application.Abstractions;
    using FaceControlApp.Application.Aggregates.BiometricalIdentifiers.Models;
    using FaceControlApp.Application.Interfaces;
    using MediatR;

    public class GetBiometricalIdentifierQueryHandler
        : AbstractRequestHandler, IRequestHandler<GetBiometricalIdentifierQuery, BiometricalIdentifierViewModel>
    {
        public GetBiometricalIdentifierQueryHandler(
            IMediator mediator,
            IFaceControlAppDbContext dbContext,
            IMapper mapper)
            : base(mediator, dbContext, mapper)
        {
        }

        public async Task<BiometricalIdentifierViewModel> Handle(GetBiometricalIdentifierQuery request, CancellationToken cancellationToken)
        {
            var biometricalIdentifier = this.DbContext.BiometricalIdentifiers
                .FirstOrDefault(x => x.Id == request.Id);

            return new BiometricalIdentifierViewModel
            {
                Id = biometricalIdentifier.Id,
                PersonName = biometricalIdentifier.PersonName,
                FaceImageBase64 = biometricalIdentifier.FaceImage
            };
        }
    }
}
