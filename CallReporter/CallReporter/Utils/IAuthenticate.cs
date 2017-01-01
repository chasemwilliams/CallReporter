﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CallReporter.Utils
{
    public interface IAuthenticate
    {
        Task<bool> Authenticate(string provider);
    };
}
