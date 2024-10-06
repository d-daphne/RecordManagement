/* AddBloodPressureMeasurementApplication.Models.cs
 * 
 * A view model used to add new record of blood pressure 
 * 
 * Revision History
 *			Created. Sep 27 2024. Daphne	
 *			Revised. Oct 4 2024. Daphne
 */

using BloodPressureMeasurementApplication.Entities;
using System.ComponentModel.DataAnnotations;

namespace BloodPressureMeasurementApplication.Models
{
	public class AddBloodPressureViewModel
	{
		public BloodPressure NewBloodPressure { get; set; }

		public List<Position>? Positions { get; set; }
	}
}
