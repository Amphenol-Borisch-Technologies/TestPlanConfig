using System;
using System.Collections.Generic;
using System.Xml.Serialization;

[XmlRoot("TO")]
public class TestOperation
{
    [XmlElement("TG")]
    public List<TestGroup> TestGroups { get; set; }

    [XmlAttribute("Folder")]
    public string Folder { get; set; }

    [XmlAttribute("Description")]
    public string Description { get; set; }
}

public class TestGroup
{
    [XmlElement("MC")]
    public List<MethodCustom> MethodCustoms { get; set; }

    [XmlElement("MI")]
    public List<MethodInterval> MethodIntervals { get; set; }

    [XmlElement("MP")]
    public List<MethodProcess> MethodProcesses { get; set; }

    [XmlElement("MT")]
    public List<MethodTextual> MethodTextuals { get; set; }

    [XmlAttribute("Class")]
    public string Class { get; set; }

    [XmlAttribute("Description")]
    public string Description { get; set; }

    [XmlAttribute("CancelIfFail")]
    public bool CancelIfFail { get; set; }

    [XmlAttribute("Independent")]
    public bool Independent { get; set; }
}

public class MethodCustom
{
    [XmlElement("Parameter")]
    public List<Parameter> Parameters { get; set; }

    [XmlAttribute("Method")]
    public string Method { get; set; }

    [XmlAttribute("Description")]
    public string Description { get; set; }

    [XmlAttribute("CancelIfFail")]
    public bool CancelIfFail { get; set; }
}

public class Parameter
{
    [XmlAttribute("Key")]
    public string Key { get; set; }

    [XmlAttribute("Value")]
    public string Value { get; set; }
}

public class MethodProcess
{
    [XmlAttribute("Method")]
    public string Method { get; set; }

    [XmlAttribute("Description")]
    public string Description { get; set; }

    [XmlAttribute("CancelIfFail")]
    public bool CancelIfFail { get; set; }

    [XmlAttribute("Path")]
    public string Path { get; set; }

    [XmlAttribute("Executable")]
    public string Executable { get; set; }

    [XmlAttribute("Parameters")]
    public string Parameters { get; set; }

    [XmlAttribute("Expected")]
    public string Expected { get; set; }
}

public class MethodInterval
{
    [XmlAttribute("Method")]
    public string Method { get; set; }

    [XmlAttribute("Description")]
    public string Description { get; set; }

    [XmlAttribute("CancelIfFail")]
    public bool CancelIfFail { get; set; }

    [XmlAttribute("LowComparator")]
    public string LowComparator { get; set; }

    [XmlAttribute("Low")]
    public double Low { get; set; }

    [XmlAttribute("High")]
    public double High { get; set; }

    [XmlAttribute("HighComparator")]
    public string HighComparator { get; set; }

    [XmlAttribute("FD")]
    public int FractionalDigits { get; set; }

    [XmlAttribute("Prefix")]
    public string Prefix { get; set; }

    [XmlAttribute("Units")]
    public string Units { get; set; }

    [XmlAttribute("VA_Descriptor")]
    public string VADescriptor { get; set; }
}

public class MethodTextual
{
    [XmlAttribute("Method")]
    public string Method { get; set; }

    [XmlAttribute("Description")]
    public string Description { get; set; }

    [XmlAttribute("CancelIfFail")]
    public bool CancelIfFail { get; set; }

    [XmlAttribute("Text")]
    public string Text { get; set; }
}
