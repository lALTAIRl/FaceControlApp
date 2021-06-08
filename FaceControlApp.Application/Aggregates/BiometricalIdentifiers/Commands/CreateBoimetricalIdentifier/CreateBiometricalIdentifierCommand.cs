namespace FaceControlApp.Application.Aggregates.BiometricalIdentifiers.Commands.CreateBoimetricalIdentifier
{
    using MediatR;
    using Microsoft.AspNetCore.Http;

    public class CreateBiometricalIdentifierCommand : IRequest<Unit>
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
