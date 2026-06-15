using System;
using System.ComponentModel;
using System.Configuration;
using System.Linq;

namespace HotelBooking.Entity.Common
{
    public static class ConfigurationConstants
    {
        //public static bool IsAllowInsecureHttp()
        //{
        //    bool result = false;
        //    var configValue = ConfigurationManager.AppSettings["IsAllowInsecureHttp"];
        //    bool.TryParse(configValue, out result);
        //    return result;
        //}

        public static string HostingEnv_ContentRootPath { get; set; }
    }
}
