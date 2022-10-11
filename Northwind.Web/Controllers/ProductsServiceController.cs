using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Northwind.Contracts.Dto.Product;
using Northwind.Domain.Models;
using Northwind.Persistence;
using Northwind.Services.Abstraction;
using X.PagedList;

namespace Northwind.Web.Controllers
{
    public class ProductsServiceController : Controller
    {
        private readonly IServiceManager _context;

        public ProductsServiceController(IServiceManager context)
        {
            _context = context;
        }

        // GET: ProductsService
        public async Task<IActionResult> Index(string searchString, string currentFilter, int? page)
        {
            var pageNumber = page ?? 1;
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewBag.CurrentFilter = searchString;

            var product = await _context.ProductService.GetAllProduct(false);
            if (!String.IsNullOrEmpty(searchString))
            {
                product = product.Where(p => p.ProductName.ToLower().Contains(searchString.ToLower()) ||
                p.Supplier.CompanyName.ToLower().Contains(searchString.ToLower()));
            }
            return View(product.ToPagedList(pageNumber, 10));
        }

        // GET: ProductsService/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var product = await _context.ProductService.GetProductById((int)id, false);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: ProductsService/Create
        public async Task<IActionResult> Create()
        {
            var allCategory = await _context.CategoryService.GetAllCategory(false);
            var allSupplier = await _context.SupplierService.GetAllSupplier(false);
            ViewData["CategoryId"] = new SelectList(allCategory, "CategoryId", "CategoryName");
            ViewData["SupplierId"] = new SelectList(allSupplier, "SupplierId", "CompanyName");
            return View();
        }

        // POST: ProductsService/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductName,SupplierId,CategoryId,QuantityPerUnit,UnitPrice,UnitsInStock,UnitsOnOrder,ReorderLevel,Discontinued")] ProductForCreateDto product)
        {
            if (ModelState.IsValid)
            {
                _context.ProductService.Insert(product);
                return RedirectToAction(nameof(Index));
            }
            var allCategory = await _context.CategoryService.GetAllCategory(false);
            var allSupplier = await _context.SupplierService.GetAllSupplier(false);
            ViewData["CategoryId"] = new SelectList(allCategory, "CategoryId", "CategoryName", product.CategoryId);
            ViewData["SupplierId"] = new SelectList(allSupplier, "SupplierId", "CompanyName", product.SupplierId);
            return View(product);
        }

        // GET: ProductsService/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var product = await _context.ProductService.GetProductById((int)id, true);
            if (product == null)
            {
                return NotFound();
            }
            var allCategory = await _context.CategoryService.GetAllCategory(false);
            var allSupplier = await _context.SupplierService.GetAllSupplier(false);
            ViewData["CategoryId"] = new SelectList(allCategory, "CategoryId", "CategoryName", product.CategoryId);
            ViewData["SupplierId"] = new SelectList(allSupplier, "SupplierId", "CompanyName", product.SupplierId);
            return View(product);
        }

        // POST: ProductsService/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductId,ProductName,SupplierId,CategoryId,QuantityPerUnit,UnitPrice,UnitsInStock,UnitsOnOrder,ReorderLevel,Discontinued")] ProductDto product)
        {
            if (id != product.ProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.ProductService.Edit(product);
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            var allCategory = await _context.CategoryService.GetAllCategory(false);
            var allSupplier = await _context.SupplierService.GetAllSupplier(false);
            ViewData["CategoryId"] = new SelectList(allCategory, "CategoryId", "CategoryName", product.CategoryId);
            ViewData["SupplierId"] = new SelectList(allSupplier, "SupplierId", "CompanyName", product.SupplierId);
            return View(product);
        }

        // GET: ProductsService/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var product = await _context.ProductService.GetProductById((int)id, false);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: ProductsService/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.ProductService.GetProductById((int)id, false);
            _context.ProductService.Remove(product);
            return RedirectToAction(nameof(Index));
        }
    }
}
