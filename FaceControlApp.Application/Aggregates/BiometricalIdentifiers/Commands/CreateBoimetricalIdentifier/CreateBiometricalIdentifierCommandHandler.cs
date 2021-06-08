namespace FaceControlApp.Application.Aggregates.BiometricalIdentifiers.Commands.CreateBoimetricalIdentifier
{
    using AutoMapper;
    using FaceControlApp.Application.Abstractions;
    using FaceControlApp.Application.Interfaces;
    using FaceControlApp.Domain.Entities;
    using MediatR;
    using System;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    public class CreateBiometricalIdentifierCommandHandler 
        : AbstractRequestHandler, IRequestHandler<CreateBiometricalIdentifierCommand, Guid>
    {
        public CreateBiometricalIdentifierCommandHandler(
            IMediator mediator, 
            IFaceControlAppDbContext dbContext, 
            IMapper mapper) 
            : base(mediator, dbContext, mapper)
        {
        }

        public async Task<Guid> Handle(CreateBiometricalIdentifierCommand request, CancellationToken cancellationToken)
        {
            byte[] imageData = null;

            using (var binaryReader = new BinaryReader(request.FaceImage.OpenReadStream()))
            {
                imageData = binaryReader.ReadBytes((int)request.FaceImage.Length);
            }

            var biometricalIdentifier = new BiometricalIdentifier
            {
                PersonName = request.PersonName,
                FaceImage = imageData
            };

            this.DbContext.BiometricalIdentifiers.Add(biometricalIdentifier);

            this.DbContext.SaveChanges();

            return biometricalIdentifier.Id;
        }
    }
}
