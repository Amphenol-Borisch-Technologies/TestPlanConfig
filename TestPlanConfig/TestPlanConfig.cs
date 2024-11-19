using System;
using System.Collections.Generic;
using System.Xml.Linq;

class TestPlanConfig {
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

    const String TEST_OPERATION_CONFIG_FILE = @"C:\Users\phils\source\repos\TestPlanConfig\TestPlanConfig\T10.xml";
    static readonly String Missing = $"Test Operation Config File '{TEST_OPERATION_CONFIG_FILE}' missing a";

    static void Main() {
        XDocument tocf = XDocument.Load(TEST_OPERATION_CONFIG_FILE);
        XElement toElement = tocf.Element(Test.Operation) ?? throw new ArgumentException($"{Missing} root 'TO' element.");
        String folder = (toElement.Attribute("Folder")?.Value) ?? throw new ArgumentException($"{Missing} 'Folder' attribute.");
        String description = (toElement.Attribute("Description")?.Value) ?? throw new ArgumentException($"{Missing} 'Description' attribute.");
        Console.WriteLine($"Folder            : {folder}");
        Console.WriteLine($"Description       : {description}");

        IEnumerable<XElement> tgElements = toElement.Elements(Test.Group);
        foreach (XElement tg in tgElements) {
            String tgClass = tg.Attribute("Class")?.Value ?? throw new ArgumentException($"{Missing} 'Class' attribute.");
            String tgDescription = tg.Attribute("Description")?.Value ?? throw new ArgumentException($"{Missing} 'Description' attribute.");

            Boolean tgCancelIfFail = Boolean.Parse(tg.Attribute("CancelIfFail")?.Value ?? throw new ArgumentException($"{Missing} 'CancelIfFail' attribute."));
            Boolean i = Boolean.Parse(tg.Attribute("Independent")?.Value ?? throw new ArgumentException($"{Missing} 'Independent' attribute."));
            Console.WriteLine($"\nTG Class          : {tgClass}");
            Console.WriteLine($"TG Description    : {tgDescription}");
            Console.WriteLine($"Cancel If Fail    : {tgCancelIfFail}");
            Console.WriteLine($"Independent       : {i}");

            IEnumerable<XElement> methods = tg.Elements();
            foreach (XElement method in methods) {
                if (!Enum.TryParse(method.Name.LocalName, out METHODS m)) throw new ArgumentException($"Invalid Method element {method.Name.LocalName}.");
                String methodName = method.Attribute("Method")?.Value ?? throw new ArgumentException($"{Missing} 'Method' attribute.");
                String methodDescription = method.Attribute("Description")?.Value ?? throw new ArgumentException($"{Missing} 'Description' attribute.");
                Boolean methodCancelIfFail = Boolean.Parse(method.Attribute("CancelIfFail")?.Value ?? throw new ArgumentException($"{Missing} 'CancelIfFail' attribute."));

                Console.WriteLine($"\nMethod Type       : {m}");
                Console.WriteLine($"  Method          : {methodName}");
                Console.WriteLine($"  Description     : {methodDescription}");
                Console.WriteLine($"  Cancel If Fail  : {methodCancelIfFail}");

                // TODO: Remove all validation code here that duplicates my XML schema 1.0 restrictions/validations.
                // TODO: Add validation code here unavailable with XML schema 1.0.
                // NOTE: If using XML schema 1.1, could benefit from xs:assert, to check that LowComparator ≤ HighComparator, etc.
                // NOTE: Until can get an XML processor compatible with XML schema 1.1, must validate this and other criteria in this C# code instead.
                //   NOTE: Microsoft Visual Studio 2022 only supports XML schema 1.0.
                //   NOTE: Microsoft Visual Studio Code 1.95.3 with Red Hat's XML extension only supports XML schema 1.0.
                //     NOTE: Tried several other VS Code extensions, but they didn't support XML schema 1.1 either.
                //   NOTE: Only XML processors that explicitly support XML schema 1.1 are expen$ive; Oxygen XML Editor, Altova XMLSpy, Saxon EE, Liquid XML Studio, etc.
                // TODO: Use Activator.CreateInstance to auto-create appropriate TestMeasurement objects, eliminating below switch.
                // TODO: Rename TestMeasurement objects to TestMethod objects?
                switch(m) {
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
                        Int32 fd = Int32.Parse(method.Attribute("FD")?.Value);
                        String prefix = method.Attribute("Prefix")?.Value;
                        String units = method.Attribute("Units")?.Value;
                        String vaDescriptor = method.Attribute("VA_Descriptor")?.Value;
                        Console.WriteLine($"    Low           : {low}");
                        Console.WriteLine($"    High          : {high}");
                        Console.WriteLine($"    FD            : {fd}");
                        Console.WriteLine($"    Prefix        : {prefix}");
                        Console.WriteLine($"    Units         : {units}");
                        Console.WriteLine($"    VA Descriptor : {vaDescriptor}");
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
