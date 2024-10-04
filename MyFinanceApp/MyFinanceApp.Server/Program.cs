using Amazon.CognitoIdentityProvider;
using Amazon.Extensions.CognitoAuthentication;
using AppLibrary.DiConfigs;
using AppLibrary.Utilities;
using Microsoft.Extensions.Options;
using MyFinanceApp.Server.Site;

var builder = WebApplication.CreateBuilder(args);

//-----------------------------------------------------
//DAPPER REPOSITORY SETUP EXPERIMENTATION
// Add services to the container.
builder.Services.AddSingleton<ConfigureServices>();
//Scoped means a new instance of this repo will always be created
//builder.Services.AddTransient<IUserRepository, UserRepository>();
RegisterServices.AddServicesToRepositories(builder.Services);
//-----------------------------------------------------





// Add services to the container.
// This line configures the AwsCognitoSettings class to bind to the "AWS" section of the appsettings.json file.
// The settings will be available for dependency injection.
builder.Services.Configure<AwsCognitoSettings>(builder.Configuration.GetSection("AWSCognito"));

// This line registers the AmazonCognitoIdentityProviderClient as a singleton service.
builder.Services.AddSingleton<IAmazonCognitoIdentityProvider, AmazonCognitoIdentityProviderClient>();

// This line registers the CognitoUserPool as a singleton service.
// The lambda function is used to configure the CognitoUserPool instance.
builder.Services.AddSingleton<CognitoUserPool>(sp =>
{
    // Retrieve the AwsCognitoSettings instance from the service provider.
    var settings = sp.GetRequiredService<IOptions<AwsCognitoSettings>>().Value;

    // Retrieve the IAmazonCognitoIdentityProvider instance from the service provider.
    var provider = sp.GetRequiredService<IAmazonCognitoIdentityProvider>();

    // Create and return a new instance of CognitoUserPool using the retrieved settings and provider.
    return new CognitoUserPool(settings.UserPoolId, settings.ClientId, provider, settings.ClientSecret);
});





builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

//need to implement this better in the future
builder.Services.AddExceptionHandler<AppExecptionHandler>();

//DI SETUP FOR CLEAN ARCHITECTURE
// DI container is part of the .NET runtime infrastructure, and your provided files configure and register services into this container.
// The actual DI container is built and managed by the framework based on these configurations

//builder.Configuration = A collection of configuration providers for the application to compose. This is useful for adding new configuration sources and providers.
var settings = new Settings(builder.Configuration);

DiConfiguration.ConfigureServices(builder.Services, settings);

var app = builder.Build();

//need to implement this better in the future
//app.UseExceptionHandler("/Error");
//app.UseExceptionHandler(
//    new ExceptionHandlerOptions()
//    {
//        AllowStatusCode404Response = true, // important!
//        ExceptionHandlingPath = "/error"
//    }
//);

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
