/*---------------------------------------------------------------------------------------------
 *  Copyright (c) 2017-2018 The International Federation of Red Cross and Red Crescent Societies. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using System;
using Dolittle.Execution;
using Serilog;
using Serilog.Configuration;
using Serilog.Events;

namespace Infrastructure.Logging
{
    public static class SerilogConfigurationExtensions
    {
        public static LoggerConfiguration JsonConsole(this LoggerSinkConfiguration sinkConfiguration, Func<ExecutionContext> getCurrentExecutionContext,
            LogEventLevel restrictedToMinimumLevel = LogEventLevel.Verbose)
        {
            return sinkConfiguration.Sink(new JsonConsoleSink(getCurrentExecutionContext), restrictedToMinimumLevel);
        }
    }
}