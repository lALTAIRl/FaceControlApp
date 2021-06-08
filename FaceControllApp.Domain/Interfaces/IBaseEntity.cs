using System;

namespace FaceControlApp.Domain.Interfaces
{
    public interface IBaseEntity
    {
        public Guid Id
        {
            get; set;
        }
    }
}
