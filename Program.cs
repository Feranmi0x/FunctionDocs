using Microsoft.EntityFrameworkCore;
using FunctionDocs.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddRazorPages();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure middleware
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();         // Enables serving from wwwroot
app.UseRouting();
app.UseAuthorization();

app.MapRazorPages();          // Maps all Razor Pages automatically

app.Run();