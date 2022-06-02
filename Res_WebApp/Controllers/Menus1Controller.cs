using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Res_WebApp.Data;
using Res_WebApp.Models;

namespace Res_WebApp.Controllers
{
    public class Menus1Controller : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _hostEnvirooment;

        public Menus1Controller(ApplicationDbContext context, IWebHostEnvironment hostEnvirooment)
        {
            _context = context;
            this._hostEnvirooment = hostEnvirooment;
        }

        // GET: Menus1
        public async Task<IActionResult> Index()
        {
              return _context.Menu != null ? 
                          View(await _context.Menu.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Menu'  is null.");
        }
        public IActionResult Starters()
        {
            return _context.Menu != null ?
                         View(_context.Menu.Where(o => o.FoodType == "Starter").ToList()):
                         Problem("Entity set 'ApplicationDbContext.Menu'  is null.");
            
        }
        public IActionResult Mains()
        {
            return _context.Menu != null ?
                         View(_context.Menu.Where(o => o.FoodType == "Mains").ToList()) :
                         Problem("Entity set 'ApplicationDbContext.Menu'  is null.");
        }

        public IActionResult Drinks()
        {
            return _context.Menu != null ?
                         View(_context.Menu.Where(o => o.FoodType == "Drink").ToList()) :
                         Problem("Entity set 'ApplicationDbContext.Menu'  is null.");
        }
        public IActionResult Deserts()
        {
            return _context.Menu != null ?
                        View(_context.Menu.Where(o => o.FoodType == "Deserts").ToList()) :
                        Problem("Entity set 'ApplicationDbContext.Menu'  is null.");
        }

        // GET: Menus1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Menu == null)
            {
                return NotFound();
            }

            var menu = await _context.Menu
                .FirstOrDefaultAsync(m => m.MenuId == id);
            if (menu == null)
            {
                return NotFound();
            }

            return View(menu);
        }

        // GET: Menus1/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Menus1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MenuId,ImageFile,Name,Description,FoodType,Price")] Menu menu)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _hostEnvirooment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(menu.ImageFile.FileName);
                string extention = Path.GetExtension(menu.ImageFile.FileName);
                menu.ImgFood = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extention;
                string path = Path.Combine(wwwRootPath + "/Image/", fileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await menu.ImageFile.CopyToAsync(fileStream);
                }

                _context.Add(menu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(menu);
        }

        // GET: Menus1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Menu == null)
            {
                return NotFound();
            }

            var menu = await _context.Menu.FindAsync(id);
            if (menu == null)
            {
                return NotFound();
            }
            return View(menu);
        }

        // POST: Menus1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MenuId,ImgFood,Name,Description,FoodType,Price")] Menu menu)
        {
            if (id != menu.MenuId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(menu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MenuExists(menu.MenuId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(menu);
        }

        // GET: Menus1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Menu == null)
            {
                return NotFound();
            }

            var menu = await _context.Menu
                .FirstOrDefaultAsync(m => m.MenuId == id);
            if (menu == null)
            {
                return NotFound();
            }

            return View(menu);
        }

        // POST: Menus1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Menu == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Menu'  is null.");
            }
            var menu = await _context.Menu.FindAsync(id);
            if (menu != null)
            {
                _context.Menu.Remove(menu);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MenuExists(int id)
        {
          return (_context.Menu?.Any(e => e.MenuId == id)).GetValueOrDefault();
        }
    }
}
