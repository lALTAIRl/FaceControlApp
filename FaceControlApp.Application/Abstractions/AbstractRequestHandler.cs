namespace FaceControlApp.Application.Abstractions
{
    using AutoMapper;
    using FaceControlApp.Application.Interfaces;
    using MediatR;

    public abstract class AbstractRequestHandler
    {
        protected IMediator Mediator
        {
            get;
        }

        protected IFaceControlAppDbContext DbContext
        {
            get;
        }

        protected IMapper Mapper
        {
            get;
        }

        public AbstractRequestHandler(
            IMediator mediator,
            IFaceControlAppDbContext dbContext,
            IMapper mapper)
        {
            this.Mediator = mediator;
            this.DbContext = dbContext;
            this.Mapper = mapper;
        }
    }
}
