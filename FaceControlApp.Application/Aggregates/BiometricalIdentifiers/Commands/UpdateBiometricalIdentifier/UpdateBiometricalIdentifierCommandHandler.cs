﻿namespace FaceControlApp.Application.Aggregates.BiometricalIdentifiers.Commands.UpdateBiometricalIdentifier
{
    using System.IO;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using FaceControlApp.Application.Abstractions;
    using FaceControlApp.Application.Interfaces;
    using MediatR;

    public class UpdateBiometricalIdentifierCommandHandler
        : AbstractRequestHandler, IRequestHandler<UpdateBiometricalIdentifierCommand, Unit>
    {
        public UpdateBiometricalIdentifierCommandHandler(
            IMediator mediator,
            IFaceControlAppDbContext dbContext,
            IMapper mapper)
            : base(mediator, dbContext, mapper)
        {
        }

        public async Task<Unit> Handle(UpdateBiometricalIdentifierCommand request, CancellationToken cancellationToken)
        {
            var identifier = this.DbContext.BiometricalIdentifiers
                .FirstOrDefault(x => x.Id == request.Id);

            byte[] imageData = null;

            using (var binaryReader = new BinaryReader(request.FaceImage.OpenReadStream()))
            {
                imageData = binaryReader.ReadBytes((int)request.FaceImage.Length);
            }

            identifier.FaceImage = imageData;

            this.DbContext.SaveChanges();

            return Unit.Value;
        }
    }
}
