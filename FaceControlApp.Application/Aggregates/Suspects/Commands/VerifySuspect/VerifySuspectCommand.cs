namespace FaceControlApp.Application.Aggregates.Suspects.Commands.VerifySuspect
{
    using System;
    using MediatR;

    public class VerifySuspectCommand : IRequest<Guid>
    {
        public Guid SuspectId
        {
            get; set;
        }

        public string PersonName
        {
            get; set;
        }
    }
}
