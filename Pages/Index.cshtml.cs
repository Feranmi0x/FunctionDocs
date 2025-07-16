using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using FunctionDocs.Data; // Make sure this matches your AppDbContext namespace
using FunctionDocs.Models; // Make sure this matches your FunctionEntry namespace
using System.Collections.Generic;
using System.Linq;

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
    }
}