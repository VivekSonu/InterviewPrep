using Humanizer;
using Lab.Data;
using Lab.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyModel;
using Microsoft.Extensions.FileSystemGlobbing.Internal;
using Microsoft.IdentityModel.Tokens;
using Microsoft.JSInterop;
using Newtonsoft.Json.Linq;
using static System.Net.Mime.MediaTypeNames;


namespace Lab
{
    //public class User
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; } = String.Empty;
    //}
    public class Program
    {
        public static void Main(string[] args)
        {
            //var  users = new List<User>
            //{
            //     new User { Id = 1, Name = "Vivek" },
            //     new User { Id = 2, Name = "Rahul" }
            //};
            var builder=WebApplication.CreateBuilder(args);

            builder.Services.AddScoped<IUserService,UserService>();

//            Dependency Injection(DI) is a design pattern used to achieve loose coupling between classes. Instead of a class creating its own dependencies,
//            the dependencies are provided by an external container at runtime.This follows the principle of Inversion of Control (IoC),
//            making applications easier to maintain, test, and extend.

//            In ASP.NET Core, dependencies are typically injected through the constructor, and the built-in IoC container manages object creation and lifetimes.

            builder.Services.AddScoped<ScopedService>();
            builder.Services.AddSingleton<SingeltonService>();
            builder.Services.AddTransient<TransientService>();

            builder.Services.AddScoped<IPaymentService,PaymentService>();
            builder.Services.AddScoped<IProductService,ProductService>();
            builder.Services.AddScoped<IEmailService,EmailService>();

            builder.Services.AddAuthentication("bearer").AddJwtBearer(option =>
            {
                var key = System.Text.Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!);

                option.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = builder.Configuration["Jwt:Issuer"],

                    ValidateAudience=false,
                    ValidateLifetime=true,

                    ValidateIssuerSigningKey=true,
                    IssuerSigningKey=new SymmetricSecurityKey(key)

                };
            });

            builder.Services.AddControllers();

            builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Lab")));

            var app = builder.Build();


            app.Use(async ( context,  next) =>
            {
                var startTime = DateTime.UtcNow;
                Console.WriteLine($"Path:{context.Request.Path}");
                await next();
                var endTime = DateTime.UtcNow;
                Console.WriteLine($"Time taken:{(endTime-startTime).TotalMilliseconds}");
            });



            app.Use(async (context, next) =>
            {
                try
                {
                    await next();
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    context.Response.StatusCode = 500;
                    await context.Response.WriteAsync("Something went wrong");

                }
            });

            app.MapControllers();

            app.MapGet("/", () => { return "Hello world"; });

            //app.MapGet("/users",  ()=>users.ToList());

            //app.MapGet("/users/{id}", (int id) => users.FirstOrDefault((x) => x.Id == id));

            //app.MapPost("/user", (User user) => { 
            //    users.Add(user);
            //    return Results.Ok(user);
            //});

            app.Run();
        }
    }
}
