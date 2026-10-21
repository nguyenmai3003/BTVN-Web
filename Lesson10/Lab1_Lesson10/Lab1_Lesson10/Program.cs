var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
// UseStaticFiles phục vụ cả ảnh được upload sau thời điểm build.
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapStaticAssets();

// Route cụ thể phải đặt trước route mặc định.
app.MapControllerRoute(
    name: "StudentList",
    pattern: "Admin/Student/List",
    defaults: new { controller = "Student", action = "Index" });

app.MapControllerRoute(
    name: "StudentAdd",
    pattern: "Admin/Student/Add",
    defaults: new { controller = "Student", action = "Create" });

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Student}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();
