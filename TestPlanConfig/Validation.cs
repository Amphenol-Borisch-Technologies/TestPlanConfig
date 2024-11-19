using System;
using System.Xml;
using System.Xml.Schema;

class Validator {
    static Boolean xmlValid = true;
    static void Main() {
        XmlSchemaSet schemaSet = new XmlSchemaSet();
        schemaSet.Add(null, @"C:\Users\phils\source\repos\TestPlanConfig\TestPlanConfig\T10.xsd");
        XmlReaderSettings settings = new XmlReaderSettings {
            ValidationType = ValidationType.Schema,
            Schemas = schemaSet
        };
        settings.ValidationEventHandler += ValidationCallback;

        using (XmlReader reader = XmlReader.Create(@"C:\Users\phils\source\repos\TestPlanConfig\TestPlanConfig\T10.xml", settings)) {
            while (reader.Read()) { }
        }

        if (xmlValid) Console.WriteLine("XML document is valid.");
    }

    static void ValidationCallback(Object sender, ValidationEventArgs e) {
        xmlValid = false;
        if (e.Severity == XmlSeverityType.Warning) {
            Console.WriteLine($"Warning: {e.Message}");
        } else if (e.Severity == XmlSeverityType.Error) {
            Console.WriteLine($"Error: {e.Message}");
        }
    }
}
