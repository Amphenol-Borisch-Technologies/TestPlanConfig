using System;
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
            using (XmlReader reader = XmlReader.Create(@"C:\Users\phils\source\repos\TestPlanConfig\TestPlanConfig\T10.xml", settings)) { while (reader.Read()) { } }
        } catch (Exception ex) {
            xmlValid = false;
            Console.WriteLine($"Error: {ex.Message}{Environment.NewLine}");
        }

        if (xmlValid) Console.WriteLine($"XML document is valid.{Environment.NewLine}");
        else Console.WriteLine($"XML document is not valid.{Environment.NewLine}");
    }

    static void ValidationCallback(Object sender, ValidationEventArgs vea) {
        xmlValid = false;
        Console.WriteLine($"Source             : {vea.Exception.Source}");
        Console.WriteLine($"SourceUri          : {vea.Exception.SourceUri}");
        Console.WriteLine($"LineNumber         : {vea.Exception.LineNumber}");
        Console.WriteLine($"LinePosition       : {vea.Exception.LinePosition}");
        Console.WriteLine($"SourceSchemaObject : {vea.Exception.SourceSchemaObject}");
        Console.WriteLine($"Severity           : {vea.Severity}");
        Console.WriteLine($"Message            : {vea.Message}{Environment.NewLine}");
    }
}
