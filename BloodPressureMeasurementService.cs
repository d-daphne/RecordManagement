/* BloodPressureMeasurementServices.cs
 * 
 * A service class inherited an interface that stores all methods  
 * 
 * Revision History
 *			Created. Sep 27 2024. Daphne	
 *			Revised. Oct 4 2024. Daphne
 */

using BloodPressureMeasurementApplication.Entities;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace BloodPressureMeasurementApplication.Services
{
	public class BloodPressureMeasurementService : IBloodPressureMeasurementService
	{
		private readonly BloodPressureDbContext _context;

		private readonly List<string> _categories = new List<string>() { "success", "Elevated", "Hypertension Stage 1", "Hypertension Stage 2", "Hypertensive Crisis" };

        public BloodPressureMeasurementService(BloodPressureDbContext bloodPressureDbContext)
        {
            _context = bloodPressureDbContext;
        }

		// Method to get all bp measurements
        public List<BloodPressure> GetBloodPressures()
		{
			return _context.BloodPressures.Include(b => b.Position).ToList();
		}

		// Method to get all positions
		public List<Position> GetPositions()
		{
			return _context.Positions.ToList();
		}

		// Method to find bp measurement by Id
		public BloodPressure FindBloodPressureById(int? id)
		{
			return _context.BloodPressures.Find(id);
		}

		// Method to add new bp measurement
		public int AddBloodPressure(BloodPressure bloodPressure)
		{
			_context.BloodPressures.Add(bloodPressure);
			_context.SaveChanges();
			return bloodPressure.BPId;
		}

		// Method to edit a current measurement
		public int EditBloodPressure(BloodPressure bloodPressure)
		{
			_context.BloodPressures.Update(bloodPressure);
			_context.SaveChanges();

			return bloodPressure.BPId;
		}

		// Method to delete a current measure
		public int DeleteBloodPressure(BloodPressure bloodPressure)
		{
			_context.BloodPressures.Remove(bloodPressure);
			_context.SaveChanges();

			return bloodPressure.BPId;
		}
	}
}