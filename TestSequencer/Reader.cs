using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace TestSequencer {
    class Reader {
        // TODO: Modify this to read the Test Operation XML sequence files and auto-generate a skeleton C# project.
        // - Copy a standard template project into a folder auto-created based on CCA Number.
        // - Auto-generate C# files, classes & methods from the Test Operation XML sequence files.
        // - Include standard Debug.Assert statements for:
        //   - TO/TestOperation Folder & Description attributes added to first method in TestOperation.
        //     - Also list of TG/TestGroups in TestOperation.
        //   - TG/TestGroup Class, Description, CancelIfFail, Independent attributes added to first method in TestGroup.
        //     - Also list of {MC,MI,MP,MT) methods in TestGroup.
        // - Potentially include external invocations to Keysight VEE or Python executables, if test developer selects these options.
        // - Goal is to automate as much of the routine, standardized test generation as possible.
        [STAThread]
        public static void Main() {
            XDocument tocf = XDocument.Load(Properties.Resources.XML_File);
            XElement toElement = tocf.Element("TO");
            String folder = (toElement.Attribute("Folder")?.Value);
            String description = (toElement.Attribute("Description")?.Value);
            Console.WriteLine($"Folder            : {folder}");
            Console.WriteLine($"Description       : {description}");

            IEnumerable<XElement> tgElements = toElement.Elements("TG");
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
                    String methodName = method.Attribute("Method")?.Value;
                    String methodDescription = method.Attribute("Description")?.Value;
                    Boolean methodCancelIfFail = Boolean.Parse(method.Attribute("CancelIfFail")?.Value);

                    Console.WriteLine($"\nMethod Type       : {method.Name.LocalName}");
                    Console.WriteLine($"  Method          : {methodName}");
                    Console.WriteLine($"  Description     : {methodDescription}");
                    Console.WriteLine($"  Cancel If Fail  : {methodCancelIfFail}");

                    // TODO: Use Activator.CreateInstance to auto-create appropriate TestMeasurement objects, eliminating below switch.
                    // TODO: Rename TestMeasurement objects to TestMethod objects?
                    switch (method.Name.LocalName) {
                        case "MC":
                            IEnumerable<XElement> parameters = method.Elements("Parameter");
                            foreach (XElement parameter in parameters) {
                                String key = parameter.Attribute("Key")?.Value;
                                String value = parameter.Attribute("Value")?.Value;
                                Console.WriteLine($"    Parameter Key : {key}, Value: {value}");
                            }
                            break;
                        case "MI":
                            Double low = Double.Parse(method.Attribute("Low")?.Value);
                            Double high = Double.Parse(method.Attribute("High")?.Value);
                            if (low > high) {
                                throw new ArgumentException($"Invalid Method element {method.Name.LocalName}:{Environment.NewLine}" +
                                    $"Method      :{methodName}{Environment.NewLine}" +
                                    $"Description :{methodDescription}{Environment.NewLine}" +
                                    $"Invalidity  : Low '{low}' is > High '{high}'.{Environment.NewLine}");
                            }
                            UInt32 fractionalDigits = UInt32.Parse(method.Attribute("FractionalDigits")?.Value);
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
                        case "MP":
                            String path = method.Attribute("Path")?.Value;
                            String executable = method.Attribute("Executable")?.Value;
                            String parms = method.Attribute("Parameters")?.Value;
                            String expected = method.Attribute("Expected")?.Value;
                            Console.WriteLine($"    Path          : {path}");
                            Console.WriteLine($"    Executable    : {executable}");
                            Console.WriteLine($"    Parameters    : {parms}");
                            Console.WriteLine($"    Expected      : {expected}");
                            break;
                        case "MT":
                            String text = method.Attribute("Text")?.Value;
                            Console.WriteLine($"    Text          : {text}");
                            break;
                        default:
                            throw new InvalidOperationException($"METHODS '{method.Name.LocalName}' not handled.");
                    }
                }
            }
        }
    }
}
