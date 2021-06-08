using FaceControlApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FaceControlApp.Application.Interfaces
{
    public interface IFaceControlAppDbContext
    {
        DbSet<BiometricalIdentifier> BiometricalIdentifiers
        {
            get; set;
        }
    }
}
