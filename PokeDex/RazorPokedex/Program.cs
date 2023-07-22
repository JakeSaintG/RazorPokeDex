using Microsoft.EntityFrameworkCore;
using RazorPokedex.Data;
using RazorPokedex.Repositories;
using RazorPokedex.Utils;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<Context>();
builder.Services.AddScoped<IDbUtils, DbUtils>();
builder.Services.AddScoped<IAddOrEditPkmnRepository, AddOrEditPkmnRepository>();

builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

using (var serviceScope = app.Services.CreateScope())
{
    var dbUtils = serviceScope.ServiceProvider.GetService<IDbUtils>();
    dbUtils.CheckDbExist();
}

app.Run();
