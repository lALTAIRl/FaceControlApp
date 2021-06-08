using FaceControlApp.Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FaceControlApp.Persistence
{
    public class FaceControlAppDbContext : DbContext, IFaceControlAppDbContext
    {
        public FaceControlAppDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
