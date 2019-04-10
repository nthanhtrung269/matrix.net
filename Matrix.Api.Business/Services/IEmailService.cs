﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Matrix.Framework.Business;

namespace Matrix.Api.Business.Services
{
    public interface IEmailService : IService
    {
        Task<Guid> SendMail(Guid application, List<string> to, List<string> cc, List<string> bcc, string subject, string body, bool html);
    }
}