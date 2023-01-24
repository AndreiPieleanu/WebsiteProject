﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.DALExceptions
{
    public class NoDataReturnedException: DalException
    {
        public NoDataReturnedException(string message) : base(message) { }
    }
}
