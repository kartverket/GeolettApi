using Amazon.Runtime.Internal.Util;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeolettApi.Web.Configuration
{
    public static class SerilogConfiguration
    {
        public static void ConfigureSerilog(IConfigurationRoot configuration)
        {
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .Destructure.ByTransforming<RequestMetrics>(JsonConvert.SerializeObject)
                .CreateLogger();
        }
    }
}
