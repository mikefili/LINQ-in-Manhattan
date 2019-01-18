﻿using System;
using Newtonsoft.Json.Linq;
using System.IO;
using LINQ.classes;
using System.Collections.Generic;

namespace LINQ
{
    public class Program
    {
        public static string dataPath = "C:/Users/Owner/codefellows/401/labs/Lab08-LINQ_In_Manhattan/data.json";

        static void Main(string[] args)
        {
            
            HandleJSON(GetJObject(dataPath));
        }

        public static JObject GetJObject(string path)
        {
            JObject jObject = JObject.Parse(File.ReadAllText(@path));
            return jObject;
        }

        public static JObject HandleJSON(JObject jObject)
        {
            JArray items = (JArray)jObject["features"];
            int dataArr = items.Count;

            for (int i = 0; i < dataArr; i++)
            {
                CityClass city = new CityClass()
                {
                    Address = (string)jObject["features"][i]["properties"]["address"],
                    City = (string)jObject["features"][i]["properties"]["city"],
                    State = (string)jObject["features"][i]["properties"]["state"],
                    Zip = (int)jObject["features"][i]["properties"]["zip"],
                    Borough = (string)jObject["features"][i]["properties"]["borough"],
                    Neighborhood = (string)jObject["features"][i]["properties"]["neighborhood"],
                    County = (string)jObject["features"][i]["properties"]["county"]
                };
                Console.WriteLine();
                Console.WriteLine($"Address: {city.Address}");
                Console.WriteLine($"{city.City}, {city.State} {city.Zip}");
                Console.WriteLine($"Borough: {city.Borough}");
                Console.WriteLine($"Neighborhood: {city.Neighborhood}");
                Console.WriteLine($"County: {city.County}");
            }
            Console.WriteLine();
            return jObject;
        }

        //static IEnumerable<string> filterWithoutNeighborhood(IEnumerable<string> items)
        //{
        //    HandleJSON();
        //    // anonymous type variable
        //    var filterWithoutNeighborhood = from  in bestCats
        //                       where cats.Contains("e")
        //                       select cats;
        //}
    }
}
