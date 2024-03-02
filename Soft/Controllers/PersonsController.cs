using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MJ.Soft.Data;
using MJ.Soft.Models;

namespace MJ.Soft.Controllers;

public class PersonsController(ApplicationDbContext context): Controller {
    private readonly ApplicationDbContext c = context;
    public async Task<IActionResult> Index() => View(await c.Persons.ToListAsync());
    public async Task<IActionResult> Details(int? id) {
        if (id == null) return NotFound();
        var person = await c.Persons.FirstOrDefaultAsync(m => m.Id == id);
        if (person == null) return NotFound();
        return View(person);
    }
    public IActionResult Create() => View();
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,FirstName,FamilyName,DoB,Gender")] Person person) {
        if (ModelState.IsValid) {
            c.Add(person);
            await c.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(person);
    }
    public async Task<IActionResult> Edit(int? id) {
        if (id == null) return NotFound();
        var person = await c.Persons.FindAsync(id);
        return person == null ? NotFound() : View(person);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,FamilyName,DoB,Gender")] Person person) {
        if (id != person.Id) return NotFound();
        if (ModelState.IsValid) {
            try {
                c.Update(person);
                await c.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) {
                if (!MovieExists(person.Id)) return NotFound();
                else throw;
            }
            return RedirectToAction(nameof(Index));
        }
        return View(person);
    }
    public async Task<IActionResult> Delete(int? id) {
        if (id == null) return NotFound();
        var person = await c.Persons.FirstOrDefaultAsync(m => m.Id == id);
        return person == null ? NotFound() : View(person);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id) {
        var person = await c.Persons.FindAsync(id);
        if (person != null) c.Persons.Remove(person);
        await c.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
    private bool MovieExists(int id) => c.Persons.Any(e => e.Id == id);
}
