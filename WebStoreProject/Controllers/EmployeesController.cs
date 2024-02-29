using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using WebStoreProject.Data;
using WebStoreProject.Models;
using WebStoreProject.Services.Interfaces;
using WebStoreProject.ViewModels;

namespace WebStoreProject.Controllers
{
	public class EmployeesController : Controller
	{
		//private ICollection<Employees> _employees;
		private readonly IEmployeesData _EmployeesData;

		public EmployeesController(IEmployeesData EmployeesData)
		{
			//_employees = TestData.Employees;
			_EmployeesData = EmployeesData;
		}

		public IActionResult Index()
		{
			var result = _EmployeesData.GetAll();
			return View(result);
		}

		public IActionResult Details(int id)
		{
			//var employee = _employees.FirstOrDefault(x => x.Id == index);
			var employee = _EmployeesData.GetById(id);
			ViewData["Employee"] = employee;
			if (employee is null)
			{
				return NotFound();
			}
			return View(employee);
		}

		public IActionResult Add()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Add(EmployeeEditViewModel Model)
		{
			var employee = new Employees
			{
				Id = Model.Id,
				FirstName = Model.FirstName,
				LastName = Model.LastName,
				Patronymic = Model.Patronymic,
				Age = Model.Age,
				Experience = Model.Experience,
				Birthday = Model.Birthday,
			};

			_EmployeesData.Add(employee);
			return RedirectToAction("Index");
		}
		public IActionResult Edit(int id)
		{
			var employee = _EmployeesData.GetById(id);
			if (employee is null)
				return NotFound();

			var model = new EmployeeEditViewModel
			{
				Id = employee.Id,
				FirstName = employee.FirstName,
				LastName = employee.LastName,
				Age = employee.Age,
				Patronymic = employee.Patronymic,
                Experience = employee.Experience,
				Birthday = employee.Birthday,
            };

			return View(model);
		}

		[HttpPost]
        public IActionResult Edit(EmployeeEditViewModel Model)
		{
			var employee = new Employees
			{
				Id = Model.Id,
				FirstName = Model.FirstName,
				LastName = Model.LastName,
				Patronymic = Model.Patronymic,
				Age = Model.Age,
				Experience = Model.Experience,
                Birthday = Model.Birthday,
            };
			 
			if(!_EmployeesData.Edit(employee)) return NotFound(); 

			return RedirectToAction("Index");
		}

        public IActionResult Delete(int id)
        {
            if (id < 0) return BadRequest();

			var employee = _EmployeesData.GetById(id);
			if (employee == null) return NotFound();

            var model = new EmployeeEditViewModel
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Age = employee.Age,
                Patronymic = employee.Patronymic,
                Experience = employee.Experience,
                Birthday = employee.Birthday,
            };

            return View(model);
        }

		[HttpPost]
        public IActionResult DeleteConfirmed(int id)
		{
			if (!_EmployeesData.Delete(id)) return NotFound();

			return RedirectToAction("Index");
		}

       // public void Throw(string Message) => throw new ApplicationException(Message);

	}
}
