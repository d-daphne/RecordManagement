/* BloodPressureController.cs
 * 
 * A controller controls the logic of the application 
 * 
 * Revision History
 *			Created. Sep 27 2024. Daphne	
 *			Revised. Oct 4 2024. Daphne
 */

using BloodPressureMeasurementApplication.Entities;
using BloodPressureMeasurementApplication.Models;
using BloodPressureMeasurementApplication.Services;
using Microsoft.AspNetCore.Mvc;

namespace BloodPressureMeasurementApplication.Controllers
{
	public class BloodPressureController : Controller
	{
		private readonly IBloodPressureMeasurementService _service;

		public BloodPressureController(IBloodPressureMeasurementService service)
		{
			_service = service;
		}

		[HttpGet("/information")]
		public IActionResult ShowInfo()
		{
			return View("BpInformation");
		}

		[HttpGet("/all")]
		public IActionResult AllBloodPressures()
		{
			var viewModel = new AllBloodPressuresViewModel()
			{
				BpList = _service.GetBloodPressures()
			};


			return View("All", viewModel);
		}

		[HttpGet("/add")]
		public IActionResult AddBloodPressure()
		{
			var viewModel = new AddBloodPressureViewModel()
			{
				NewBloodPressure = new BloodPressure(),
				Positions = _service.GetPositions()
			};

			return View("Add", viewModel);
		}

		[HttpPost("/add")]
		public IActionResult AddBloodPressure(AddBloodPressureViewModel viewModel)
		{
			if (ModelState.IsValid)
			{
				_service.AddBloodPressure(viewModel.NewBloodPressure);
				TempData["message"] = $"New record {viewModel.NewBloodPressure.Systolic}/{viewModel.NewBloodPressure.Diastolic} has been added.";
				TempData["className"] = "success";
				return RedirectToAction("AllBloodPressures");
			}
			else
			{
				viewModel.Positions = _service.GetPositions();
				return View("Add", viewModel);
			}
		}

		[HttpGet("/edit/{id}")]
		public IActionResult EditBloodPressure(int? id)
		{
			var viewModel = new EditBloodPressureViewModel()
			{
				CurrentBloodPressure = _service.FindBloodPressureById(id),
				Positions = _service.GetPositions()
			};

			return View("Edit", viewModel);
		}

		[HttpPost("/edit/{id}")]
		public IActionResult EditBloodPressure(EditBloodPressureViewModel viewModel)
		{
			if (ModelState.IsValid)
			{
				_service.EditBloodPressure(viewModel.CurrentBloodPressure);
				TempData["message"] = $"{viewModel.CurrentBloodPressure.Systolic}/{viewModel.CurrentBloodPressure.Diastolic} has been updated.";
				TempData["className"] = "info";
				return RedirectToAction("AllBloodPressures");
			}
			else
			{
				viewModel.Positions = _service.GetPositions();
				return View("Edit", viewModel);
			}
		}

		[HttpGet("/delete/{id}")]
		public IActionResult DeleteBloodPressure(int? id)
		{
			var viewModel = new DeleteBloodPressureViewModel()
			{
				CurrentBloodPressure = _service.FindBloodPressureById(id),
			};

			return View("Delete", viewModel);
		}

		[HttpPost("/delete/{id}")]
		public IActionResult DeleteBloodPressure(DeleteBloodPressureViewModel viewModel)
		{
				_service.DeleteBloodPressure(viewModel.CurrentBloodPressure);
				TempData["message"] = $"{viewModel.CurrentBloodPressure.Systolic}/{viewModel.CurrentBloodPressure.Diastolic} has been deleted.";
				TempData["className"] = "warning";

				return RedirectToAction("AllBloodPressures");
		}
	}
}
