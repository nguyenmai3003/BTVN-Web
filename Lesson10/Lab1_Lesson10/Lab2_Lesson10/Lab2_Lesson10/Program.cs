var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews(options =>
{
    // Việt hóa lỗi chuyển đổi dữ liệu (ví dụ: điểm không phải số, ngày không hợp lệ).
    var messages = options.ModelBindingMessageProvider;
    messages.SetAttemptedValueIsInvalidAccessor((value, field) =>
        $"Giá trị '{value}' không hợp lệ cho {field}.");
    messages.SetValueMustBeANumberAccessor(field => $"{field} phải là một số hợp lệ.");
    messages.SetValueIsInvalidAccessor(value => $"Giá trị '{value}' không hợp lệ.");
    messages.SetUnknownValueIsInvalidAccessor(field => $"{field} không hợp lệ.");
    messages.SetValueMustNotBeNullAccessor(_ => "Vui lòng nhập dữ liệu.");
});

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

app.MapStaticAssets();

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
