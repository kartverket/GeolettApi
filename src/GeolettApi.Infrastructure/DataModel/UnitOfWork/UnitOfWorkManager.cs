﻿using System.Threading;
using Microsoft.Extensions.Logging;

namespace GeolettApi.Infrastructure.DataModel.UnitOfWork
{
    public class UnitOfWorkManager : IUnitOfWorkManager
    {
        private readonly GeolettContext _rootContext;
        private readonly ILogger<UnitOfWorkManager> _logger;
        private int _requestCount;

        public UnitOfWorkManager(
            GeolettContext rootContext,
            ILogger<UnitOfWorkManager> logger)
        {
            _rootContext = rootContext;
            _logger = logger;
        }

        public IUnitOfWork GetUnitOfWork()
        {
            return new UnitOfWork(_rootContext, _logger, Interlocked.Increment(ref _requestCount) == 1);
        }
    }
}
