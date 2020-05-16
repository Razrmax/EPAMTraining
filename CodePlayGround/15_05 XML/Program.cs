using System;
using System.Xml;
using System.Xml.Linq;

namespace _15_05_XML
{
    class Program
    {
        static void Main(string[] args)
        {
            XNamespace nameSpace = "http://Test.net/LINQ";
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(@"C:\Users\Maxim\Desktop\Programming\EPAMTraining\CodePlayGround\15_05 XML\XMLFile1.xml");
            XmlElement xRoot = xDoc.DocumentElement; foreach (XmlNode xnode in xRoot)
            {
                if (xnode.Attributes.Count > 0)
                {
                    XmlNode attr = xnode.Attributes.GetNamedItem("name"); if (attr != null)
                        Console.WriteLine(attr.Value);
                }
                foreach (XmlNode childnode in xnode.ChildNodes)
                {
                    if (childnode.Name == "company")
                    {
                        Console.WriteLine($"Компания:{ childnode.InnerText}");
                    }
                    if (childnode.Name == "age")
                    {
                        Console.WriteLine($"Возраст:{ childnode.InnerText}");
                    }
                }
                Console.WriteLine();
            }

            XElement name = new XElement("Name", "Alex");
            Console.WriteLine(name.ToString());

            name = new XElement("Person", 
                new XElement("FirstName", "Alex"), 
                new XElement("LastName", "Erohin"));
            Console.WriteLine("XML: \n\n" + name + "\n\nИзвлекаем значение:" + (string)name);

            try
            {
                XElement smoker = new XElement("Smoker", "Tue");
                Console.WriteLine(smoker);
                Console.WriteLine((bool) smoker);
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            //XDocument xDocument = new XDocument(
            //    new XAttribute(XNamespace.Xmlns + "linq", nameSpace),
            //    new XElement("Employee",
            //        new XAttribute("type", "Programmer"),
            //        new XElement("FirstName", "Alex"),
            //        new XElement("LastName", "Erohin")),
            //    new XElement("Employee"),
            //    new XAttribute("type", "Editor"),
            //    new XElement("FirstName", "Elena"));
            //Console.WriteLine(xDocument.ToString());
            Console.Read();
        }
        }
}
