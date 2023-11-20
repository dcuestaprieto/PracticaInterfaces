using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaInterfacesPrimerTrimestre
{
    public class GetRoute
    {
        public static string ReturnRoute(string DB_name)
        {
            return Path.Combine(FileSystem.AppDataDirectory, DB_name);
        }
    }
}

