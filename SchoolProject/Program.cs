var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

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
