//using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Text.Json;
namespace HDFCBankApp.Repositories
{
    public class JSONDataRepository<T> : IDataRepository<T>
    {
        public List<T> Deserialize(string filepath)
        {
            List<T> items = new List<T>();

            // retrive all items from file
            Debug.WriteLine(filepath);
            FileStream stream = new FileStream(filepath, FileMode.Open);
            if (stream != null)
            {
                items = JsonSerializer.Deserialize<List<T>>(stream);
            }

            stream.Close();

            return items;
        }

        public bool Serialize(string filepath, List<T> items)
        {
            /// code for saving
            bool status = false;
            FileStream stream = File.Create(filepath);
            JsonSerializer.Serialize(stream, items);
            stream.Close();
            status = true;
            return status;
        }
    }
}