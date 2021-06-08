using FaceControlApp.Domain.Interfaces;
using System;

namespace FaceControlApp.Domain.Entities
{
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
