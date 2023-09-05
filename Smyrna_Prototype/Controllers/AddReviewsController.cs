using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Smyrna_Prototype.Models;
using Smyrna_Prototype.ViewModels;

namespace Smyrna_Prototype.Controllers
{
    public class AddReviewsController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IAddReviewRepository reviewRepository;

        public AddReviewsController(AppDbContext context, IAddReviewRepository reviewRepository)
        {
            _context = context;
            this.reviewRepository = reviewRepository;
        }

        // GET: AddReviews
        public async Task<IActionResult> Index()
        {
              return _context.AddReviews != null ? 
                          View(await _context.AddReviews.ToListAsync()) :
                          Problem("Entity set 'AppDbContext.AddReview'  is null.");
        }

        // GET: AddReviews/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.AddReviews == null)
            {
                return NotFound();
            }

            var addReview = await _context.AddReviews
                .FirstOrDefaultAsync(m => m.AddReviewId == id);
            if (addReview == null)
            {
                return NotFound();
            }

            return View(addReview);
        }

        // GET: AddReviews/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AddReviewsss/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AddReviewId,CustomerName,CustomerReview,Date")] AddReview addReview)
        {
            if (ModelState.IsValid)
            {
                _context.Add(addReview);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(addReview);
        }

        // GET: AddReviews/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.AddReviews == null)
            {
                return NotFound();
            }

            var addReview = await _context.AddReviews.FindAsync(id);
            if (addReview == null)
            {
                return NotFound();
            }
            return View(addReview);
        }

        // POST: AddReviews/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AddReviewId,CustomerName,CustomerReview,Date")] AddReview addReview)
        {
            if (id != addReview.AddReviewId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(addReview);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AddReviewExists(addReview.AddReviewId))
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
            return View(addReview);
        }

        // GET: AddReviews/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.AddReviews == null)
            {
                return NotFound();
            }

            var addReview = await _context.AddReviews
                .FirstOrDefaultAsync(m => m.AddReviewId == id);
            if (addReview == null)
            {
                return NotFound();
            }

            return View(addReview);
        }

        // POST: AddReviews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.AddReviews == null)
            {
                return Problem("Entity set 'AppDbContext.AddReview'  is null.");
            }
            var addReview = await _context.AddReviews.FindAsync(id);
            if (addReview != null)
            {
                _context.AddReviews.Remove(addReview);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AddReviewExists(int id)
        {
          return (_context.AddReviews?.Any(e => e.AddReviewId == id)).GetValueOrDefault();
        }
    }
}
