using NServiceBus;
using Statuos.Data;
using Statuos.Domain;
using Statuos.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statuos.Import.Backend
{
    public class ImportProjectHandler : IHandleMessages<ImportProject>
    {
        public IStatuosContext Context { get; set; }
        public void Handle(ImportProject message)
        {
            var customer = Context.Customers.Where(c => c.Name == message.CustomerName).FirstOrDefault();
            var user = Context.Users.Where(u => u.UserName == message.ProjectManager).SingleOrDefault();
            var project = new BasicProject { CustomerId = customer.Id, Title = message.ProjectName, ProjectManagerId = user.Id };
            Context.Projects.Add(project);
        }
    }
}
