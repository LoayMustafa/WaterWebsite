using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.Extensions.Localization;
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
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
