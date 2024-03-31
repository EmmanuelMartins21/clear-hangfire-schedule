namespace clear_hangfire_schedule.Services
{
    public class ClearDirectoryService : IClearDirectoryService
    {
        public Task DeleteFilesOlderThan3Months()
        {
            Console.WriteLine("Inicio do Job " + DateTime.Now);
            string downloadsFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            downloadsFolderPath = Path.Combine(downloadsFolderPath, "Downloads");

            if (Directory.Exists(downloadsFolderPath))
            {
                DirectoryInfo downloadsDirectory = new DirectoryInfo(downloadsFolderPath);

                FileInfo[] files = downloadsDirectory.GetFiles();

                foreach (FileInfo file in files)
                {
                    if (file.LastWriteTime < DateTime.Now.AddMonths(-3))
                    {
                        file.Delete();
                        Console.WriteLine($"Arquivo deletado: {file.FullName}");
                    }
                }
                Console.WriteLine("Deleção de arquivos concluída.");
                return Task.CompletedTask;                
            }
            else
            {
                Console.WriteLine("A pasta de Downloads não foi encontrada.");
                return Task.CompletedTask;
            }
        }

    }
}
