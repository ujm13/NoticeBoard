using Microsoft.EntityFrameworkCore;
using NoticeBoard.Repository.Db;
using NoticeBoard.WebApplication.Infrastructures.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<NoticeBoardDbContext>(
    o => o.UseSqlServer(builder.Configuration.GetConnectionString("NoticeBoardDb")));

builder.Services.AddNoticeBoardServices();
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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Announcement}/{action=GetList}/{id?}");

app.Run();