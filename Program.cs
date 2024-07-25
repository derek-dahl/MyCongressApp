var builder = WebApplication.CreateBuilder(args); // Create a new instance of the WebApplicationBuilder class.

// Add services to the container.
builder.Services.AddControllersWithViews(); // Add the controllers with views services.

// Retrieve the API key from user secrets
var apiKey = builder.Configuration["CongressApiKey"];

// Register CongressAuthenticator with the API key
builder.Services.AddSingleton(new CongressAuthenticator(apiKey));

// Register HttpClient and CongressClient
builder.Services.AddHttpClient<CongressClient>();

var app = builder.Build(); // Build the app.

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error"); // Use the exception handler middleware.
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts(); // Use the HSTS middleware.
}

app.UseHttpsRedirection(); // Use the HTTPS redirection middleware.
app.UseStaticFiles(); // Use the static files middleware.

app.UseRouting(); // Use the routing middleware.

app.UseAuthorization(); // Use the authorization middleware.

app.MapControllerRoute( // Map the controller route.
    name: "default", // The name of the route.
    pattern: "{controller=Home}/{action=Index}/{id?}"
); // Map the controller route.

app.Run(); // Run the app.
