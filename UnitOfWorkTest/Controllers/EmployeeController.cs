using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UnitOfWorkTest.Model;

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
		public async Task<IEnumerable<Employee>> Get()
		{
			return await _context.Employees.Include(e => e.Roles).ToListAsync();
		}

		[HttpPost]
		public void Create([FromBody] EmployeeDTO request)
		{
			try
			{
				Employee employee = new Employee(request.Name, request.Department, request.Email);
				_context.Employees.Add(employee);
				_context.SaveChanges();
			}
			catch (DbUpdateException)
			{
				throw;
			}
		}

		[HttpPut]
		public async Task Update()
		{
			try
			{
				Employee employee = await _context.Employees.Include(e => e.Roles).FirstOrDefaultAsync(e => e.Id == "5e2ed534-3a65-4f0a-93ce-4c4137814792");
				employee.Roles.Add(new Role("CEO"));

				await _context.SaveChangesAsync();
			}
			catch (DbUpdateException)
			{
				throw;
			}
		}

		//	[HttpPost]
		//	[Route("v2")]
		//	public async Task CreateV2()
		//	{
		//		var executionStrategy = _context.Database.CreateExecutionStrategy();

		//		await executionStrategy.ExecuteAsync(async () =>
		//		{
		//			using (var transaction = _context.Database.BeginTransaction(IsolationLevel.ReadCommitted))
		//			{
		//				try
		//				{
		//					Employee employee = new Employee
		//					{
		//						//Id = Guid.NewGuid().ToString(),
		//						Id = new Guid("97b526fd-d459-49fd-b7cf-db199caa654e").ToString(),
		//						Name = "Jack v2",
		//						Department = "HR v2",
		//						Email = "Jack@test.com"
		//					};

		//					_context.Employees.Add(employee);
		//					_context.SaveChanges();
		//				}
		//				catch (DbUpdateException)
		//				{
		//					Console.WriteLine("Caught");
		//					throw;
		//				}

		//				Department department = new Department
		//				{
		//					Id = Guid.NewGuid().ToString(),
		//					Name = "Human Resource v2",
		//					Size = 200
		//				};

		//				_context.Departments.Add(department);
		//				_context.SaveChanges();

		//				await transaction.CommitAsync();
		//			}
		//		});

		//		Console.WriteLine("Post v2");
		//	}
	}
}

// ALTER TABLE "Departments" RENAME TO "Department";
// ALTER TABLE "Employees" RENAME TO "Employee";

// ALTER TABLE "Department" RENAME TO "Departments";
// ALTER TABLE "Employee" RENAME TO "Employees";