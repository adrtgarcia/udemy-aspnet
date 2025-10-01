using Microsoft.EntityFrameworkCore;
using SistemaVendas.Aplicacao.Interfaces;
using SistemaVendas.Aplicacao.Services;
using SistemaVendas.Dominio.Interfaces;
using SistemaVendas.Dominio.Services;
using SistemaVendas.Dominio.Repositorio;
using SistemaVendas.Repositorio.Entities;
using SistemaVendas.Repositorio.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Startup.cs
builder.Services.Configure<CookiePolicyOptions>(options =>
{
    options.CheckConsentNeeded = context => true;
    options.MinimumSameSitePolicy = SameSiteMode.None;
});

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MyStock")));

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
//builder.Services.AddSession();

builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// Aplicação
builder.Services.AddScoped<IServicoAplicacaoCategoria, ServicoAplicacaoCategoria>();
builder.Services.AddScoped<IServicoAplicacaoCliente, ServicoAplicacaoCliente>();
builder.Services.AddScoped<IServicoAplicacaoProduto, ServicoAplicacaoProduto>();
builder.Services.AddScoped<IServicoAplicacaoVenda, ServicoAplicacaoVenda>();
builder.Services.AddScoped<IServicoAplicacaoUsuario, ServicoAplicacaoUsuario>();

// Domínio
builder.Services.AddScoped<IServicoDominioCategoria, ServicoDominioCategoria>();
builder.Services.AddScoped<IServicoDominioCliente, ServicoDominioCliente>();
builder.Services.AddScoped<IServicoDominioProduto, ServicoDominioProduto>();
builder.Services.AddScoped<IServicoDominioVenda, ServicoDominioVenda>();
builder.Services.AddScoped<IServicoDominioUsuario, ServicoDominioUsuario>();

// Repositório
builder.Services.AddScoped<IRepositorioCategoria, RepositorioCategoria>();
builder.Services.AddScoped<IRepositorioCliente, RepositorioCliente>();
builder.Services.AddScoped<IRepositorioProduto, RepositorioProduto>();
builder.Services.AddScoped<IRepositorioVenda, RepositorioVenda>();
builder.Services.AddScoped<IRepositorioVendaProduto, RepositorioVendaProduto>();
builder.Services.AddScoped<IRepositorioUsuario, RepositorioUsuario>();


builder.Services.AddMvc();

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

// Métodos do builder
app.UseCookiePolicy();
app.UseSession();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}");

app.Run();
