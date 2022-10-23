using Microsoft.EntityFrameworkCore;
using Practice.DataAccess;

var builder = WebApplication.CreateBuilder(args);
//BDD
const string ConnectionName = "testNaitusDB";
var connectionString = builder.Configuration.GetConnectionString(ConnectionName);

//context to server
builder.Services.AddDbContext<testNaitusDBContext>(options => options.UseSqlServer(connectionString));
// Add services to the container.
builder.Services.AddControllersWithViews();

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
