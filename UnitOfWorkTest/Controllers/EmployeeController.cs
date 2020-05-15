using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace UnitOfWorkTest.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class EmployeeController : ControllerBase
	{
		private readonly AppDbContext _context;

		public EmployeeController(AppDbContext context)
		{
			_context = context;
		}

		[HttpGet]
		public IEnumerable<Employee> Get()
		{
			Console.WriteLine("Get");
			return null;
		}

		[HttpPost]
		public void Create()
		{
			Employee employee = new Employee
			{
				Id = Guid.NewGuid().ToString(),
				Name = "Jack",
				Department = "HR",
				Email = "Jack@test.com"
			};

			_context.Employees.Add(employee);

			Department department = new Department
			{
				Id = Guid.NewGuid().ToString(),
				Name = "Human Resource",
				Size = 100
			};

			_context.Departments.Add(department);
			_context.SaveChanges();

			Console.WriteLine("Post");
		}
	}
}