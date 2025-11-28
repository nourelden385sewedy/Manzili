using Manzili.Data;
using Manzili.Repositories.AdressRepository;
using Manzili.Repositories.GenericRepository;
using Manzili.Repositories.UserRepository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// 1. DBContext
builder.Services.AddDbContext<ManziliDbContext>(options
    => options.UseSqlServer(builder.Configuration.GetConnectionString("Home")));


// 2. Repos
builder.Services.AddScoped(typeof(IGenericRepo<>), typeof(GenericRepo<>));
builder.Services.AddScoped<IUserRepo, UserRepo>();
builder.Services.AddScoped<IAddressRepo, AddressRepo>();

// 3. Services



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

app.Run();
