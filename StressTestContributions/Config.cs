using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StressTestContributions
{
    // These could be made into parameters later
    public static class Config
    {
        public const string CollectionUri = "https://ottost.visualstudio.com/";
        public static readonly Guid PrepopulatedGitRepositoryGuid = Guid.Parse("390e002c-fd5b-45b4-adf7-7c38efc1afcf");
        public static readonly Guid TargetProject = Guid.Parse("660a5451-fa9d-4d24-bd99-c06d737b98ea");
        public const string PrepopulatedRepositoryProject = "Sample Project";
        /// <summary>
        /// There isn't a good way to create alot of commits with the client library use IonicaBizau/github-contributions instead
        /// </summary>
        public const string PrepopulatedGitRepository = "GeneratedRepo";
    }
}
