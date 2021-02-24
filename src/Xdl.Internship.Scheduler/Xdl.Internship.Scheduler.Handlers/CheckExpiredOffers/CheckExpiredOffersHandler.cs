﻿using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Xdl.Internship.Scheduler.Handlers.CheckExpiredOffers
{
    public class CheckExpiredOffersHandler : IRequestHandler<CheckExpiredOffersRequest>
    {
        public Task<Unit> Handle(CheckExpiredOffersRequest request, CancellationToken cancellationToken)
        {
            Console.WriteLine("MESSAGE FROM HANDLE!!!");
            return (Task<Unit>)Task.CompletedTask;
        }
    }
}