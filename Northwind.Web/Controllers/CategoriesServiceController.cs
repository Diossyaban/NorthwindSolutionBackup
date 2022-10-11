using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Northwind.Contracts.Dto.Category;
using Northwind.Domain.Models;
using Northwind.Persistence;
using Northwind.Services.Abstraction;

namespace Northwind.Web.Controllers
{
    public class CategoriesServiceController : Controller
    {
        //private readonly NorthwindContext _context;
        private readonly IServiceManager _serviceContext;

        public CategoriesServiceController(IServiceManager serviceContext)
        {
            //_context = context;
            _serviceContext = serviceContext;
        }

        // GET: CategoriesService
        public async Task<IActionResult> Index()
        {
            //var categories = await _context.Categories.ToListAsync();
            var categoriesDto = await _serviceContext.CategoryService.GetAllCategory(false);
            return View(categoriesDto);
            //return View(await _context.Categories.ToListAsync());
        }

        // GET: CategoriesService/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            /*var category = await _context.Categories
                .FirstOrDefaultAsync(m => m.CategoryId == id);*/
            var category = await _serviceContext.CategoryService.GetCategoryById((int)id, false);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // GET: CategoriesService/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CategoriesService/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CategoryId,CategoryName,Description,Picture")] CategoryForCreateDto category)
        {
            if (ModelState.IsValid)
            {
                /*_context.Add(category);
                await _context.SaveChangesAsync();*/
                _serviceContext.CategoryService.Insert(category);
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        // GET: CategoriesService/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            /*var category = await _context.Categories.FindAsync(id);*/
            var category = await _serviceContext.CategoryService.GetCategoryById((int)id, true);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // POST: CategoriesService/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CategoryId,CategoryName,Description,Picture")] CategoryDto category)
        {
            if (id != category.CategoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    /*_context.Update(category);
                    await _context.SaveChangesAsync();*/
                    _serviceContext.CategoryService.Edit(category);
                }
                catch (DbUpdateConcurrencyException)
                {
                    /*if (!CategoryExists(category.CategoryId))
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
            return View(category);
        }

        // GET: CategoriesService/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            /*var category = await _context.Categories
                .FirstOrDefaultAsync(m => m.CategoryId == id);*/
            var category = await _serviceContext.CategoryService.GetCategoryById((int)id, false);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // POST: CategoriesService/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            /*var category = await _context.Categories.FindAsync(id);
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();*/
            var category = await _serviceContext.CategoryService.GetCategoryById((int)id, false);
            _serviceContext.CategoryService.Remove(category);
            return RedirectToAction(nameof(Index));
        }

        /*private bool CategoryExists(int id)
        {
            return _context.Categories.Any(e => e.CategoryId == id);
        }*/
    }
}
