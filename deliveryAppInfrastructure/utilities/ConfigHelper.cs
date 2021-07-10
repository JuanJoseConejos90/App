using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace deliveryAppInfrastructure.utilities
{
    public static class ConfigHelper
    {
        private static readonly IConfigurationRoot Configuration;
        static ConfigHelper()
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

        }
        public static T GetConfig<T>(string key, T defaultValue)
        {
            try
            {
                var result = Configuration[key];
                return (T)Convert.ChangeType(result, typeof(T));
            }
            catch (Exception)
            {
                if (defaultValue != null)
                {
                    return defaultValue;
                }
                return default(T);
            }
        }

        public static T GetConfig<T>(string key)
        {
            try
            {
                var result = Configuration[key];
                return (T)Convert.ChangeType(result, typeof(T));
            }
            catch (Exception)
            {
                throw new Exception(string.Format("{0} is not found in the configuration file appSettings configuration, check profile configuration!", key));
            }
        }
    }
}
