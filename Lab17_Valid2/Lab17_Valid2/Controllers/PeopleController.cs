using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Lab17_Valid2.Data;
using Lab17_Valid2.Models;

namespace Lab17_Valid2.Controllers
{
  public class PeopleController : Controller
  {
    private readonly ApplicationDbContext _context;

    public PeopleController(ApplicationDbContext context)
    {
      _context = context;
    }

    // GET: People
    public async Task<IActionResult> Index()
    {
          return _context.Persons != null ? 
                      View(await _context.Persons.ToListAsync()) :
                      Problem("Entity set 'ApplicationDbContext.Persons'  is null.");
    }

    // GET: People/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null || _context.Persons == null)
        {
            return NotFound();
        }

        var person = await _context.Persons
            .FirstOrDefaultAsync(m => m.PersonId == id);
        if (person == null)
        {
            return NotFound();
        }

        return View(person);
    }

    // GET: People/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: People/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("PersonId,FirstName,SecondName,Age,Address,Work,Education,Email,PhoneNumber,Pasport")] Person person)
    {
      if (ModelState.IsValid)
      {
        _context.Add(person);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));            
      }
      return View(person);
    }

    // GET: People/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
      if (id == null || _context.Persons == null)
      {
        return NotFound();
      }

      var person = await _context.Persons.FindAsync(id);
      if (person == null)
      {
        return NotFound();
      }
      return View(person);
    }

    // POST: People/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("PersonId,FirstName,SecondName,Age,Address,Work,Education,Email,PhoneNumber,Pasport")] Person person)
    {
      if (id != person.PersonId)
      {
          return NotFound();
      }

      if (ModelState.IsValid)
      {
        try
        {
          _context.Update(person);
          await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
          if (!PersonExists(person.PersonId))
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
      return View(person);
    }

    // GET: People/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
      if (id == null || _context.Persons == null)
      {
        return NotFound();
      }

      var person = await _context.Persons
          .FirstOrDefaultAsync(m => m.PersonId == id);
      if (person == null)
      {
        return NotFound();
      }

      return View(person);
    }

    // POST: People/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
      if (_context.Persons == null)
      {
        return Problem("Entity set 'ApplicationDbContext.Persons'  is null.");
      }
      var person = await _context.Persons.FindAsync(id);
      if (person != null)
      {
        _context.Persons.Remove(person);
      }
            
      await _context.SaveChangesAsync();
      return RedirectToAction(nameof(Index));
    }

    private bool PersonExists(int id)
    {
      return (_context.Persons?.Any(e => e.PersonId == id)).GetValueOrDefault();
    } 
  }
}
