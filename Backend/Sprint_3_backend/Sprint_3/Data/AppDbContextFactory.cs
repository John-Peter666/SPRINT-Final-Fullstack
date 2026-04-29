using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Sprint_3.Data
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();

            optionsBuilder.UseMySql(
                "server=localhost;port=3306;database=sprint3;user=root;password=cimatec",
                ServerVersion.AutoDetect("server=localhost;port=3306;database=sprint3;user=root;password=cimatec")
            );

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
