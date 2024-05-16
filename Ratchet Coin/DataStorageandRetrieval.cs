using System;
using System.Collections.Generic;

namespace DataStorageandRetrival
{
    public class DataStorageandRetrival
    {
        private Dictionary<string, string> _data;

        public DataStorageandRetrival()
        {
            _data = new Dictionary<string,string>();
        }

        public void StoreData(string key, string value)
        {
            if(_data.ContainsKey(key))
            {
                Console.WriteLine($"Key '{key}' already exists. Updating value...");
                _data[key] = value;
            }
            else
            {
                _data.Add(key, value);
            }
            Console.WriteLine($"Data Stored Successfully with key 'key'");
        }

        public string RetrieveData(string key)
        {
            if(_data.ContainsKey(key))
            {
                return _data[key];
            }
            else
            {
                Console.WriteLine($"Key '{key}' not found. Unable to retrieve data.");
                return null;
            }
        }
    }   
}