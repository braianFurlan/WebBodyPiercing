using Microsoft.EntityFrameworkCore;
using WebBodyPiercing.Data;
using Microsoft.EntityFrameworkCore.SqlServer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Incluir dbcontext
builder.Services.AddDbContext<PiercingDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("PiercingDbContext")));



var app = builder.Build();

// invocar la ejecucion del seeder con un scope para resolver el dbcontext  
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<PiercingDbContext>();
    DbSeeder.Seed(dbContext);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
