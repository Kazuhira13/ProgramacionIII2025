using Clase11.Data;
using Clase11.Services;
using Firebase.Auth;
using Firebase.Auth.Providers;
using FirebaseAdmin;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.UseUrls("http://*:5000");


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("main") ?? "";
builder.Services.AddDbContext<ClaseDbContext>(x => x.UseMySQL(connectionString));

Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", @"firebase_cred.json");
builder.Services.AddSingleton(FirebaseApp.Create());

var firebaseProjectName = "pruebaapi-436ec";
var firebaseApiKeyFromEnv = Environment.GetEnvironmentVariable("FIREBASE_API_KEY");
builder.Services.AddSingleton(new FirebaseAuthClient(new FirebaseAuthConfig
{
    ApiKey = firebaseApiKeyFromEnv,
    AuthDomain = $"{firebaseProjectName}.firebaseapp.com",
    Providers = new FirebaseAuthProvider[]
    {
        new EmailProvider(),
        new GoogleProvider()
    }
}));
builder.Services.AddTransient<IFirebaseAuthService, FirebaseAuthService>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.Authority = $"https://securetoken.google.com/{firebaseProjectName}";
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = $"https://securetoken.google.com/{firebaseProjectName}",
            ValidateAudience = true,
            ValidAudience = firebaseProjectName,
            ValidateLifetime = true
        };
    });


var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseDeveloperExceptionPage();
app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();

app.MapControllers();

app.Run();
