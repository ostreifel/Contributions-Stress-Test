using System;
using Microsoft.TeamFoundation.SourceControl.WebApi;
using Microsoft.VisualStudio.Services.Client;
using Microsoft.VisualStudio.Services.WebApi;

namespace StressTestContributions
{
    class StressTest
    {

        static void Main(string[] args)
        {
            var connection = new VssConnection(new Uri(Config.CollectionUri), new VssClientCredentials());
            var gitClient = connection.GetClient<GitHttpClient>();
            PullRequestStress.CreatePullRequests(gitClient);
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }



    }
}
