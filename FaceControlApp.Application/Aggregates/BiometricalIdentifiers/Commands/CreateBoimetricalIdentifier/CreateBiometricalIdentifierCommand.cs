namespace FaceControlApp.Application.Aggregates.BiometricalIdentifiers.Commands.CreateBoimetricalIdentifier
{
    using System;
    using MediatR;
    using Microsoft.AspNetCore.Http;

    public class CreateBiometricalIdentifierCommand : IRequest<Guid>
    {
        public string PersonName
        {
            get; set;
        }

        public IFormFile FaceImage
        {
            get; set;
        }
    }
}
