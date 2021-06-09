namespace FaceControlApp.Application.Aggregates.Suspects.Queries.GetSuspectDetails
{
    using System;
    using FaceControlApp.Domain.Entities;
    using MediatR;

    public class GetSuspectDetailsQuery : IRequest<Suspect>
    {
        public Guid Id
        {
            get; set;
        }
    }
}
