using System;
using Enterprise.Services;
using Microsoft.AspNetCore.Mvc;

namespace EnterpriseSolution.Controllers
{
	public class PayController : Controller
	{
		private readonly IPayComputationService _payComputationService;

		public PayController(IPayComputationService payComputationService)
		{
			_payComputationService = payComputationService;
		}

		public IActionResult Index()
		{

		}
	}
}

