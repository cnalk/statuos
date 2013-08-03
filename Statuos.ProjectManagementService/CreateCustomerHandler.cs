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
    public class CreateCustomerHandler : IHandleMessages<ImportCustomer>
    {
        public StatuosContext Context { get; set; }
        public ILog Logger = LogManager.GetLogger(typeof(CreateCustomerHandler));

        public void Handle(ImportCustomer message)
        {
            Logger.Info(string.Format("Starting Create Customer {0}", message.Name));
            var customer = Context.Customers.Where(c => c.Name == message.Name).SingleOrDefault();
            if (customer == null)
                Context.Customers.Add(new Customer { Name = message.Name, Code = message.Code });
        }
    }
}
