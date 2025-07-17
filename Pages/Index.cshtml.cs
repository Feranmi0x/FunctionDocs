

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using FunctionDocs.Data;
using FunctionDocs.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FunctionDocs.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly AppDbContext _context;

        public IndexModel(ILogger<IndexModel> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public List<FunctionEntry> Functions { get; set; } = new();

        public void OnGet()
        {
            Functions = _context.FunctionEntries.ToList();
        }

        // 🧨 Add this method for deleting a function entry
        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var entry = await _context.FunctionEntries.FindAsync(id);

            if (entry != null)
            {
                _context.FunctionEntries.Remove(entry);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}