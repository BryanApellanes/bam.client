﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Bam.Client
{
    public interface IOperationArguments : IArguments
    {
        string OperationName { get; }
    }
}
