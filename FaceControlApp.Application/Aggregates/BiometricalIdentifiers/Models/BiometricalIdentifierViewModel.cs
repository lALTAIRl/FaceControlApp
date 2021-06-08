namespace FaceControlApp.Application.Aggregates.BiometricalIdentifiers.Models
{
    using System;

    public class BiometricalIdentifierViewModel
    {
        public Guid Id
        {
            get; set;
        }

        public string PersonName
        {
            get; set;
        }

        public string FaceImageBase64
        {
            get; set;
        }
    }
}
