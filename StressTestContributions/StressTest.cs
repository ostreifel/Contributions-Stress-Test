using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.TeamFoundation.SourceControl.WebApi;
using Microsoft.TeamFoundation.WorkItemTracking.WebApi;
using Microsoft.VisualStudio.Services.Common;
using Microsoft.VisualStudio.Services.WebApi;

namespace StressTestContributions
{
    class StressTest
    {

        static void Main(string[] args)
        {
            var connection = new VssConnection(new Uri(Config.CollectionUri), new VssCredentials());
            var gitClient = connection.GetClient<GitHttpClient>();
            PullRequestStress.CreatePullRequests(gitClient);
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }



    }
}
