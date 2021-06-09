namespace FaceControlApp.Application.Interfaces
{
    using FaceControlApp.Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using System.Threading;
    using System.Threading.Tasks;

    public interface IFaceControlAppDbContext
    {
        DbSet<BiometricalIdentifier> BiometricalIdentifiers
        {
            get; set;
        }

        DbSet<Suspect> Suspects
        {
            get; set;
        }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

        int SaveChanges();
    }
}
