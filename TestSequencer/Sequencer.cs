using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Text;
using System.Xml.Serialization;
using static TestSequencer.GeneratorXML;

namespace TestSequencer {

    [XmlRoot("TO")] public class TO {
        [XmlAttribute("Namespace")] public String Namespace { get; set; }
        [XmlAttribute("Description")] public String Description { get; set; }
        [XmlElement("TG")] public List<TG> TestGroups { get; set; }
    }

    public class TG {
        [XmlAttribute("Class")] public String Class { get; set; }
        [XmlAttribute("Description")] public String Description { get; set; }
        [XmlAttribute("CancelIfFail")] public Boolean CancelIfFail { get; set; }
        [XmlAttribute("Independent")] public Boolean Independent { get; set; }
        [XmlElement("MC", typeof(MC))]
        [XmlElement("MI", typeof(MI))]
        [XmlElement("MP", typeof(MP))]
        [XmlElement("MT", typeof(MT))]
        public List<MethodBase> Methods { get; set; }
    }

    public class MethodBase {
        [XmlAttribute("Method")] public String Method { get; set; }
        [XmlAttribute("Description")] public String Description { get; set; }
        [XmlAttribute("CancelIfFail")] public Boolean CancelIfFail { get; set; }
        public String Assertion() {
            StringBuilder sb = new StringBuilder($"Debug.Assert({GetType().Name}");
            PropertyInfo[] properties = GetType().GetProperties(BindingFlags.Public);
            Int32 i = 0;
            foreach (PropertyInfo pi in properties) {
                sb.Append($"{pi.Name}: \"{E((String)pi.GetValue(this))}\"");
                String s = properties.Length < i ? ", " : "));";
                sb.Append(s);
                i++;
            }
            return sb.ToString();
        }
    }

    public class MC : MethodBase {
        [XmlElement("Parameter")] public List<Parameter> Parameters { get; set; }
    }

    public class Parameter {
        [XmlAttribute("Key")] public String Key { get; set; }
        [XmlAttribute("Value")] public String Value { get; set; }
    }

    public class MI : MethodBase {
        [XmlAttribute("LowComparator")] public MI_LowComparator LowComparator { get; set; }
        [XmlAttribute("Low")] public Double Low { get; set; }
        [XmlAttribute("High")] public Double High { get; set; }
        [XmlAttribute("HighComparator")] public MI_HighComparator HighComparator { get; set; }
        [XmlAttribute("FractionalDigits")] public UInt32 FractionalDigits { get; set; }
        [XmlAttribute("UnitPrefix")] public MI_UnitPrefix UnitPrefix { get; set; }
        [XmlAttribute("Units")] public MI_Units Units { get; set; }
        [XmlAttribute("UnitSuffix")] public MI_UnitSuffix UnitSuffix { get; set; }
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

    public enum MI_LowComparator { GE, GT }
    public enum MI_HighComparator { LE, LT }
    public enum MI_UnitPrefix { NONE, peta, tera, giga, mega, kilo, hecto, deca, deci, centi, milli, micro, nano, pico, femto }
    public enum MI_Units { NONE, Amperes, Celcius, Farads, Henries, Hertz, Ohms, Seconds, Siemens, Volts, VoltAmperes, Watts }
    public enum MI_UnitSuffix { NONE, AC, DC, Peak, PP, RMS }
}
