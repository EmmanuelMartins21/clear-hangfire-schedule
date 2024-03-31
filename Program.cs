using clear_hangfire_schedule.Services;
using Hangfire;
using Hangfire.MemoryStorage;

var builder = WebApplication.CreateBuilder(args);

var _service = new ClearDirectoryService();
builder.Services.AddHangfire(config =>
{
    config.UseMemoryStorage();
});
builder.Services.AddHangfireServer();

var app = builder.Build();

app.UseHangfireDashboard();

RecurringJob.AddOrUpdate("DeleteRecorrente", () => _service.DeleteFilesOlderThan3Months(), Cron.Weekly(),
    new RecurringJobOptions { TimeZone = TimeZoneInfo.Local });


app.Run();
