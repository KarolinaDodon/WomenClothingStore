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
           // Отключаем падение приложения из-за незавершенных изменений в моделях
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

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

// Автоматическое применение миграций при старте в Docker
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<ApplicationDbContext>();

        // Обеспечиваем создание папки для БД, если её нет
        var dbPath = Path.GetDirectoryName(context.Database.GetDbConnection().DataSource);
        if (!string.IsNullOrEmpty(dbPath) && !Directory.Exists(dbPath))
        {
            Directory.CreateDirectory(dbPath);
        }

        // Применяем миграции
        if (context.Database.IsRelational())
        {
            context.Database.Migrate();
        }

        
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "Ошибка при автоматическом применении миграций базы данных.");
    }
}

app.Run();