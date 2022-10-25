using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITJob.CommandService.SeedWorks.Exceptions
{
    public class CommandServiceException : Exception
    {
        /// <summary/>
        /// <param name="message"></param>
        public CommandServiceException(string message)
            : base(message)
        {
        }
    }
}
