# ASP.NET Core MVC: Evolução do Program.cs e Startup.cs

Com o lançamento do ASP.NET Core 6.0, a Microsoft introduziu o conceito de **Minimal APIs** e simplificou significativamente a estrutura inicial dos projetos. 
A principal mudança foi a unificação dos arquivos `Program.cs` e `Startup.cs` em um único arquivo `Program.cs`.

## Responsabilidades

- **Program.cs**: Ponto de entrada da aplicação e configuração do host
- **Startup.cs**: 
  - `ConfigureServices()`: Configuração de serviços e injeção de dependência
  - `Configure()`: Configuração do pipeline de middleware HTTP

## Principais Mudanças

1. **Top-level statements**: Não há mais necessidade de definir uma classe `Program` explicitamente
2. **WebApplicationBuilder**: Substitui o `HostBuilder` e simplifica a configuração
3. **WebApplication**: Combina `IApplicationBuilder` e `IHost` em uma única interface
4. **Configuração inline**: Serviços e middleware são configurados no mesmo arquivo

### Conversão de ConfigureServices para builder.Services

**Antes (Startup.cs)**:
```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddControllersWithViews();
    services.AddDbContext<MyContext>(options => 
        options.UseSqlServer(connectionString));
}
```

**Depois (Program.cs)**:
```csharp
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<MyContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));
```

### Conversão de Configure para app.Use

**Antes (Startup.cs)**:
```csharp
public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
{
    app.UseHttpsRedirection();
    app.UseStaticFiles();
    app.UseRouting();
}
```

**Depois (Program.cs)**:
```csharp
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
```

## Ordem dos Middlewares

```csharp
// 1. Exception handling
app.UseExceptionHandler("/Home/Error");

// 2. HSTS
app.UseHsts();

// 3. HTTPS Redirection
app.UseHttpsRedirection();

// 4. Static Files
app.UseStaticFiles();

// 5. Cookie Policy
app.UseCookiePolicy();

// 6. Session
app.UseSession();

// 7. Routing
app.UseRouting();

// 8. Authentication
app.UseAuthentication();

// 9. Authorization
app.UseAuthorization();

// 10. Endpoint mapping
app.MapControllerRoute(/*...*/);
```
