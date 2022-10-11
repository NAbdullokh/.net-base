using DataBaseFirst.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("ConnectionData")));

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseDeveloperExceptionPage();

app.UseRouting();

app.Use(async (context, next) =>
{
    if (context.Response.StatusCode == StatusCodes.Status404NotFound)
    {
        await context.Response.WriteAsJsonAsync(new
        {
            message = "Bunday API xizmati mavjud emas!"
        });
    }
    await next();
});

app.MapControllers();

app.Run();
