namespace FaceControlApp.Application.Aggregates.Suspects.Queries.GetSuspects
{
    using System.Collections.Generic;
    using FaceControlApp.Domain.Entities;
    using MediatR;

    public class GetSuspectsQuery : IRequest<List<Suspect>>
    {
    }
}
