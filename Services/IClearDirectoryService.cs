namespace clear_hangfire_schedule.Services
{
    public interface IClearDirectoryService
    {
        public Task DeleteFilesOlderThan3Months();
    }
}
