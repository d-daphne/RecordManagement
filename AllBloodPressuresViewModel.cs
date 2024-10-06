/* AllBloodPressureMeasurementApplication.Models.cs
 * 
 * A view model used to display all records of blood pressure 
 * 
 * Revision History
 *			Created. Sep 27 2024. Daphne	
 *			Revised. Oct 4 2024. Daphne
 */

using BloodPressureMeasurementApplication.Entities;

namespace BloodPressureMeasurementApplication.Models
{
	public class AllBloodPressuresViewModel
	{
		public List<BloodPressure> BpList {  get; set; }
	}
}
