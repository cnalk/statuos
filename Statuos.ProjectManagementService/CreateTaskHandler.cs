using NServiceBus;
using NServiceBus.Logging;
using Statuos.Data;
using Statuos.Domain;
using Statuos.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Statuos.ProjectManagementService
{
    public class CreateTaskHandler : IHandleMessages<CreateTask>
    {
        public StatuosContext Context { get; set; }
        public ILog Logger = LogManager.GetLogger(typeof(CreateTaskHandler));

        public void Handle(CreateTask message)
        {
            Logger.Info(string.Format("Starting create task for {0}", message.TaskName));
            var project = Context.Projects.Where(p => p.Title == message.ProjectName && p.Customer.Name == message.CustomerName).Single();
            var task = Context.Tasks.Where(t => t.ProjectId == project.Id && t.Title == message.TaskName).SingleOrDefault();
            if(task == null)
                Context.Tasks.Add(new BasicTask { ProjectId = project.Id, Title = message.TaskName });
        }
    }
}
