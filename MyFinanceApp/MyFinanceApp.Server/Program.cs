using AppLibrary.DiConfigs;
using AppLibrary.Utilities;
using MyFinanceApp.Server.Site;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<ConfigureServices>();
//Scoped means a new instance of this repo will always be created
//builder.Services.AddTransient<IUserRepository, UserRepository>();

RegisterServices.AddServicesToRepositories(builder.Services);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddExceptionHandler<AppExecptionHandler>();

var settings = new Settings(builder.Configuration);

DiConfiguration.ConfigureServices(builder.Services, settings);

var app = builder.Build();

//app.UseExceptionHandler("/Error");
app.UseExceptionHandler(
    new ExceptionHandlerOptions()
    {
        AllowStatusCode404Response = true, // important!
        ExceptionHandlingPath = "/error"
    }
);

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{

}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
