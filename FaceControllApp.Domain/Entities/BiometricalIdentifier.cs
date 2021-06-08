namespace FaceControlApp.Domain.Entities
{
    using FaceControlApp.Domain.Interfaces;
    using System;

    public class BiometricalIdentifier : IBaseEntity
    {
        public Guid Id
        {
            get; set;
        }

        public string PersonName
        {
            get; set;
        }

        public byte[] FaceImage
        {
            get; set;
        }
    }
}
