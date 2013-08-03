using NServiceBus;
using NServiceBus.Logging;
using Statuos.Data;
using Statuos.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statuos.ProjectManagementService
{
    public class ImportTaskHandler : IHandleMessages<ImportTaskHours>
    {
        public IBus Bus { get; set; }
        public StatuosContext Context { get; set; }
        public ILog Logger = LogManager.GetLogger(typeof(ImportTaskHandler));

        public void Handle(ImportTaskHours message)
        {
            Logger.Info(string.Format("Starting Import Task Hours for {0} hours is {1}", message.TaskName, message.Hours));
            var project = Context.Projects.Where(p => p.Title == message.ProjectName && p.Customer.Name == message.CustomerName).Single();
            var task = Context.Tasks.Where(t => t.ProjectId == project.Id && t.Title == message.TaskName).Single();
            var user = Context.Users.Where(u => u.UserName == message.UserName).Single();
            task.Charges.Add(new Domain.Charge { Date = message.DateCharged == DateTime.MinValue ? DateTime.Now : message.DateCharged, Hours = message.Hours, User = user });
            Bus.Publish<ITaskImportSucceeded>(m => { m.ImportId = message.ImportId; });
        }
    }
}
