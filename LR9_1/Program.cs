using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using LR9_1.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

List<ObjectModel> objects = new List<ObjectModel>
{
    new ObjectModel { ID = 1, Name = "Ãóìêà", Price = 10.0m },
    new ObjectModel { ID = 2, Name = "Îë³âåöü", Price = 20.0m },
    new ObjectModel { ID = 3, Name = "Ðó÷êà", Price = 30.0m }
};

app.MapGet("/", () =>
{
    return Results.Ok(objects);
});

app.Run();
