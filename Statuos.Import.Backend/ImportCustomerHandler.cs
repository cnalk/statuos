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
        public IStatuosContext Context { get; set; }
        public IBus Bus { get; set; }
        public void Handle(ImportCustomer message)
        {            
            Context.Customers.Add(new Customer { Name = message.Name, Code = message.Code });
        }
    }
}
