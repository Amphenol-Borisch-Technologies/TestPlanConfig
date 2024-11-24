using System;
using System.Collections.Generic;
using System.Xml.Serialization;

[XmlRoot("TO")]
public class TestOperation {
    [XmlAttribute("Folder")] public String Folder { get; set; }
    [XmlAttribute("Description")] public String Description { get; set; }
    [XmlElement("TG")] public List<TestGroup> TestGroups { get; set; } = new List<TestGroup>();
}

public class TestGroup {
    [XmlAttribute("Class")] public String Class { get; set; }
    [XmlAttribute("Description")] public String Description { get; set; }
    [XmlAttribute("CancelIfFail")] public Boolean CancelIfFail { get; set; }
    [XmlAttribute("Independent")] public Boolean Independent { get; set; }
    [XmlElement("MC", typeof(MethodCustom))]
    [XmlElement("MI", typeof(MethodInterval))]
    [XmlElement("MP", typeof(MethodProcess))]
    [XmlElement("MT", typeof(MethodTextual))]
    public List<Object> Methods { get; set; } = new List<Object>();
}

public abstract class MethodBase {
    [XmlAttribute("Method")] public String Method { get; set; }
    [XmlAttribute("Description")] public String Description { get; set; }
    [XmlAttribute("CancelIfFail")] public Boolean CancelIfFail { get; set; }
}

public class MethodCustom : MethodBase {
    [XmlElement("Parameter")] public List<Parameter> Parameters { get; set; } = new List<Parameter>();
}

public class Parameter {
    [XmlAttribute("Key")] public String Key { get; set; }
    [XmlAttribute("Value")] public String Value { get; set; }
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

