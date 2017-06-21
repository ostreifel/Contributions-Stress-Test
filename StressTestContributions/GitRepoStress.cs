using System;
using Microsoft.TeamFoundation.Core.WebApi;
using Microsoft.TeamFoundation.SourceControl.WebApi;

namespace StressTestContributions
{
    internal class GitRepoStress
    {
        internal static void CreateRepositories(GitHttpClient gitClient)
        {
            for (int i = 0; i < 300; i++)
            {
                var repo = gitClient.CreateRepositoryAsync(new GitRepository {
                    Name = $"StressRepo{i}",
                    ProjectReference = new TeamProjectReference {
                        Id = Config.TargetProject
                    }
                }).Result;
            }
        }
    }
}