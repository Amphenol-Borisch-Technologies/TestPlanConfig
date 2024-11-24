using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace TestSequencer {
    [XmlRoot("TO")]
    public class TO {
        [XmlAttribute("Folder")] public String Folder { get; set; }
        [XmlAttribute("Description")] public String Description { get; set; }
        [XmlElement("TG")] public List<TG> TGs { get; set; }
    }

    public class TG {
        [XmlAttribute("Class")] public String Class { get; set; }
        [XmlAttribute("Description")] public String Description { get; set; }
        [XmlAttribute("CancelIfFail")] public Boolean CancelIfFail { get; set; }
        [XmlAttribute("Independent")] public Boolean Independent { get; set; }
        [XmlElement("MC", Type = typeof(MC))]
        [XmlElement("MI", Type = typeof(MI))]
        [XmlElement("MP", Type = typeof(MP))]
        [XmlElement("MT", Type = typeof(MT))]
        public List<MethodBase> Methods { get; set; }
    }

    public abstract class MethodBase {
        [XmlAttribute("Method")] public String Method { get; set; }
        [XmlAttribute("Description")] public String Description { get; set; }
        [XmlAttribute("CancelIfFail")] public Boolean CancelIfFail { get; set; }
    }

    public class MC : MethodBase {
        [XmlElement("Parameter")] public List<Parameter> Parameters { get; set; }
    }

    public class MI : MethodBase {
        [XmlAttribute("LowComparator")] public String LowComparator { get; set; }
        [XmlAttribute("Low")] public String Low { get; set; }
        [XmlAttribute("High")] public String High { get; set; }
        [XmlAttribute("HighComparator")] public String HighComparator { get; set; }
        [XmlAttribute("FD")] public String FD { get; set; }
        [XmlAttribute("Units")] public String Units { get; set; }
        [XmlAttribute("VoltAmpere")] public String VoltAmpere { get; set; }
    }

    public class MP : MethodBase {
        [XmlAttribute("Path")] public String Path { get; set; }
        [XmlAttribute("Executable")] public String Executable { get; set; }
        [XmlAttribute("Parameters")] public String Parameters { get; set; }
        [XmlAttribute("Expected")] public String Expected { get; set; }
    }

    public class MT : MethodBase {
        [XmlAttribute("Text")] public String Text { get; set; }
    }

    public class Parameter {
        [XmlAttribute("Key")] public String Key { get; set; }
        [XmlAttribute("Value")] public String Value { get; set; }
    }
}