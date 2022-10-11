using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Northwind.Domain.Base;
using Northwind.Domain.Models;
using Northwind.Persistence;

namespace Northwind.Web.Controllers
{
    public class CustomersRepoController : Controller
    {
        //private readonly NorthwindContext _context;
        private readonly IRepositoryManager _context;

        public CustomersRepoController(IRepositoryManager context)
        {
            _context = context;
        }

        // GET: CustomersRepo
        public async Task<IActionResult> Index()
        {
            return View(await _context.EmployeeRepository.GetAllCategory(false));
        }

        // GET: CustomersRepo/Details/5
        public async Task<IActionResult> Details(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            /*var customer = await _context.Customers
                .FirstOrDefaultAsync(m => m.CustomerId == id);*/
            var customer = await _context.EmployeeRepository.GetCategoryById((string)id, false);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // GET: CustomersRepo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CustomersRepo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CustomerId,CompanyName,ContactName,ContactTitle,Address,City,Region,PostalCode,Country,Phone,Fax")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                /*_context.Add(customer);
                await _context.SaveChangesAsync();*/
                _context.EmployeeRepository.Insert(customer);
                await _context.SaveAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        // GET: CustomersRepo/Edit/5
        public async Task<IActionResult> Edit(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var customer = await _context.Customers.FindAsync(id);
            var customer = await _context.EmployeeRepository.GetCategoryById((string)id, true);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        // POST: CustomersRepo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("CustomerId,CompanyName,ContactName,ContactTitle,Address,City,Region,PostalCode,Country,Phone,Fax")] Customer customer)
        {
            if (id != customer.CustomerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    /*_context.Update(customer);
                    await _context.SaveChangesAsync();*/
                    _context.EmployeeRepository.Edit(customer);
                    await _context.SaveAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    /*if (!CustomerExists(customer.CustomerId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }*/
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        // GET: CustomersRepo/Delete/5
        public async Task<IActionResult> Delete(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            /*var customer = await _context.Customers
                .FirstOrDefaultAsync(m => m.CustomerId == id);*/
            var customer = await _context.EmployeeRepository.GetCategoryById((string)id, false);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // POST: CustomersRepo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string? id)
        {
            /*var customer = await _context.Customers.FindAsync(id);
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();*/
            var customer = await _context.EmployeeRepository.GetCategoryById((string)id, false);
            _context.EmployeeRepository.Remove(customer);
            await _context.SaveAsync();
            return RedirectToAction(nameof(Index));
        }

/*        private bool CustomerExists(string id)
        {
            return _context.Customers.Any(e => e.CustomerId == id);
        }*/
    }
}
