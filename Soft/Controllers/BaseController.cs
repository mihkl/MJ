using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MJ.Soft.Data;
using MJ.Domain;

namespace MJ.Soft.Controllers;

public class BaseController<TModel>(ApplicationDbContext context, DbSet<TModel> s): Controller
    where TModel : Entity {
    protected readonly ApplicationDbContext c = context;
    protected readonly DbSet<TModel> dbSet = s;
    public async Task<IActionResult> Index() => View(await dbSet.ToListAsync());
    public async Task<IActionResult> Details(int? id) {
        if (id == null) return NotFound();
        var model = await dbSet.FirstOrDefaultAsync(m => m.Id == id);
        if (model == null) return NotFound();
        return View(model);
    }
    public IActionResult Create() => View();

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(TModel model) {
        if (ModelState.IsValid) {
            c.Add(model);
            await c.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(model);
    }
    public async Task<IActionResult> Edit(int? id) {
        if (id == null) return NotFound();
        var model = await dbSet.FindAsync(id);
        return model == null ? NotFound() : View(model);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, TModel model) {
        if (id != model.Id) return NotFound();
        if (ModelState.IsValid) {
            try {
                c.Update(model);
                await c.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) {
                if (!ModelExists(model.Id)) return NotFound();
                else throw;
            }
            return RedirectToAction(nameof(Index));
        }
        return View(model);
    }
    public async Task<IActionResult> Delete(int? id) {
        if (id == null) return NotFound();
        var model = await dbSet.FirstOrDefaultAsync(m => m.Id == id);
        return model == null ? NotFound() : View(model);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id) {
        var model = await dbSet.FindAsync(id);
        if (model != null) dbSet.Remove(model);
        await c.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
    protected bool ModelExists(int id) => dbSet.Any(e => e.Id == id);
}
