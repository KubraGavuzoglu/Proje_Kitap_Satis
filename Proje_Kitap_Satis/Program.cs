using Kitap.Data;
using Kitap.Data.Abstract;
using Kitap.Data.Concrete;
using Kitap.Service.Abstract;
using Kitap.Service.Concrete;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();



builder.Services.AddDbContext<DatabaseContext>(); // Entityframework iþlemlerini yapabilmek için bu satýrý ekliyoruz
builder.Services.AddTransient(typeof(IRepository<>), typeof(Repository<>));


builder.Services.AddTransient(typeof(IService<>), typeof(Service<>));










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
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.MapControllerRoute(
            name: "admin",
            pattern: "{area:exists}/{controller=Main}/{action=Index}/{id?}"
          );


app.Run();
