namespace FaceControlApp.Application.Aggregates.Suspects.Commands.VerifySuspect
{
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using FaceControlApp.Application.Abstractions;
    using FaceControlApp.Application.Exceptions;
    using FaceControlApp.Application.Interfaces;
    using FaceControlApp.Domain.Entities;
    using MediatR;

    public class VerifySuspectCommandHandler
        : AbstractRequestHandler, IRequestHandler<VerifySuspectCommand, Guid>
    {
        public VerifySuspectCommandHandler(
            IMediator mediator,
            IFaceControlAppDbContext dbContext,
            IMapper mapper)
            : base(mediator, dbContext, mapper)
        {
        }

        public async Task<Guid> Handle(VerifySuspectCommand request, CancellationToken cancellationToken)
        {
            var suspect = this.DbContext.Suspects
                .FirstOrDefault(x => x.Id == request.SuspectId);

            if (suspect == null)
            {
                throw new NotFoundException();
            }

            var biometricalIdentifier = new BiometricalIdentifier
            {
                PersonName = request.PersonName,
                FaceImage = suspect.FaceImage
            };

            this.DbContext.BiometricalIdentifiers.Add(biometricalIdentifier);
            this.DbContext.Suspects.Remove(suspect);

            this.DbContext.SaveChanges();

            return biometricalIdentifier.Id;
        }
    }
}
