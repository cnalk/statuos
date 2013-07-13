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
        public IRepository<Project> ProjectRepository { get; set; }
        public void Handle(ImportProject message)
        {
            ProjectRepository.Add(new BasicProject { CustomerId = 1, ProjectManagerId = 1, Title = message.ProjectName });
        }
    }
}
