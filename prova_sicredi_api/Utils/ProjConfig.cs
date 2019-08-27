using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prova_sicredi_api.Utils
{
    class ProjConfig
    {
        public static string GetPath(string file)
        {
            return Directory.GetParent(Directory.GetParent(System.AppDomain.CurrentDomain.BaseDirectory).Parent.FullName).Parent.FullName + file;
        }
    }
}
