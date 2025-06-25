using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SauceDemoTests.Logging
{
    public class SerilogAdapter : ILoggerAdapter
    {
        private readonly ILogger _logger;

        public SerilogAdapter()
        {
            _logger = new LoggerConfiguration()
                .WriteTo.Console()
                .CreateLogger();
        }

        public void Info(string message)
        {
            _logger.Information(message);
        }

        public void Error(string message)
        {
            _logger.Error(message);
        }
    }
}
