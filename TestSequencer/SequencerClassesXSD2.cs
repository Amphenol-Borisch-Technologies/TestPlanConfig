using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace TestSequencerXSD2 {

    [XmlRoot("TO")]
    public class TestOperation {
        [XmlAttribute("Folder")] public String Folder { get; set; }
        [XmlAttribute("Description")] public String Description { get; set; }
        [XmlElement("TG")] public List<TestGroup> TestGroups { get; set; }

    }

    public class TestGroup {
        [XmlAttribute("Class")] public String Class { get; set; }
        [XmlAttribute("Description")] public String Description { get; set; }
        [XmlAttribute("CancelIfFail")] public Boolean CancelIfFail { get; set; }
        [XmlAttribute("Independent")] public Boolean Independent { get; set; }
        [XmlChoiceIdentifier("MethodType")]
        [XmlElement("MC", typeof(MethodCustom))]
        [XmlElement("MI", typeof(MethodInterval))]
        [XmlElement("MP", typeof(MethodProcess))]
        [XmlElement("MT", typeof(MethodTextual))]
        public List<Object> Methods { get; set; }
        [XmlIgnore] public MethodTypes MethodType;
    }

    public enum MethodTypes { MC, MI, MP, MT }

    public abstract class MethodBase {
        [XmlAttribute("Method")] public String Method { get; set; }
        [XmlAttribute("Description")] public String Description { get; set; }
        [XmlAttribute("CancelIfFail")] public Boolean CancelIfFail { get; set; }
    }

    public class MethodCustom : MethodBase {
        [XmlElement("Parameter")] public List<Parameter> Parameters { get; set; }
    }

    public class Parameter {
        [XmlAttribute("Key")] public String Key { get; set; }
        [XmlAttribute("Value")] public String Value { get; set; }
    }

    public class MethodInterval : MethodBase {
        [XmlAttribute("LowComparator")] public MethodIntervalLowComparator LowComparator { get; set; }
        [XmlAttribute("Low")] public Double Low { get; set; }
        [XmlAttribute("High")] public Double High { get; set; }
        [XmlAttribute("HighComparator")] public MethodIntervalHighComparator HighComparator { get; set; }
        [XmlAttribute("FractionalDigits")] public UInt32 FractionalDigits { get; set; }
        [XmlAttribute("UnitPrefix")] public MethodIntervalUnitPrefix UnitPrefix { get; set; }
        [XmlIgnore()] public Boolean UnitPrefixSpecified { get; set; }
        [XmlAttribute("Units")] public MethodIntervalUnits Units { get; set; }
        [XmlIgnore()] public Boolean UnitsSpecified { get; set; }
        [XmlAttribute("UnitSuffix")] public MethodIntervalUnitSuffix UnitSuffix { get; set; }
        [XmlIgnore()] public Boolean UnitSuffixSpecified { get; set; }
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

    public enum MethodIntervalLowComparator { GE, GT }

    public enum MethodIntervalHighComparator { LE, LT }

    public enum MethodIntervalUnitPrefix { peta, tera, giga, mega, kilo, hecto, deca, deci, centi, milli, micro, nano, pico, femto }

    public enum MethodIntervalUnits { Amperes, Celcius, Farads, Henries, Hertz, Ohms, Seconds, Siemens, Volts, VoltAmperes, Watts }

    public enum MethodIntervalUnitSuffix { AC, DC, Peak, PP, RMS }
}