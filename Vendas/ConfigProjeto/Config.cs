using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vendas.ConfigProjeto
{
    public class Config
    {

#if (DEBUG)
        public static string ArquivoConfig { get; set; } = "Config_Debug.config";
#else
        public static string ArquivoConfig { get; set; } = "Config_Release.config";
#endif

    }
}