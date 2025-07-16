using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FunctionDocs.Data; // Make sure this matches your actual namespace
using FunctionDocs.Models;

namespace FunctionDocs.Pages
{
    public class AddFunctionModel : PageModel
    {
        private readonly AppDbContext _context;

        public AddFunctionModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public FunctionEntry Function { get; set; } = new FunctionEntry
        {
            FunctionName = string.Empty,
            Description = string.Empty,
            CodeExample = string.Empty
        };

        public string? SuccessMessage { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
{
    if (!ModelState.IsValid)
        return Page();

    _context.FunctionEntries.Add(Function); // ✅ Add submitted data
    _context.SaveChanges();                // ✅ Save to DB

    SuccessMessage = "Function added successfully!";
    ModelState.Clear();

    // Reset the form for the next input
    Function = new FunctionEntry
    {
        FunctionName = string.Empty,
        Description = string.Empty,
        CodeExample = string.Empty
    };

    return Page(); // Stay on the same page
}
    }
}   