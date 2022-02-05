using System.Diagnostics;

namespace GitHubUpdater
{
    public class GitRepoUpdater : IGitRepoUpdater
    {
        public Task StartAsync()
        {
            var gitProcess = new Process();

            ProcessStartInfo gitInfo = new()
            {
                FileName = "git.exe",
                Arguments = "pull",
                WorkingDirectory = @"D:\repos\students\JS",
                UseShellExecute = false
            };

            gitProcess.StartInfo = gitInfo;
            gitProcess.Start();

            gitProcess.WaitForExit();

            gitProcess.Close();
            return Task.CompletedTask;
        }
    }
}