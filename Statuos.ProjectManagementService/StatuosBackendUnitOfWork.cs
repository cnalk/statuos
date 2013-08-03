using NServiceBus.Logging;
using NServiceBus.UnitOfWork;
using Statuos.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statuos.ProjectManagementService
{
    public class StatuosBackendUnitOfWork : IManageUnitsOfWork
    {
        public StatuosContext Context { get; set; }
        private static readonly ILog Logger = LogManager.GetLogger(typeof(StatuosBackendUnitOfWork));
        public void Begin()
        {
            Logger.Info("Unit of work started");
        }

        public void End(Exception ex = null)
        {
            if (ex == null)
            {
                Context.Save();
            }
            else
            {
                Logger.Info("Rollback changes due to an error");
            }
        }
    }
}
