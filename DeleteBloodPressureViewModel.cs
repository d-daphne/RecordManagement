/* AddBloodPressureMeasurementApplication.Models.cs
 * 
 * A view model used to delete new record of blood pressure 
 * 
 * Revision History
 *			Created. Sep 27 2024. Daphne	
 *			Revised. Oct 4 2024. Daphne
 */

using BloodPressureMeasurementApplication.Entities;

namespace BloodPressureMeasurementApplication.Models
{
	public class DeleteBloodPressureViewModel
	{
		public BloodPressure CurrentBloodPressure { get; set; }

		public List<Position>? Positions { get; set; }
	}
}
