﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HelloWorldsController : Controller
    {
        private readonly WebApplication1Context _context;

        public HelloWorldsController(WebApplication1Context context)
        {
            _context = context;
        }

        // GET: HelloWorlds
        public async Task<IActionResult> Index(string movieGenre, string searchString)
        {
            //    if (_context.HelloWorld == null)
            //    {
            //        return Problem("Entity set 'MvcMovieContext.Movie'  is null.");
            //    }
            //
            //    var movies = from m in _context.HelloWorld
            //                 select m;
            //
            //    if (!String.IsNullOrEmpty(searchString))
            //    {
            //        movies = movies.Where(s => s.Title!.Contains(searchString));
            //    }
            //
            //    return View(await movies.ToListAsync());
            //    //return View(await _context.HelloWorld.ToListAsync());
            if (_context.HelloWorld == null)
            {
                return Problem("Entity set 'MvcMovieContext.Movie'  is null.");
            }

            // Use LINQ to get list of genres.
            IQueryable<string> genreQuery = from m in _context.HelloWorld
                                            orderby m.Genre
                                            select m.Genre;
            var helloWorlds = from m in _context.HelloWorld
                         select m;

            if (!string.IsNullOrEmpty(searchString))
            {
                helloWorlds = helloWorlds.Where(s => s.Title!.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(movieGenre))
            {
                helloWorlds = helloWorlds.Where(x => x.Genre == movieGenre);
            }

            var movieGenreVM = new HelloWorldGenreViewModel
            {
                Genres = new SelectList(await genreQuery.Distinct().ToListAsync()),
                HelloWorlds = await helloWorlds.ToListAsync()
            };

            return View(movieGenreVM);

        }


        // GET: HelloWorlds/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var helloWorld = await _context.HelloWorld
                .FirstOrDefaultAsync(m => m.Id == id);
            if (helloWorld == null)
            {
                return NotFound();
            }

            return View(helloWorld);
        }

        // GET: HelloWorlds/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HelloWorlds/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,ReleaseDate,Genre,Price,Rating")] HelloWorld helloWorld)
        {
            if (ModelState.IsValid)
            {
                _context.Add(helloWorld);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(helloWorld);
        }

        // GET: HelloWorlds/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var helloWorld = await _context.HelloWorld.FindAsync(id);
            if (helloWorld == null)
            {
                return NotFound();
            }
            return View(helloWorld);
        }

        // POST: HelloWorlds/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,ReleaseDate,Genre,Price,Rating")] HelloWorld helloWorld)
        {
            if (id != helloWorld.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(helloWorld);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HelloWorldExists(helloWorld.Id))
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
            return View(helloWorld);
        }

        // GET: HelloWorlds/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var helloWorld = await _context.HelloWorld
                .FirstOrDefaultAsync(m => m.Id == id);
            if (helloWorld == null)
            {
                return NotFound();
            }

            return View(helloWorld);
        }

        // POST: HelloWorlds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var helloWorld = await _context.HelloWorld.FindAsync(id);
            if (helloWorld != null)
            {
                _context.HelloWorld.Remove(helloWorld);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HelloWorldExists(int id)
        {
            return _context.HelloWorld.Any(e => e.Id == id);
        }
    }
}
