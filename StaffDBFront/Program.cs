using StaffDBFront.Components;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using StaffDBFront.Data;

var builder = WebApplication.CreateBuilder(args);

//direct db connection, used for scaffolding
builder.Services.AddDbContextFactory<StaffDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("StaffDBContext") ?? throw new InvalidOperationException("Connection string 'StaffDBContext' not found.")));

//base address for connection to back-end
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5263/") });

builder.Services.AddQuickGridEntityFrameworkAdapter();

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

// Add services to the container.
builder.Services.AddRazorComponents()
	.AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error", createScopeForErrors: true);
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
    app.UseMigrationsEndPoint();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
	.AddInteractiveServerRenderMode();

app.Run();
