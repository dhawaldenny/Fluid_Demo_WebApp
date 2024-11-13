using Fluid;
using Fluid.MvcViewEngine;
using Fluid.ViewEngine;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddMvc().AddFluid();
// Add services to the container.
builder.Services.AddControllersWithViews()
    .AddFluid(); // Add Fluid support


builder.Services.AddControllersWithViews()
    .AddRazorRuntimeCompilation();

var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "fluid",
    pattern: "{controller}/{action=Index}/{id?}",
    defaults: new { controller = "Fluid" });


app.Run();
