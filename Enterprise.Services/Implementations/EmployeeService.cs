﻿using System;
using Enterprise.Entity;
using Enterprise.Persistence;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Enterprise.Services.Implementations
{
	public class EmployeeService : IEmployeeService
	{
        private readonly ApplicationDbContext _context;

		public EmployeeService(ApplicationDbContext context)
		{
			_context = context;
		}

        public async Task CreateAsync(Employee newEmployee)
        {
            await _context.Employees.AddAsync(newEmployee);
            await _context.SaveChangesAsync();
        }

        public Employee GetById(int employeeId) =>
            _context.Employees.Where(e => e.Id == employeeId).FirstOrDefault();

        public async Task Delete(int employeeId)
        {
            var employee = GetById(employeeId);
            _context.Remove(employee);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<Employee> GetAll() =>
             _context.Employees;

        public async Task UpdateAsync(Employee employee)
        {
            _context.Employees.Update(employee);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(int employeeId)
        {
            var employee = GetById(employeeId);
            _context.Update(employeeId);
            await _context.SaveChangesAsync();
        }

        public decimal LoanRepaymentAmount(int id, decimal totalAmount)
        {
            var employee = GetById(id);
            decimal loanPayment = (employee.Loan == Loan.Yes) ? totalAmount * 0.1m : totalAmount;
            return loanPayment;
        }

        public decimal UnionFees(int id)
        {
            var employee = GetById(id);
            decimal unionPayment = (employee.UnionMember == UnionMember.Yes) ? 200 : 0;
            return unionPayment;
        }

        public IEnumerable<SelectListItem> GetAllEmployeesForPayroll()
        {
            return GetAll().Select(emp => new SelectListItem()
            {
                Text = emp.FullName,
                Value = emp.Id.ToString()
            }) ;
        }
    }
}

