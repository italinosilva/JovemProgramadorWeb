using JovemProgramadorWeb.Data.Repositorio.Interfaces;
using JovemProgramadorWeb.Data.Repositorio;
using JovemProgramadorWeb.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddControllersWithViews();

builder.Services.AddHttpClient();

var connectionstring = builder.Configuration.GetConnectionString("StringConexao");
builder.Services.AddDbContext<BancoContexto>(options => options.UseSqlServer(connectionstring));
builder.Services.AddScoped<IAlunoRepositorio, AlunoRepositorio>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}");

app.Run();
