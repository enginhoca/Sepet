using BooksApp.Data;
using BooksApp.Data.Abstract;
using BooksApp.Data.Concrete.EfCore.Repositories;
using BooksApp.Service.Abstract;
using BooksApp.Service.Concrete;
using BooksApp.Shared.Helpers.Abstract;
using BooksApp.Shared.Helpers.Concrete;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddDbContext<BooksAppDbContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("SqliteConnection")));

builder.Services.AddScoped<ICategoryRepository, EfCoreCategoryRepository>();
builder.Services.AddScoped<IBookRepository, EfCoreBookRepository>();
builder.Services.AddScoped<IAuthorRepository, EfCoreAuthorRepository>();
builder.Services.AddScoped<ICartRepository, EfCoreCartRepository>();
builder.Services.AddScoped<ICartItemRepository, EfCoreCartItemRepository>();
builder.Services.AddScoped<IOrderRepository, EfCoreOrderRepository>();

builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IAuthorService, AuthorService>();
builder.Services.AddScoped<ICartService, CartService>();
builder.Services.AddScoped<ICartItemService, CartItemService>();
builder.Services.AddScoped<IOrderService, OrderService>();

builder.Services.AddScoped<IImageHelper, ImageHelper>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());//Geçerli proje içindeki tüm Profile classlarından bir nesne yarat, containera koy, DI yoluyla almak üzere hazırda beklet

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
