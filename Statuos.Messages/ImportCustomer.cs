﻿using NServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statuos.Messages
{
    public class ImportCustomer : ICommand
    {
        public string Name { get; set; }
    }
}