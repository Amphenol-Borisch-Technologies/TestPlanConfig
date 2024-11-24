using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace TestSequencer {
    [XmlRoot("TO")]
    public class TestOperation {
        [XmlAttribute("Folder")] public String Folder { get; set; }
        [XmlAttribute("Description")] public String Description { get; set; }
        [XmlElement("TG")] public List<TestGroup> TGs { get; set; }
    }

    public class TestGroup {
        [XmlAttribute("Class")] public String Class { get; set; }
        [XmlAttribute("Description")] public String Description { get; set; }
        [XmlAttribute("CancelIfFail")] public Boolean CancelIfFail { get; set; }
        [XmlAttribute("Independent")] public Boolean Independent { get; set; }
        [XmlElement("MC", Type = typeof(MethodCustom))]
        [XmlElement("MI", Type = typeof(MethodInterval))]
        [XmlElement("MP", Type = typeof(MethodProcess))]
        [XmlElement("MT", Type = typeof(MethodTextual))]
        public List<MethodBase> Methods { get; set; }
    }

    public abstract class MethodBase {
        [XmlAttribute("Method")] public String Method { get; set; }
        [XmlAttribute("Description")] public String Description { get; set; }
        [XmlAttribute("CancelIfFail")] public Boolean CancelIfFail { get; set; }
    }

    public class MethodCustom : MethodBase {
        [XmlElement("Parameter")] public List<Parameter> Parameters { get; set; }
    }

    public class MethodInterval : MethodBase {
        [XmlAttribute("LowComparator")] public String LowComparator { get; set; }
        [XmlAttribute("Low")] public Double Low { get; set; }
        [XmlAttribute("High")] public Double High { get; set; }
        [XmlAttribute("HighComparator")] public String HighComparator { get; set; }
        [XmlAttribute("FractionalDigits")] public UInt32 FractionalDigits { get; set; }
        [XmlAttribute("UnitPrefix")] public String UnitPrefix { get; set; }
        [XmlAttribute("Units")] public String Units { get; set; }
        [XmlAttribute("UnitSuffix")] public String UnitSuffix { get; set; }
    }

    public class MethodProcess : MethodBase {
        [XmlAttribute("Path")] public String Path { get; set; }
        [XmlAttribute("Executable")] public String Executable { get; set; }
        [XmlAttribute("Parameters")] public String Parameters { get; set; }
        [XmlAttribute("Expected")] public String Expected { get; set; }
    }

    public class MethodTextual : MethodBase {
        [XmlAttribute("Text")] public String Text { get; set; }
    }

    public class Parameter {
        [XmlAttribute("Key")] public String Key { get; set; }
        [XmlAttribute("Value")] public String Value { get; set; }
    }
}