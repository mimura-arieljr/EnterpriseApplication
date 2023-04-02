using System;
using Enterprise.Entity;

namespace Enterprise.Services
{
	public interface IEmployeeService
	{
		Task CreateAsync(Employee newEmployee); // Creates new employee
		Employee GetById(int employeeId); // Get employee using unique ID
		Task Delete(int employeeId); // Deletes and employess using unique ID
		Task UpdateAsync(Employee employee); // Updates employee
		Task UpdateAsync(int employeeId); // Updates employee by unique ID
		decimal UnionFees(int employeeId);
		decimal LoanRepaymentAmount(int id, decimal totalAmount);
		IEnumerable<Employee> GetAll();
	}
}

