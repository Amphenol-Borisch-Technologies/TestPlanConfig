using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace TestSequencer {

    public interface IAssertion { String Assertion(); }

    [XmlRoot("TO")]
    public class TO {
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
        public List<MethodShared> Methods { get; set; }
    }

    public abstract class MethodShared {
        [XmlAttribute("Method")] public String Method { get; set; }
        [XmlAttribute("Description")] public String Description { get; set; }
        [XmlAttribute("CancelIfFail")] public Boolean CancelIfFail { get; set; }

        public String AssertionShared() {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Method: {EF(GetType().GetProperty("Method").GetValue(this))}, ");
            sb.Append($"Description: {EF(GetType().GetProperty("Description").GetValue(this))}, ");
            sb.Append($"CancelIfFail: {EF(GetType().GetProperty("CancelIfFail").GetValue(this).ToString().ToLower())}, ");
            return sb.ToString();
        }
        internal String EF(Object o) {
            String s = (o.ToString()).Replace("\\", "\\\\").Replace("\"", "\\\"").Replace("\'", "\\\'");
            return "\"" + s + "\"";
        }
    }

    public class MC : MethodShared, IAssertion {
        [XmlElement("Parameter")] public List<Parameter> Parameters { get; set; }

        public String Assertion() {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Debug.Assert({GetType().Name}(");
            sb.Append(AssertionShared());
            if (Parameters.Count > 0) sb.Append($"Parameters: {KV()}));");
            return sb.ToString();
        }
        private String KV() {
            StringBuilder sb = new StringBuilder();
            foreach (Parameter p in Parameters) sb.Append($"Key={p.Key}/Value={p.Value}|");
            String s = sb.ToString();
            return EF(s.Remove(s.Length - 1) + "));"); // Remove trailing "/", add closing "));"
        }
    }

    public class Parameter {
        [XmlAttribute("Key")] public String Key { get; set; }
        [XmlAttribute("Value")] public String Value { get; set; }
    }

    public class MI : MethodShared, IAssertion {
        [XmlAttribute("LowComparator")] public MI_LowComparator LowComparator { get; set; }
        [XmlAttribute("Low")] public Double Low { get; set; }
        [XmlAttribute("High")] public Double High { get; set; }
        [XmlAttribute("HighComparator")] public MI_HighComparator HighComparator { get; set; }
        [XmlAttribute("FractionalDigits")] public UInt32 FractionalDigits { get; set; }
        [XmlAttribute("UnitPrefix")] public MI_UnitPrefix UnitPrefix { get; set; }
        [XmlAttribute("Units")] public MI_Units Units { get; set; }
        [XmlAttribute("UnitSuffix")] public MI_UnitSuffix UnitSuffix { get; set; }

        public String Assertion() {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Debug.Assert({GetType().Name}(");
            sb.Append(AssertionShared());
            sb.Append($"LowComparator: {EF(GetType().GetProperty("LowComparator").GetValue(this))}, ");
            sb.Append($"Low: {EF(GetType().GetProperty("Low").GetValue(this))}, ");
            sb.Append($"High: {EF(GetType().GetProperty("High").GetValue(this))}, ");
            sb.Append($"HighComparator: {EF(GetType().GetProperty("HighComparator").GetValue(this))}, ");
            sb.Append($"FractionalDigits: {EF(GetType().GetProperty("FractionalDigits").GetValue(this))}, ");
            sb.Append($"UnitPrefix: {EF(GetType().GetProperty("UnitPrefix").GetValue(this))}, ");
            sb.Append($"Units: {EF(GetType().GetProperty("Units").GetValue(this))}, ");
            sb.Append($"UnitSuffix: {EF(GetType().GetProperty("UnitSuffix").GetValue(this))}));");
            return sb.ToString();
        }
    }

    public enum MI_LowComparator { GE, GT }
    public enum MI_HighComparator { LE, LT }
    public enum MI_UnitPrefix { NONE, peta, tera, giga, mega, kilo, hecto, deca, deci, centi, milli, micro, nano, pico, femto }
    public enum MI_Units { NONE, Amperes, Celcius, Farads, Henries, Hertz, Ohms, Seconds, Siemens, Volts, VoltAmperes, Watts }
    public enum MI_UnitSuffix { NONE, AC, DC, Peak, PP, RMS }

    public class MP : MethodShared, IAssertion {
        [XmlAttribute("Path")] public String Path { get; set; }
        [XmlAttribute("Executable")] public String Executable { get; set; }
        [XmlAttribute("Parameters")] public String Parameters { get; set; }
        [XmlAttribute("Expected")] public String Expected { get; set; }

        public String Assertion() {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Debug.Assert({GetType().Name}(");
            sb.Append(AssertionShared());
            sb.Append($"Path: {EF(GetType().GetProperty("Path").GetValue(this))}, ");
            sb.Append($"Executable: {EF(GetType().GetProperty("Executable").GetValue(this))}, ");
            sb.Append($"Parameters: {EF(GetType().GetProperty("Parameters").GetValue(this))}, ");
            sb.Append($"Expected: {EF(GetType().GetProperty("Expected").GetValue(this))}));");
            return sb.ToString();
        }
    }

    public class MT : MethodShared, IAssertion {
        [XmlAttribute("Text")] public String Text { get; set; }

        public String Assertion() {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Debug.Assert({GetType().Name}(");
            sb.Append(AssertionShared());
            sb.Append($"Text: {EF(GetType().GetProperty("Text").GetValue(this))}));");
            return sb.ToString();
        }
    }
}
