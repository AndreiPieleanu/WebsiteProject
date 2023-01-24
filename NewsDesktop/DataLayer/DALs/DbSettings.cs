using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.DALs
{
    public class DbSettings
    {
        public DbSettings(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public string connectionString { get; private set; }
    }
}
