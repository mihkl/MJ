using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MJ.Domain;
using MJ.Soft.Data;

namespace MJ.Soft.Controllers;

public class MoviesController(ApplicationDbContext context): Controller {
    private readonly ApplicationDbContext c = context;
    public async Task<IActionResult> Index() => View(await c.Movie.ToListAsync());
    public async Task<IActionResult> Details(int? id) {
        if (id == null) return NotFound();
        var movie = await c.Movie.FirstOrDefaultAsync(m => m.Id == id);
        if (movie == null) return NotFound();
        return View(movie);
    }
    public IActionResult Create() => View();
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Title,ReleaseDate,Genre,Price")] Movie movie) {
        if (ModelState.IsValid) {
            c.Add(movie);
            await c.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(movie);
    }
    public async Task<IActionResult> Edit(int? id) {
        if (id == null) return NotFound();
        var movie = await c.Movie.FindAsync(id);
        return movie == null ? NotFound() : View(movie);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,Title,ReleaseDate,Genre,Price")] Movie movie) {
        if (id != movie.Id) return NotFound();
        if (ModelState.IsValid) {
            try {
                c.Update(movie);
                await c.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) {
                if (!MovieExists(movie.Id)) return NotFound();
                else throw;
            }
            return RedirectToAction(nameof(Index));
        }
        return View(movie);
    }
    public async Task<IActionResult> Delete(int? id) {
        if (id == null) return NotFound();
        var movie = await c.Movie.FirstOrDefaultAsync(m => m.Id == id);
        return movie == null ? NotFound() : View(movie);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id) {
        var movie = await c.Movie.FindAsync(id);
        if (movie != null) c.Movie.Remove(movie);
        await c.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
    private bool MovieExists(int id) => c.Movie.Any(e => e.Id == id);
}
