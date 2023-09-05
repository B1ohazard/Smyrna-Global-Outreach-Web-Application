using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Smyrna_Prototype.Models;
using Smyrna_Prototype.ViewModels;

namespace Smyrna_Prototype.Controllers
{
    public class ProducesController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IProductRepository productRepository;

        public ProducesController(AppDbContext context, IWebHostEnvironment webHostEnvironment, IProductRepository productRepository)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
            this.productRepository = productRepository;
        }

        // GET: Produces
        public async Task<IActionResult> Index()
        {
              return _context.Products != null ? 
                          View(await _context.Products.ToListAsync()) :
                          Problem("Entity set 'AppDbContext.Products'  is null.");
        }

        // GET: Produces/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var produce = await _context.Products
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (produce == null)
            {
                return NotFound();
            }

            return View(produce);
        }

        //[Authorize(Roles = "Administrator")]
        // GET: Produces/Create
        public IActionResult Create()
        {
            return View();
        }

    // POST: Produces/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductId,ProductName,ProductDescription,ProductQuantity,Title,ImageFile,Date")] Produce produce)
        {
            if (ModelState.IsValid)
            {
                //Save image to wwwroot/image
                produce.Title = produce.ProductName;
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(produce.ImageFile.FileName);
                string extension = Path.GetExtension(produce.ImageFile.FileName);
                produce.ImageName = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                string path = Path.Combine(wwwRootPath + "/Image/", fileName);
                using (var fileStream = new FileStream(path, FileMode.Create))

                {
                    await produce.ImageFile.CopyToAsync(fileStream);
                }

                _context.Add(produce);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(produce);
        }

        // GET: Produces/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var produce = await _context.Products.FindAsync(id);
            if (produce == null)
            {
                return NotFound();
            }
            return View(produce);
        }

        // POST: Produces/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductId,ProductName,ProductDescription,ProductQuantity,Title,ImageName,Date")] Produce produce)
        {
            if (id != produce.ProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(produce);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProduceExists(produce.ProductId))
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
            return View(produce);
        }

        // GET: Produces/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var produce = await _context.Products
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (produce == null)
            {
                return NotFound();
            }

            return View(produce);
        }

        // POST: Produces/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var imageModel = await _context.Products.FindAsync(id);

            //delete image from wwwroot/image
            var imagePath = Path.Combine(_webHostEnvironment.WebRootPath, "image", imageModel.ImageName);
            if (System.IO.File.Exists(imagePath))
                System.IO.File.Delete(imagePath);

            //delete the record in the db
            _context.Products.Remove(imageModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult List(string SearchProductTypeString)
        {
            var productListViewModel = new SearchProduceListViewModel();
            productListViewModel.Products = productRepository.GetAllProducts;

            var searchProduceListViewModel = new SearchProduceListViewModel();
            searchProduceListViewModel.Products = productRepository.GetAllProducts.Where(s => s.ProductName == SearchProductTypeString);

            if ((SearchProductTypeString == null))
            {
                return View(productListViewModel);
            }
            else if ((SearchProductTypeString != null))
            {
                return View(searchProduceListViewModel);
            }
            else
            {
                return View(productListViewModel);
            }
        }

        private bool ProduceExists(int id)
        {
          return (_context.Products?.Any(e => e.ProductId == id)).GetValueOrDefault();
        }
    }
}
