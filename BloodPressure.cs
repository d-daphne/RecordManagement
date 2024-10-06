/* BloodPressure.cs
 * 
 * A class includes all blood pressure properties
 * 
 * Revision History
 *			Created. Sep 27 2024. Daphne	
 *			Revised. Oct 4 2024. Daphne
 */

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BloodPressureMeasurementApplication.Entities
{
	public class BloodPressure
	{
		[Key]
		public int BPId { get; set; }
		
		[Required(ErrorMessage = "Please enter systolic measurement.")]
		[Range(20, 400, ErrorMessage = "Value should be between 20 and 400.")]
		[DisplayName("Systolic (mm Hg)")]
		public int? Systolic { get; set; }

		[Required(ErrorMessage = "Please enter disatolic measurement.")]
		[Range(10, 300, ErrorMessage = "Value should be between 10 and 300.")]
		[DisplayName("Diastolic (mm Hg)")]
		public int? Diastolic { get; set; }

		[Required]
		[Range(typeof(DateTime), "2021-01-01", "2024-12-31", ErrorMessage = "Date must be from 2021 to end of 2024.")]
		[DisplayName("Date of measurement")]
		public DateTime? Date { get; set; }

		[Required(ErrorMessage = "Please select a position.")]
		[DisplayName("Position")]
		[ForeignKey("PositionId")]
		public int? PositionId { get; set; }

		public Position? Position { get; set; }

		public string Category 
		{
			get
			{
				if (Systolic < 120 && Diastolic < 80)
					return "Normal";
				else if ((Systolic >= 120 && Systolic < 130) && (Diastolic < 80))
					return "Elevated";
				else if ((Systolic >= 130 && Systolic < 140) || (Diastolic >= 80 && Diastolic < 90))
					return "Hypertension Stage 1";
				else if ((Systolic >= 140 && Systolic <= 180) || (Diastolic >= 90 && Diastolic <= 120))
					return "Hypertension Stage 2";
				else
					return "Hypertensive Crisis";
			}
		}

		public string ColorTextClass
		{
			get 
			{
				if (Category == "Normal") return "success";
				else if (Category == "Elevated") return "primary";
				else if (Category == "Hypertensive Crisis") return "danger";
				else if (Category == "Hypertension Stage 1") return "warning";
				else return "info";
			}
		}
	}
}
