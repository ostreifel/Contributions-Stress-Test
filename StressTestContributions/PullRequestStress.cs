using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.TeamFoundation.SourceControl.WebApi;

namespace StressTestContributions
{
    public static class PullRequestStress
    {
        public static void CreatePullRequests(GitHttpClient client)
        {
            var criteria = new GitQueryCommitsCriteria
            {
                
            };
            var commits = client.GetCommitsAsync(Config.PrepopulatedRepoProject, Config.PrepopulatedGitRepository, criteria, 0, 10000).Result;
            Console.WriteLine($"Retreived {commits.Count} commits");
        }
    }
}
