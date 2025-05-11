using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace NewtonSoftVsSystemText
{
    public static class SystemTextinator
    {
        public static string Serialize<T>(T obj)
        {
            return System.Text.Json.JsonSerializer.Serialize(obj);
        }

        public static T Deserialize<T>(string json)
        {
            try
            {
                return System.Text.Json.JsonSerializer.Deserialize<T>(json);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return default;
            }
        }

        public static T Deserialize<T>(string json, JsonSerializerOptions settings)
        {
            try
            {
                return System.Text.Json.JsonSerializer.Deserialize<T>(json, settings);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return default;
            }
        }
    }
}
