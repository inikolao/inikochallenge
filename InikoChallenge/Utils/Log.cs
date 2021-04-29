using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InikoChallenge.Utils
{
	/// <summary>
	/// Class that is used to provide application logging functionality.
	/// </summary>
	public class Log
	{

        /// <summary>
        /// Gets the application logger.
        /// </summary>
        /// <value>
        /// The application logger.
        /// </value>
        public static Logger Logger
        {
            get
            {
                return NLog.LogManager.GetCurrentClassLogger();
            }
        }
    }
}
