using System;
using System.IO;
using System.Xml.Serialization;

namespace TestSequencer {

    class DeserializerCopilotXSDandXML {
        static void Main() {
            XmlSerializer serializer = new XmlSerializer(typeof(TestOperation));
            using (FileStream fileStream = new FileStream(Properties.Resources.XML_File, FileMode.Open)) {
                TestOperation to = (TestOperation)serializer.Deserialize(fileStream);
                PrintTO(to);
            }
        }

        static void PrintTO(TestOperation to) {
            Console.WriteLine($"Folder: {to.Folder}");
            Console.WriteLine($"Description: {to.Description}");
            foreach (TestGroup tg in to.TGs) {
                Console.WriteLine($"\nTG Class: {tg.Class}");
                Console.WriteLine($"Description: {tg.Description}");
                Console.WriteLine($"CancelIfFail: {tg.CancelIfFail}");
                Console.WriteLine($"Independent: {tg.Independent}");
                foreach (var method in tg.Methods) {
                    Console.WriteLine($"  Method: {method.Method}, Description: {method.Description}, CancelIfFail: {method.CancelIfFail}");
                    if (method is MethodCustom mc) {
                        foreach (var parameter in mc.Parameters) {
                            Console.WriteLine($"    Parameter Key: {parameter.Key}, Value: {parameter.Value}");
                        }
                    } else if (method is MethodInterval mi) {
                        Console.WriteLine($"    LowComparator: {mi.LowComparator}, Low: {mi.Low}, High: {mi.High}, HighComparator: {mi.HighComparator}, FD: {mi.FD}, Prefix: {mi.Prefix}, Units: {mi.Units}, VoltAmpere: {mi.VoltAmpere}");
                    } else if (method is MethodProcess mp) {
                        Console.WriteLine($"    Path: {mp.Path}, Executable: {mp.Executable}, Parameters: {mp.Parameters}, Expected: {mp.Expected}");
                    } else if (method is MethodTextual mt) {
                        Console.WriteLine($"    Text: {mt.Text}");
                    }
                }
            }
        }
    }
}
