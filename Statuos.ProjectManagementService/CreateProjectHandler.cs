using NServiceBus;
using NServiceBus.Logging;
using Statuos.Data;
using Statuos.Domain;
using Statuos.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statuos.ProjectManagementService
{
    public class CreateProjectHandler : IHandleMessages<ImportProject>
    {
        public StatuosContext Context { get; set; }
        public ILog Logger = LogManager.GetLogger(typeof(CreateProjectHandler));

        public void Handle(ImportProject message)
        {
            Logger.Info(string.Format("Starting Create Project For {0} project name is {1}", message.CustomerName, message.ProjectName));
            var customer = Context.Customers.Where(c => c.Name == message.CustomerName).Single();
            var user = Context.Users.Where(u => u.UserName == message.ProjectManager).Single();
            var project = Context.Projects.Where(p => p.CustomerId == customer.Id && p.Title == message.ProjectName).SingleOrDefault();
            if(project == null)
                Context.Projects.Add(new BasicProject { CustomerId = customer.Id, Title = message.ProjectName, ProjectManagerId = user.Id });
        }
    }
}
