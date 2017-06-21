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
            var commits = client.GetCommitsAsync(Config.PrepopulatedRepositoryProject, Config.PrepopulatedGitRepository, criteria, 0, 10000).Result;
            Console.WriteLine($"Retreived {commits.Count} commits");

            var someCommits = commits.Skip(1).Take(1000);
            var branchNumber = 0;
            var branches = client.UpdateRefsAsync(someCommits.Select(c => new GitRefUpdate
            {
                Name = $"refs/heads/branch{branchNumber++}",
                RepositoryId = Config.PrepopulatedGitRepositoryGuid,
                OldObjectId = "0000000000000000000000000000000000000000",
                NewObjectId = c.CommitId
            }), Config.PrepopulatedGitRepositoryGuid).Result;
            Console.WriteLine($"Created {branches.Count} branches");
            var firstBranch = branches.First();
            var otherBranches = branches.Skip(1);
            foreach (var branch in otherBranches) {
                var pullRequest = client.CreatePullRequestAsync(new GitPullRequest {
                    SourceRefName = branch.Name,
                    TargetRefName = firstBranch.Name,
                    Title = $"Merge {branch.Name} to {firstBranch.Name}"
                }, Config.PrepopulatedGitRepositoryGuid).Result;
                Console.WriteLine($"Created pullrequest {pullRequest.Title}");
            }
        }
    }
}
