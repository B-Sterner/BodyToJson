using System;
using System.Collections;
using System.Collections.Generic;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            JsonObjectDemo.JsonObjectDemoSetUp();
            Console.ReadLine();
        }
    }



    public static class JsonObjectDemo
    {
        public static void JsonObjectDemoSetUp()
        {
            Dictionary<string, string> contactInfo = new Dictionary<string, string>();
            contactInfo["title"] = "Awesome Title!";
            contactInfo["title2"] = "Awesome Title2!";

            JsonObject subBody2 = new JsonObject();
            subBody2.Add("sb2_1", "sub2CustomValue1");
            subBody2.Add("sb2_2", "sub2CustomValue2");

            JsonObject subBody = new JsonObject();
            subBody.Add("sb1_1", "subCustomValue1");
            subBody.Add("sb1_2", "subCustomValue2");
            subBody.Add("subBody2", subBody2);

            string[] codes2 = "Y2k,UT".Split(",");
            subBody.Add("codes2", codes2);

            JsonObject body = new JsonObject();
            body.AddFromDictionary(contactInfo, "title");
            body.AddFromDictionary(contactInfo, "title2");
            body.Add("CustomTitle1", "CustomValue1");
            body.Add("subBody", subBody);


            List<JsonObject> ListOfJsonObjects = new List<JsonObject>
            {
                subBody2,
                subBody2,
                subBody2
            };
            body.AddJasonArray("ListOfBodies", ListOfJsonObjects);

            Console.WriteLine(body.ToJsonString());
        }
    }
}
