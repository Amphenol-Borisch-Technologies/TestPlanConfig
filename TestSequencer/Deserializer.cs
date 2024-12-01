using System;
using System.IO;
using System.Xml.Serialization;

namespace TestSequencer {

    class Deserializer {
        static void Main() {
            XmlSerializer serializer = new XmlSerializer(typeof(TO));
            using (FileStream fileStream = new FileStream(Properties.Resources.XML_File, FileMode.Open)) {
                TO to = (TO)serializer.Deserialize(fileStream);
                PrintTO(to);
            }
        }

        static void PrintTO(TO to) {
            Console.WriteLine($"Namespace: {to.Namespace}");
            Console.WriteLine($"Description: {to.Description}");
            foreach (TG tg in to.TestGroups) {
                Console.WriteLine($"\nTG Class: {tg.Class}");
                Console.WriteLine($"Description: {tg.Description}");
                Console.WriteLine($"CancelIfFail: {tg.CancelIfFail}");
                Console.WriteLine($"Independent: {tg.Independent}");
                foreach (MethodShared method in tg.Methods) {
                    Console.WriteLine($"  Method: {method.Method}, Description: {method.Description}, CancelIfFail: {method.CancelIfFail}");
                    if (method is MC mc) {
                        foreach (Parameter p in mc.Parameters) {
                            Console.WriteLine($"    Parameter Key: {p.Key}, Value: {p.Value}");
                        }
                    } else if (method is MI mi) {
                        Console.WriteLine($"    LowComparator: {mi.LowComparator}, Low: {mi.Low}, High: {mi.High}, HighComparator: {mi.HighComparator}, FractionalDigits: {mi.FractionalDigits}, UnitPrefix: {mi.UnitPrefix}, Units: {mi.Units}, UnitSuffix: {mi.UnitSuffix}");
                    } else if (method is MP mp) {
                        Console.WriteLine($"    Path: {mp.Path}, Executable: {mp.Executable}, Parameters: {mp.Parameters}, Expected: {mp.Expected}");
                    } else if (method is MT mt) {
                        Console.WriteLine($"    Text: {mt.Text}");
                    }
                }
            }
        }
    }
}
