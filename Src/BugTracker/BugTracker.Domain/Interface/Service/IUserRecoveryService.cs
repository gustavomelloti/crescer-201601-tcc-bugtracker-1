﻿using BugTracker.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Domain.Interface.Service
{
    public interface IUserRecoveryService
    {
        void Add(UserRecovery userRecovery);
        UserRecovery FindByEmail(string email);
    }
}
