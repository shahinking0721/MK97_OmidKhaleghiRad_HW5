using BusinesRuleProject.Domain;
using BusinesRuleProject.Interface;
using CsvHelper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;

namespace BusinesRuleProject.Database
{
    public class DBStorage
    {
        private string workingDirectory;
        private string projectDirectory;
        public List<Product> productsDB;
        public DBStorage()
        {


            workingDirectory = Environment.CurrentDirectory;
            projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName;
            JsonSerializer serializer = new JsonSerializer();
            
            using (FileStream s = File.Open($"{projectDirectory}/../Database/ProductJson.json", FileMode.Open))
            using (StreamReader sr = new StreamReader(s))
            using (JsonReader reader = new JsonTextReader(sr))
            {
                while (!sr.EndOfStream)
                {
                    productsDB = serializer.Deserialize<List<Product>>(reader);
                }
            }
        }



        public void SaveChanges()
        {
            var userJsonString = JsonConvert.SerializeObject(productsDB);
            File.WriteAllText(@$"{projectDirectory}/../Database/ProductJson.json", userJsonString);
        }
        public List<Product> getAllListProduct()
        {
            return productsDB;
        }
    }
}
    

