using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using WATERWebsite.Presistance;
using WATERWebsite.Services;
using WATERWebsite.Settings;
using Westwind.Globalization.AspnetCore;

var builder = WebApplication.CreateBuilder(args);

/**/
// Standard ASP.NET Localization features are recommended
// Make sure this is done FIRST!
builder.Services.AddLocalization(options =>
{
    options.ResourcesPath = "Properties";
});


// Replace StringLocalizers with Db Resource Implementation
builder.Services.AddSingleton(typeof(IStringLocalizerFactory),
                      typeof(DbResStringLocalizerFactory));
builder.Services.AddSingleton(typeof(IHtmlLocalizerFactory),
                      typeof(DbResHtmlLocalizerFactory));


// Required: Enable Westwind.Globalization (opt parm is optional)
// shown here with optional manual configuration code
builder.Services.AddWestwindGlobalization();
/**/

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddRazorPages();
builder.Services.Configure<MailSettings>(builder.Configuration.GetSection(nameof(MailSettings)));
builder.Services.AddTransient<IMailingService, MailingService>();
builder.Services.AddDistributedMemoryCache();

// Add services to the container.

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromDays(10);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();
app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();
app.UseSession();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
