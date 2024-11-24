using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace TestSequencerXSD1 {
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(AnonymousType = true)]
    [XmlRootAttribute(Namespace = "", IsNullable = false)]
    public class TestOperation {
        [XmlAttribute(DataType = "ID")] public String Folder { get; set; }
        [XmlAttribute()] public String Description { get; set; }
        [XmlElement("TG", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)] public List<TestGroup> TestGroups { get; set; }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public class TestGroup {
        [XmlAttribute(DataType = "ID")] public String Class { get; set; }
        [XmlAttribute()] public String Description { get; set; }
        [XmlAttribute()] public Boolean CancelIfFail { get; set; }
        [XmlAttribute()] public Boolean Independent { get; set; }
        [XmlElement("MC", typeof(MethodCustom), Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [XmlElement("MI", typeof(MethodInterval), Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [XmlElement("MP", typeof(MethodProcess), Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [XmlElement("MT", typeof(MethodTextual), Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public List<MethodBase> Methods { get; set; }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public abstract class MethodBase {
        [XmlAttribute(DataType = "ID")] public String Method { get; set; }
        [XmlAttribute()] public String Description { get; set; }
        [XmlAttribute()] public Boolean CancelIfFail { get; set; }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public class MethodCustom : MethodBase {
        [XmlElement("Parameter", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)] public List<Parameter>[] Parameters { get; set; }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(AnonymousType = true)]
    public class Parameter {
        [XmlAttribute()] public String Key { get; set; }
        [XmlAttribute()] public String Value { get; set; }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public class MethodInterval : MethodBase {
        [XmlAttribute()] public MethodIntervalLowComparator LowComparator { get; set; }
        [XmlAttribute()] public Double Low { get; set; }
        [XmlAttribute()] public Double High { get; set; }
        [XmlAttribute()] public MethodIntervalHighComparator HighComparator { get; set; }
        [XmlAttribute(DataType = "nonNegativeInteger")] public UInt32 FractionalDigits { get; set; }
        [XmlAttribute()] public MethodIntervalUnitPrefix UnitPrefix { get; set; }
        [XmlIgnoreAttribute()] public Boolean PrefixSpecified { get; set; }
        [XmlAttribute()] public MethodIntervalUnits Units { get; set; }
        [XmlIgnoreAttribute()] public Boolean UnitsSpecified { get; set; }
        [XmlAttribute()] public MethodIntervalUnitSuffix UnitSuffix { get; set; }
        [XmlIgnoreAttribute()] public Boolean UnitSuffixSpecified { get; set; }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public class MethodProcess : MethodBase {
        [XmlAttribute()] public String Path { get; set; }
        [XmlAttribute()] public String Executable { get; set; }
        [XmlAttribute()] public String Parameters { get; set; }
        [XmlAttribute()] public String Expected { get; set; }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public class MethodTextual : MethodBase {
        [XmlAttribute()] public String Text { get; set; }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [XmlTypeAttribute(AnonymousType = true)]
    public enum MethodIntervalLowComparator { GE, GT }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [XmlTypeAttribute(AnonymousType = true)]
    public enum MethodIntervalHighComparator { LE, LT }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [XmlTypeAttribute(AnonymousType = true)]
    public enum MethodIntervalUnitPrefix { peta, tera, giga, mega, kilo, hecto, deca, deci, centi, milli, micro, nano, pico, femto }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [XmlTypeAttribute(AnonymousType = true)]
    public enum MethodIntervalUnits { Amperes, Celcius, Farads, Henries, Hertz, Ohms, Seconds, Siemens, Volts, VoltAmperes, Watts }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [XmlTypeAttribute(AnonymousType = true)]
    public enum MethodIntervalUnitSuffix { AC, DC, Peak, PP, RMS }
}