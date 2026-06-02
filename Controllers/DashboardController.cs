using System.Security.Claims;
using apbd_10.Data;
using apbd_10.Models;
using apbd_10.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace apbd_10.Controllers;

[Authorize]
public class DashboardController : Controller
{
    private readonly AppDbContext _db;

    public DashboardController(AppDbContext db)
    {
        _db = db;
    }

    public async Task<IActionResult> Index()
    {
        var userId = GetCurrentUserId();

        var notes = await _db.UserNotes
            .Where(n => n.AppUserId == userId)
            .OrderByDescending(n => n.CreatedAt)
            .ToListAsync();

        return View(notes);
    }

    [HttpGet]
    public IActionResult CreateNote()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateNote(CreateNoteViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var note = new UserNote
        {
            AppUserId = GetCurrentUserId(),
            Title = model.Title,
            Content = model.Content,
            CreatedAt = DateTime.UtcNow
        };

        _db.UserNotes.Add(note);
        await _db.SaveChangesAsync();

        return RedirectToAction("Index");
    }

    private int GetCurrentUserId()
    {
        var id = User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (id == null)
        {
            throw new InvalidOperationException("User ID claim is missing.");
        }

        return int.Parse(id);
    }
}