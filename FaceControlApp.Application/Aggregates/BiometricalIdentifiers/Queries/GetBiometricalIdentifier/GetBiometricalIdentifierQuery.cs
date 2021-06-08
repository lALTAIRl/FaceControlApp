namespace FaceControlApp.Application.Aggregates.BiometricalIdentifiers.Queries.GetBiometricalIdentifier
{
    using System;
    using FaceControlApp.Application.Aggregates.BiometricalIdentifiers.Models;
    using MediatR;

    public class GetBiometricalIdentifierQuery : IRequest<BiometricalIdentifierViewModel>
    {
        public Guid Id
        {
            get; set;
        }
    }
}
