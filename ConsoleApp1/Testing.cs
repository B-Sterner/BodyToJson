using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace ConsoleApplication1
{
    public class JsonObject
    {
        Dictionary<string, string> ObjectDictionary = new Dictionary<string, string>();

        public void Add(string key, string val)
        {
            ObjectDictionary[key] = val;
        }
        public void Add(string key, JsonObject jVal)
        {
            var jsonVal = jVal.ToJsonString();
            ObjectDictionary[key] = jsonVal;
        }
        public void Add(string key, string[] aVal)
        {
            AddJasonArray(key, aVal);
        }
        public void AddFromDictionary(Dictionary<string, string> source, string key)
        {
            if (source.ContainsKey(key))
            {
                ObjectDictionary[key] = source[key];
            }
        }

        public void AddJasonArray(string key, string[] args)
        {
            ObjectDictionary[key] = $"[{string.Join(",", args.Select(s => AddQuotes(s)))}]";
        }

        public void AddJasonArray(string key, string value)
        {
            ObjectDictionary[key] = $"[{AddQuotes(value)}]";
        }

        public void AddJasonArray(string key, List<JsonObject> objects)
        {
            ObjectDictionary[key] = $"[{BuildString(objects)}]";
        }

        private string BuildString(List<JsonObject> objects)
        {
            if(objects.Count == 0)
            {
                return "";
            }

            StringBuilder sb = new StringBuilder();
            foreach (JsonObject obj in objects)
            {
                sb.Append(obj.ToJsonString()).Append(",");
            }
            return sb.ToString(0, sb.Length - 1);
        }

        public string ToJsonString()
        {
            if (ObjectDictionary.Count == 0)
                return "{}";
            else
                return $"{{{ConvertDictionaryToJsonString()}}}";
        }

        private string ConvertDictionaryToJsonString()
        {
            return string.Join(
                ",", 
                ObjectDictionary.Select(kv => $"{AddQuotes(kv.Key)}:{AddQuotes(kv.Value)}")
            );
        }

        private string AddQuotes(string value)
        {
            bool skipQuotes = (
                (value.StartsWith("[") && value.EndsWith("]"))
                || (value.StartsWith("{") && value.EndsWith("}"))
            );
            return skipQuotes ? value : $"\"{value}\"";
            //return skipQuotes ? value : $"\\\"{value}\\\"";
        }
    }
}
