using JuliePro.Data;
using JuliePro.DataSeed;
using JuliePro.Services;
using JuliePro.Utility;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews()
    .AddViewLocalization(); //TODO : ajoutez la bonne configuration

builder.Services.AddDbContext<JulieProDbContext>(opt => {

    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
    opt.UseLazyLoadingProxies();

});

builder.Services.AddScoped<IJulieProDbContextSeed, JulieProDbContextSeedDev>();

builder.Services.AddScoped(typeof(IServiceBaseAsync<>), typeof(ServiceBaseEF<>));
builder.Services.AddScoped<TrainerService>();
builder.Services.AddScoped<CertificationService>();

builder.Services.AddSingleton<IImageFileManager, ImageFileManager>();



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

using (var scope = app.Services.CreateScope()) {

    var scopeProvider = scope.ServiceProvider;
    try
    {
        var seed = scopeProvider.GetRequiredService<IJulieProDbContextSeed>();
        await seed.SeedAsync();

    }
    catch (Exception ex) {

        app.Logger.LogError(EventCode.ErrorDb, ex, ex.Message);
    }

}


app.Run();
