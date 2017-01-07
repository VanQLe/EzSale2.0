using Serilog.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog.Events;
using System.Reflection;

namespace PrideTek.EzSale.Infrastructure.Logging
{
    public class ApplicationDetailsEnricher : ILogEventEnricher
    {
        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            var applicationAssembly = Assembly.GetEntryAssembly();

            var name = applicationAssembly.GetName();
            var version = applicationAssembly.GetName().Version;

            logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty(StaticStrings.AppName, name));
            logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty(StaticStrings.AppVersion, version));
        }
    }
}
