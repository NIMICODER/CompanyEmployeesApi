using CompanyEmployeesApi.Extensions;
using Contracts;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using NLog;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Options;
using CompanyEmployeesApi.ActionFilters;
using Service.DataShaping;
using Shared.DataTransferObjects;
using CompanyEmployees.Presentation.ActionFilters;
using CompanyEmployeesApi.Utility;

namespace CompanyEmployeesApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(),
            "/nlog.config"));


            // Add services to the container.
            
            builder.Services.ConfigureCors();
            builder.Services.ConfigureIISIntegration();
            builder.Services.ConfigureLoggerService();
            builder.Services.ConfigureRepositoryManager();
            builder.Services.ConfigureServiceManager();
            builder.Services.ConfigureSqlContext(builder.Configuration);
            builder.Services.AddAutoMapper(typeof(Program));
            builder.Services.AddScoped<IDataShaper<EmployeeDto>, DataShaper<EmployeeDto>>();
            builder.Services.AddScoped<ValidateMediaTypeAttribute>();
            builder.Services.AddScoped<IEmployeeLinks, EmployeeLinks>();




            builder.Services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            NewtonsoftJsonPatchInputFormatter GetJsonPatchInputFormatter() =>
                    new ServiceCollection().AddLogging().AddMvc().AddNewtonsoftJson()
                    .Services.BuildServiceProvider()
                    .GetRequiredService<IOptions<MvcOptions>>().Value.InputFormatters

                    .OfType<NewtonsoftJsonPatchInputFormatter>().First();

            builder.Services.AddScoped<ValidationFilterAttribute>();
            builder.Services.AddControllers(config => {
                config.RespectBrowserAcceptHeader = true;
                config.ReturnHttpNotAcceptable = true;
                config.InputFormatters.Insert(0, GetJsonPatchInputFormatter());
            }).AddXmlDataContractSerializerFormatters()
             .AddCustomCSVFormatter()
             .AddApplicationPart(typeof(CompanyEmployees.Presentation.AssemblyReference).Assembly);

            builder.Services.AddCustomMediaTypes();

            builder.Services.AddAuthentication();
            builder.Services.ConfigureIdentity();

           
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            //if (app.Environment.IsDevelopment())
            //{
            //    app.UseSwagger();
            //    app.UseSwaggerUI();
            //}
            var logger = app.Services.GetRequiredService<ILoggerManager>();
            app.ConfigureExceptionHandler(logger);
            if (app.Environment.IsProduction())
                app.UseHsts();




            app.UseHttpsRedirection();
            app.UseStaticFiles();
            //This next code is configuring the ASP.NET Core middleware to use forwarded headers when processing incoming requests.
            //Forwarded headers are HTTP headers that contain information about the original client IP address and
            //other information that may be lost or modified as a request passes through proxy servers or load balancers.
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.All
            });
            app.UseCors("CorsPolicy");

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}