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
                foreach (var method in tg.Methods) {
                    Console.WriteLine($"  Method: {((MethodBase)method).Method}, Description: {((MethodBase)method).Description}, CancelIfFail: {((MethodBase)method).CancelIfFail}");
                    if (method is MC mc) {
                        foreach (var parameter in mc.Parameters) {
                            Console.WriteLine($"    Parameter Key: {parameter.Key}, Value: {parameter.Value}");
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
