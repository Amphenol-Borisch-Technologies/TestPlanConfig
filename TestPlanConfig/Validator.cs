using System;
using System.Text;
using System.Xml;
using System.Xml.Schema;

namespace TestSequencer {
    internal class Validator {
        private static Boolean xmlValid = true;
        private static readonly StringBuilder messages = new StringBuilder();
        private static readonly String xmlFile = @"C:\Users\phils\source\repos\TestPlanConfig\TestPlanConfig\T10.xml";
        private static readonly String xsdFile = @"C:\Users\phils\source\repos\TestPlanConfig\TestPlanConfig\T10.xsd";
        private static XmlReader reader;

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
                using (reader = XmlReader.Create(xmlFile, settings)) {
                    Double low, high;
                    while (reader.Read()) {
                        if (reader.NodeType == XmlNodeType.Element && reader.Name == "MI") {
                            // NOTE: This if block required because Microsoft's Visual Studio only supports XML Schema 1.0.
                            // - If Visual Studio supported XSD 1.1, then <xs:assert test="@Low le @High"/>  would obviate this block.
                            // - Below NOTES compare some mainstream XML editing options.
                            //
                            // NOTE: XML Liquid Studio Community Edition supports XML Schema 1.1.
                            // - Liquid Studio is a powerful but complex external XML editor.
                            // - It's co$t free and it's license permits commericial usage.
                            // - Confirmed it detects Low > High occurences via <xs:assert test="@Low le @High"/>.
                            // - Chose to not utilize Liquid Studio because it adds too much complexity at this time.
                            //
                            // NOTE: XML Notepad supports XML Schema 1.0.
                            // - XML Notepad is a powerful but simple external XML editor.
                            // - It's co$t free and it's license permits commericial usage.
                            //
                            // NOTE: Visual Studio Code with Red Hat's XML extension supports XML Schema 1.0.
                            // - VS Code is a powerful but complex external multi-purpose editor.
                            // - It's co$t free and it's license permits commericial usage.
                            //   - Red Hat's XML extension provides XML Schema 1.0 support.
                            //   - Tried several other provider's XML extensions, but none supported XML schema 1.1.
                            //   - As a multi-purpose editor, can develop C# .Net applications.  Plus many other languages.
                            //
                            // NOTE: Visual Studio's supports XML Schema 1.0.
                            // - Visual Studio's integrated XML editor is powerful but complex.
                            //   - Being integrated with Visual Studio is incredibly convenient however.
                            //   - Visual Studio isn't co$t free, but permits commercial use.
                            //   - As a multi-purpose editor, can develop C# .Net applications.  Plus many other languages.
                            low = Double.Parse(reader.GetAttribute("Low"));
                            high = Double.Parse(reader.GetAttribute("High"));
                            if (low > high) {
                                xmlValid = false;
                                messages.AppendLine($"MethodInterval's Low > High:");
                                messages.AppendLine($"  Line Number   : {(reader as IXmlLineInfo).LineNumber}");
                                messages.AppendLine($"  Line Position : {(reader as IXmlLineInfo).LinePosition}");
                                messages.AppendLine($"  Node Type     : {reader.NodeType}");
                                messages.AppendLine($"  Description   : {reader.GetAttribute("Description")}");
                                messages.AppendLine($"  Method        : {reader.GetAttribute("Method")}");
                                messages.AppendLine($"  Low           : {reader.GetAttribute("Low")}");
                                messages.AppendLine($"  High          : {reader.GetAttribute("High")}");
                                messages.AppendLine($"  XML           : {reader.ReadOuterXml()}{Environment.NewLine}");
                            }
                        }
                    }
                }
            } catch (Exception ex) {
                xmlValid = false;
                messages.AppendLine($"Exception:");
                messages.AppendLine($"  Exception     : {ex.Message}{Environment.NewLine}");
            }

            if (!xmlValid) {
                messages.AppendLine($"XML document invalid: file:///{xmlFile}.{Environment.NewLine}");
                CustomMessageBox.Show(Title: "XML Document Invalid", Message: messages.ToString(), OptionalIcon: System.Drawing.SystemIcons.Error);
            }
        }

        private static void ValidationCallback(Object sender, ValidationEventArgs vea) {
            xmlValid = false;
            messages.AppendLine($"Validation Event:");
            messages.AppendLine($"  Line Number   : {vea.Exception.LineNumber}");
            messages.AppendLine($"  Line Position : {vea.Exception.LinePosition}");
            messages.AppendLine($"  Severity      : {vea.Severity}");
            messages.AppendLine($"  Node Type     : {reader.NodeType}");
            messages.AppendLine($"  Description   : {reader.GetAttribute("Description")}");
            messages.AppendLine($"  XML           : {reader.ReadOuterXml()}");
            messages.AppendLine($"  Message       : {vea.Message}{Environment.NewLine}");
        }
    }
}
