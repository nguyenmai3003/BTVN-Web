namespace XuanMai
{
    public class  program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();
            app.MapGet("/",() => "hello xuan Mai");
            app.Run();
        }
    }
}