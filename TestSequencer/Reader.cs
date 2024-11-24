using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace TestSequencer {
    class Reader {
        enum METHODS { MC, MI, MP, MT }
        private struct Test {
            internal const String Operation = "TO";
            internal const String Group = "TG";
        }

        private struct Method {
            internal const String Custom = "MC";
            internal const String Interval = "MI";
            internal const String Process = "MP";
            internal const String Textual = "MT";
        }

        [STAThreadAttribute]
        public static void Main() {
            XDocument tocf = XDocument.Load(Properties.Resources.XML_File);
            XElement toElement = tocf.Element(Test.Operation);
            String folder = (toElement.Attribute("Folder")?.Value);
            String description = (toElement.Attribute("Description")?.Value);
            Console.WriteLine($"Folder            : {folder}");
            Console.WriteLine($"Description       : {description}");

            IEnumerable<XElement> tgElements = toElement.Elements(Test.Group);
            foreach (XElement tg in tgElements) {
                String tgClass = tg.Attribute("Class")?.Value;
                String tgDescription = tg.Attribute("Description")?.Value;

                Boolean tgCancelIfFail = Boolean.Parse(tg.Attribute("CancelIfFail")?.Value);
                Boolean i = Boolean.Parse(tg.Attribute("Independent")?.Value);
                Console.WriteLine($"\nTG Class          : {tgClass}");
                Console.WriteLine($"TG Description    : {tgDescription}");
                Console.WriteLine($"Cancel If Fail    : {tgCancelIfFail}");
                Console.WriteLine($"Independent       : {i}");

                IEnumerable<XElement> methods = tg.Elements();
                foreach (XElement method in methods) {
                    if (!Enum.TryParse(method.Name.LocalName, out METHODS m)) throw new ArgumentException($"Invalid Method element {method.Name.LocalName}.");
                    String methodName = method.Attribute("Method")?.Value;
                    String methodDescription = method.Attribute("Description")?.Value;
                    Boolean methodCancelIfFail = Boolean.Parse(method.Attribute("CancelIfFail")?.Value);

                    Console.WriteLine($"\nMethod Type       : {m}");
                    Console.WriteLine($"  Method          : {methodName}");
                    Console.WriteLine($"  Description     : {methodDescription}");
                    Console.WriteLine($"  Cancel If Fail  : {methodCancelIfFail}");

                    // TODO: Use Activator.CreateInstance to auto-create appropriate TestMeasurement objects, eliminating below switch.
                    // TODO: Rename TestMeasurement objects to TestMethod objects?
                    switch (m) {
                        case METHODS.MC:
                            IEnumerable<XElement> parameters = method.Elements("Parameter");
                            foreach (XElement parameter in parameters) {
                                String key = parameter.Attribute("Key")?.Value;
                                String value = parameter.Attribute("Value")?.Value;
                                Console.WriteLine($"    Parameter Key : {key}, Value: {value}");
                            }
                            break;
                        case METHODS.MI:
                            Double low = Double.Parse(method.Attribute("Low")?.Value);
                            Double high = Double.Parse(method.Attribute("High")?.Value);
                            if (low > high) {
                                throw new ArgumentException($"Invalid Method element {method.Name.LocalName}:{Environment.NewLine}" +
                                    $"Method      :{methodName}{Environment.NewLine}" +
                                    $"Description :{methodDescription}{Environment.NewLine}" +
                                    $"Invalidity  : Low '{low}' is > High '{high}'.{Environment.NewLine}");
                            }
                            Int32 fractionalDigits = Int32.Parse(method.Attribute("FractionalDigits")?.Value);
                            String unitPrefix = method.Attribute("UnitPrefix")?.Value;
                            String units = method.Attribute("Units")?.Value;
                            String unitSuffix = method.Attribute("UnitSuffix")?.Value;
                            Console.WriteLine($"    Low           : {low}");
                            Console.WriteLine($"    High          : {high}");
                            Console.WriteLine($"    FracDigits    : {fractionalDigits}");
                            Console.WriteLine($"    UnitPrefix    : {unitPrefix}");
                            Console.WriteLine($"    Units         : {units}");
                            Console.WriteLine($"    UnitSuffix    : {unitSuffix}");
                            break;
                        case METHODS.MP:
                            String path = method.Attribute("Path")?.Value;
                            String executable = method.Attribute("Executable")?.Value;
                            String parms = method.Attribute("Parameters")?.Value;
                            String expected = method.Attribute("Expected")?.Value;
                            Console.WriteLine($"    Path          : {path}");
                            Console.WriteLine($"    Executable    : {executable}");
                            Console.WriteLine($"    Parameters    : {parms}");
                            Console.WriteLine($"    Expected      : {expected}");
                            break;
                        case METHODS.MT:
                            String text = method.Attribute("Text")?.Value;
                            Console.WriteLine($"    Text          : {text}");
                            break;
                        default:
                            throw new InvalidOperationException($"METHODS '{m}' not handled.");
                    }
                }
            }
        }
    }
}
