﻿using System;
using System.Text;
using System.Xml;
using System.Xml.Schema;

static class Validator {
    static Boolean xmlValid = true;
    static StringBuilder messages = new StringBuilder();

    [STAThreadAttribute] 
    public static void Main() {
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
                            xmlValid = false;
                            messages.AppendLine($"Error:");
                            messages.AppendLine($"  MethodInterval's Low > High.");
                            messages.AppendLine($"  Method        : {reader.GetAttribute("Method")}.");
                            messages.AppendLine($"  Description   : {reader.GetAttribute("Description")}.");
                            messages.AppendLine($"  Low           : {reader.GetAttribute("Low")}.");
                            messages.AppendLine($"  High          : {reader.GetAttribute("High")}.");
                            messages.AppendLine($"  Line Number   : {(reader as IXmlLineInfo).LineNumber}.{Environment.NewLine}");
                        }
                    }
                }
            }
        } catch (Exception ex) {
            xmlValid = false;
            messages.AppendLine($"Error:{Environment.NewLine}{ex.Message}{Environment.NewLine}");
        }

        if (!xmlValid) {
            messages.AppendLine($"XML document is not valid.{Environment.NewLine}");
            CustomMessageBox.Show(messages.ToString());
        }
    }

    static void ValidationCallback(Object sender, ValidationEventArgs vea) {
        xmlValid = false;
        messages.AppendLine($"Error:");
        messages.AppendLine($"  SourceUri     : {vea.Exception.SourceUri}");
        messages.AppendLine($"  Line Number   : {vea.Exception.LineNumber}");
        messages.AppendLine($"  Line Position : {vea.Exception.LinePosition}");
        messages.AppendLine($"{vea.Message}{Environment.NewLine}");
    }
}
