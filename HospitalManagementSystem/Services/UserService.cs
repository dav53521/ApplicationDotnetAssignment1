﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDotnetAssignment1.Services
{
    public abstract class UserService<T>
    {
        T Repository { get; set; }

        public abstract void PrintMainMenu();
    }
}
