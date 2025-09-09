using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore;
using BookWarms.Data;
using BookWarms.Services;
namespace BookWarms
{ 
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("BookWarmConnection")));
            builder.Services.AddScoped<BookService>();
            builder.Services.AddScoped<UserService>();
            builder.Services.AddScoped<LibraryService>();
            builder.Services.AddScoped<ReviewService>();

            builder.Services.AddControllers();

            // CORS: open for local dev. Use specific origins in production.
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("DevCors", policy =>
                    policy
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
            });

            var app = builder.Build();
            using (var scope = app.Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                db.Database.EnsureCreated();
            }
            //if (app.Environment.IsDevelopment())
            //{
            //    app.UseSwagger();
            //    app.UseSwaggerUI();
            //}
            app.UseHttpsRedirection();

            // IMPORTANT: CORS must be before MapControllers and obviously before app.Run
            app.UseCors("DevCors");
            app.UseAuthorization();
            app.MapControllers();
            app.Run();

            app.UseCors(x => x
               .AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader());
        }
    }
}
