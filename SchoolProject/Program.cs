using Microsoft.EntityFrameworkCore;
using SchoolProject.DAL;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<SchoolDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});

var app = builder.Build();
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "Areas",
        pattern: "{area:exists}/{controller=DashBoard}/{action=Index}"
        );
});
//app.MapGet("/", () => "Hello World!");

app.UseStaticFiles();
app.Run();
