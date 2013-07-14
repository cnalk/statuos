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
    public class ImportCustomerHandler : IHandleMessages<ImportCustomer>
    {
        public IRepository<Customer> CustomerRepository { get; set; }
        public void Handle(ImportCustomer message)
        {
            IStatuosContext context = new StatuosContext();
            context.Customers.Add(new Customer { Name = message.Name, Code = message.Code });
            context.Save();
            context.Dispose();
        }
    }
}
