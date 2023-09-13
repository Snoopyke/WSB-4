using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http.Headers;

namespace Workers.Data
{
    public static class DataService
    {
        /// <summary>
        ///  Data Service
        /// </summary> 
        /// 
        public static void Write(Company company) // Write json file with emploees
        {
            try
            {
                JsonSerializerSettings settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
                string JsonCompanycontent = JsonConvert.SerializeObject(company, settings);
                File.WriteAllText("Company.json", JsonCompanycontent);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        public static Company Read(string path) // Read json file with employees
            {
            try
            {
                JsonSerializerSettings settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
                if (!File.Exists(path)) { Console.WriteLine("Company.json does not exists"); throw new NullReferenceException(); }
                string JsonCompanycontent =  File.ReadAllText(path);
                Company json = JsonConvert.DeserializeObject<Company>(JsonCompanycontent, settings) ?? new Company();
                return json;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new Company();
            } 
        }
    }
}