namespace FaceControlApp.Application.Aggregates.BiometricalIdentifiers.Commands.UpdateBiometricalIdentifier
{
    using System;
    using MediatR;
    using Microsoft.AspNetCore.Http;

    public class UpdateBiometricalIdentifierCommand : IRequest<Unit>
    {
        public Guid Id
        {
            get; set;
        }

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
