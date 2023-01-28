using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.LLExceptions
{
    public class NewsOperationException: Exception
    {
        public NewsOperationException(string message): base(message) { }
    }
}
