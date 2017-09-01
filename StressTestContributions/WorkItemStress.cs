using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.TeamFoundation.WorkItemTracking.WebApi;
using Microsoft.TeamFoundation.WorkItemTracking.WebApi.Models;
using Microsoft.VisualStudio.Services.WebApi.Patch;
using Microsoft.VisualStudio.Services.WebApi.Patch.Json;

namespace StressTestContributions
{
    internal class WorkItemStress
    {
        internal static void CreateWorkItems(WorkItemTrackingHttpClient witClient)
        {
            for (var i = 0; i < 50000;)
            {
                var createWis = new List<Task<WorkItem>>();
                for (var j = 0; j < 100; j++, i++)
                {
                    createWis.Add(witClient.CreateWorkItemAsync(new JsonPatchDocument {
                        new JsonPatchOperation {
                            From = "value",
                            Path = "/fields/System.Title",
                            Operation = Operation.Add,
                            Value = $"Bug {i}"
                        }
                    }, Config.PrepopulatedRepositoryProject, "Bug"));
                }
                foreach (var wiTask in createWis)
                {
                    var closed = wiTask.Result;
                }
                //var closeWis = new List<Task<WorkItem>>();
                //foreach (var wiTask in createWis)
                //{
                //    var workItem = wiTask.Result;
                //    closeWis.Add(witClient.UpdateWorkItemAsync(new JsonPatchDocument {
                //        new JsonPatchOperation {
                //            From = "value",
                //            Path = "/fields/System.State",
                //            Operation = Operation.Add,
                //            Value = "Closed"
                //        }
                //    }, workItem.Id.Value));
                //}
                //foreach (var wiTask in closeWis)
                //{
                //    var closed = wiTask.Result;
                //}
                Console.WriteLine($"Created wi {i} workitems");
            }
        }
    }
}