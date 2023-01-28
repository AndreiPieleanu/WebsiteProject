using LogicLayer.DALExceptions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.DALs
{
    public abstract class BaseDal
    {
        private readonly DbSettings _settings;

        protected BaseDal(DbSettings settings)
        {
            _settings = settings;
        }

        protected void CreateConnection()
        {

        }

        /// <summary>
        /// Tries to open the connection. Throws an exception if the connection could not be made (in this case it's not connecting to the VPN)
        /// </summary>
        /// <param name="con"></param>
        /// <exception cref="NoConnectionException"></exception>
        protected void TryOpenConnection()
        {
            
        }

        protected void CloseConnection()
        {
            
        }
    }
}
