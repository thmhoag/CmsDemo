using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CmsDemo.Data.Contexts;
using CmsDemo.Data.Entities;
using CmsDemo.Data.Repositories;

namespace CmsDemo.Web.Controllers
{
	public class CustomersController : Controller
	{
		private readonly IRepository<Customer> _repo;
		public CustomersController(IRepository<Customer> repository)
		{
			_repo = repository;
		}

		public async Task<ActionResult> Index()
		{
			var customerList = await _repo.Table.ToListAsync();
			return View(customerList);
		}

		public async Task<ActionResult> Details(int? id)
		{
			if (id == null)
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

			var customer = await _repo.FindByIdAsync(id.Value);
			if (customer == null)
				return HttpNotFound();

			return View(customer);
		}

		public ActionResult Create()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Create(Customer customer)
		{
			if (!ModelState.IsValid)
				return View(customer);

			await _repo.InsertAsync(customer);
			return RedirectToAction("Index");
		}

		public async Task<ActionResult> Edit(int? id)
		{
			if (id == null)
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

			var customer = await _repo.FindByIdAsync(id.Value);
			if (customer == null)
				return HttpNotFound();

			return View(customer);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Edit(Customer customer)
		{
			if (!ModelState.IsValid)
				return View(customer);

			await _repo.UpdateAsync(customer);
			return RedirectToAction("Index");
		}

		public async Task<ActionResult> Delete(int? id)
		{
			if (id == null)
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

			var customer = await _repo.FindByIdAsync(id.Value);
			if (customer == null)
				return HttpNotFound();

			return View(customer);
		}

		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> DeleteConfirmed(int id)
		{
			var customer = await _repo.FindByIdAsync(id);
			await _repo.DeleteAsync(customer);

			return RedirectToAction("Index");
		}
	}
}
