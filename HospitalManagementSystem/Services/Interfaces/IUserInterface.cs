﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDotnetAssignment1.Services.Interfaces
{
    public interface IUserInterface
    {
        public bool AreLoginDetailsCorrect(int inputtedId, string password);
    }
}
