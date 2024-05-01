using FizzBuzzAPP.Services;

namespace FizzBuzzAPP
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);
            // Add services to the container.
            builder.Services.AddTransient<ITextStyler, RegularTextStyler>();
            if (DateTime.Now.DayOfWeek == DayOfWeek.Wednesday)
            {
                builder.Services.AddTransient<ITextStyler, WednesdayTextStyler>();
            }
            
            builder.Services.AddScoped<FizzBuzzService>();
            builder.Services.AddRazorPages();
            var app = builder.Build();

            app.MapRazorPages();

            app.Run();

        }
    }
}
