﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Interfaces
{
    public interface IEmailService
    {
        Task<bool> SendEmail(string email, string subject, string body);
    }
}
