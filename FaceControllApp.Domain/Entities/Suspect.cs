namespace FaceControlApp.Domain.Entities
{
    using System;
    using FaceControlApp.Domain.Interfaces;

    public class Suspect : IBaseEntity
    {
        public Guid Id
        {
            get; set;
        }

        public string FaceImage
        {
            get; set;
        }
    }
}
