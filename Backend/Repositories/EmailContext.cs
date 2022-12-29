using EmailProject.Repositories.Models;
using Microsoft.EntityFrameworkCore;

namespace EmailProject.Repositories
{
	public class Context : DbContext
	{
		public Context(DbContextOptions<Context> options) : base(options)
		{
		}

		public DbSet<User> Users { get; set; }
		public DbSet<Email> Emails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
				.HasIndex(u => u.Email)
				.IsUnique();
            Seed(modelBuilder);
        }

		private static void Seed(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<User>(options =>
			{
				options.HasData(
						new User { Id = Guid.NewGuid(), Email = "user1@test.com", Name = "user1" },
						new User { Id = Guid.NewGuid(), Email = "user2@test.com", Name = "user2" },
						new User { Id = Guid.NewGuid(), Email = "user3@test.com", Name = "user3" },
						new User { Id = Guid.NewGuid(), Email = "user4@test.com", Name = "user4" },
						new User { Id = Guid.NewGuid(), Email = "user5@test.com", Name = "user5" }
                    );
			});
		}
    }
}

