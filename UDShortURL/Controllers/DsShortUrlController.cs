using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UDShortURL.Models;

namespace UDShortURL.Controllers
{
    public class DsShortUrlController : Controller
    {
        private readonly DsShortUrlContext _context;

        public DsShortUrlController(DsShortUrlContext context)
        {
            _context = context;
        }

        // GET: DsShortUrl
        public async Task<IActionResult> Index1()
        {
            return View(await _context.ShortUrls.ToListAsync());
        }

        // GET: DsShortUrl/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dsShortUrl = await _context.ShortUrls
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dsShortUrl == null)
            {
                return NotFound();
            }

            return View(dsShortUrl);
        }

       
        

        // GET: DsShortUrl/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dsShortUrl = await _context.ShortUrls
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dsShortUrl == null)
            {
                return NotFound();
            }

            return View(dsShortUrl);
        }

        // POST: DsShortUrl/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dsShortUrl = await _context.ShortUrls.FindAsync(id);
            if (dsShortUrl != null)
            {
                _context.ShortUrls.Remove(dsShortUrl);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index1));
        }

        private bool DsShortUrlExists(int id)
        {
            return _context.ShortUrls.Any(e => e.Id == id);
        }
    }
}
