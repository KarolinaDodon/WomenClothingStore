using WomenClothingStore.Web;
using WomenClothingStore.Domain.Interfaces;
using WomenClothingStore.Infrastructure.Data;
using WomenClothingStore.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using FluentValidation;
using WomenClothingStore.Web.Validators;
using WomenClothingStore.Web.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Регистрация DbContext 
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")
        ?? "Data Source=WomenClothingStore.db")
           .ConfigureWarnings(w => w.Ignore(Microsoft.EntityFrameworkCore.Diagnostics.RelationalEventId.PendingModelChangesWarning)));

// Регистрация репозиториев
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

// Регистрация FluentValidation
builder.Services.AddValidatorsFromAssemblyContaining<ProductValidator>();

// Регистрация сервисов
builder.Services.AddScoped<FileUploadService>();
builder.Services.AddScoped<CartService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

// Безопасная инициализация данных базы при старте
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<ApplicationDbContext>();

        var dbPath = Path.GetDirectoryName(context.Database.GetDbConnection().DataSource);
        if (!string.IsNullOrEmpty(dbPath) && !Directory.Exists(dbPath))
        {
            Directory.CreateDirectory(dbPath);
        }

        // Запуск создания БД, если файла нет
        context.Database.EnsureCreated();

        // Силовое обновление ссылок в файле .db, чтобы точно отобразились нужные вещи
        var skirt1 = context.ProductImages.FirstOrDefault(p => p.Id == 4);
        if (skirt1 != null) skirt1.Url = "https://images.pexels.com/photos/4690501/pexels-photo-4690501.jpeg?auto=compress&cs=tinysrgb&w=600";

        var skirt2 = context.ProductImages.FirstOrDefault(p => p.Id == 5);
        if (skirt2 != null) skirt2.Url = "https://images.pexels.com/photos/23947043/pexels-photo-23947043.jpeg?auto=compress&cs=tinysrgb&w=600";

        var skirt3 = context.ProductImages.FirstOrDefault(p => p.Id == 6);
        if (skirt3 != null) skirt3.Url = "https://images.pexels.com/photos/5217676/pexels-photo-5217676.jpeg?auto=compress&cs=tinysrgb&w=600";

        context.SaveChanges();
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "Ошибка при автоматической инициализации данных базы.");
    }
}

app.Run();