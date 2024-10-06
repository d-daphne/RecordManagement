/* BloodPressureDbContext.cs
 * 
 * DbContext to map database 
 * 
 * Revision History
 *			Created. Sep 27 2024. Daphne	
 *			Revised. Oct 4 2024. Daphne
 */

using Microsoft.EntityFrameworkCore;

namespace BloodPressureMeasurementApplication.Entities
{
    public class BloodPressureDbContext : DbContext
    {
        public BloodPressureDbContext(DbContextOptions<BloodPressureDbContext> options) : base(options) { }

        public DbSet<BloodPressure> BloodPressures { get; set; }

		public DbSet<Position> Positions { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			// Seed position data
			modelBuilder.Entity<Position>().HasData(
				new Position { PositionId = 1, PositionName = "Standing" },
				new Position { PositionId = 2, PositionName = "Sitting" },
				new Position { PositionId = 3, PositionName = "Lying down" }
				);

			// Seed blood pressure data
			modelBuilder.Entity<BloodPressure>().HasData(
				new BloodPressure { BPId = 1, Systolic = 120, Diastolic = 80, Date = new DateTime(2024, 9, 8), PositionId = 1},
				new BloodPressure { BPId = 2, Systolic = 110, Diastolic = 90, Date = new DateTime(2024, 5, 7), PositionId = 2 },
				new BloodPressure { BPId = 3, Systolic = 100, Diastolic = 80, Date = new DateTime(2024, 6, 5), PositionId = 3 },
				new BloodPressure { BPId = 4, Systolic = 90, Diastolic = 120, Date = new DateTime(2024, 8, 9), PositionId = 2 },
				new BloodPressure { BPId = 5, Systolic = 95, Diastolic = 100, Date = new DateTime(2024, 9, 1), PositionId = 1 }
				);
		}
	}
}
