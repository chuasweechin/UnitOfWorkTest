using System;
using System.Collections.Generic;
using UnitOfWorkTest.Model;

namespace UnitOfWorkTest
{
	public class Employee
	{
		public string Id { get; set; }
		public string Name { get; set; }
		public string Department { get; set; }
		public string Email { get; set; }
		public List<Role> Roles { get; set; }

		protected Employee() {}

		public Employee(string name, string department, string email)
		{
			Id = Guid.NewGuid().ToString();
			//string id = "97b526fd-d459-49fd-b7cf-db199caa654e";

			Name = name;
			Department = department;
			Email = email + DateTime.Now.ToString();
			//Roles = new List<Role>();
			//Roles = new List<Role>
			//{
			//	new Role("Apple")
			//};
		}
	}
}