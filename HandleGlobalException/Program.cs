using HandleGlobalException.Exception1;

var builder = WebApplication.CreateBuilder(args);

// Register Middleware as a Service
builder.Services.AddTransient<GlobalExceptionHandler>();

var app = builder.Build();

// Add it's middleware
app.UseMiddleware<GlobalExceptionHandler>();

app.MapGet("/", () => "Hello World!");

app.Run();
