using ChatApp.Hubs;
using Microsoft.AspNetCore;
using Serilog;
using Serilog.Events; // to user LogEventLevel info and filter it to just log the messages

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddSignalR();


// global loggers
var messageLogger = new LoggerConfiguration()
.WriteTo.File("C:\\Users\\Jos\\Documents\\Logger\\LogMessages.txt", rollingInterval: RollingInterval.Day)
.CreateLogger();
// every day it creates a new log file.
builder.Logging.AddSerilog(messageLogger);


var errorLogger = new LoggerConfiguration()
.WriteTo.File("C:\\Users\\Jos\\Documents\\Logger\\LogErrors.txt", rollingInterval: RollingInterval.Day)
.MinimumLevel.Error()
.CreateLogger();
builder.Logging.AddSerilog(errorLogger);
// These configurations define how the loggers 
// behave, what information they capture, and where they write the logs.


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
  app.UseExceptionHandler("/Error");
  // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
  app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

app.MapRazorPages();
app.MapHub<ChatHub>("/chatHub");

app.Run();
