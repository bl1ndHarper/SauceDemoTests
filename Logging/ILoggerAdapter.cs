using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SauceDemoTests.Logging
{
    public interface ILoggerAdapter
    {
        void Info(string message);
        void Error(string message);
    }
}
