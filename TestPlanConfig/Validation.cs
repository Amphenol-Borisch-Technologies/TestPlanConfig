using System;
using System.Diagnostics;
using System.Text;
using System.Xml;
using System.Xml.Schema;

static class Validator {
    static Boolean xmlValid = true;
    static void Main() {
        XmlSchemaSet schemaSet = new XmlSchemaSet();
        schemaSet.Add(null, @"C:\Users\phils\source\repos\TestPlanConfig\TestPlanConfig\T10.xsd");
        XmlReaderSettings settings = new XmlReaderSettings {
            ValidationType = ValidationType.Schema,
            Schemas = schemaSet
        };
        settings.ValidationEventHandler += ValidationCallback;
        try {
            using (XmlReader reader = XmlReader.Create(@"C:\Users\phils\source\repos\TestPlanConfig\TestPlanConfig\T10.xml", settings)) {
                Double low, high;
                while (reader.Read()) {
                    if (reader.NodeType == XmlNodeType.Element && reader.Name == "MI") {
                        low = Double.Parse(reader.GetAttribute("Low"));
                        high = Double.Parse(reader.GetAttribute("High"));
                        if (low > high) {
                            StringBuilder sb = new StringBuilder();
                            sb.AppendLine($"  MethodInterval's Low > High.");
                            sb.AppendLine($"  Method        : {reader.GetAttribute("Method")}.");
                            sb.AppendLine($"  Description   : {reader.GetAttribute("Description")}.");
                            sb.AppendLine($"  Low           : {reader.GetAttribute("Low")}.");
                            sb.AppendLine($"  High          : {reader.GetAttribute("High")}.");
                            sb.AppendLine($"  Line Number   : {(reader as IXmlLineInfo).LineNumber}.");
                            throw new Exception(sb.ToString());
                        }
                    }
                }
            }
        } catch (Exception ex) {
            xmlValid = false;
            Console.WriteLine($"Error:{Environment.NewLine}{ex.Message}{Environment.NewLine}");
        }

        if (xmlValid) Console.WriteLine($"XML document is valid.{Environment.NewLine}");
        else Console.WriteLine($"XML document is not valid.{Environment.NewLine}");
    }

    static void ValidationCallback(Object sender, ValidationEventArgs vea) {
        xmlValid = false;
        Console.WriteLine($"Error:");
        Console.WriteLine($"  SourceUri     : {vea.Exception.SourceUri}");
        Console.WriteLine($"  Line Number   : {vea.Exception.LineNumber}");
        Console.WriteLine($"  Line Position : {vea.Exception.LinePosition}");
        Console.WriteLine($"{vea.Message}{Environment.NewLine}");
    }
}
