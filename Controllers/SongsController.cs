using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ModernSoftwareDevelopmentAssignment5.Data;
using ModernSoftwareDevelopmentAssignment5.Models;
using NuGet.Protocol.Plugins;

namespace ModernSoftwareDevelopmentAssignment5.Controllers
{
    public class SongsController : Controller
    {
        private readonly ModernSoftwareDevelopmentAssignment5Context _context;

        public SongsController(ModernSoftwareDevelopmentAssignment5Context context)
        {
            _context = context;
        }

        Order myOrder = new Order();

        // GET: Songs
        public async Task<IActionResult> Index(string SongArtist)
        {
            //return _context.Song != null ? 
            //View(await _context.Song.ToListAsync()) :
            //Problem("Entity set 'ModernSoftwareDevelopmentAssignment5Context.Song'  is null.");

            //var showAll = from m in _context.Song
            //              select m;

            //if (!String.IsNullOrEmpty(SearchartistID))
            //{
            //    int id = Convert.ToInt32(SearchartistID);
            //    showAll = showAll.Where(s => s.artistID == (id));
            //}


            //return View(await showAll.ToListAsync());

            if (_context.Song == null) {
                return Problem("Entity set 'ModernSoftwareDevelopmentAssignment5.Song'  is null.");
            }
            //Use LINQ to get a list of Artists
           // IQueryable<int> artistQuery = from m in _context.Song
            //                                 orderby m.artistID
             //                                select m.artistID;
            IQueryable<Artist> artistQuery = from m in _context.Artist
                                            orderby m.Id
                                            select m;
            var songs = from m in _context.Song
                        select m;
            
            
            if (!string.IsNullOrEmpty(SongArtist))
            {
                IQueryable<int> artistID=from m in _context.Artist
                                         where m.Name == SongArtist
                                         select m.Id;
                int id=artistID.FirstOrDefault();
                songs = songs.Where(s => s.artistID == (id));
            }

            var songArtistVM = new SongArtistModel
            {
                Artists=new SelectList(await artistQuery.Distinct().ToListAsync()),
                Songs= await songs.ToListAsync()
            };
            Console.WriteLine("Behold:");
            Console.WriteLine(SongArtist);
            return View(songArtistVM);
        }

        // GET: Songs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Song == null)
            {
                return NotFound();
            }

            var song = await _context.Song
                .FirstOrDefaultAsync(m => m.ID == id);
            if (song == null)
            {
                return NotFound();
            }

            return View(song);
        }

        // GET: Songs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Songs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,artistID,price")] Song song)
        {
            if (ModelState.IsValid)
            {
                _context.Add(song);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(song);
        }

        // GET: Songs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Song == null)
            {
                return NotFound();
            }

            var song = await _context.Song.FindAsync(id);
            if (song == null)
            {
                return NotFound();
            }
            return View(song);
        }

        // POST: Songs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,artistID,price")] Song song)
        {
            if (id != song.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(song);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SongExists(song.ID))
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
            return View(song);
        }

        // GET: Songs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Song == null)
            {
                return NotFound();
            }

            var song = await _context.Song
                .FirstOrDefaultAsync(m => m.ID == id);
            if (song == null)
            {
                return NotFound();
            }

            return View(song);
        }

        // POST: Songs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Song == null)
            {
                return Problem("Entity set 'ModernSoftwareDevelopmentAssignment5Context.Song'  is null.");
            }
            var song = await _context.Song.FindAsync(id);
            if (song != null)
            {
                _context.Song.Remove(song);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SongExists(int id)
        {
          return (_context.Song?.Any(e => e.ID == id)).GetValueOrDefault();
        }

        //Add song to order
        [HttpPost]
        public void AddToCart(Song song)
        {
            myOrder.addItem(song.ID, 1, song.price);

        }

        //Get order price
        [HttpPost]
        public decimal GetPrice(Song song)
        {
            return myOrder.getTotalPrice();

        }

        //Clear order
        [HttpPost]
        public void ClearOrder(Song song)
        {
            myOrder.deleteAll();

        }

        
    }
}
