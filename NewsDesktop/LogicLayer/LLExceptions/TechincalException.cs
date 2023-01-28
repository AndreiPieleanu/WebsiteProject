using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.LLExceptions
{
    public class TechincalException: Exception
    {
        public TechincalException(string message): base(message) { }
    }
}
