var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();


app.MapAreaControllerRoute(
    name: "admin",
    areaName:"Admin",
    pattern: "admin/{controller=Home}/{action=Index}/{id?}"
    );

//Burada gelen isteğin rota yapılanmasını çözümler.
//Biz de buraya ihtiyacımıza göre rota yapılanmaları yazabiliriz.
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
