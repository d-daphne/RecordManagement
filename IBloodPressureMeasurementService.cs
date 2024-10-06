/* IBloodPressureMeasurementServices.cs
 * 
 * An interface shows methods 
 * 
 * Revision History
 *			Created. Sep 27 2024. Daphne	
 *			Revised. Oct 4 2024. Daphne
 */

using BloodPressureMeasurementApplication.Entities;

namespace BloodPressureMeasurementApplication.Services
{
	public interface IBloodPressureMeasurementService
	{
		public List<BloodPressure> GetBloodPressures();

		public List<Position> GetPositions();

		public BloodPressure FindBloodPressureById(int? id);

		public int AddBloodPressure(BloodPressure bloodPressure);

		public int EditBloodPressure(BloodPressure bloodPressure);

		public int DeleteBloodPressure(BloodPressure bloodPressure);
	}
}
