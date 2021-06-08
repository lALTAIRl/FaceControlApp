using FaceControlApp.Application.Interfaces;
using FaceControlApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FaceControlApp.Persistence
{
    public class FaceControlAppDbContext : DbContext, IFaceControlAppDbContext
    {
        public FaceControlAppDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<BiometricalIdentifier> BiometricalIdentifiers 
        { 
            get; set; 
        }
    }
}
