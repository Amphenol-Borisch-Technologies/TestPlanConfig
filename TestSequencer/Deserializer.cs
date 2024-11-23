using System;
using System.IO;
using System.Xml.Serialization;

namespace TestSequencer {

    class Deserializer {
        public static void Main() {
            XmlSerializer serializer = new XmlSerializer(typeof(TO));
            using (FileStream fileStream = new FileStream(@"C:\Users\phils\source\repos\TestPlanConfig\TestPlanConfig\T10.xml", FileMode.Open)) {
                TO testOperation = (TO)serializer.Deserialize(fileStream);
            }
        }
    }

}
