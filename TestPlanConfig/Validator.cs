using System;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using static System.Net.Mime.MediaTypeNames;

namespace TestSequencer {
    internal static class Validator {
        private static Boolean xmlValid = true;
        private static readonly StringBuilder messages = new StringBuilder();
        private static readonly String xmlFile = @"C:\Users\phils\source\repos\TestPlanConfig\TestPlanConfig\T10.xml";
        private static readonly String xsdFile = @"C:\Users\phils\source\repos\TestPlanConfig\TestPlanConfig\T10.xsd";

        [STAThreadAttribute]
        public static void Main() {
            XmlSchemaSet schemaSet = new XmlSchemaSet();
            schemaSet.Add(null, xsdFile);
            XmlReaderSettings settings = new XmlReaderSettings {
                ValidationType = ValidationType.Schema,
                Schemas = schemaSet
            };
            settings.ValidationEventHandler += ValidationCallback;
            try {
                using (XmlReader reader = XmlReader.Create(xmlFile, settings)) {
                    Double low, high;
                    while (reader.Read()) {
                        if (reader.NodeType == XmlNodeType.Element && reader.Name == "MI") {
                            // NOTE: This if block required because Microsoft Visual Studio only supports XML Schema 1.0.
                            // - If Visual Studio supported XSD 1.1, then <xs:assert test="@Low le @High"/>
                            //   would obviate this if block.
                            // - XML Liquid Studio Community Edition supports XML Schema 1.1.
                            // - Microsoft Visual Studio only supports XML schema 1.0.
                            // - Microsoft Visual Studio Code with Red Hat's XML extension only supports XML schema 1.0.
                            //   - Tried several other VS Code extensions, but they didn't support XML schema 1.1 either.
                            // - XML Notepad only supports only supports XML schema 1.0.
                            low = Double.Parse(reader.GetAttribute("Low"));
                            high = Double.Parse(reader.GetAttribute("High"));
                            if (low > high) {
                                xmlValid = false;
                                messages.AppendLine($"Error:");
                                messages.AppendLine($"  MethodInterval's Low > High.");
                                messages.AppendLine($"  Method        : {reader.GetAttribute("Method")}");
                                messages.AppendLine($"  Description   : {reader.GetAttribute("Description")}");
                                messages.AppendLine($"  Low           : {reader.GetAttribute("Low")}");
                                messages.AppendLine($"  High          : {reader.GetAttribute("High")}");
                                messages.AppendLine($"  Line Number   : {(reader as IXmlLineInfo).LineNumber}{Environment.NewLine}");
                            }
                        }
                    }
                }
            } catch (Exception ex) {
                xmlValid = false;
                messages.AppendLine($"Error:{Environment.NewLine}{ex.Message}{Environment.NewLine}");
            }

            if (!xmlValid) {
                messages.AppendLine($"XML document invalid: file:///{xmlFile}.{Environment.NewLine}");
                CustomMessageBox.Show(Title: "XML Document Invalid", Message: messages.ToString(), OptionalIcon: System.Drawing.SystemIcons.Error);
            }
        }

        private static void ValidationCallback(Object sender, ValidationEventArgs vea) {
            xmlValid = false;
            messages.AppendLine($"Error:");
            messages.AppendLine($"  SourceUri     : {vea.Exception.SourceUri}");
            messages.AppendLine($"  Line Number   : {vea.Exception.LineNumber}");
            messages.AppendLine($"  Line Position : {vea.Exception.LinePosition}");
            messages.AppendLine($"{vea.Message}{Environment.NewLine}");
        }
    }
}
